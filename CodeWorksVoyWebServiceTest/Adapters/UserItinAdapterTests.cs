using KellermanSoftware.CompareNetObjects;
using Moq;
using System;
using System.Collections.Generic;
using CodeWorksVoyWebService.Bussiness_Logic.Bussiness_Objects;
using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;
using CodeWorksVoyWebService.Bussiness_Logic.Utils;
using CodeWorksVoyWebService.Services;
using Xunit;
using CodeWorksVoyWebServiceTest.Controllers.Mocks;
using CodeWorksVoyWebServiceTest.Utils;
using Microsoft.Extensions.Configuration;
using Xunit.Abstractions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using CodeWorksVoyWebService.Models.CubaData;
using CodeWorksVoyWebService.Models.WebData;
using CodeWorksVoyWebService.Models.VoyagerReserve;
using CodeWorksVoyWebService.Models.UserData;
using Microsoft.EntityFrameworkCore;

namespace CodeWorksVoyWebServiceTest.Adapters
{
    public class UserItinAdapterTests : IDisposable
    {
        private MockRepository mockRepository;

        private Mock<ISessionObject> mockSessionObjects;
        private Mock<IItineraryService> mockItineraryService;
        private Mock<IHotelAdapter> mockHotelAdapter;
        private Mock<IPlaceAdapter> mockPlaceAdapter;
        private Mock<ICardAdapter> mockCardAdapter;
        private Mock<IUserItinAdapter> mockUserItinAdapter;
        private Mock<ITransferAdapter> mockTransferAdapter;
        private Mock<IMapService> mockMapService;
        private UserItinAdapter userItinAdapter;
        private readonly ITestOutputHelper output;

        private SessionObject sessionObjects;
        private List<PRSelection> prSelections;
        private List<TransferNode> transferNodes;


        private Mock<ISessionObjectsService> mockSessionObjectsService;
        private Mock<IPriceService> mockPrintService;




        public UserItinAdapterTests(ITestOutputHelper output)
        {
            this.output = output;
            this.mockRepository = new MockRepository(MockBehavior.Default);


            this.mockItineraryService = this.mockRepository.Create<IItineraryService>();
            this.mockHotelAdapter = this.mockRepository.Create<IHotelAdapter>();
            this.mockPlaceAdapter = this.mockRepository.Create<IPlaceAdapter>();
            this.mockCardAdapter = this.mockRepository.Create<ICardAdapter>();
            this.mockUserItinAdapter = this.mockRepository.Create<IUserItinAdapter>();
            this.mockTransferAdapter = this.mockRepository.Create<ITransferAdapter>();
            this.mockMapService = this.mockRepository.Create<IMapService>();
            this.mockSessionObjectsService = this.mockRepository.Create<ISessionObjectsService>();
            this.mockPrintService = this.mockRepository.Create<IPriceService>();
        }

        public void Dispose()
        {//
            this.mockRepository.VerifyAll();
        }

        private void CreateUserItinAdapter()
        {
            // Setup concret objects for tests
            TripCardObj cardObj = JsonUtils.getJsonObjectFromFile<TripCardObj>("./TestObjects/card.json");
            prSelections = JsonUtils.getJsonObjectFromFile<List<PRSelection>>("./TestObjects/pRSelections.json");
            transferNodes = JsonUtils.getJsonObjectFromFile<List<TransferNode>>("./TestObjects/transferNodes.json");
            CodeWorksVoyWebService.Models.WebData.UserItinerary userItin = JsonUtils.getJsonObjectFromFile<CodeWorksVoyWebService.Models.WebData.UserItinerary>("./TestObjects/userItin.json");
            List<TransferNodeItem> transferNodeItems = JsonUtils.getJsonObjectFromFile<List<TransferNodeItem>>("./TestObjects/transferNodeItems.json");
            List<PlaceState> placeStates = JsonUtils.getJsonObjectFromFile<List<PlaceState>>("./TestObjects/placeStates.json");

            ServiceFactory serviceFactory = new ServiceFactory();
            var serviceProvider = serviceFactory.Services.BuildServiceProvider();
            var cache = serviceProvider.GetService<IMemoryCache>();
            var config= serviceProvider.GetService<IConfiguration>();
            var contextAdmin= serviceProvider.GetService< WebDataContext>();

            sessionObjects = new SessionObject(config);

            // Warning you must remove manually the Configration object from Json for SessionObject
            sessionObjects = JsonUtils.getJsonObjectFromFile<SessionObject>("./TestObjects/sessionObjects-StoredItinBefore.json", sessionObjects);

            // Setup Mocks 
            this.mockUserItinAdapter.SetupAllProperties();
            this.mockUserItinAdapter.SetReturnsDefault<CodeWorksVoyWebService.Models.WebData.UserItinerary>(userItin);
            this.mockCardAdapter.SetReturnsDefault<List<PRSelection>>(prSelections);
            this.mockUserItinAdapter.SetReturnsDefault<List<TransferNode>>(transferNodes);
            this.mockTransferAdapter.SetupAllProperties();
            this.mockTransferAdapter.SetReturnsDefault<List<TransferNodeItem>>(transferNodeItems);
            this.mockMapService.SetReturnsDefault<List<PlaceState>>(placeStates);
            this.mockSessionObjectsService.SetReturnsDefault<ISessionObject>(sessionObjects);

            // Use A FluentAPI pattern so multiple methods can be chained.
            Mock<ISessionObject> mockSessionObjects = new MockSessionObjects().SetUpObject();

            userItinAdapter = new UserItinAdapter(cache,contextAdmin);

        }


        [Fact]
        public void InsertUserItinData_ItinObj_DataUpdated()
        {
            // Arrange
            CreateUserItinAdapter();
            var unitUnderTest = userItinAdapter;
           

            // Act
            unitUnderTest.insertUserItin(transferNodes,prSelections,sessionObjects,"$testtemplate$");
            //ItinObj itinObjX = JsonUtils.getJsonObjectFromFile<ItinObj>("./TestObjects/itinObj.json");
            //CompareLogic compareLogic = new CompareLogic();
           // ComparisonResult result = compareLogic.Compare(itinObjX, itinObj);

            //These will be different, write out the differences
            //if (!result.AreEqual)
           //     output.WriteLine("This is output from {0}", result.DifferencesString);
            // Assert
            //Assert.True(result.AreEqual);
        }

      
    }
}
