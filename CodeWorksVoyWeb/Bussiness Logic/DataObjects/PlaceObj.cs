using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;

/// <summary>
/// Summary description for PlaceObj
/// </summary>
public class PlaceObj
{

    private int mapOrder;

    public int MapOrder
    {
        get { return mapOrder; }
        set { mapOrder = value; }
    }

    private string shortPlaceName;

    public string ShortPlaceName
    {
        get { return shortPlaceName; }
        set { shortPlaceName = value; }
    }

    private string placeName;

    public string PlaceName
    {
        get { return placeName; }
        set { placeName = value; }
    }
    private int placeID;

    public int PlaceID
    {
        get { return placeID; }
        set { placeID = value; }
    }

    public int CountryId { get => countryId; set => countryId = value; }

    private int countryId;
}
