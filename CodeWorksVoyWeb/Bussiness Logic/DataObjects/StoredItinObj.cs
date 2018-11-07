using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWorkVoyWebService.Bussiness_Logic.DataObjects;

namespace CodeWorksVoyWebService.Bussiness_Logic.DataObjects
{
    public class StoredItinObj : ItinObj
    {
        private List<PlaceState> placeStates;

        public List<PlaceState> PlaceStates { get => placeStates; set => placeStates = value; }
    }
}
