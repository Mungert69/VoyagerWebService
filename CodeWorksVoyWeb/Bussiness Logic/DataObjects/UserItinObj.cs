using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserItinObj
/// </summary>
public class UserItinObj
{
    public Object getField(string field ){
     Type t = this.GetType();
            // field is a member variable
            return t.GetField(field);

    }

    private string depAirport;

    public string DepAirport
    {
        get { return depAirport; }
        set { depAirport = value; }
    }

    private int itinID;

    public int ItinID
    {
        get { return itinID; }
        set { itinID = value; }
    }
    private int userItinID;

    public int UserItinID
    {
        get { return userItinID; }
        set { userItinID = value; }
    }
    private string itinName;

    public string ItinName
    {
        get { return itinName; }
        set { itinName = value; }
    }

    private int outFlightID;

    public int OutFlightID
    {
        get { return outFlightID; }
        set { outFlightID = value; }
    }
    private int inFlightID;

    public int InFlightID
    {
        get { return inFlightID; }
        set { inFlightID = value; }
    }

    private string airport;

    public string Airport
    {
        get { return airport; }
        set { airport = value; }
    }
    private DateTime departTime;

    public DateTime DepartTime
    {
        get { return departTime; }
        set { departTime = value; }
    }
    private DateTime returnTime;

    public DateTime ReturnTime
    {
        get { return returnTime; }
        set { returnTime = value; }
    }
    private int nights;

    public int Nights
    {
        get { return nights; }
        set { nights = value; }
    }
    private string airline;

    public string Airline
    {
        get { return airline; }
        set { airline = value; }
    }
    private int airlineID;

    public int AirlineID
    {
        get { return airlineID; }
        set { airlineID = value; }
    }
    private decimal totalCost;

    public decimal TotalCost
    {
        get { return totalCost; }
        set { totalCost = value; }
    }

    private DateTime priceDateStamp;

    public DateTime PriceDateStamp
    {
        get { return priceDateStamp; }
        set { priceDateStamp = value; }
    }

    private String tripTag;
    public String TripTag {

        get { return tripTag; }
        set { tripTag = value; }
    }
}
