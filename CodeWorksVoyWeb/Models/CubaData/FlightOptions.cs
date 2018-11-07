using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.CubaData
{
    public partial class FlightOptions
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string Airport { get; set; }
        public string Day { get; set; }
    }
}
