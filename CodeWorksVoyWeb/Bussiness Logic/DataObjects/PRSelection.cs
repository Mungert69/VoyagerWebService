using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using CodeWorkVoyWebService.Bussiness_Logic.DataObjects;
using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;

/// <summary>
/// Summary description for PHSelection
/// </summary>
public class PRSelection
{
    private bool oldPrice;

    public bool OldPrice
    {
        get { return oldPrice; }
        set { oldPrice = value; }
    }

    private int nights = 0;

    public int Nights
    {
        get { return nights; }
        set { nights = value; }
    }

    private String hotel = "";

    public String Hotel
    {
        get { return hotel; }
        set { hotel = value; }
    }
    private int hotelID = 0;

    public int HotelID
    {
        get { return hotelID; }
        set { hotelID = value; }
    }

    private String place = "";

    public String Place
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

    public PlaceCardObj PlaceCard { get => placeCard; set => placeCard = value; }
    public HotelCardObj HotelCard { get => hotelCard; set => hotelCard = value; }
    //public TransferObj Transfer { get => transfer; set => transfer = value; }

    private PlaceCardObj placeCard;
    private HotelCardObj hotelCard;
    //private TransferObj transfer;

}
