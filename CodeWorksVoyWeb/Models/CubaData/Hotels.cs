using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.CubaData
{
    public partial class Hotels
    {
        public int Pkey { get; set; }
        public int HotelId { get; set; }
        public int? SupplierId { get; set; }
        public string Hotel { get; set; }
        public string Place { get; set; }
        public short? MinChildAge { get; set; }
        public string UseIt { get; set; }
        public string EnforceMaxShare { get; set; }
        public int? Nights { get; set; }
        public string Ref { get; set; }
        public string OpDays { get; set; }
        public string Web { get; set; }
        public string Star { get; set; }
        public int? PlaceId { get; set; }
        public string BoardBasis { get; set; }
        public string HotelAddress1 { get; set; }
        public string HotelAddress2 { get; set; }
        public string HotelAddress3 { get; set; }
        public string HotelAddress4 { get; set; }
        public string HotelPostCode { get; set; }
        public string HotelMapReference { get; set; }
        public string HotelTelephoneNumber { get; set; }
        public string HotelEmail { get; set; }
        public bool? Allocation { get; set; }
        public bool? IsVilla { get; set; }
        public int? MaxShare { get; set; }
        public bool? UseMap { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int? ZoomLevel { get; set; }
        public string Icon { get; set; }
    }
}
