using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserItinPlaceObj
/// </summary>
public class UserItinPlaceObj
{
    private int itinID;

    public int ItinID
    {
        get { return itinID; }
        set { itinID = value; }
    }
    private string place;

    public string Place
    {
        get { return place; }
        set { place = value; }
    }
    private int placeID;

    public int PlaceID
    {
        get { return placeID; }
        set { placeID = value; }
    }
    private string hotel;

    public string Hotel
    {
        get { return hotel; }
        set { hotel = value; }
    }
    private int nights;

    public int Nights
    {
        get { return nights; }
        set { nights = value; }
    }
    private int hotelID;

    public int HotelID
    {
        get { return hotelID; }
        set { hotelID = value; }
    }
}
