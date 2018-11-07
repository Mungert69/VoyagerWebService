using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.CubaData
{
    public partial class Psc
    {
        public int Pkey { get; set; }
        public int? SupplierId { get; set; }
        public string Airline { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string DepAirport { get; set; }
        public string DestAirport { get; set; }
        public decimal? Dep { get; set; }
        public decimal? Arr { get; set; }
    }
}
