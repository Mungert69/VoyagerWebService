using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.CubaData
{
    public partial class Prices
    {
        public int SupplierId { get; set; }
        public decimal Price { get; set; }
        public int? AirportId { get; set; }
    }
}
