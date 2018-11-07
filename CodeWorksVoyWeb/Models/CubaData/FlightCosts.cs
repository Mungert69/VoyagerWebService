using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.CubaData
{
    public partial class FlightCosts
    {
        public int Pkey { get; set; }
        public int FlightId { get; set; }
        public int? SupplierId { get; set; }
        public DateTime? Fdate { get; set; }
        public string Fnumber { get; set; }
        public string Description { get; set; }
        public decimal? Cost { get; set; }
        public float? ChildDiscount { get; set; }
        public float? InfantCost { get; set; }
        public string UseIt { get; set; }
        public string Web { get; set; }
        public int? AptrateId { get; set; }
    }
}
