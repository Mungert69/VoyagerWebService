using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.VoyagerReserve
{
    public partial class Countries
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int? CountryCode { get; set; }
    }
}
