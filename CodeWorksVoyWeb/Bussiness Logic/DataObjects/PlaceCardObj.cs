using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWorkVoyWebService.Bussiness_Logic.DataObjects;

namespace CodeWorksVoyWebService.Bussiness_Logic.DataObjects
{
    
    public class PlaceCardObj : CardObj
    {

        private PlaceState placeState;



        public PlaceCardObj()
        {
            placeState = new PlaceState();
        }

        public PlaceState PlaceState { get => placeState; set => placeState = value; }


    }
}
