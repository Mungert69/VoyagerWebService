using System;
using System.Collections.Generic;
using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using CodeWorkVoyWebService.Bussiness_Logic.Bussiness_Objects;
using CodeWorkVoyWebService.Bussiness_Logic.DataObjects;


namespace CodeWorkVoyWebService.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    [ApiController]
    public class PlacesController : Controller
    {
        //private readonly CubaDataContext _context;
        private readonly IPlaceAdapter _placeAdapter;
        private readonly ICardAdapter _cardAdapter;

        public PlacesController( ICardAdapter cardAdapter, IPlaceAdapter placeAdapter)
        {
            //_context = context;
            _cardAdapter = cardAdapter;
            _placeAdapter = placeAdapter;
        }

        // GET: api/Places/Card/5
        [HttpGet("Card/{id}")]
        public IActionResult GetPlaceCard([FromRoute] string id)
        {
            if (id != "0") { 
            PlaceCardObj card = getCardFromPlace(Convert.ToInt32(id));

            return Ok(card);
        }
            return Ok("");

        }

        private PlaceCardObj getCardFromPlace (int placeId)
        {


            return _placeAdapter.getCardFromPlace(placeId);
            
        }

        // GET: api/Places/StyleCards/43
        [HttpGet("StyleCards/{templateTypeId}")]
        public IEnumerable<CodeWorkVoyWebService.Models.WebData.Card> GetPlaceStyleCards([FromRoute] int templateTypeId)
        {
            //ToDo country code ie (true,1) below
           
            List<CodeWorkVoyWebService.Models.WebData.Card> styleCards = new List<CodeWorkVoyWebService.Models.WebData.Card>();
            styleCards=_cardAdapter.GetStyleCards(templateTypeId);
               


            return styleCards;



        }

        // GET: api/Places/Cards
        [HttpGet("Cards")]
        public IEnumerable<PlaceCardObj> GetPlaceCards( [FromRoute] int templateTypeId, [FromRoute] int detailLevel)
        {
            //ToDo country code ie (true,1) below
            List<PlaceObj> places = _placeAdapter.getPlaces(true);
            List<PlaceCardObj> cards=new List<PlaceCardObj>();
            foreach (PlaceObj place in places) {
                cards.Add(getCardFromPlace(place.PlaceID));
            }
           

            return cards;



        }

        // GET: api/Places
        [HttpGet]
        public IEnumerable<PlaceObj> GetPlaces()
        {
            return _placeAdapter.getPlaces(true);
        }

    }
}