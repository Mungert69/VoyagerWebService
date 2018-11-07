using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.CubaData
{
    public partial class AirportCodes
    {
        public int Pkey { get; set; }
        public string AirportCode { get; set; }
        public string AirportName { get; set; }
        public string Country { get; set; }
        public float? Psc { get; set; }
    }
}
