using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.CubaData
{
    public partial class RoomUpgrades
    {
        public int Pkey { get; set; }
        public int RoomUpgradeId { get; set; }
        public int? HotelId { get; set; }
        public string RoomUpgradeCode { get; set; }
        public string HotelName { get; set; }
        public string RoomUpgradeType { get; set; }
        public decimal? RoomUpgradeRate { get; set; }
        public decimal? RoomUpgardeValue { get; set; }
        public string RoomUpgradeDesc { get; set; }
    }
}
