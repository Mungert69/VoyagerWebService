using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.CubaData
{
    public partial class AirportNodes
    {
        public string AirportName { get; set; }
        public int NodeId { get; set; }
        public bool? In { get; set; }
        public bool? Out { get; set; }
    }
}
