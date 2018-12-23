using CodeWorksVoyWebService.Bussiness_Logic.Bussiness_Objects;
using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;
using CodeWorksVoyWebService.Bussiness_Logic.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeWorksVoyWebService.Services
{
    public class CacheServices : ICacheServices
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
        private IMemoryCache _cache;
        //private string userHashId="xxxx";
        private bool CreateTestJsonFiles = false;
        private List<TripCardObj> cards;


        public CacheServices(IMemoryCache cache, ISessionObjectsService sessionObjectsService, IItineraryService itineraryService, IHotelAdapter hotelAdapter, IPlaceAdapter placeAdapter, ICardAdapter cardAdapter, IUserItinAdapter userItinAdapter, ITransferAdapter transferAdapter, IMapService mapService, IPriceService priceService, IConfiguration configuration)
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
            _cache = cache;
            cards = new List<TripCardObj>();
        }

        public List<TripCardObj> waitCardsReady(){
            List<TripCardObj> cards=null;
            try {
                cards=FactoryUtils.CheckCacheNoWrite<List<TripCardObj>>(ref _cache, cards, "TripCards");
            }
            catch (Exception e) {
                string stopHere = "";
            }
            return cards;
        }

        public void  initCards() {

            List<CodeWorksVoyWebService.Models.WebData.AdminItinTemplates> adminTemplates = _userItinAdapter.getAllAdminTemplateItins();

            TripCardObj card;
            foreach (CodeWorksVoyWebService.Models.WebData.AdminItinTemplates adminTemplate in adminTemplates)
            {
                card = new TripCardObj();
                try
                {

                    card.setCardFromItinerary(Convert.ToInt32(adminTemplate.AdminItinId), (int)adminTemplate.TemplateTypeId, _userItinAdapter, CreateTestJsonFiles);
                    card.getDatePriceObjs(_priceService);
                    card.setPRSeletions(_userItinAdapter, _cardAdapter);
                    cards.Add(card);
                }
                catch (Exception e)
                {
                    card.Id = 0;
                    card.Title = "Error retreiving Itinerary with id : " + adminTemplate.AdminItinId;
                }

            }
            
            if (CreateTestJsonFiles) JsonUtils.writeJsonObjectToFile("allCards.json", cards);
            FactoryUtils.WriteCache<List<TripCardObj>>(ref _cache, cards, "TripCards");

        }

    }
}
