using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.CubaData
{
    public partial class Airports
    {
        public int PKey { get; set; }
        public int? Aid { get; set; }
        public string Airline { get; set; }
        public string DepAirport { get; set; }
        public string AirportCode { get; set; }
    }
}
