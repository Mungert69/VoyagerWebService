using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.VoyagerReserve
{
    public partial class BookValueInfo
    {
        public int BookingId { get; set; }
        public int? EnquiryId { get; set; }
        public string CustomerId { get; set; }
        public string Product { get; set; }
        public DateTime? BookDate { get; set; }
        public DateTime? TravelDate { get; set; }
        public float? FlightPriceTotal { get; set; }
        public float? FlightCostTotal { get; set; }
        public float? AccommPriceTotal { get; set; }
        public float? AccommCostTotal { get; set; }
        public float? XferPriceTotal { get; set; }
        public float? XferCostTotal { get; set; }
        public float? RepPriceTotal { get; set; }
        public float? RepCostTotal { get; set; }
        public float? PscpriceTotal { get; set; }
        public float? PsccostTotal { get; set; }
        public float? AptpriceTotal { get; set; }
        public float? AptcostTotal { get; set; }
        public float? AdditsPriceTotal { get; set; }
        public float? AdditsCostTotal { get; set; }
        public float? TotalTravelPrice { get; set; }
        public float? TotalTravelCost { get; set; }
        public float? TouristCardsPrice { get; set; }
        public float? TouristCardsCost { get; set; }
        public float? TotalTransaction { get; set; }
        public float? TotalPaid { get; set; }
        public float? TotalCccharges { get; set; }
        public float? TotalOutstanding { get; set; }
        public float? DueToTcoast { get; set; }
        public float? BaseNetCosts { get; set; }
        public float? VoyCharges { get; set; }
        public string TcoastInvoice { get; set; }
        public string ConfirmClient { get; set; }
        public string TicketsReceived { get; set; }
        public string TicketsSent { get; set; }
        public DateTime? BalanceDueDate { get; set; }
        public short? NumAds { get; set; }
        public short? NumCh { get; set; }
        public short? NumInf { get; set; }
        public string BookStatus { get; set; }
        public float? InsurancePrice { get; set; }
        public float? InsuranceCost { get; set; }
    }
}
