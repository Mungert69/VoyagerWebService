using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.CubaData
{
    public partial class Aptrates
    {
        public int Pkey { get; set; }
        public int SupplierId { get; set; }
        public string Airline { get; set; }
        public float? Aptrate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string TaxCode { get; set; }
        public int? AptrateId { get; set; }
    }
}
