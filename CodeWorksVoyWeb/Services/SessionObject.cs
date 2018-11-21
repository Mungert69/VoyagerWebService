using System;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;


public class SessionObject : ISessionObject
{

    System.Collections.Hashtable Session = new System.Collections.Hashtable();
    private const string PRICEBRAKEDOWN = "pricebrakedown";
    private const string PLACE = "place";
    private const string PLACEID = "placeid";
    private const string HOTEL = "hotel";
    private const string HOTELID = "hotelid";
    private const string PRSELECTIONS = "prselections";
    private const string TICK = "tick";
    private const string TICKCOUNT = "tickcount";
    private const string PULSE = "pulse";
    private const string IMAGE = "image";
    private const string PLACESELECTED = "placeselected";
    private const string NIGHTS = "nights";
    private const string RETURNPAGE = "returnpage";
    private const string USERID = "userid";
    private const string USERITINID = "useritinid";
    private const string TOTALCOST = "totalcost";
    private const string FIREPAGEEVENT = "firepageevent";
    private const string TRANSFERFILTER = "transferfilter";
    private const string PLACESTATES = "placestates";
    private const string WITHCAR = "withcar";
    private const string TRANSFERNODES = "transfernodes";
    private const string SELECTEDDEPAIRPORT = "selecteddepairport";
    private const string SELECTEDARVAIRPORT = "selectedarvairport";
    private const string PAGESTATES = "pagestates";
    private const string SELECTEDLEVEL1ITEM = "selectedlevel1item";
    private const string SELECTEDLEVEL2ITEM = "selectedlevel2item";
    private const string SELECTEDLEVEL3ITEM = "selectedlevel3item";
    private const string SELECTEDLEVEL4ITEM = "selectedlevel4item";
    private const string SELECTEDDATE = "selecteddate";
    private const string SELECTEDINFO = "selectedinfo";
    private const string PICPOS = "picpos";
    private const string PICPOSMAX = "picposmax";
    private const string PREVLEVEL = "prevlevel";
    private const string ITINTEMPLATE = "itintemplate";
    private const string SELECTEDINDEX = "selectedindex";
    private const string SELECTEDDEPAIRPORTCODE = "selecteddepairportcode";
    private const string PREVPLACEID = "prevplaceid";
    private const string ISTEMPLATECHANGED = "istemplatechanged";
    private const string DISPLAYFLIGHTPANEL = "displayflightpanel";
    private const string FLASHSTATE = "flashstate";
    private const string TIMEID = "timeid";
    private const string ISCARHIRE = "iscarhire";
    private const string FLIGHTOBJ = "flightobj";
    private const string CHOOSEMODE = "choosemode";
    private const string FLIGHTSTATES = "flightstates";
    private const string SHOWPRICES = "showprices";
    private const string AGENTID = "agentid";
    private const string VIEWPDFMODE = "viewpdfmode";
    private const string ISADMIN = "isadmin";
    private const string ISAGENT = "isagent";
    private const string ISSUPERUSER = "issuperuser";

  
    private IConfiguration _Configuration;
    public SessionObject(IConfiguration configuration) {
        Configuration = configuration;
    }
    public SessionObject()
    {
      
    }

    public string Country
    {
        get { return Configuration.GetSection("AppConfiguration")["Country"]; }
    }

    public int DefaultPlaceID
    {
        get { return Convert.ToInt16(Configuration.GetSection("AppConfiguration")["DefaultPlaceID"]); }
    }


