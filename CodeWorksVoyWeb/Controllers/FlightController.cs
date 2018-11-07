using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using CodeWorkVoyWebService.Bussiness_Logic.Utils;
using CodeWorkVoyWebService.Services;
using CodeWorksVoyWebService.Services;

namespace CodeWorkVoyWebService.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    [Controller]
    public class FlightController : Controller
    {

        private ISessionObjectsService _sessionObjectsService;
        private IFlightAdapter _flightAdapter;
        private IPriceService _priceService;
        private IItineraryService _itineraryService;
        private IHotelAdapter _hotelAdapter;
        private IPlaceAdapter _placeAdapter;
        private ITransferAdapter _transferAdapter;
        private string userHashId = "xxxx";

        public FlightController(ISessionObjectsService sessionObjectsService, IItineraryService itineraryService, IHotelAdapter hotelAdapter, IPlaceAdapter placeAdapter, IFlightAdapter flightAdapter, IPriceService priceService, ITransferAdapter transferAdapter)
        {
            _sessionObjectsService = sessionObjectsService;
            _flightAdapter = flightAdapter;
            _priceService = priceService;
            _itineraryService = itineraryService;
            _hotelAdapter = hotelAdapter;
            _placeAdapter = placeAdapter;
            _transferAdapter = transferAdapter;
        }


        [HttpGet]
        public IActionResult Index()
        {

            //List<FlightObj> objs = _flightAdapter.getAirlines(1);
            return Ok(_flightAdapter.getAirlines(1));
        }


        [HttpGet("GetAirports/{id}")]
        public IActionResult GetAirports([FromRoute] int id)
        {
            ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userHashId);
            sessionObject.Flight.SupplierID = id;
            return Ok(_flightAdapter.getAirportsByAID(id));

        }

        [HttpGet("GetAirlines")]
        public IActionResult GetAirlines()
        {
            ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userHashId);
            return Ok(_flightAdapter.getAirlines(sessionObject.CountryFlag));

        }

        [HttpGet("GetOutFlight/{id}")]
        public IActionResult GetOutFlights([FromRoute] string id)
        {
            ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userHashId);
            sessionObject.Flight.DepartAirport = id;
            DateTime SelectedDate = DateTime.Now;
            DateTime startDate = SelectedDate.AddDays(-30d);
            DateTime endDate = SelectedDate.AddDays(60d);


            List<FlightObj> flightObjs = _flightAdapter.getOutFlightsByDateRangeForward(sessionObject.Flight.SupplierID, SelectedDate, endDate);
            _sessionObjectsService.setSessionObject(userHashId, sessionObject);
            return Ok(flightObjs);
        }

        [HttpGet("GetInFlight/{id}/{id2}")]
        public IActionResult getInFlights([FromRoute] int id, [FromRoute] string id2)
        {
            ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userHashId);
            sessionObject.Flight.OutFlightID = id;
            sessionObject.Flight.StartDate = Convert.ToDateTime(id2);

            DateTime SelectedDate = sessionObject.Flight.StartDate;
            DateTime startDate = SelectedDate.AddDays(5d);
            DateTime endDate = SelectedDate.AddDays(30d);


            List<FlightObj> flightObjs = _flightAdapter.getInFlightsByDateRangeForward(sessionObject.Flight.SupplierID, SelectedDate, endDate);
            _sessionObjectsService.setSessionObject(userHashId, sessionObject);
            return Ok(flightObjs);
        }

        [HttpGet("GetCost/{id}/{id2}")]
        public IActionResult GetCost([FromRoute] int id, [FromRoute] string id2)
        {
            StringBuilder message = new StringBuilder();
            ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userHashId);
            sessionObject.Flight.InFlightID = id;
            sessionObject.Flight.EndDate = Convert.ToDateTime(id2);
            TimeSpan span = sessionObject.Flight.EndDate - sessionObject.Flight.StartDate;
            sessionObject.SelectedNights = Convert.ToInt32(span.TotalDays);
            _sessionObjectsService.setSessionObject(userHashId, sessionObject);
            message.Append(CheckLastHop());
            if (!testNightsEqual())
            {
                message.Append(" Nights not equal");
                return Ok(JsonUtils.ConvertJsonStr(message.ToString()));
            };
            decimal cost = getPrice();
            //DateTime SelectedDate = _sessionObjects.Flight.StartDate;
            return Ok(JsonUtils.ConvertJsonStr(message.ToString() + " Cost is : " + cost));
        }

        [HttpGet("GetCost")]
        public IActionResult GetCost()
        {
            StringBuilder message = new StringBuilder();
            ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userHashId);
            TimeSpan span = sessionObject.Flight.EndDate - sessionObject.Flight.StartDate;
            sessionObject.SelectedNights = Convert.ToInt32(span.TotalDays);
            _sessionObjectsService.setSessionObject(userHashId, sessionObject);
            message.Append(CheckLastHop());
            if (!testNightsEqual())
            {
                message.Append(" Nights not equal");
                return Ok(JsonUtils.ConvertJsonStr(message.ToString()));
            };
            decimal cost = getPrice();
            //DateTime SelectedDate = _sessionObjects.Flight.StartDate;
            return Ok(JsonUtils.ConvertJsonStr(message.ToString() + " Cost is : " + cost));
        }

        public string CheckLastHop()
        {
            string message = "";
            ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userHashId);
            _itineraryService.SessionObject = sessionObject;
            if (sessionObject.Flight.DepartAirportID == -1)
            {
                message = "Please select a Departing Airport.";

                return message;
            }
            //TransferAdapter transferAdapter = new TransferAdapter();

            // Check can get back in one day.
            int lastPlaceID = sessionObject.PRSelections[sessionObject.PRSelections.Count - 1].PlaceID;

            // check  if last transfer already takes you back to airport
            if (_transferAdapter.checkLastTransferIsComplete(sessionObject.Flight.DepartAirportID, sessionObject.TransferNodes[sessionObject.TransferNodes.Count - 1].TransferID))
            {
                return "Itinerary Complete.";
            }


            if (!sessionObject.PageStates.FinishSelected && !sessionObject.PageStates.IsTemplate)
            {
                if (sessionObject.WithCar)
                {
                    if (_transferAdapter.lastHopAirport(sessionObject.Flight.DepartAirportID, lastPlaceID, sessionObject.WithCar))
                    {
                        _itineraryService.addFinalTransferNode(sessionObject.Flight.DepartAirportID);
                        _sessionObjectsService.setSessionObject(userHashId, sessionObject);
                        // _sessionObjects.PageStates.FinishSelected = true;
                        message = "We have added another day to your itinerary so that you can connect with your return flight.";

                    }
                    else
                    {
                        message = "You can not get back to the airport in one day from your last place. Please select another place closer to you choosen departing airport.";
                        // ErrorBox.Visible = true;
                        return message;
                    }

                }
                else
                {
                    if (_transferAdapter.lastHopAirport(sessionObject.Flight.DepartAirportID, lastPlaceID, sessionObject.WithCar))
                    {
                        _itineraryService.addFinalTransferNode(sessionObject.Flight.DepartAirportID);
                        _sessionObjectsService.setSessionObject(userHashId, sessionObject);
                        return "Itinerary Complete.";
                        //_sessionObjects.PageStates.FinishSelected = true;
                    }
                    else
                    {
                        sessionObject.SelectedPlaceID = lastPlaceID;
                        //addFinalTransferNode(SelectedDepAirportID);
                        // Add Havana as a final place and the transfer to the airport the next day.
                        int finalPlaceID = 12;
                        int lastDefaultHotel = 47;

                        sessionObject.SelectedPlaceID = finalPlaceID;
                        sessionObject.SelectedPlace = _placeAdapter.getPlaceName(sessionObject.SelectedPlaceID);


                        sessionObject.SelectedIndex = sessionObject.PRSelections.Count - 1;
                        int prevPlaceID = sessionObject.PRSelections[sessionObject.SelectedIndex].PlaceID;
                        _itineraryService.addTransferNode(prevPlaceID);
                        _itineraryService.addPlace(prevPlaceID);
                        sessionObject.PRSelections[sessionObject.PRSelections.Count - 1].Nights = 1;

                        _itineraryService.addFinalTransferNode(sessionObject.Flight.DepartAirportID);

                        // Add a hotel: either the first previously selected hotel or the default hotel.
                        foreach (PRSelection selection in sessionObject.PRSelections)
                        {
                            if (selection.PlaceID == finalPlaceID)
                            {
                                if (selection.HotelID != 0)
                                {
                                    lastDefaultHotel = selection.HotelID;
                                }
                                break;
                            }
                        }

                        sessionObject.SelectedHotelID = lastDefaultHotel;
                        sessionObject.SelectedHotel = _hotelAdapter.getHotelName(sessionObject.SelectedHotelID);
                        _itineraryService.addHotel();


                        message = "You can not get back to the airport in one day. Last night in Havana has been added. You can now Change the new Hotel or Just Finish and Get Price ";
                        //ErrorBox.Visible = true;
                        _sessionObjectsService.setSessionObject(userHashId, sessionObject);
                        return message;
                        //PageStates.FinishSelected = true;
                        //Response.Redirect("builder"+Country+".aspx?place=" + SelectedPlace + "&hotel=" + SelectedHotel);
                    }
                }
            }


            return "Got to end of CheckLastHop";
        }


        private decimal getPrice()
        {
            decimal price = 0;
            ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userHashId);
            // Get and display a Price.
            sessionObject.UserItinID = 0;
            _priceService.SessionObject=sessionObject;
           
            price= _priceService.getPrice();
            _sessionObjectsService.setSessionObject(userHashId, sessionObject);
            return price;


            //Response.Redirect("Detail.aspx");
        }
        private bool testNightsEqual()
        {
            int totalNights = 0;
            ISessionObject sessionObject = _sessionObjectsService.getSessionObject(userHashId);
            if (sessionObject.PRSelections == null) return false;

            foreach (PRSelection sel in sessionObject.PRSelections)
            {
                totalNights += sel.Nights;

            }

            if (totalNights == sessionObject.SelectedNights)
            {

                return true;

            }
            else
            {
                int diff = totalNights - sessionObject.SelectedNights;
                if (diff < 0)
                {

                }
                else
                {


                }


            }

            return false;
        }


    }
}