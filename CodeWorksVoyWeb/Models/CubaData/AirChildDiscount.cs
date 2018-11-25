using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.CubaData
{
    public partial class AirChildDiscount
    {
        public int SupplierId { get; set; }
        public float? ChildDiscount { get; set; }
        public short? PerAdult { get; set; }
    }
}