    public int CountryFlag
    {
        get { return Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CountryFlag"]); }
    }


    public int ArrivalAirportID
    {
        get { return Convert.ToInt16(Configuration.GetSection("AppConfiguration")["ArrivalAirportID"]); }
    }


    public int DepartAirportID
    {
        get { return Convert.ToInt16(Configuration.GetSection("AppConfiguration")["DepartAirportID"]); }
    }

    public bool PickUpCarAtAirport
    {
        get
        {
            return Convert.ToBoolean(Configuration.GetSection("AppConfiguration")["PickCarAtAirport"]);

        }
    }


    public bool IsAdmin
    {
        get
        {
            // Initilise if null.
            if (Session[ISADMIN] == null)
            {
                Session[ISADMIN] = false;
            }

            return (bool)Session[ISADMIN];

        }
        set { Session[ISADMIN] = value; }
    }

    public bool IsAgent
    {
        get
        {
            // Initilise if null.
            if (Session[ISAGENT] == null)
            {
                Session[ISAGENT] = false;
            }

            return (bool)Session[ISAGENT];

        }
        set { Session[ISAGENT] = value; }
    }

    public bool IsSuperUser
    {
        get
        {
            // Initilise if null.
            if (Session[ISSUPERUSER] == null)
            {
                Session[ISSUPERUSER] = false;
            }

            return (bool)Session[ISSUPERUSER];

        }
        set { Session[ISSUPERUSER] = value; }
    }


    public int AgentID
    {
        get
        {
            if (Session[AGENTID] == null) Session[AGENTID] = 0;
            return (int)Session[AGENTID];
        }
        set
        {
            Session[AGENTID] = value;
        }
    }

    public bool ViewPDFMode
    {
        get
        {
            // Initilise if null.
            if (Session[VIEWPDFMODE] == null)
            {
                Session[VIEWPDFMODE] = false;
            }

            return (bool)Session[VIEWPDFMODE];

        }
        set { Session[VIEWPDFMODE] = value; }
    }


    public ItinTemplateObj ItinTemplate
    {
        get
        {
            // Initilise if null.
            if (Session[ITINTEMPLATE] == null)
            {
                Session[ITINTEMPLATE] = new ItinTemplateObj();
            }

            return (ItinTemplateObj)Session[ITINTEMPLATE];

        }
        set
        {
            Session[ITINTEMPLATE] = value;
        }

    }

    public FlightStates FlightStates
    {
        get
        {
            // Initilise if null.
            if (Session[FLIGHTSTATES] == null)
            {
                Session[FLIGHTSTATES] = new FlightStates();
            }

            return (FlightStates)Session[FLIGHTSTATES];

        }
        set
        {
            Session[FLIGHTSTATES] = value;
        }

    }


    public FlightObj Flight
    {
        get
        {
            // Initilise if null.
            if (Session[FLIGHTOBJ] == null)
            {
                Session[FLIGHTOBJ] = new FlightObj();
            }

            return (FlightObj)Session[FLIGHTOBJ];

        }
        set
        {
            Session[FLIGHTOBJ] = value;
        }

    }


    public PageStates PageStates
    {
        get
        {
            // Initilise if null.
            if (Session[PAGESTATES] == null)
            {
                Session[PAGESTATES] = new PageStates();
            }

            return (PageStates)Session[PAGESTATES];

        }
        set
        {
            Session[PAGESTATES] = value;
        }

    }


    public PlaceStates PlaceStates
    {
        get
        {
          

            return (PlaceStates)Session[PLACESTATES];

        }
        set
        {
            Session[PLACESTATES] = value;
        }

    }

    public List<TransferNode> TransferNodes
    {
        get
        {
            // Initilise if null.
            if (Session[TRANSFERNODES] == null)
            {
                Session[TRANSFERNODES] = new List<TransferNode>();
            }

            return (List<TransferNode>)Session[TRANSFERNODES];

        }
        set { Session[TRANSFERNODES] = value; }
    }

    public TransferFilter TransferFilter
    {
        get
        {
            // Initilise if null.
            if (Session[TRANSFERFILTER] == null)
            {
                Session[TRANSFERFILTER] = new TransferFilter();
            }

            return (TransferFilter)Session[TRANSFERFILTER];

        }
        set { Session[TRANSFERFILTER] = value; }
    }




    public bool DisplayFlightPanel
    {
        get
        {
            // Initilise if null.
            if (Session[DISPLAYFLIGHTPANEL] == null)
            {
                Session[DISPLAYFLIGHTPANEL] = false;
            }

            return (bool)Session[DISPLAYFLIGHTPANEL];

        }
        set { Session[DISPLAYFLIGHTPANEL] = value; }
    }

    public bool tick
    {
        get
        {
            // Initilise if null.
            if (Session[TICK] == null)
            {
                Session[TICK] = true;
            }

            return (bool)Session[TICK];

        }
        set { Session[TICK] = value; }
    }


    public bool pulse
    {
        get
        {
            // Initilise if null.
            if (Session[PULSE] == null)
            {
                Session[PULSE] = true;
            }

            return (bool)Session[PULSE];

        }
        set { Session[PULSE] = value; }
    }

    public bool ShowPrices
    {
        get
        {
            // Initilise if null.
            if (Session[SHOWPRICES] == null)
            {
                Session[SHOWPRICES] = true;
            }

            return (bool)Session[SHOWPRICES];

        }
        set { Session[SHOWPRICES] = value; }
    }



    public bool IsTemplateChanged
    {
        get
        {
            // Initilise if null.
            if (Session[ISTEMPLATECHANGED] == null)
            {
                Session[ISTEMPLATECHANGED] = false;
            }

            return (bool)Session[ISTEMPLATECHANGED];

        }
        set { Session[ISTEMPLATECHANGED] = value; }
    }


    public bool FirePageEvent
    {
        get
        {
            // Initilise if null.
            if (Session[FIREPAGEEVENT] == null)
            {
                Session[FIREPAGEEVENT] = false;
            }

            return (bool)Session[FIREPAGEEVENT];

        }
        set { Session[FIREPAGEEVENT] = value; }
    }


    public string PriceBrakeDown
    {
        get
        {
            return (string)Session[PRICEBRAKEDOWN];
        }
        set
        {
            Session[PRICEBRAKEDOWN] = value;
        }
    }

    public string SelectedDepAirportCode
    {
        get
        {
            return (string)Session[SELECTEDDEPAIRPORTCODE];
        }
        set
        {
            Session[SELECTEDDEPAIRPORTCODE] = value;
        }
    }

    public string SelectedInfo
    {
        get
        {
            if (Session[SELECTEDINFO] == null) Session[SELECTEDINFO] = "";
            return (string)Session[SELECTEDINFO];
        }
        set
        {
            Session[SELECTEDINFO] = value;
        }
    }

    public bool WithCar
    {
        get

        {
            if (Session[WITHCAR] == null) Session[WITHCAR] = false;
            return (bool)Session[WITHCAR];
        }
        set
        {
            Session[WITHCAR] = value;
        }
    }


    public bool ChooseMode
    {
        get
        {
            if (Session[CHOOSEMODE] == null) Session[CHOOSEMODE] = false;
            return (bool)Session[CHOOSEMODE];
        }
        set
        {
            Session[CHOOSEMODE] = value;
        }
    }


    public string PrevLevel
    {
        get
        {
            if (Session[PREVLEVEL] == null) Session[PREVLEVEL] = "0x-1x-1x-1";
            return (string)Session[PREVLEVEL];
        }
        set
        {
            Session[PREVLEVEL] = value;
        }
    }



    public bool IsCarHire
    {
        get
        {
            if (Session[ISCARHIRE] == null) Session[ISCARHIRE] = false;
            return (bool)Session[ISCARHIRE];
        }
        set
        {
            Session[ISCARHIRE] = value;
        }
    }


    public int FlashState
    {
        get
        {
            if (Session[FLASHSTATE] == null) Session[FLASHSTATE] = 0;
            return (int)Session[FLASHSTATE];
        }
        set
        {
            Session[FLASHSTATE] = value;
        }
    }

    public int TickCount
    {
        get
        {
            if (Session[TICKCOUNT] == null) Session[TICKCOUNT] = 0;
            return (int)Session[TICKCOUNT];
        }
        set
        {
            Session[TICKCOUNT] = value;
        }
    }

    public int TimeID
    {
        get
        {
            if (Session[TIMEID] == null)
            {
                return 0;

                //TODO check this is ok to return zero.

                //PriceCalc priceCalc = new PriceCalc();

                //Session[TIMEID] = priceCalc.getNearestTimeID();
            }
            return (int)Session[TIMEID];
        }
        set
        {
            Session[TIMEID] = value;
        }
    }



    public int UserItinID
    {
        get
        {
            if (Session[USERITINID] == null) Session[USERITINID] = 0;
            return (int)Session[USERITINID];
        }
        set
        {
            Session[USERITINID] = value;
        }
    }

    public int SelectedIndex
    {
        get
        {
            if (Session[SELECTEDINDEX] == null) Session[SELECTEDINDEX] = -1;
            return (int)Session[SELECTEDINDEX];
        }
        set
        {
            Session[SELECTEDINDEX] = value;
        }
    }


    public int PicPos
    {
        get
        {
            if (Session[PICPOS] == null) Session[PICPOS] = 0;
            return (int)Session[PICPOS];
        }
        set
        {
            Session[PICPOS] = value;
        }
    }

    public int PicPosMax
    {
        get
        {
            if (Session[PICPOSMAX] == null) Session[PICPOSMAX] = 5;
            return (int)Session[PICPOSMAX];
        }
        set
        {
            Session[PICPOSMAX] = value;
        }
    }

    public int SelectedLevel1Item
    {
        get
        {
            if (Session[SELECTEDLEVEL1ITEM] == null) Session[SELECTEDLEVEL1ITEM] = 0;
            return (int)Session[SELECTEDLEVEL1ITEM];
        }
        set
        {
            Session[SELECTEDLEVEL1ITEM] = value;
        }
    }

    public int SelectedLevel2Item
    {
        get
        {
            if (Session[SELECTEDLEVEL2ITEM] == null) Session[SELECTEDLEVEL2ITEM] = 0;
            return (int)Session[SELECTEDLEVEL2ITEM];
        }
        set
        {
            Session[SELECTEDLEVEL2ITEM] = value;
        }
    }

    public int SelectedLevel3Item
    {
        get
        {
            if (Session[SELECTEDLEVEL3ITEM] == null) Session[SELECTEDLEVEL3ITEM] = 0;
            return (int)Session[SELECTEDLEVEL3ITEM];
        }
        set
        {
            Session[SELECTEDLEVEL3ITEM] = value;
        }
    }

    public int SelectedLevel4Item
    {
        get
        {
            if (Session[SELECTEDLEVEL4ITEM] == null) Session[SELECTEDLEVEL4ITEM] = 0;
            return (int)Session[SELECTEDLEVEL4ITEM];
        }
        set
        {
            Session[SELECTEDLEVEL4ITEM] = value;
        }
    }

    public int SelectedNights
    {
        get
        {
            if (Session[NIGHTS] == null) return -1;
            return (int)Session[NIGHTS];
        }
        set
        {
            Session[NIGHTS] = value;
        }
    }

    public int SelectedPlaceID
    {
        get
        {

            try
            {
                if (Session[PLACEID] == null) return Convert.ToInt16(Configuration.GetSection("AppConfiguration")["DefaultPlaceID"]);
                return (int)Session[PLACEID];
            }
            catch (Exception e)
            {
                return Convert.ToInt16(Configuration.GetSection("AppConfiguration")["DefaultPlaceID"]);
            }
            //  if ((Int16)Session[PLACEID] == 0) Session[PLACEID]=Convert.ToInt16(Configuration.GetSection("AppConfiguration")["DefaultPlaceID"]);
            // return (Int16)Session[PLACEID];
        }
        set
        {
            Session[PLACEID] = value;
        }
    }

    public int PrevPlaceID
    {
        get
        {
            if (Session[PREVPLACEID] == null) Session[PREVPLACEID] = 0;
            return (int)Session[PREVPLACEID];
        }
        set
        {
            Session[PREVPLACEID] = value;
        }
    }



    public DateTime SelectedDate
    {
        get
        {
            if (Session[SELECTEDDATE] == null) Session[SELECTEDDATE] = System.DateTime.Now;
            return (DateTime)Session[SELECTEDDATE];
        }
        set
        {
            Session[SELECTEDDATE] = value;
        }
    }




    public decimal TotalCost
    {
        get
        {
            if (Session[TOTALCOST] == null) Session[TOTALCOST] = 0M;
            return (decimal)Session[TOTALCOST];
        }
        set
        {
            Session[TOTALCOST] = value;
        }
    }

    public int UserID
    {
        get
        {
            if (Session[USERID] == null) return 0;
            return (int)Session[USERID];
        }
        set
        {
            Session[USERID] = value;
        }
    }

    public string SelectedImage
    {
        get
        {
            return (string)Session[IMAGE];
        }
        set
        {
            Session[IMAGE] = value;
        }
    }

    public string ReturnPage
    {
        get
        {
            if (Session[RETURNPAGE] == null) return "";
            return (string)Session[RETURNPAGE];
        }
        set
        {
            Session[RETURNPAGE] = value;
        }
    }

    public List<PRSelection> PRSelections
    {
        get
        {

            return (List<PRSelection>)Session[PRSELECTIONS];

        }
        set { Session[PRSELECTIONS] = value; }
    }

    public bool containsPlaceID(int placeID)
    {
        if (PRSelections != null)
        {
            foreach (PRSelection selection in (List<PRSelection>)Session[PRSELECTIONS])
            {
                if (selection.PlaceID == placeID)
                {
                    return true;
                }
            }
        }
        return false;

    }


    // Setters and getters for the place session object
    public string SelectedPlace
    {
        get
        {
            if (Session[PLACE] == null) return Configuration.GetSection("AppConfiguration")["DefaultPlace"];
            return (string)Session[PLACE];
        }
        set
        {
            Session[PLACE] = value;
        }
    }

    public string SelectedDepAirport
    {
        get
        {
            if (Session[SELECTEDDEPAIRPORT] == null) return "";
            return (string)Session[SELECTEDDEPAIRPORT];
        }
        set
        {
            Session[SELECTEDDEPAIRPORT] = value;
        }
    }

    public string SelectedArvAirport
    {
        get
        {
            if (Session[SELECTEDARVAIRPORT] == null) return "";
            return (string)Session[SELECTEDARVAIRPORT];
        }
        set
        {
            Session[SELECTEDARVAIRPORT] = value;
        }
    }


    // Setters and getters for the place session object
    public string SelectedHotel
    {
        get
        {
            if (Session[HOTEL] == null) return Configuration.GetSection("AppConfiguration")["DefaultHotel"];
            return (string)Session[HOTEL];
        }
        set
        {
            Session[HOTEL] = value;
        }
    }

    public int SelectedHotelID
    {
        get
        {
            if (Session[HOTELID] == null) return Convert.ToInt16(Configuration.GetSection("AppConfiguration")["DefaultHotelID"]);
            return (int)Session[HOTELID];
        }
        set { Session[HOTELID] = value; }

    }

    public bool IsPlaceSelected
    {
        get
        {
            if (Session[PLACESELECTED] == null) return true;
            return (bool)Session[PLACESELECTED];
        }
        set
        {
            Session[PLACESELECTED] = value;
        }
    }

    public IConfiguration Configuration { get => _Configuration; set => _Configuration = value; }
}
