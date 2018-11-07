using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.VoyagerReserve
{
    public partial class CustomersEmail
    {
        public int Cid { get; set; }
        public string CustomerId { get; set; }
        public string CustomerTitle { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string PartnersName { get; set; }
        public string OrganizationName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerAddress2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string Telephonenumberhome { get; set; }
        public string Telephonenumberwork { get; set; }
        public string MobileTelephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string MaritalStatus { get; set; }
        public string FamilyName { get; set; }
        public string ClientNotes { get; set; }
        public string EnqNotes { get; set; }
        public bool? Smoking { get; set; }
        public bool? Single { get; set; }
        public DateTime? LastBusiness { get; set; }
        public DateTime? LastUpdate { get; set; }
        public DateTime? FirstEnquiry { get; set; }
        public string WeekNo { get; set; }
        public string MailStatus { get; set; }
        public int? PreferredPhone { get; set; }
        public int? Adults { get; set; }
        public int? Children { get; set; }
        public int? Infants { get; set; }
        public string Notes { get; set; }
        public string FamiliarName { get; set; }
        public bool Subscribed { get; set; }
        public string Type { get; set; }
    }
}
