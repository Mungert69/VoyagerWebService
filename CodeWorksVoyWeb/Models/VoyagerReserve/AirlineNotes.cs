﻿using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.VoyagerReserve
{
    public partial class AirlineNotes
    {
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string NoteText { get; set; }
    }
}
