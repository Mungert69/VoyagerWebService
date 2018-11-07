using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.WebData
{
    public partial class PictureGroups
    {
        public string PictureGroupType { get; set; }
        public string FileName { get; set; }
        public int? OrderBy { get; set; }
        public bool? UseIt { get; set; }
    }
}
