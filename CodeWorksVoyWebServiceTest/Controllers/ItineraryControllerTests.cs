
using CodeWorksVoyWebService.Bussiness_Logic.Bussiness_Objects;
using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;
using CodeWorksVoyWebService.Bussiness_Logic.Utils;
using CodeWorksVoyWebService.Controllers;
using CodeWorksVoyWebService.Services;
using CodeWorksVoyWebServiceTest.Controllers.Mocks;
using KellermanSoftware.CompareNetObjects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace CodeWorksVoyWebServiceTest.Controllers
{
    public class ItineraryControllerTests : IDisposable
    {
        private MockRepository mockRepository;

        private ISessionObjectsService _sessionObjectsService;
        private IItineraryService _itineraryService;
        private IHotelAdapter _hotelAdapter;
        private IPlaceAdapter _placeAdapter;
        private ICardAdapter _cardAdapter;
        private IUserItinAdapter _userItinAdapter;
        private ITransferAdapter _transferAdapter;
        private IMapService _mapService;
        private IPriceService _priceService;
        private IConfiguration _configuration;
        private ItineraryController itineraryController;
        private readonly ITestOutputHelper output;
        private SessionObject sessionObjects;
        private ICacheServices _cacheServices;
      




        public ItineraryControllerTests(ITestOutputHelper output)
        {
            this.output = output;
            this.mockRepository = new MockRepository(MockBehavior.Default);


              }

        public void Dispose()
        {//
            this.mockRepository.VerifyAll();
        }

        private void CreateItineraryControllers()
        {
            // Setup concret objects for tests
            //TripCardObj cardObj = JsonUtils.getJsonObjectFromFile<TripCardObj>("./card.json");
            //List<PRSelection> prSelections = JsonUtils.getJsonObjectFromFile<List<PRSelection>>("./pRSelections.json");
            //List<TransferNode> transferNodes = JsonUtils.getJsonObjectFromFile<List<TransferNode>>("./transferNodes.json");
            //CodeWorksVoyWebService.Models.WebData.UserItinerary userItin = JsonUtils.getJsonObjectFromFile<CodeWorksVoyWebService.Models.WebData.UserItinerary>("./userItin.json");
            //List<TransferNodeItem> transferNodeItems = JsonUtils.getJsonObjectFromFile<List<TransferNodeItem>>("./transferNodeItems.json");
            //List<PlaceState> placeStates = JsonUtils.getJsonObjectFromFile<List<PlaceState>>("./placeStates.json");

            ServiceFactory serviceFactory = new ServiceFactory();
            var serviceProvider = serviceFactory.Services.BuildServiceProvider();
            _sessionObjectsService = serviceProvider.GetService<ISessionObjectsService>();
         _itineraryService = serviceProvider.GetService<IItineraryService>();
         _hotelAdapter = serviceProvider.GetService<IHotelAdapter>();
          _placeAdapter = serviceProvider.GetService<IPlaceAdapter>();
          _cardAdapter = serviceProvider.GetService<ICardAdapter>();
          _userItinAdapter = serviceProvider.GetService<IUserItinAdapter>();
          _transferAdapter = serviceProvider.GetService<ITransferAdapter>();
         _mapService = serviceProvider.GetService<IMapService>();
         _priceService = serviceProvider.GetService<IPriceService>();
         _configuration = serviceProvider.GetService<IConfiguration>();
            _cacheServices= serviceProvider.GetService<ICacheServices>();

            itineraryController = new ItineraryController(_cacheServices,_sessionObjectsService, _itineraryService, _hotelAdapter, _placeAdapter, _cardAdapter, _userItinAdapter, _transferAdapter, _mapService, _priceService, _configuration);


        }


        [Fact]
        public void GetItinObj_ItinObj_MatchesSavedItinObj()
        {
            // Arrange
            CreateItineraryControllers();
            var unitUnderTest = itineraryController;
            string id = "30058";
            int templateTypeId = 1;

            // Act
            ItinObj itinObj = unitUnderTest.GetItinObj(
                id,
                templateTypeId, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"));
            ItinObj itinObjX = JsonUtils.getJsonObjectFromFile<ItinObj>("./itinObj.json");
            CompareLogic compareLogic = new CompareLogic();
            ComparisonResult result = compareLogic.Compare(itinObjX, itinObj);

            //These will be different, write out the differences
            if (!result.AreEqual)
            {
                output.WriteLine("This is output from {0}", result.DifferencesString);
            }
            // Assert
            Assert.True(result.AreEqual);
        }


        [Fact]
        public void GetStoredItinObj_StoredItinObj_MatchesSavedStoredItinObj()
        {
            CreateItineraryControllers();
            // Arrange
            var unitUnderTest = itineraryController;
            string id = "30058";
            int templateTypeId = 1;
             unitUnderTest.GetItinObj(
                id,
                templateTypeId, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"));

            // Act
            StoredItinObj itinObj = unitUnderTest.GetStoredItinObj(Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"));
            StoredItinObj itinObjX = JsonUtils.getJsonObjectFromFile<StoredItinObj>("./storedItinObj.json");
            CompareLogic compareLogic = new CompareLogic();
            ComparisonResult result = compareLogic.Compare(itinObjX, itinObj);

            //These will be different, write out the differences
            if (!result.AreEqual)
            {
                output.WriteLine("This is output from {0}", result.DifferencesString);
            }
            // Assert
            Assert.True(result.AreEqual);
        }




        [Fact]
        public void RemoveNight_PRSelections_NightRemoved()
        {
            CreateItineraryControllers();
            // Arrange
            var unitUnderTest = itineraryController;
            string id = "30058";
            int templateTypeId = 1;

            unitUnderTest.GetItinObj(
                id,
                templateTypeId, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"));
           
            // Act

            unitUnderTest.RemoveNight(1, Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"));
            unitUnderTest.CreateTestJsonFiles = false;
            ItinObj itinObj = unitUnderTest.GetStoredItinObj(Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"));
            List<PRSelection> pRSelections = itinObj.PRSelections;
            List<PRSelection> pRSelectionsX = JsonUtils.getJsonObjectFromFile<List<PRSelection>>("./pRSelections-RemoveNight.json");
            CompareLogic compareLogic = new CompareLogic();
            ComparisonResult result = compareLogic.Compare(pRSelectionsX, pRSelections);

            //These will be different, write out the differences
            if (!result.AreEqual)
            {
                output.WriteLine("This is output from {0}", result.DifferencesString);
            }
            // Assert
            Assert.True(result.AreEqual);
        }



        /*
       

        [Fact]
        public void GetItineraryCards_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateItineraryController();
            int templateTypeId = TODO;

            // Act
            var result = unitUnderTest.GetItineraryCards(
                templateTypeId);

            // Assert
            Assert.Fail();
        }

        [Fact]
        public void GetItineraryStyleCards_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateItineraryController();
            int templateTypeId = TODO;

            // Act
            var result = unitUnderTest.GetItineraryStyleCards(
                templateTypeId);

            // Assert
            Assert.Fail();
        }

        [Fact]
        public void GetPRSelections_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateItineraryController();

            // Act
            var result = unitUnderTest.GetPRSelections();

            // Assert
            Assert.Fail();
        }

        [Fact]
        public void GetTotalNights_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateItineraryController();

            // Act
            var result = unitUnderTest.GetTotalNights();

            // Assert
            Assert.Fail();
        }

        [Fact]
        public void deleteLastTransferNode_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateItineraryController();

            // Act
            unitUnderTest.deleteLastTransferNode();

            // Assert
            Assert.Fail();
        }

        [Fact]
        public void deleteLastHR_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateItineraryController();

            // Act
            unitUnderTest.deleteLastHR();

            // Assert
            Assert.Fail();
        }

        [Fact]
        public void AddNight_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateItineraryController();
            int id = TODO;

            // Act
            var result = unitUnderTest.AddNight(
                id);

            // Assert
            Assert.Fail();
        }

        [Fact]
        public void RemoveNight_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateItineraryController();
            int id = TODO;

            // Act
            var result = unitUnderTest.RemoveNight(
                id);

            // Assert
            Assert.Fail();
        }

        [Fact]
        public void DelHotel_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateItineraryController();

            // Act
            var result = unitUnderTest.DelHotel();

            // Assert
            Assert.Fail();
        }

        [Fact]
        public void AddHotel_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateItineraryController();
            int id = TODO;
            int id2 = TODO;

            // Act
            var result = unitUnderTest.AddHotel(
                id,
                id2);

            // Assert
            Assert.Fail();
        }
        */
    }
}
