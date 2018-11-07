using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.WebData
{
    public partial class SettingsWebLinks
    {
        public int PKey { get; set; }
        public string WebLinks { get; set; }
        public string WebLinksData { get; set; }
        public int? CountriesCode { get; set; }
    }
}
