using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;

public class HotelObj
{
    public HotelObj()
    {
      
    }
    public HotelObj(string hotel, int hotelID) {
        this.hotel = hotel;
        this.hotelID = hotelID;
    }
    private string hotel;

    public string Hotel
    {
        get { return hotel; }
        set { hotel = value; }
    }

    private int hotelID;

    public int HotelID
    {
        get { return hotelID; }
        set { hotelID = value; }
    }
    private int hotelRating;

    public int HotelRating
    {
        get { return hotelRating; }
        set { hotelRating = value; }
    }

  
}
