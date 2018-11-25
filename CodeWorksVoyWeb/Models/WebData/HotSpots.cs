using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.WebData
{
    public partial class HotSpots
    {
        public int PKey { get; set; }
        public int ImageId { get; set; }
        public int TopC { get; set; }
        public int BottomC { get; set; }
        public int LeftC { get; set; }
        public int RightC { get; set; }
        public string HotSpotName { get; set; }
    }
}
