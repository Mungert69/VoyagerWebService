using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.WebData
{
    public partial class SettingsCategory
    {
        public int PKey { get; set; }
        public string Category { get; set; }
        public string CategoryData { get; set; }
        public bool? CategoryUseIt { get; set; }
    }
}
