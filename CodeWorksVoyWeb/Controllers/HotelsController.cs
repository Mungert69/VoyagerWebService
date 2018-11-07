using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeWorkVoyWebService.Bussiness_Logic.Bussiness_Objects;
using CodeWorkVoyWebService.Bussiness_Logic.DataObjects;
using CodeWorkVoyWebService.Models.CubaData;

namespace CodeWorkVoyWebService.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    [Controller]
    public class HotelsController : Controller
    {
        private readonly IHotelAdapter _hotelAdapter;
        private readonly IPlaceAdapter _placeAdapter;
       // private readonly CubaDataContext _cubaDataContext;
        //private ISessionObjects _sessionObjects;
        private readonly ICardAdapter _cardAdapter;
        public HotelsController( IHotelAdapter hotelAdapter, IPlaceAdapter placeAdapter, ICardAdapter cardAdapter, CubaDataContext cubaDataContext )
        {
            _hotelAdapter = hotelAdapter;
            _placeAdapter = placeAdapter;
            _cardAdapter = cardAdapter;
           // _cubaDataContext = cubaDataContext;
           // _sessionObjects = sessionObjects;
        }
      


        // GET: api/Hotels/Card/5
        [HttpGet("Card/{id}")]
        public IActionResult GetHotelCard([FromRoute] string id)
        {
            if (id != "0") { 

            CardObj card = getCardFromHotel(Convert.ToInt32(id));
                return Ok(card);
            }

            return Ok("");

            
        }

        private CardObj getCardFromHotel(int hotelId)
        {

            return _hotelAdapter.getCardFromHotel(hotelId);
        }

        // GET: api/Hotels/StyleCards/43
        [HttpGet("StyleCards/{templateTypeId}")]
        public IEnumerable<CodeWorkVoyWebService.Models.WebData.Card> GetHotelStyleCards([FromRoute] int templateTypeId)
        {
             List<CodeWorkVoyWebService.Models.WebData.Card> styleCards = new List<CodeWorkVoyWebService.Models.WebData.Card>();
            styleCards = _cardAdapter.GetStyleCards(templateTypeId);

            return styleCards;

        }

        // GET: api/Hotels/Cards
        [HttpGet("Cards")]
        public IEnumerable<CardObj> GetHotelCards()
        {
            List<HotelObj> hotels = _hotelAdapter.getAllHotels();
            List<CardObj> cards = new List<CardObj>();
            foreach (HotelObj hotel in hotels)
            {
                cards.Add(getCardFromHotel(hotel.HotelID));
            }

            return cards;

        }


        // GET: api/Hotels/Details/5
        [HttpGet("Details/{id}")]
        public  IActionResult GetHotels([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            /*var hotels =
       from hotel in _cubaDataContext.Hotels
       where hotel.Place == id
       select new
       {
           Hotel = hotel.Hotel
         
       };

            foreach (var hotel in hotels)
            {
                String name = hotel.Hotel;
            }*/

            //var hotels =  _cubaDataContext.Hotels.Where(h => h.Place==id);
            var hotels = _hotelAdapter.getHotels(Convert.ToInt32(id));
            if (hotels == null)
            {
                return NotFound();
            }

            return Ok(hotels);
        }
        
    }
}