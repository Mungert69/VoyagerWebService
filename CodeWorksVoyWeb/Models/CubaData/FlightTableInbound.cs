using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.CubaData
{
    public partial class FlightTableInbound
    {
        public int InboundFlightId { get; set; }
        public int SupplierId { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public string Via1 { get; set; }
        public DateTime? FlightDepartureDate { get; set; }
        public string FlightNumber { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public double? Availability { get; set; }
        public DateTime? AvailabilityLastUpdate { get; set; }
        public short? FlightDay { get; set; }
        public string ViaArrTime { get; set; }
        public string FlightType { get; set; }
        public string UseIt { get; set; }
        public string OverNight { get; set; }
    }
}
