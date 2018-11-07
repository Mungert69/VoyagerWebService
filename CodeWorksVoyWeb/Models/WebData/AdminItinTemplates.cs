using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.WebData
{
    public partial class AdminItinTemplates
    {
        public int PKey { get; set; }
        public int? AdminItinId { get; set; }
        public string AccordianName { get; set; }
        public int? IndexOrder { get; set; }
        public string PageTitle { get; set; }
        public string PageDescription { get; set; }
        public bool? UseIt { get; set; }
        public int? TemplateTypeId { get; set; }
        public int? CountId { get; set; }
        public string Notes { get; set; }
        public string Country { get; set; }
    }
}
