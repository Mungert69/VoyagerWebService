using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWorksVoyWebService.Bussiness_Logic.DataObjects
{
    public class TripCardObj : CardObj
    {

        private decimal price=0;
            private DateTime travelDate;
        private int itinId;
        private int nights = 0;
        public int ItinId { get => itinId; set => itinId = value; }
        public decimal Price { get => price; set => price = value; }
        public DateTime TravelDate { get => travelDate; set => travelDate = value; }
        public int Nights { get => nights; set => nights = value; }
    }
}
