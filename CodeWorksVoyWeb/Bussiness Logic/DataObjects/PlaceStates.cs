using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using System.Collections.Generic;

/// <summary>
/// Summary description for PlaceStates
/// </summary>
public class PlaceStates
{
    private List<PlaceState> states;

    public List<PlaceState> States { get => states; set => states = value; }

    public PlaceStates(List<PlaceObj>  placeObjs)
	{
     
        States = new List<PlaceState>();
       
        foreach (PlaceObj placeObj in placeObjs) {
            addPlace(placeObj.PlaceID);
        }
    }

    public bool getIsSelected(int placeID){
        int index = findIndex(placeID);
        if (index==-1) return false;
        return States[index].IsSelected;
    }

    public bool getIsHop(int placeID)
    {
        int index = findIndex(placeID);
        if (index == -1) return false;
        return States[index].IsHop;
    }

    public bool getIsGreyed(int placeID)
    {
        int index = findIndex(placeID);
        if (index == -1) return false;
        return States[index].IsGreyed;
    }

    public void setIsSelected(int placeID, bool val) {
        int index = findIndex(placeID);
         States[index].IsSelected=val;

    }
    

    public void setIsHop(int placeID, bool val)
    {
        int index = findIndex(placeID);
        States[index].IsHop = val;
    }

    public void setIsGreyed(int placeID, bool val)
    {
        int index = findIndex(placeID);
        States[index].IsGreyed = val;
    }

    public void addPlace(int placeID) {
        PlaceState tempState = new PlaceState();
        tempState.PlaceID = placeID;
        States.Add(tempState);
    }


    private int findIndex(int val)
    {

        for (int i = 0; i < States.Count; i++)
        {
            if (States[i].PlaceID==val) { return i; }
        }
        return -1;
    }

 
}
