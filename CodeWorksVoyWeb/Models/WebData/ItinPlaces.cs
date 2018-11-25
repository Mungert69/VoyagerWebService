using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.WebData
{
    public partial class ItinPlaces
    {
        public int PKey { get; set; }
        public string StageTitle { get; set; }
        public bool? Visable { get; set; }
        public int? ItinId { get; set; }
        public string Place { get; set; }
        public int? PlaceId { get; set; }
        public string Hotel { get; set; }
        public int? Nights { get; set; }
        public int? HotelId { get; set; }
        public string Seotitle { get; set; }
        public string Seotext { get; set; }
        public int? StageOrder { get; set; }
        public string Element1 { get; set; }
        public string Element1Width { get; set; }
        public string Element1Colour { get; set; }
        public string Element2 { get; set; }
        public string Element2Width { get; set; }
        public string Element2Colour { get; set; }
        public string Element3 { get; set; }
        public string Element3Width { get; set; }
        public string Element3Colour { get; set; }
        public string Element4 { get; set; }
        public string Element4Width { get; set; }
        public string Element4Colour { get; set; }
        public string Element5 { get; set; }
        public string Element5Width { get; set; }
        public string Element5Colour { get; set; }
        public string Element6 { get; set; }
        public string Element6Width { get; set; }
        public string Element6Colour { get; set; }
        public string TourStageNote { get; set; }
        public string TourStageAccommodation { get; set; }
        public string TourStageMealBasis { get; set; }
        public string Country { get; set; }
    }
}
