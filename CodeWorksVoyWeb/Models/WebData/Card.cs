using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.WebData
{
    public partial class Card
    {
        public int PKey { get; set; }
        public int? CardTemplateType { get; set; }
        public int? CardElementDetailLevel { get; set; }
        public int? CardElementCardsPerRow { get; set; }
        public bool Card1ElementShare { get; set; }
        public string Card1ElementShareStyle { get; set; }
        public bool? Card1ElementBookmark { get; set; }
        public string Card1ElementBookmarkStyle { get; set; }
        public int? Card1ElementImageTemplate { get; set; }
        public int? Card1ElementImageDisplay { get; set; }
        public string Card1ElementImageMax { get; set; }
        public int? Card1ElementTitle { get; set; }
        public string Card1ElementTitleStyle { get; set; }
        public int? Card1ElementPlaceFeatures { get; set; }
        public string Card1ElementPlaceFeaturesStyle { get; set; }
        public int? Card1ElementHotelFeatures { get; set; }
        public string Card1ElementHotelFeaturesStyle { get; set; }
        public int? Card1ElementGroup { get; set; }
        public string Card1ElementGroupStyle { get; set; }
        public int? Card1ElementCountry { get; set; }
        public string Card1ElementCountryStyle { get; set; }
        public int? Card1ElementPlace { get; set; }
        public string Card1ElementPlaceStyle { get; set; }
        public int? Card1ElementId { get; set; }
        public string Card1ElementIdstyle { get; set; }
        public int? Card1ElementDescription { get; set; }
        public string Card1ElementDescriptionStyle { get; set; }
        public string Card1ElementDescriptionMaxCharacters { get; set; }
        public int? Card1ElementCategories { get; set; }
        public string Card1ElementCategoriesStyle { get; set; }
        public int? Card1ElementTags { get; set; }
        public string Card1ElementTagsStyle { get; set; }
        public int? Card1ElementTripNightCount { get; set; }
        public string Card1ElementTripNightCountStyle { get; set; }
        public int? Card1ElementTripPlaceCount { get; set; }
        public string Card1ElementTripPlaceCountStyle { get; set; }
        public int? Card1ElementTripPrice { get; set; }
        public string Card1ElementTripPriceStyle { get; set; }
        public int? Card1ElementTripPlacesListTemplate { get; set; }
        public string Card1ElementTripPlacesListStyle { get; set; }
        public int? Card1ElementTripHotelsListTemplate { get; set; }
        public string Card1ElementTripHotelsListStyle { get; set; }
        public int? Card1ElementTripFlightTemplate { get; set; }
        public string Card1ElementTripFlightTemplateStyle { get; set; }
        public int? Card1ElementTripFlightDeparture { get; set; }
        public string Card1ElementTripFlightDepartureStyle { get; set; }
        public int? Card1ElementTripFlightReturn { get; set; }
        public string Card1ElementTripFlightReturnStyle { get; set; }
        public int? Card1ElementTripFlightAirline { get; set; }
        public string Card1ElementTripFlightAirlineStyle { get; set; }
        public int? Card1ElementTripFlightAirport { get; set; }
        public string Card1ElementTripFlightAirportStyle { get; set; }
        public int? Card1ElementViewDetails { get; set; }
        public string Card1ElementViewDetailsStyle { get; set; }
    }
}
