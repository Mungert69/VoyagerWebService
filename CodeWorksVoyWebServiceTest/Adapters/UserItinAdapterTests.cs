using KellermanSoftware.CompareNetObjects;
using Moq;
using System;
using System.Collections.Generic;
using CodeWorksVoyWebService.Bussiness_Logic.Utils;
using CodeWorksVoyWebService.Services;
using Xunit;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Xunit.Abstractions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using CodeWorksVoyWebService.Models.WebData;
using Microsoft.EntityFrameworkCore;

namespace CodeWorksVoyWebServiceTest.Adapters
{
    public class UserItinAdapterTests : IDisposable
    {
        private MockRepository mockRepository;

       
        private UserItinAdapter userItinAdapter;
        private readonly ITestOutputHelper output;

        private SessionObject sessionObjects;
        private List<PRSelection> prSelections;
        private List<TransferNode> transferNodes;
        private IPriceService priceService;
        private WebDataContext contextAdmin;

        private Mock<ISessionObjectsService> mockSessionObjectsService;






        public UserItinAdapterTests(ITestOutputHelper output)
        {
            this.output = output;
            this.mockRepository = new MockRepository(MockBehavior.Default);


        }

        public void Dispose()
        {//
            this.mockRepository.VerifyAll();
        }

        private void CreateUserItinAdapter()
        {
           
            // Setup Dependency Injection
            ServiceFactory serviceFactory = new ServiceFactory();
            ServiceProvider serviceProvider = serviceFactory.Services.BuildServiceProvider();
            IMemoryCache cache = serviceProvider.GetService<IMemoryCache>();
            IConfiguration configuration= serviceProvider.GetService<IConfiguration>();
            contextAdmin = serviceProvider.GetService< WebDataContext>();
            priceService = serviceProvider.GetService<IPriceService>();


            // Setup concret objects for tests
            prSelections = JsonUtils.getJsonObjectFromFile<List<PRSelection>>("./TestObjects/pRSelections.json");
            transferNodes = JsonUtils.getJsonObjectFromFile<List<TransferNode>>("./TestObjects/transferNodes.json");

            sessionObjects = new SessionObject(configuration);           
            // Warning you must remove manually the Configration object from Json for SessionObject
            sessionObjects = JsonUtils.getJsonObjectFromFile<SessionObject>("./TestObjects/sessionObjects-StoredItinBefore.json", sessionObjects);
            sessionObjects.Flight.SupplierID = Convert.ToInt16(configuration.GetSection("AppConfiguration")["DefaultFlightSupplierIDForTemplatePriceCalc"]);

            priceService.SessionObject = sessionObjects;

            userItinAdapter = new UserItinAdapter(cache,contextAdmin);
            

        }


        [Fact]
        public void  InsertUserItinData_ItinObj_DataUpdatedAsync()
        {
            // Arrange
            CreateUserItinAdapter();
            priceService.createPriceFromDate(DateTime.Now, 1);

            // Act
            int userItinId=userItinAdapter.insertUserItin(transferNodes,prSelections,priceService.SessionObject,"$testtemplate$1234567890123456789012");
            CodeWorksVoyWebService.Models.WebData.UserItinerary userItinerary = contextAdmin.UserItinerary.Where(u => u.UserItinId == userItinId).First();
            CodeWorksVoyWebService.Models.WebData.UserItinerary userItineraryX = JsonUtils.getJsonObjectFromFile<CodeWorksVoyWebService.Models.WebData.UserItinerary>("./userItineraryObj.json");
            CompareLogic compareLogic = new CompareLogic();
           ComparisonResult result = compareLogic.Compare(userItineraryX.ItinName, userItinerary.ItinName);
            ComparisonResult result2 = compareLogic.Compare(userItineraryX.TotalCost, userItinerary.TotalCost);

            //These will be different, write out the differences
            if (!result.AreEqual)
                output.WriteLine("ItinNames are different", result.DifferencesString);
            if (!result2.AreEqual)
                output.WriteLine("Total Costs are different", result2.DifferencesString);
            // Assert
            Assert.True(result.AreEqual);
            Assert.True(result2.AreEqual);
        }

      
    }
}
