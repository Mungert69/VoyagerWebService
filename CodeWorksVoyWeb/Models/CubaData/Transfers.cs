using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.CubaData
{
    public partial class Transfers
    {
        public int TransferId { get; set; }
        public int? SupplierId { get; set; }
        public string Origination { get; set; }
        public string PickUp { get; set; }
        public string Dest { get; set; }
        public string DropOff { get; set; }
        public string UseIt { get; set; }
        public int? Pax { get; set; }
        public int? PickUpTypeId { get; set; }
        public int? OriginationId { get; set; }
        public int? DropOffTypeId { get; set; }
        public int? DestinationId { get; set; }
        public int? PickUpId { get; set; }
        public int? DropId { get; set; }
    }
}
