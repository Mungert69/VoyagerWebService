using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;

/// <summary>
/// Summary description for Class1
/// </summary>
public class ItinPlaces
{
    private bool isCar;

    public bool IsCar
    {
        get { return isCar; }
        set { isCar = value; }
    }
    private bool isComb;

    public bool IsComb
    {
        get { return isComb; }
        set { isComb = value; }
    }
    private bool isXfer;

    public bool IsXfer
    {
        get { return isXfer; }
        set { isXfer = value; }
    }

    private int itinID;

    public int ItinID
    {
        get { return itinID; }
        set { itinID = value; }
    }
    private string placeName1;

    public string PlaceName1
    {
        get { return placeName1; }
        set { placeName1 = value; }
    }
    private string placeName2;

    public string PlaceName2
    {
        get { return placeName2; }
        set { placeName2 = value; }
    }
    private string placeName3;

    public string PlaceName3
    {
        get { return placeName3; }
        set { placeName3 = value; }
    }
    private string placeName4;

    public string PlaceName4
    {
        get { return placeName4; }
        set { placeName4 = value; }
    }
    private string placeName5;

    public string PlaceName5
    {
        get { return placeName5; }
        set { placeName5 = value; }
    }
    private string placeName6;

    public string PlaceName6
    {
        get { return placeName6; }
        set { placeName6 = value; }
    }

    public bool testMatch(string str) {

        if (placeName1.Equals(str)) return true;
        if (placeName2.Equals(str)) return true;
        if (placeName3.Equals(str)) return true;
        if (placeName4.Equals(str)) return true;
        if (placeName5.Equals(str)) return true;
        if (placeName6.Equals(str)) return true;
        return false;

    
    }
}
