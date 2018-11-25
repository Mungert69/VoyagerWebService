using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.CubaData
{
    public partial class XferCosts
    {
        public int Id { get; set; }
        public int? TransferId { get; set; }
        public DateTime? StartDate { get; set; }
        public decimal? Net { get; set; }
        public string Days { get; set; }
        public int? CurrencyId { get; set; }
        public decimal? Cnet { get; set; }
    }
}
