using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdminUserItinObj
/// </summary>
public class SEOItinObj
{

    public string SEOTitle;
    public string SEOText;
    public string TourDepartureDates;
    public string TourFlightInfo;
    public string TourNotes;
    public string TourPrice;
    public string TourStageMealBasis;
    public string TourStageAccommodation;
    public string TourStageNote;
    public int StageID;
  
  
    public object TripTag { get; set; }
    public object Airline { get; set; }

    public SEOItinObj()
    {
        SEOTitle = "";
        SEOText = "";
        TourDepartureDates = "";
        TourFlightInfo = "";
        TourNotes = "";
        TourPrice = "";
        TourStageMealBasis="";
        TourStageAccommodation="";
        TourStageNote="";
        StageID = 0;
}
}