using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.WebData
{
    public partial class SettingsTags
    {
        public int PKey { get; set; }
        public string Tag { get; set; }
        public string TagData { get; set; }
        public bool? TagUseIt { get; set; }
        public string TagCountry { get; set; }
    }
}
