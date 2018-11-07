using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;

/// <summary>
/// Summary description for PlaceState
/// </summary>
public class PlaceState   {

    private int placeID;

    public int PlaceID
    {
        get { return placeID; }
        set { placeID = value; }
    }


    private bool isSelected = false;

    public bool IsSelected
    {
        get { return isSelected; }
        set { isSelected = value; }
    }
    private bool isHop = false;

    public bool IsHop
    {
        get { return isHop; }
        set { isHop = value; }
    }
    private bool isGreyed = false;

    public bool IsGreyed
    {
        get { return isGreyed; }
        set { isGreyed = value; }
    }

	
}
