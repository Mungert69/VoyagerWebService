using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.WebData
{
    public partial class TripStagePictures
    {
        public int PictureId { get; set; }
        public int? OrderId { get; set; }
        public string PicFilename { get; set; }
        public int? StageId { get; set; }
        public int? ElementId { get; set; }
        public string Format { get; set; }
        public string Web { get; set; }
    }
}
