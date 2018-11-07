using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.WebData
{
    public partial class MenuLevel1
    {
        public int Id1 { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string PathLevel { get; set; }
        public bool? Visible { get; set; }
        public int? Priority { get; set; }
        public bool? CategoryItem { get; set; }
        public string Country { get; set; }
    }
}
