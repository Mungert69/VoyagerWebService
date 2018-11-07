using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for FlightObj
/// </summary>
public class FlightObj
{
    public FlightObj() { }

    public FlightObj(string airline, int supplierID)
    {
        this.airline = airline;
        this.supplierID = supplierID;

    }

    private decimal flightCost;

    public decimal FlightCost
    {
        get { return flightCost; }
        set { flightCost = value; }
    }

    private string flightInfo;

    public string FlightInfo
    {
        get { return flightInfo; }
        set { flightInfo = value; }
    }

    private int departAirportID;

    public int DepartAirportID
    {
        get { return departAirportID; }
        set { departAirportID = value; }
    }

    private string departAirport;

    public string DepartAirport
    {
        get { return departAirport; }
        set { departAirport = value; }
    }

    private int arriveAirportID;

    public int ArriveAirportID
    {
        get { return arriveAirportID; }
        set { arriveAirportID = value; }
    }

    private string arriveAirport;

    public string ArriveAirport
    {
        get { return arriveAirport; }
        set { arriveAirport = value; }
    }

    private int inFlightID;

    public int InFlightID
    {
        get { return inFlightID; }
        set { inFlightID = value; }
    }

    private DateTime startDate;

    public DateTime StartDate
    {
        get { return startDate; }
        set { startDate = value; }
    }

    private DateTime endDate;

    public DateTime EndDate
    {
        get { return endDate; }
        set { endDate = value; }
    }

    private string departureTime;

    public string DepartureTime
    {
        get { return departureTime; }
        set { departureTime = value; }
    }
    private int outFlightID;

    public int OutFlightID
    {
        get { return outFlightID; }
        set { outFlightID = value; }
    }

    private DateTime flightDepartureDate;

    public DateTime FlightDepartureDate
    {
        get { return flightDepartureDate; }
        set { flightDepartureDate = value; }
    }

    public String FlightDepartureShortDate
    {
        get
        {
            if (flightDepartureDate < DateTime.Now.AddDays(-999))
            {
                return "";
            }
            else
            {
                return flightDepartureDate.ToLongDateString();
            }
        }
    
       
    }

    private string airline;

    public string Airline
    {
        get { return airline; }
        set { airline = value; }
    }

    private int supplierID;

    public int SupplierID
    {
        get { return supplierID; }
        set { supplierID = value; }
    }

    private string supplier;

    public string Supplier
    {
        get { return supplier; }
        set { supplier = value; }
    }

    private int countryFlag;

    public int CountryFlag
    {
        get { return countryFlag; }
        set { countryFlag = value; }
    }
}
