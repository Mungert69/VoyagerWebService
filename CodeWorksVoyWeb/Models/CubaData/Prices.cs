﻿using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.CubaData
{
    public partial class Prices
    {
        public int SupplierId { get; set; }
        public decimal Price { get; set; }
        public int? AirportId { get; set; }
    }
}
