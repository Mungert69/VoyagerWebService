using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using CodeWorkVoyWebService.Bussiness_Logic.Bussiness_Objects;
using CodeWorkVoyWebService.Bussiness_Logic.DataObjects;
using CodeWorkVoyWebService.Bussiness_Logic.Utils;

using CodeWorkVoyWebService.Services;
using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;
using Microsoft.AspNetCore.Http;
using CodeWorksVoyWebService.Bussiness_Logic.Utils;
using CodeWorksVoyWebService.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeWorkVoyWebService.Controllers
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
        //private string userHashId="xxxx";
        private bool createTestJsonFiles =true;

        public ItineraryController(ISessionObjectsService sessionObjectsService, IItineraryService itineraryService, IHotelAdapter hotelAdapter, IPlaceAdapter placeAdapter, ICardAdapter cardAdapter, IUserItinAdapter userItinAdapter, ITransferAdapter transferAdapter, IMapService mapService)
        {

            _sessionObjectsService = sessionObjectsService;
            _itineraryService = itineraryService;
            _hotelAdapter = hotelAdapter;
            _placeAdapter = placeAdapter;
            _cardAdapter = cardAdapter;
            _userItinAdapter = userItinAdapter;
            _transferAdapter = transferAdapter;
            _mapService = mapService;
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
            CardObj card = new CardObj();

            List <PRSelection> pRSelections = new List<PRSelection>();
            List<TransferNode> transferNodes = new List<TransferNode>();
             
            if (id != "0")
            {
                _userItinAdapter.AdminTemplate = true;

                card = getCardFromItinerary(Convert.ToInt32(id), templateTypeId);
                if (createTestJsonFiles) JsonUtils.writeJsonObjectToFile("card.json", card);

                pRSelections = _userItinAdapter.getItinPlaces(card.ItinId);
                pRSelections = _cardAdapter.updateSelectionWithCards(pRSelections);
                if (createTestJsonFiles) JsonUtils.writeJsonObjectToFile("pRSelections.json", pRSelections);


                itinObj.Card = card;
                itinObj.PRSelections = pRSelections;


                if (!isView)
                {
                    transferNodes = _userItinAdapter.getTransfersNodes(card.ItinId);
                    List<TransferNodeItem> transferNodeItems = _transferAdapter.getTransferNodeItems(transferNodes);
                    if (createTestJsonFiles) JsonUtils.writeJsonObjectToFile("transferNodeItems.json", transferNodeItems);
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

            if (createTestJsonFiles) JsonUtils.writeJsonObjectToFile("itinObj.json", itinObj);
            return itinObj;
        }



        // GET: api/Itinerary/StoredItinObj
        [HttpGet("StoredItinObj/{userId}")]
        public StoredItinObj GetStoredItinObj([FromRoute] string userId)
        {
            ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userId);
            if (createTestJsonFiles) JsonUtils.writeJsonObjectToFile("sessionObjects-StoredItinBefore.json", sessionObject);
            CardObj card = new CardObj();
            List<PRSelection> pRSelections = sessionObject.PRSelections;
            pRSelections = _cardAdapter.updateSelectionWithCards(pRSelections);

            List<TransferNode> transferNodes = sessionObject.TransferNodes;
            List<TransferNodeItem>  transferNodeItems = _transferAdapter.getTransferNodeItems(transferNodes);
           
            // Update placeStates in sessionObject.

            List<PlaceState> placeStates = _mapService.selectHops(sessionObject);
            if (createTestJsonFiles) JsonUtils.writeJsonObjectToFile("placeStates.json", placeStates);

            StoredItinObj itinObj = new StoredItinObj();
            //TODO write UserData code
            card.Id = 0;
            card.Title = "User Itinerary";
            itinObj.Card = card;
            itinObj.PRSelections = pRSelections;
            itinObj.TransferNodeItems = transferNodeItems;
            itinObj.PlaceStates = placeStates;
            if (createTestJsonFiles) JsonUtils.writeJsonObjectToFile("storedItinObj.json", itinObj);

            return itinObj;
        }


        private CardObj getCardFromItinerary(int userItinId, int templateTypeId)
        {

            CardObj card = new CardObj();

            CodeWorkVoyWebService.Models.WebData.UserItinerary userItin = _userItinAdapter.getAdminItin(userItinId);
            if (createTestJsonFiles) JsonUtils.writeJsonObjectToFile("userItin.json", userItin);

            card.Id = userItin.UserItinId;
            card.ItinId = userItin.ItinId;
            card.Title = userItin.ItinName;
            card.Panel1 = userItin.Seotext;
            card.Longitude = "";
            card.Latitude = "";
            card.CountryId = 0;
            card.Country = "";
            card.TypeId = templateTypeId;

            List<string> strList = new List<string>();
            strList.Add("");
            card.PicFileName = strList.ElementAt(0);

            card.PicFileNames = strList;
            return card;
        }

        // GET: api/Itinerary/Cards/43
        [HttpGet("Cards/{templateTypeId}")]
        public IEnumerable<CardObj> GetItineraryCards([FromRoute] int templateTypeId)
        {

            _userItinAdapter.AdminTemplate = true;

            List<CodeWorkVoyWebService.Models.WebData.AdminItinTemplates> adminTemplates = _userItinAdapter.getAdminTemplateItins(templateTypeId);

            //List<CodeWorkVoyWebService.Models.WebData.UserItinerary> userItins = _userItinAdapter.getAdminTemplateItins();
            List<CardObj> cards = new List<CardObj>();
            int counter = 0;
            foreach (CodeWorkVoyWebService.Models.WebData.AdminItinTemplates adminTemplate in adminTemplates)
            {
                cards.Add(getCardFromItinerary(Convert.ToInt32(adminTemplate.AdminItinId), templateTypeId));
                counter++;
                if (counter == 20) break;
            }

            return cards;

        }

        // GET: api/Interary/StyleCards/43
        [HttpGet("StyleCards/{templateTypeId}")]
        public IEnumerable<CodeWorkVoyWebService.Models.WebData.Card> GetItineraryStyleCards([FromRoute] int templateTypeId)
        {
            //TODO country code ie (true,1) below

            List<CodeWorkVoyWebService.Models.WebData.Card> styleCards = new List<CodeWorkVoyWebService.Models.WebData.Card>();
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
            ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userId);
            sessionObject.PRSelections[id].Nights = sessionObject.PRSelections[id].Nights + 1;
            _sessionObjectsService.setSessionObject(userId, sessionObject);
            return Ok(JsonUtils.ConvertJsonStr("Night added"));
        }



        [HttpGet("RemoveNight/{id}/{userId}")]
        public IActionResult RemoveNight([FromRoute] int id, [FromRoute] string userId)
        {
            ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userId);

            sessionObject.PRSelections[id].Nights = sessionObject.PRSelections[id].Nights - 1;
            if (sessionObject.PRSelections[id].Nights <= 1) { sessionObject.PRSelections[id].Nights = 1; }
            if (createTestJsonFiles) JsonUtils.writeJsonObjectToFile("pRSelections-RemoveNight.json", sessionObject.PRSelections);
            _sessionObjectsService.setSessionObject(userId, sessionObject);
            return Ok(JsonUtils.ConvertJsonStr("Night removed"));
        }

        [HttpGet("DelHotel/{userId}")]
        public IActionResult DelHotel([FromRoute] string userId)
        {
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

            return Ok(JsonUtils.ConvertJsonStr("Last hop deleted"));
            // Rebuild map.
            /*selectHops();
            getMapButtons();
            AddHotelButton.Visible = false;
            getSelections();
            getHotels();
            updateTabPanel();
            getPlaceInfo();*/
        }


        [HttpGet("AddHotel/{id}/{id2}/{userId}")]
        public IActionResult AddHotel([FromRoute] int id, [FromRoute] int id2, [FromRoute] string userId)
        {
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
            // Add a hotel to selected resort.


            //FinishPanel.Visible = true;
            //getSelections();
            //selectHops();
            //getMapButtons();
            //AddHotelButton.Visible = false;
            sessionObject.IsTemplateChanged = true;
            //TemplateChangedLabel.Visible = IsTemplateChanged;
            //Response.Redirect("TripBuilder.aspx?place=" + SelectedPlace + "&hotel=" + SelectedHotel);

            _sessionObjectsService.setSessionObject(userId, sessionObject);
            return Ok(JsonUtils.ConvertJsonStr("Itin added"));

        }



    }


}
