using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.WebData
{
    public partial class ItinTemplateTimeId
    {
        public int PKey { get; set; }
        public int UserItinId { get; set; }
        public int? TimeId { get; set; }
        public decimal? Price { get; set; }
    }
}
