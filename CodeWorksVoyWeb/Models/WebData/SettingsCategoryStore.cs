using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.WebData
{
    public partial class SettingsCategoryStore
    {
        public int PKey { get; set; }
        public int? TripId { get; set; }
        public string Category { get; set; }
    }
}
