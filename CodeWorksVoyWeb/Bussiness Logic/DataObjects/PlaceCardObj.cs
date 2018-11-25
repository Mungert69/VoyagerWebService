using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;

namespace CodeWorksVoyWebService.Bussiness_Logic.DataObjects
{
    
    public class PlaceCardObj : CardObj
    {

        private PlaceState placeState;
        private string placeFeatures;

        public PlaceCardObj()
        {
            placeState = new PlaceState();
        }

        public PlaceState PlaceState { get => placeState; set => placeState = value; }
        public string PlaceFeatures { get => placeFeatures; set => placeFeatures = value; }
    }
}
