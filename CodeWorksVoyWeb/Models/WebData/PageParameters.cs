using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.WebData
{
    public partial class PageParameters
    {
        public string PathLevel { get; set; }
        public string MapGroupType { get; set; }
        public string PictureGroupType { get; set; }
        public string Seo1 { get; set; }
        public string Seo2 { get; set; }
        public bool? UseIt { get; set; }
        public string FileType { get; set; }
        public string Path { get; set; }
        public bool? Visible { get; set; }
        public string IndexPath { get; set; }
        public string InfoPageName { get; set; }
        public int? Priority { get; set; }
    }
}
