using System;
using System.Collections.Generic;

namespace CodeWorksVoyWebService.Models.UserData
{
    public partial class UserTransfers
    {
        public int PKey { get; set; }
        public int ItinId { get; set; }
        public int TransferId { get; set; }
        public bool WithCar { get; set; }
    }
}
