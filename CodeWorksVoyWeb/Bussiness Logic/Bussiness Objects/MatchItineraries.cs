using System;
using System.Collections.Generic;
//using ItinDataTableAdapters;

/// <summary>
/// Summary description f|| MatchItinerary
/// </summary>
public class MatchItinerary
{

    private List<string> resorts;
    private List<ItinPlaces> itinMatches = new List<ItinPlaces>();
    private List<ItinPlaces> filteredItinPlaces;

    public List<ItinPlaces> ItinMatches
    {
        get { return itinMatches; }
        set { itinMatches = value; }
    }




    public List<string> Resorts
    {
        get { return resorts; }
        set { resorts = value; }
    }

    private List<ItinPlaces> itineraryPlaces;

    public List<ItinPlaces> ItineraryPlaces
    {
        get { return itineraryPlaces; }
        set { itineraryPlaces = value; }
    }

    public MatchItinerary(){
 /*
        ItinerariesTableAdapter adapt = new ItinerariesTableAdapter();
        ItinData.ItinerariesDataTable table = adapt.GetAllPlaces();
        itineraryPlaces = new List<ItinPlaces>();

        // Populate Itineray Places object to hold all itinerary places names.
        foreach (ItinData.ItinerariesRow row in table)
        {
            ItinPlaces newItin = new ItinPlaces();
            newItin.ItinID = row.ItineraryID;
            newItin.IsXfer = row.PossibleByTransfers;
            newItin.IsCar = row.PossibleByCar;
            newItin.IsComb = row.PossibleByCombination;

                newItin.PlaceName1 = row.PlaceName1;
   newItin.PlaceName2 = row.PlaceName2; 
   newItin.PlaceName3 = row.PlaceName3;
        newItin.PlaceName4 = row.PlaceName4; 
    newItin.PlaceName5 = row.PlaceName5;
newItin.PlaceName6 = row.PlaceName6; 
            itineraryPlaces.Add(newItin);
        }

    }

    public string getItinListString(int itinID)
    {
        string str = "";
        foreach (ItinPlaces itinPlace in ItineraryPlaces)
        {
            if (itinPlace.ItinID == itinID)
            {
                if (!itinPlace.PlaceName1.Equals("")) str += itinPlace.PlaceName1 + "  ";
                if (!itinPlace.PlaceName2.Equals("")) str += itinPlace.PlaceName2 + "  ";
                if (!itinPlace.PlaceName3.Equals("")) str += itinPlace.PlaceName3 + "  ";
                if (!itinPlace.PlaceName4.Equals("")) str += itinPlace.PlaceName4 + "  ";
                if (!itinPlace.PlaceName5.Equals("")) str += itinPlace.PlaceName5 + "  ";
                if (!itinPlace.PlaceName6.Equals("")) str += itinPlace.PlaceName6;
                return str;
            }
        }
        return "No Matching Itineraries";
  * */
    }

    public List<string> getItinList(int itinID)
    {
        List<string> str = new List<string>();
        foreach (ItinPlaces itinPlace in ItineraryPlaces)
        {
            if (itinPlace.ItinID == itinID)
            {
                if (!itinPlace.PlaceName1.Equals("")) str.Add(itinPlace.PlaceName1);
                if (!itinPlace.PlaceName2.Equals("")) str.Add(itinPlace.PlaceName2);
                if (!itinPlace.PlaceName3.Equals("")) str.Add(itinPlace.PlaceName3);
                if (!itinPlace.PlaceName4.Equals("")) str.Add(itinPlace.PlaceName4);
                if (!itinPlace.PlaceName5.Equals("")) str.Add(itinPlace.PlaceName5);
                if (!itinPlace.PlaceName6.Equals("")) str.Add(itinPlace.PlaceName6);
                return str;
            }
        }
        return null;
    }


    public bool isXfer;
    public void getItin(bool val)
    {
        this.isXfer=val;
        // To Do filter on isXfer.
        filteredItinPlaces = new List<ItinPlaces>();
        foreach (ItinPlaces itinPlace in itineraryPlaces) {
            /*if (itinPlace.IsComb)
            {
                filteredItinPlaces.Add(itinPlace);
                continue;
            }*/
            if (itinPlace.IsCar && !isXfer) { filteredItinPlaces.Add(itinPlace);
            continue;
            }
            if (itinPlace.IsXfer && isXfer) { filteredItinPlaces.Add(itinPlace); }
        }

        itinMatches = new List<ItinPlaces>();
        List<string> oldResorts = new List<string>();
        oldResorts.AddRange(resorts);

        if (match())
        {
            return;
            // got exact match first time.
        }

        // Try matching with one less place.
        else
        {
            for (int x = 0; x < oldResorts.Count; x++)
            {
                resorts = new List<string>();
                for (int y = 0; y < oldResorts.Count; y++)
                {
                    if (y != x)
                    {
                        resorts.Add(oldResorts[y]);
                    }
                }
                match();
            }
        }
    }



    private bool match()
    {
        bool matched = false;
        int numResorts = resorts.Count;
        for (int i = 0; i < filteredItinPlaces.Count; i++)
        {
            int matchedCount = 0;
            for (int x = 0; x < resorts.Count; x++)
            {
                if (filteredItinPlaces[i].testMatch(resorts[x]))
                {
                    matchedCount++;
                }
            }
            if (matchedCount == numResorts)
            {
                itinMatches.Add(filteredItinPlaces[i]);
                matched = true;
            }

        }
        return matched;
    }


}