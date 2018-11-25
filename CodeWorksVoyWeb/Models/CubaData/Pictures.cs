using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.CubaData
{
    public partial class Pictures
    {
        public int PictureId { get; set; }
        public short? OrderNo { get; set; }
        public string PicFilename { get; set; }
        public int? AccommodationId { get; set; }
        public int? GeneralItemId { get; set; }
        public int? PlaceId { get; set; }
        public string AccommodationName { get; set; }
        public string PlaceName { get; set; }
        public string RegionName { get; set; }
        public string CountryName { get; set; }
        public string ShortTitle { get; set; }
        public string Caption { get; set; }
        public string ProductGroup { get; set; }
        public string Format { get; set; }
        public string Web { get; set; }
        public bool? IsImage { get; set; }
    }
}
