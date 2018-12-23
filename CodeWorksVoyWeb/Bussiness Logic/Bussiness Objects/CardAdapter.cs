using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using System.Collections.Generic;
using System.Text;
using CodeWorksVoyWebService.Models.CubaData;
using CodeWorksVoyWebService.Models.WebData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;

public class CardAdapter : ICardAdapter
{

        //private readonly CubaDataContext _context;
        //private readonly WebDataContext _contextWebData;
        private readonly List<CodeWorksVoyWebService.Models.WebData.Card> cardTable;
        private readonly IPlaceAdapter _placeAdapter;
        private readonly IHotelAdapter _hotelAdapter;


        public CardAdapter(CubaDataContext context, IMemoryCache cache, WebDataContext contextWebData, IPlaceAdapter placeAdapter, IHotelAdapter hotelAdapter)
        {
            cache.TryGetValue<List<CodeWorksVoyWebService.Models.WebData.Card>>("CardTable", out cardTable);
            if (cardTable == null)
            {
                cache.CreateEntry("CardTable");
                cardTable = contextWebData.Card.ToList();
                cache.Set<List<CodeWorksVoyWebService.Models.WebData.Card>>("CardTable", cardTable);
            }
            _placeAdapter = placeAdapter;
            _hotelAdapter = hotelAdapter;

        }

        public List<PRSelection> updateSelectionWithCards(List<PRSelection> pRSelections)
        {

            if (pRSelections == null)
            {
                pRSelections = new List<PRSelection>();              
                return pRSelections;
            }

            List<PRSelection> returnSelections = new List<PRSelection>();
           
            foreach (PRSelection pRSelection in pRSelections)
            {
                PlaceCardObj placeCard = new PlaceCardObj();
                HotelCardObj hotelCard = new HotelCardObj();
                placeCard = _placeAdapter.getCardFromPlace(pRSelection.PlaceID);
                hotelCard = _hotelAdapter.getCardFromHotel(pRSelection.HotelID);
                pRSelection.HotelCard = hotelCard;
                pRSelection.PlaceCard = placeCard;
                returnSelections.Add(pRSelection);

            }
            return returnSelections;

        }


        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        public  static object SetPropValue(object src, string propName, string value)
        {
              src.GetType().GetProperty(propName).SetValue(src, value, null);
            return src;
        }

        public static object SetPropValue(ref CodeWorksVoyWebService.Models.WebData.Card src, string propName, string value)
        {
            src.GetType().GetProperty(propName).SetValue(src, value, null);
            return src;
        }


        private CodeWorksVoyWebService.Models.WebData.Card SetFieldHiddenOnValueZero(CodeWorksVoyWebService.Models.WebData.Card card, string firstField, string secondField) {

            if (Convert.ToInt32(GetPropValue(card, firstField)) == 0)
            {
                SetPropValue(ref card, secondField, "Hidden");
            }
            else {
                // make sure field is not null.
                if (GetPropValue(card, secondField) == null) {
                    SetPropValue(ref card, secondField, "");
                }
            }
           
            return card;
        }

        public List<CodeWorksVoyWebService.Models.WebData.Card> GetStyleCards(int templateTypeId) {
            List<CodeWorksVoyWebService.Models.WebData.Card> styleCards = new List<CodeWorksVoyWebService.Models.WebData.Card>();
            var detailLevels = cardTable.Where(c => c.CardTemplateType == templateTypeId ).Select(s => s.CardElementDetailLevel).ToList();
            foreach (int detailLevel in detailLevels) {
                styleCards.Add(this.GetCardData(templateTypeId, detailLevel));
            }
            return styleCards;
        }
        public CodeWorksVoyWebService.Models.WebData.Card GetCardData(int templateTypeId, int detailLevel)
        {

            CodeWorksVoyWebService.Models.WebData.Card card = cardTable.Where(c => c.CardTemplateType == templateTypeId && c.CardElementDetailLevel == detailLevel).First();


            List<string> firstFields = new List<string>();
            List<string> secondFields = new List<string>();

            this.SetFieldHiddenOnValueZero(card, "Card1ElementShare", "Card1ElementShareStyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementBookmark", "Card1ElementBookmarkStyle");

            this.SetFieldHiddenOnValueZero(card, "Card1ElementTitle","Card1ElementTitleStyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementPlaceFeatures","Card1ElementPlaceFeaturesStyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementHotelFeatures","Card1ElementHotelFeaturesStyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementGroup","Card1ElementGroupStyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementCountry","Card1ElementCountryStyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementPlace","Card1ElementPlaceStyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementId","Card1ElementIdstyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementDescription","Card1ElementDescriptionStyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementCategories","Card1ElementCategoriesStyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementTags","Card1ElementTagsStyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementTripNightCount","Card1ElementTripNightCountStyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementTripPlaceCount","Card1ElementTripPlaceCountStyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementTripPrice","Card1ElementTripPriceStyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementTripPlacesListTemplate","Card1ElementTripPlacesListStyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementTripHotelsListTemplate","Card1ElementTripHotelsListStyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementTripFlightTemplate","Card1ElementTripFlightTemplateStyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementTripFlightDeparture","Card1ElementTripFlightDepartureStyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementTripFlightReturn","Card1ElementTripFlightReturnStyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementTripFlightAirline","Card1ElementTripFlightAirlineStyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementTripFlightAirport","Card1ElementTripFlightAirportStyle");
            this.SetFieldHiddenOnValueZero(card, "Card1ElementViewDetails","Card1ElementViewDetailsStyle");

            return card;

        }


    }

