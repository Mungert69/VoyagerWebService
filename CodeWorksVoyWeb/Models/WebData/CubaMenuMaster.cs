using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.WebData
{
    public partial class CubaMenuMaster
    {
        public int Pkey { get; set; }
        public string MenuLevel1 { get; set; }
        public string MenuLevel2 { get; set; }
        public string MenuLevel3 { get; set; }
        public string MenuLevel4 { get; set; }
        public int? Priority { get; set; }
        public bool? UseIt { get; set; }
        public string FileType { get; set; }
        public string MapGroupType { get; set; }
        public string PictureGroupType { get; set; }
        public string Seo1 { get; set; }
        public string Seo2 { get; set; }
        public string IndexPath { get; set; }
        public bool? VisableOnMenu { get; set; }
        public string InfopageName { get; set; }
        public string Country { get; set; }
    }
}
