using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.VoyagerReserve
{
    public partial class Suppliers
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierType { get; set; }
        public string Currency { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string ContactName { get; set; }
        public string Country { get; set; }
        public float? Discount { get; set; }
        public string PaymentArrangements { get; set; }
        public bool? UseIt { get; set; }
        public string Locate { get; set; }
        public short? CountryFlag { get; set; }
        public int? DefaultPrice { get; set; }
    }
}
