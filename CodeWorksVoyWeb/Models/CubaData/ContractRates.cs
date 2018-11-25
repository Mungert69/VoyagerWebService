using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.CubaData
{
    public partial class ContractRates
    {
        public int ContractRateId { get; set; }
        public int? HotelId { get; set; }
        public DateTime? StartDate { get; set; }
        public decimal? NetRate { get; set; }
        public decimal? SingleRate { get; set; }
        public string ContractBoardBasis { get; set; }
        public string ContractRoomType { get; set; }
        public double? AdultShareDiscount { get; set; }
        public string Estimated { get; set; }
        public string Web { get; set; }
        public int? SupplierId { get; set; }
        public int? RoomOccupancy { get; set; }
        public int? CurrencyId { get; set; }
        public decimal? CnetRate { get; set; }
        public decimal? CsingleRate { get; set; }
    }
}
