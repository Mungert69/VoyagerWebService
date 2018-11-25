using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.CubaData
{
    public partial class RoomUpgradeRates
    {
        public int Pkey { get; set; }
        public int? HotelId { get; set; }
        public DateTime? StartDate { get; set; }
        public decimal? NetRate { get; set; }
        public string RoomType { get; set; }
        public int? CurrencyId { get; set; }
        public decimal? CnetRate { get; set; }
    }
}
