using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.UserData
{
    public partial class ItinPlaces
    {
        public int PKey { get; set; }
        public int ItinId { get; set; }
        public string Place { get; set; }
        public int PlaceId { get; set; }
        public string Hotel { get; set; }
        public int Nights { get; set; }
        public int HotelId { get; set; }
    }
}
