﻿using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.WebData
{
    public partial class ItinTemplateTimeIdlookup
    {
        public string TimeRangeName { get; set; }
        public int TimeId { get; set; }
        public DateTime? Date { get; set; }
    }
}
