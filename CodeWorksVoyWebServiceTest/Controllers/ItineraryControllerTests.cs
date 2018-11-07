
using KellermanSoftware.CompareNetObjects;
using Moq;
using System;
using System.Collections.Generic;
using CodeWorkVoyWebService.Bussiness_Logic.Bussiness_Objects;
using CodeWorkVoyWebService.Bussiness_Logic.DataObjects;
using CodeWorkVoyWebService.Bussiness_Logic.Utils;
using CodeWorkVoyWebService.Controllers;
using CodeWorkVoyWebService.Services;
using Xunit;
using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;
using CodeWorksVoyWebServiceTest.Controllers.Mocks;
using CodeWorksVoyWebServiceTest.Utils;
using Microsoft.Extensions.Configuration;
using Xunit.Abstractions;
using CodeWorksVoyWebService.Services;

namespace CodeWorksVoyWebServiceTest.Controllers
{
    public class ItineraryControllerTests : IDisposable
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
        private ItineraryController itineraryController;
        private ItineraryController itineraryController_StoredItinObj;
        private readonly ITestOutputHelper output;
        private SessionObject sessionObjects;
        private Mock<ISessionObjectsService> mockSessionObjectsService;




        public ItineraryControllerTests(ITestOutputHelper output)
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
        }

        public void Dispose()
        {//
            this.mockRepository.VerifyAll();
        }

        private void CreateItineraryControllers()
        {
            // Setup concret objects for tests
            CardObj cardObj = JsonUtils.getJsonObjectFromFile<CardObj>("./TestObjects/card.json");
            List<PRSelection> prSelections = JsonUtils.getJsonObjectFromFile<List<PRSelection>>("./TestObjects/pRSelections.json");
            List<TransferNode> transferNodes = JsonUtils.getJsonObjectFromFile<List<TransferNode>>("./TestObjects/transferNodes.json");
            CodeWorkVoyWebService.Models.WebData.UserItinerary userItin = JsonUtils.getJsonObjectFromFile<CodeWorkVoyWebService.Models.WebData.UserItinerary>("./TestObjects/userItin.json");
            List<string> transferStrings = JsonUtils.getJsonObjectFromFile<List<string>>("./TestObjects/transferStrings.json");
            List<PlaceState> placeStates = JsonUtils.getJsonObjectFromFile<List<PlaceState>>("./TestObjects/placeStates.json");
            IConfiguration config = TestContainerConfig.InitConfiguration();
             sessionObjects= new SessionObject(config);
            sessionObjects= JsonUtils.getJsonObjectFromFile<SessionObject>("./TestObjects/sessionObjects-StoredItinBefore.json",sessionObjects);
            
            // Setup Mocks 
            this.mockUserItinAdapter.SetupAllProperties();
            this.mockUserItinAdapter.SetReturnsDefault<CodeWorkVoyWebService.Models.WebData.UserItinerary>(userItin);
            this.mockCardAdapter.SetReturnsDefault<List<PRSelection>>(prSelections);
            this.mockUserItinAdapter.SetReturnsDefault<List<TransferNode>>(transferNodes);       
            this.mockTransferAdapter.SetupAllProperties();
            this.mockTransferAdapter.SetReturnsDefault<List<string>>(transferStrings);
            this.mockMapService.SetReturnsDefault<List<PlaceState>>(placeStates);
            this.mockSessionObjectsService.SetReturnsDefault<ISessionObject>(sessionObjects);

            // Use A FluentAPI pattern so multiple methods can be chained.
            Mock<ISessionObject> mockSessionObjects = new MockSessionObjects().SetUpObject();

            itineraryController_StoredItinObj = new ItineraryController(
               this.mockSessionObjectsService.Object,
               this.mockItineraryService.Object,
               this.mockHotelAdapter.Object,
               this.mockPlaceAdapter.Object,
               this.mockCardAdapter.Object,
               this.mockUserItinAdapter.Object,
               this.mockTransferAdapter.Object,
               this.mockMapService.Object);

           
            itineraryController =new ItineraryController(
                this.mockSessionObjectsService.Object,
                this.mockItineraryService.Object,
                this.mockHotelAdapter.Object,
                this.mockPlaceAdapter.Object,
                this.mockCardAdapter.Object,
                this.mockUserItinAdapter.Object,
                this.mockTransferAdapter.Object,
                this.mockMapService.Object);

           
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
                templateTypeId);
            ItinObj itinObjX = JsonUtils.getJsonObjectFromFile<ItinObj>("./TestObjects/itinObj.json");
            CompareLogic compareLogic = new CompareLogic();
            ComparisonResult result = compareLogic.Compare(itinObjX, itinObj);

            //These will be different, write out the differences
            if (!result.AreEqual)
                output.WriteLine("This is output from {0}", result.DifferencesString);
            // Assert
            Assert.True(result.AreEqual);
        }


        [Fact]
        public void GetStoredItinObj_StoredItinObj_MatchesSavedStoredItinObj()
        {
            CreateItineraryControllers();
            // Arrange
            var unitUnderTest = itineraryController_StoredItinObj;

            // Act
            StoredItinObj itinObj = unitUnderTest.GetStoredItinObj();
            StoredItinObj itinObjX = JsonUtils.getJsonObjectFromFile<StoredItinObj>("./TestObjects/storedItinObj.json");
            CompareLogic compareLogic = new CompareLogic();
            ComparisonResult result = compareLogic.Compare(itinObjX, itinObj);

            //These will be different, write out the differences
            if (!result.AreEqual)
                output.WriteLine("This is output from {0}", result.DifferencesString);
            // Assert
            Assert.True(result.AreEqual);
        }




        [Fact]
        public void RemoveNight_PRSelections_NightRemoved()
        {
            CreateItineraryControllers();
            // Arrange
            var unitUnderTest = itineraryController_StoredItinObj;

            // Act
            
            unitUnderTest.RemoveNight(3);
            List<PRSelection> pRSelections =sessionObjects.PRSelections;
            List<PRSelection> pRSelectionsX = JsonUtils.getJsonObjectFromFile<List<PRSelection>>("./TestObjects/pRSelections-RemoveNight.json");
            CompareLogic compareLogic = new CompareLogic();
            ComparisonResult result = compareLogic.Compare(pRSelectionsX, pRSelections);

            //These will be different, write out the differences
            if (!result.AreEqual)
                output.WriteLine("This is output from {0}", result.DifferencesString);
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
