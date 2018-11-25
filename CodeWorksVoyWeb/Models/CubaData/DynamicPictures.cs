using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.CubaData
{
    public partial class DynamicPictures
    {
        public int PictureId { get; set; }
        public short? OrderNo { get; set; }
        public string PicFilename { get; set; }
        public string Path { get; set; }
        public string CountryName { get; set; }
        public string ShortTitle { get; set; }
        public string Caption { get; set; }
        public string Web { get; set; }
    }
}
