using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.WebData
{
    public partial class TemplateTypes
    {
        public int TemplateTypeId { get; set; }
        public string TemplateType { get; set; }
        public string TemplateTypeMenuGroup { get; set; }
        public bool? TemplateTypeMenuGroupFeatured { get; set; }
        public int? DisplayOrder { get; set; }
        public int? Count { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public bool? UseIt { get; set; }
        public string ButtonName { get; set; }
        public string ButtonHeading { get; set; }
        public string ButtonCopy { get; set; }
        public string TripGroupDescriptionShort { get; set; }
        public string TripGroupDescriptionLong { get; set; }
        public string TripGroupTag { get; set; }
        public bool? SuppressPrice { get; set; }
        public bool? DefaultView { get; set; }
        public bool? Templated { get; set; }
        public bool? Tour { get; set; }
        public bool? Sightseeing { get; set; }
        public bool? InfoPage { get; set; }
        public string ButtonPath { get; set; }
        public string TripGroupImageBanner { get; set; }
        public string Country { get; set; }
    }
}
