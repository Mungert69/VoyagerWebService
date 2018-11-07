using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.CubaData
{
    public partial class TransferLogic
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double? DrivingTime { get; set; }
        public int? Distance { get; set; }
        public bool? PossibleAsTransfer { get; set; }
        public bool? PossibleAsCarHire { get; set; }
        public bool? CombinationRequired { get; set; }
        public string TransferNote { get; set; }
        public string TransferItem1 { get; set; }
        public bool? Item1Included { get; set; }
        public string CarOrder1 { get; set; }
        public string TransferItem2 { get; set; }
        public bool? Item2Included { get; set; }
        public string CarOrder2 { get; set; }
        public string TransferItem3 { get; set; }
        public bool? Item3Included { get; set; }
        public string CarOrder3 { get; set; }
        public string TransferItem4 { get; set; }
        public bool? Item4Included { get; set; }
        public string CarOrder4 { get; set; }
        public string CarHireCopy1 { get; set; }
        public string CarHireCopy2 { get; set; }
        public string CarHireCopy3 { get; set; }
        public string CarOrder5 { get; set; }
        public string CarOrder6 { get; set; }
        public string CarOrder7 { get; set; }
        public bool? OriginCarRentalOffice { get; set; }
        public bool? DestinationCarRentalOffice { get; set; }
        public decimal? TransferPrice { get; set; }
        public decimal? FlyDrivePrice { get; set; }
        public string CollectDrop { get; set; }
        public string CarOrder8 { get; set; }
        public bool? NotPossible { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? ItemPrice1 { get; set; }
        public decimal? ItemPrice2 { get; set; }
        public decimal? ItemPrice3 { get; set; }
        public decimal? ItemPrice4 { get; set; }
        public int? FlightId1 { get; set; }
        public int? FlightId2 { get; set; }
        public int? FlightId3 { get; set; }
        public int? FlightId4 { get; set; }
        public int? GroundId1 { get; set; }
        public int? GroundId2 { get; set; }
        public int? GroundId3 { get; set; }
        public int? GroundId4 { get; set; }
    }
}
