using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.CubaData
{
    public partial class AccommodationAllInclusiveFacilities
    {
        public int Aikey { get; set; }
        public int AccommodationId { get; set; }
        public string AccommodationName { get; set; }
        public bool? BuffetMeals { get; set; }
        public bool? AlaCarte { get; set; }
        public bool? Snacks { get; set; }
        public bool? LocalDrinks { get; set; }
        public bool? InternationalDrinks { get; set; }
        public bool? DaytimeActivities { get; set; }
        public bool? AieveningEntertainment { get; set; }
        public bool? NonMotorisedWatersports { get; set; }
        public bool? MotorisedWatersports { get; set; }
        public bool? AiscubaDiving { get; set; }
        public bool? OtherFeatures { get; set; }
        public string BuffetMealsNote { get; set; }
        public string AlaCarteNote { get; set; }
        public string SnacksNote { get; set; }
        public string LocalDrinksNote { get; set; }
        public string InternationalDrinksNote { get; set; }
        public string DaytimeActivitiesNote { get; set; }
        public string AieveningEntertainmentNote { get; set; }
        public string NonMotorisedWatersportsNote { get; set; }
        public string AiscubaDivingNote { get; set; }
        public string MotorisedWatersportsNote { get; set; }
        public string OtherFeaturesNote { get; set; }
    }
}
