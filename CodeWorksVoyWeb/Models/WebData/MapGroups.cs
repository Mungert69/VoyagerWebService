using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.WebData
{
    public partial class MapGroups
    {
        public string MapGroupType { get; set; }
        public string FileName { get; set; }
        public int? OrderBy { get; set; }
        public bool? UseIt { get; set; }
    }
}
