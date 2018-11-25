using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.CubaData
{
    public partial class Places
    {
        public int PlaceNameId { get; set; }
        public string PlaceName { get; set; }
        public string ShortPlaceName { get; set; }
        public int? MapOrder { get; set; }
        public string UseIt { get; set; }
        public string Region { get; set; }
        public string WithAccomm { get; set; }
        public string Title1 { get; set; }
        public string Copy1 { get; set; }
        public string Title2 { get; set; }
        public string Copy2 { get; set; }
        public string Title3 { get; set; }
        public string Copy3 { get; set; }
        public string Title4 { get; set; }
        public string Copy4 { get; set; }
        public string Title5 { get; set; }
        public string Copy5 { get; set; }
        public string Title6 { get; set; }
        public string Copy6 { get; set; }
        public string Title7 { get; set; }
        public string Copy7 { get; set; }
        public string Title8 { get; set; }
        public string Copy8 { get; set; }
        public int? GeneralItemId { get; set; }
        public bool? WebUseIt { get; set; }
        public string PlaceBriefDescription { get; set; }
        public bool? CarHireOffice { get; set; }
        public string Xml { get; set; }
        public bool? UseMap { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int? ZoomLevel { get; set; }
        public int? CountryId { get; set; }
    }
}
