using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.VoyagerReserve
{
    public partial class System
    {
        public int EnquiryId { get; set; }
        public int? BookingId { get; set; }
        public int? CustomerId { get; set; }
        public int? AgentId { get; set; }
        public int? ReceiptNumber { get; set; }
        public float? MarkUp { get; set; }
        public int? Aptrate { get; set; }
        public int? NetTouristCardsCost { get; set; }
        public int? BrochureId { get; set; }
        public int? AdultId { get; set; }
        public int? ChildId { get; set; }
        public float? RepCharge { get; set; }
        public float? ChildFlightDiscount { get; set; }
        public decimal? InfantPrice { get; set; }
        public string Two2Room { get; set; }
        public float? Vatrate { get; set; }
        public int? Xact { get; set; }
        public float? Tccadd { get; set; }
        public float? VoyPc { get; set; }
        public int? NewAddId { get; set; }
        public int? NewNoteId { get; set; }
        public int? DoPscfromId { get; set; }
        public int? DoNewXferFromId { get; set; }
        public int? DoAptsellfromId { get; set; }
        public float? FlightMarkUp { get; set; }
        public int? NetTouristCardsCostZero { get; set; }
        public int? TccaddZero { get; set; }
    }
}
