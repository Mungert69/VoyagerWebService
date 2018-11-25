using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.WebData
{
    public partial class UserTransfers
    {
        public int PKey { get; set; }
        public int ItinId { get; set; }
        public int TransferId { get; set; }
        public bool WithCar { get; set; }
        public string Test { get; set; }
    }
}
