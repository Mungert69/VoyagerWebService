using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using CodeWorksVoyWebService.Bussiness_Logic.Bussiness_Objects;
using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;
using CodeWorksVoyWebService.Bussiness_Logic.Utils;

using CodeWorksVoyWebService.Services;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeWorksVoyWebService.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    [ApiController]
    public class ItineraryController : Controller
    {


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
        private ICacheServices _cacheServices;
        //private string userHashId="xxxx";
        private bool createTestJsonFiles =false;

        public bool CreateTestJsonFiles { get => createTestJsonFiles; set => createTestJsonFiles = value; }

        public ItineraryController(ICacheServices cacheServices, ISessionObjectsService sessionObjectsService, IItineraryService itineraryService, IHotelAdapter hotelAdapter, IPlaceAdapter placeAdapter, ICardAdapter cardAdapter, IUserItinAdapter userItinAdapter, ITransferAdapter transferAdapter, IMapService mapService, IPriceService priceService, IConfiguration configuration)
        {

            _sessionObjectsService = sessionObjectsService;
            _itineraryService = itineraryService;
            _hotelAdapter = hotelAdapter;
            _placeAdapter = placeAdapter;
            _cardAdapter = cardAdapter;
            _userItinAdapter = userItinAdapter;
            _transferAdapter = transferAdapter;
            _mapService = mapService;
            _priceService = priceService;
            _configuration = configuration;
            _cacheServices = cacheServices;
        }


        // GET: api/Itinerary/ItinObj/30058/43
        [HttpGet("ItinObj/{id}/{templateTypeId}/{userId}")]
        public ItinObj GetItinObj([FromRoute] string id, [FromRoute] int templateTypeId, [FromRoute] string userId)
        {

            return ItinObj(id, templateTypeId, false, userId);
        }

        // GET: api/Itinerary/ViewItinObj/30058/43
        [HttpGet("ViewItinObj/{id}/{templateTypeId}")]
        public ItinObj GetViewItinObj([FromRoute] string id, [FromRoute] int templateTypeId)
        {
            return ItinObj(id, templateTypeId, true,null);

        }


        private ItinObj ItinObj(string id, int templateTypeId, bool isView, string userId)
        {
            //TODO write UserData code
            ItinObj itinObj = new ItinObj();

            // Prevent buffer over run.
            if ((userId !=null && userId.Length > 36) || id.Length>10 ) return itinObj;
            TripCardObj card = new TripCardObj();

            List <PRSelection> pRSelections = new List<PRSelection>();
            List<TransferNode> transferNodes = new List<TransferNode>();
             
            if (id != "0")
            {

                //TODO .getDatePriceObjs will not be called for a userItin.
                card.setCardFromItinerary(Convert.ToInt32(id), templateTypeId, _userItinAdapter, CreateTestJsonFiles);
                card.getDatePriceObjs(_priceService);
                pRSelections= card.setPRSeletions(_userItinAdapter, _cardAdapter);
               

                if (CreateTestJsonFiles) JsonUtils.writeJsonObjectToFile("card.json", card);
                if (CreateTestJsonFiles) JsonUtils.writeJsonObjectToFile("pRSelections.json", pRSelections);


                itinObj.Card = card;
                itinObj.PRSelections = pRSelections;


                if (!isView)
                {
                    transferNodes = _userItinAdapter.getTransfersNodes(card.ItinId);
                    if (CreateTestJsonFiles) JsonUtils.writeJsonObjectToFile("transferNodes.json", transferNodes);

                    List<TransferNodeItem> transferNodeItems = _transferAdapter.getTransferNodeItems(transferNodes);
                    if (CreateTestJsonFiles) JsonUtils.writeJsonObjectToFile("transferNodeItems.json", transferNodeItems);
                    itinObj.TransferNodeItems = transferNodeItems;

                    ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userId);
                    sessionObject.PRSelections = pRSelections;
                    sessionObject.TransferNodes = transferNodes;
                    sessionObject.SelectedPlaceID = sessionObject.PRSelections[sessionObject.PRSelections.Count - 1].PlaceID;
                    sessionObject.SelectedPlace = sessionObject.PRSelections[sessionObject.PRSelections.Count - 1].Place;
                    sessionObject.WithCar = sessionObject.TransferNodes[sessionObject.TransferNodes.Count - 1].WithCar;
                    sessionObject.PrevPlaceID = sessionObject.PRSelections[sessionObject.PRSelections.Count - 1].PlaceID;
                    sessionObject.PageStates.FirstPlaceSelected = true;
                    sessionObject.SelectedIndex = sessionObject.PRSelections.Count - 1;
                    sessionObject.Flight.ArriveAirportID = sessionObject.ArrivalAirportID;
                    sessionObject.Flight.DepartAirportID = sessionObject.DepartAirportID;
                    _sessionObjectsService.setSessionObject(userId, sessionObject);
                }
            }

            if (CreateTestJsonFiles) JsonUtils.writeJsonObjectToFile("itinObj.json", itinObj);
            return itinObj;
        }



        // GET: api/Itinerary/StoredItinObj
        [HttpGet("StoredItinObj/{userId}")]
        public StoredItinObj GetStoredItinObj([FromRoute] string userId)
        {
            ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userId);
            if (CreateTestJsonFiles) JsonUtils.writeJsonObjectToFile("sessionObjects-StoredItinBefore.json", sessionObject);

            //Setup card Object from Stored session data.
            TripCardObj card = new TripCardObj();
            List<PRSelection> pRSelections = sessionObject.PRSelections;
            pRSelections = _cardAdapter.updateSelectionWithCards(pRSelections);
            card.setPRSeletions(pRSelections);

            List<TransferNode> transferNodes = sessionObject.TransferNodes;
            List<TransferNodeItem>  transferNodeItems = _transferAdapter.getTransferNodeItems(transferNodes);
           
            // Update placeStates in sessionObject.

            List<PlaceState> placeStates = _mapService.selectHops(sessionObject);
            if (CreateTestJsonFiles) JsonUtils.writeJsonObjectToFile("placeStates.json", placeStates);

            StoredItinObj itinObj = new StoredItinObj();
            //TODO write UserData code
            card.Id = 0;
            card.Title = "User Itinerary";
            itinObj.Card = card;
            itinObj.PRSelections = pRSelections;
            itinObj.TransferNodeItems = transferNodeItems;
            itinObj.PlaceStates = placeStates;
            if (CreateTestJsonFiles) JsonUtils.writeJsonObjectToFile("storedItinObj.json", itinObj);

            return itinObj;
        }



        // GET: api/Itinerary/Cards/43
        [HttpGet("Cards/{templateTypeId}")]
        public IEnumerable<TripCardObj> GetItineraryCards([FromRoute] int templateTypeId)
        {


            List<CodeWorksVoyWebService.Models.WebData.AdminItinTemplates> adminTemplates = _userItinAdapter.getAdminTemplateItins(templateTypeId);

            List<TripCardObj> cards = new List<TripCardObj>();
             TripCardObj card;
            foreach (CodeWorksVoyWebService.Models.WebData.AdminItinTemplates adminTemplate in adminTemplates)
            {
                card = new TripCardObj();
                card.setCardFromItinerary(Convert.ToInt32(adminTemplate.AdminItinId), templateTypeId, _userItinAdapter, CreateTestJsonFiles);
                card.getDatePriceObjs(_priceService);
                card.setPRSeletions(_userItinAdapter, _cardAdapter);
                cards.Add(card);            
            }

            return cards;

        }


        [HttpGet("AllCards/{userId}")]
        public IEnumerable<TripCardObj> GetAllItineraryCards([FromRoute] string userId)
        {

            List<TripCardObj> cards;
            cards=_cacheServices.waitCardsReady();
            JsonUtils.writeJsonObjectToFile("allCards.json", cards);
            return cards;

        }

        // GET: api/Interary/StyleCards/43
        [HttpGet("StyleCards/{templateTypeId}")]
        public IEnumerable<CodeWorksVoyWebService.Models.WebData.Card> GetItineraryStyleCards([FromRoute] int templateTypeId)
        {
            //TODO country code ie (true,1) below

            List<CodeWorksVoyWebService.Models.WebData.Card> styleCards = new List<CodeWorksVoyWebService.Models.WebData.Card>();
            styleCards = _cardAdapter.GetStyleCards(templateTypeId);

            return styleCards;
        }



        [HttpGet("TotalNights/{userId}")]
        public IActionResult GetTotalNights([FromRoute] string userId)
        {
            ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userId);
            return Ok(sessionObject.SelectedNights);

        }

        public void deleteLastTransferNode(string userId)
        {
            ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userId);
            List<TransferNode> tempNodes = sessionObject.TransferNodes;
            if (tempNodes.Count == 0) return;
            tempNodes.RemoveAt(tempNodes.Count - 1);

            _sessionObjectsService.setSessionObject(userId, sessionObject);
        }


        public void deleteLastHR(string userId)
        {
            ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userId);
            List<PRSelection> tempSelections = sessionObject.PRSelections;
            if (tempSelections.Count == 0) return;
            tempSelections.RemoveAt(tempSelections.Count - 1);
            _sessionObjectsService.setSessionObject(userId, sessionObject);

        }
        [HttpGet("AddNight/{id}/{userId}")]
        public IActionResult AddNight([FromRoute] int id, [FromRoute] string userId)
        {
            try { 
            ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userId);
            sessionObject.PRSelections[id].Nights = sessionObject.PRSelections[id].Nights + 1;
            _sessionObjectsService.setSessionObject(userId, sessionObject);
            return Ok(JsonUtils.ConvertJsonStr("Night added"));
            }
            catch (Exception e)
            {
                return Ok(JsonUtils.ConvertJsonStr("Failed to add Night error was : " + e.Message));
            }
        }

        [HttpGet("Save/{userId}")]
        public IActionResult SaveItinerary( [FromRoute] string userId)
        {
            try
            {
                ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userId);
                _priceService.SessionObject = sessionObject;
                sessionObject.Flight.SupplierID = Convert.ToInt16(_configuration.GetSection("AppConfiguration")["DefaultFlightSupplierIDForTemplatePriceCalc"]);

                _priceService.createPriceFromDate(DateTime.Now, 1);
                int userItinId = _userItinAdapter.insertUserItin(sessionObject, userId);
                sessionObject.UserItinID = userItinId;
                _sessionObjectsService.setSessionObject(userId, sessionObject);
                return Ok(JsonUtils.ConvertJsonStr("Itinerary saved with Id : " + userItinId));
            }
            catch (Exception e)
            {
                return Ok(JsonUtils.ConvertJsonStr("Failed to save Itinerary error was : " + e.Message));
            }
        }



        [HttpGet("RemoveNight/{id}/{userId}")]
        public IActionResult RemoveNight([FromRoute] int id, [FromRoute] string userId)
        {
            try
            {
                ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userId);

                sessionObject.PRSelections[id].Nights = sessionObject.PRSelections[id].Nights - 1;
                if (sessionObject.PRSelections[id].Nights <= 1) { sessionObject.PRSelections[id].Nights = 1; }
                if (CreateTestJsonFiles) JsonUtils.writeJsonObjectToFile("pRSelections-RemoveNight.json", sessionObject.PRSelections);
                _sessionObjectsService.setSessionObject(userId, sessionObject);
                return Ok(JsonUtils.ConvertJsonStr("Night removed"));
            }
            catch (Exception e) {
                return Ok(JsonUtils.ConvertJsonStr("Failed to remove Night error was : "+e.Message));
            }
        }

        [HttpGet("DelHotel/{userId}")]
        public IActionResult DelHotel([FromRoute] string userId)
        {
            try { 
            ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userId);

            // Remove last Place hotel and transfer node.
            deleteLastTransferNode(userId);
            deleteLastHR(userId);

            // Set selected place and withcar to last place.
            if (sessionObject.PRSelections.Count > 0)
            {
                sessionObject.SelectedPlaceID = sessionObject.PRSelections[sessionObject.PRSelections.Count - 1].PlaceID;
                sessionObject.SelectedPlace = sessionObject.PRSelections[sessionObject.PRSelections.Count - 1].Place;
                sessionObject.WithCar = sessionObject.TransferNodes[sessionObject.TransferNodes.Count - 1].WithCar;
                sessionObject.PrevPlaceID = sessionObject.SelectedPlaceID;
                sessionObject.SelectedIndex = sessionObject.PRSelections.Count - 1;
            }
            else
            {
                sessionObject.PageStates.FirstPlaceSelected = false;
                sessionObject.SelectedIndex = -1;
            }
            _sessionObjectsService.setSessionObject(userId, sessionObject);
                Random rnd = new Random();
                int test = rnd.Next();
            return Ok(JsonUtils.ConvertJsonStr("Last hop deleted "+test));
            }
            catch (Exception e)
            {
                return Ok(JsonUtils.ConvertJsonStr("Failed to remove Hotel error was : " + e.Message));
            }
        }


        [HttpGet("AddHotel/{id}/{id2}/{userId}")]
        public IActionResult AddHotel([FromRoute] int id, [FromRoute] int id2, [FromRoute] string userId)
        {
            try { 
            ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userId);
            _itineraryService.SessionObject = sessionObject;
            sessionObject.SelectedPlaceID = id;
            sessionObject.SelectedPlace = _placeAdapter.getPlaceName(id);
            sessionObject.SelectedHotelID = id2;
            sessionObject.SelectedHotel = _hotelAdapter.getHotelName(id2);


            sessionObject.pulse = false;
            sessionObject.PageStates.HotelAdded = true;
            //  Add a place if it has not been added before; only in builder mode.
            if (!(sessionObject.PageStates.IsTemplate || sessionObject.PageStates.FinishSelected))
            {
                int prevPlaceID;
                if (sessionObject.PageStates.FirstPlaceSelected)
                {
                    prevPlaceID = sessionObject.PRSelections[sessionObject.PRSelections.Count - 1].PlaceID;
                }
                else
                {

                    prevPlaceID = sessionObject.ArrivalAirportID;
                }
                if (sessionObject.PRSelections != null && sessionObject.SelectedIndex != -1 && sessionObject.SelectedPlaceID == sessionObject.PRSelections[sessionObject.SelectedIndex].PlaceID)
                {
                    _itineraryService.addHotel();
                }
                else
                {
                    // Use Exception to catch not being able to add transfer node
                    try
                    {
                        _itineraryService.addTransferNode(prevPlaceID);
                    }
                    catch
                    {

                        return NotFound(JsonUtils.ConvertJsonStr(" - Not Possible"));

                    }

                    _itineraryService.addPlace(prevPlaceID);
                    sessionObject.PageStates.FirstPlaceSelected = true;
                    _itineraryService.addHotel();

                }

            }
            else
            {
                if (sessionObject.PRSelections != null && sessionObject.SelectedPlaceID == sessionObject.PRSelections[sessionObject.SelectedIndex].PlaceID)
                {
                    _itineraryService.addHotel();
                }
            }
           
            sessionObject.IsTemplateChanged = true;
          
            _sessionObjectsService.setSessionObject(userId, sessionObject);
            return Ok(JsonUtils.ConvertJsonStr("Added Hotel " + sessionObject.SelectedHotel+ " in Place "+sessionObject.SelectedPlace));
            }
            catch (Exception e)
            {
                return Ok(JsonUtils.ConvertJsonStr("Failed to add Hotel error was : " + e.Message));
            }

        }



    }


}
