using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.WebData
{
    public partial class SettingsCategoryStore
    {
        public int PKey { get; set; }
        public int? TripId { get; set; }
        public string Category { get; set; }
    }
}
