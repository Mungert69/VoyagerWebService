using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.UserData
{
    public partial class UserItinerary
    {
        public int UserItinId { get; set; }
        public int UserId { get; set; }
        public string ItinName { get; set; }
        public int OutFlightId { get; set; }
        public int InFlightId { get; set; }
        public int ItinId { get; set; }
        public string Airport { get; set; }
        public DateTime DepartTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public int Nights { get; set; }
        public string Airline { get; set; }
        public int AirlineId { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime? PriceDateStamp { get; set; }
        public string DepAirport { get; set; }
    }
}
