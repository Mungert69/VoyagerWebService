using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.CubaData
{
    public partial class ContractRules
    {
        public int ChildRuleId { get; set; }
        public int? HotelId { get; set; }
        public DateTime? StartDate { get; set; }
        public short? AgeFrom { get; set; }
        public short? AgeTo { get; set; }
        public decimal? Child1ShareDiscount { get; set; }
        public decimal? Child2ShareDiscount { get; set; }
        public decimal? Child3ShareDiscount { get; set; }
        public short? RulesNumAdults { get; set; }
        public short? RulesMaxShare { get; set; }
        public string RoomType { get; set; }
        public int? SupplierId { get; set; }
        public int? MaxChildren { get; set; }
        public bool? OwnRoom { get; set; }
        public bool? ApplyToAllRooms { get; set; }
        public decimal? OwnRoomDiscount1 { get; set; }
        public decimal? OwnRoomDiscount2 { get; set; }
        public decimal? OwnRoomDiscount3 { get; set; }
        public DateTime? DateStamp { get; set; }
        public decimal? Cchild1ShareDiscount { get; set; }
        public decimal? CownRoomDiscount1 { get; set; }
        public int? CurrencyId { get; set; }
    }
}
