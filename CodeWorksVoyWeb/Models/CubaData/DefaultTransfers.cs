using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.CubaData
{
    public partial class DefaultTransfers
    {
        public int TransferId { get; set; }
        public string Origination { get; set; }
        public string Destination { get; set; }
        public int? Type { get; set; }
        public decimal? Price { get; set; }
    }
}
