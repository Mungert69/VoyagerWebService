using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.WebData
{
    public partial class ItinTemplateTimeIdescorted
    {
        public int Id { get; set; }
        public string ItinName { get; set; }
        public string TemplateName { get; set; }
        public int? TimeId { get; set; }
        public string TimeName { get; set; }
        public decimal? Price { get; set; }
        public string Country { get; set; }
    }
}
