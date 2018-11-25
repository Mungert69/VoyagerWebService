using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.WebData
{
    public partial class SettingsTagsStore
    {
        public int PKey { get; set; }
        public int? TripId { get; set; }
        public string Tag { get; set; }
    }
}
