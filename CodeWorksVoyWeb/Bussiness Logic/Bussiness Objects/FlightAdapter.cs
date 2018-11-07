using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using System.Collections.Generic;
using CodeWorkVoyWebService.Models.CubaData;
using CodeWorkVoyWebService.Models.VoyagerReserve;
using CodeWorkVoyWebService.Bussiness_Logic.Bussiness_Objects;
using Microsoft.Extensions.Caching.Memory;

/// <summary>
/// Summary description for FlightAdapter
/// </summary>
public class FlightAdapter : IFlightAdapter
{
    private readonly List<CodeWorkVoyWebService.Models.VoyagerReserve.Suppliers> suppliersTable;
    private readonly List<CodeWorkVoyWebService.Models.CubaData.AirportCodes> airportCodesTable;
    private readonly List<CodeWorkVoyWebService.Models.CubaData.DefaultAirports> defaultAirportsTable;
    private readonly List<CodeWorkVoyWebService.Models.CubaData.Airports> airportsTable;
    private readonly List<CodeWorkVoyWebService.Models.CubaData.FlightTable> flightTable;
    private readonly List<CodeWorkVoyWebService.Models.CubaData.FlightTableInbound> flightInboundTable;
    //private readonly CubaDataContext _context;
    //private readonly VoyagerReserveContext _contextRes;
    public FlightAdapter(IMemoryCache cache,CubaDataContext context, VoyagerReserveContext contextRes)
    {
        suppliersTable=FactoryUtils.CheckCache<CodeWorkVoyWebService.Models.VoyagerReserve.Suppliers>(ref cache, contextRes,  suppliersTable, "SuppliersTable");
        airportCodesTable = FactoryUtils.CheckCache<CodeWorkVoyWebService.Models.CubaData.AirportCodes>(ref cache, context, airportCodesTable, "AirportCodesTable");
        defaultAirportsTable = FactoryUtils.CheckCache<CodeWorkVoyWebService.Models.CubaData.DefaultAirports>(ref cache, context, defaultAirportsTable, "DefaultAirportsTable");
        airportsTable = FactoryUtils.CheckCache<CodeWorkVoyWebService.Models.CubaData.Airports>(ref cache, context, airportsTable, "AirportsTable");

        flightTable = FactoryUtils.CheckCache<CodeWorkVoyWebService.Models.CubaData.FlightTable>(ref cache, context, flightTable, "FlightTable");

        flightInboundTable = FactoryUtils.CheckCache<CodeWorkVoyWebService.Models.CubaData.FlightTableInbound>(ref cache, context, flightInboundTable, "FlightInboundTable");

        //_context = context;
        //_contextRes = contextRes;

    }


    public string getAirportName(string airportCode) {
        return airportCodesTable.Where(a => a.AirportCode == airportCode).Select(a => a.AirportName).First();
    }
    public  List<FlightObj> getAirlines(int countryFlag)
    {
        List<FlightObj> flightObjs = new List<FlightObj>();
        List<CodeWorkVoyWebService.Models.VoyagerReserve.Suppliers> table=suppliersTable.Where(s => s.SupplierType == "Airline" && s.UseIt == true).ToList();
        int test;

     
        foreach (CodeWorkVoyWebService.Models.VoyagerReserve.Suppliers row in table)
        {
            FlightObj flightObj = new FlightObj(row.SupplierName, Convert.ToInt32(row.SupplierId));
            test = Convert.ToInt32(row.CountryFlag) & countryFlag;
            if (test == countryFlag)
            {
                flightObjs.Add(flightObj);
            }


        }
        return flightObjs;
    }

    public string getDefaultAirport(int supplierID)
    {

        return  defaultAirportsTable.Where(a => a.SupplierId == supplierID).Select( a => a.AirportCode).First();

       
    }

    public  List<AirportObj> getAirportsByAID(int supplierID)
    {
        List<AirportObj> airportObjs = new List<AirportObj>();

        /*var table = _context.Psc   // your starting point - table in the "from" statement
          .Join(_context.Airports, // the source table of the inner join
          psc => psc.DepAirport,
          airports => airports.AirportCode,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
                // Select the foreign key (the second part of the "on" clause)
             (psc,airports) => new {  Psc = psc ,Airports = airports}) // selection
          .Where(joined => joined.Psc.SupplierId == supplierID).Select(s => s.Airports.DepAirport).ToList();
        */
        var table = airportsTable.Where(a => a.Aid == supplierID).ToList();
        airportObjs.Add(new AirportObj());
        foreach (CodeWorkVoyWebService.Models.CubaData.Airports row in table)
        {
            AirportObj airportObj = new AirportObj();
            airportObj.AirportName = row.DepAirport;
       
            airportObjs.Add(airportObj);

        }
        return airportObjs;
    }

    public  List<FlightObj> getOutFlightsByDateRange(int supplierID, DateTime date, DateTime startDate)
    {
        List<FlightObj> flightObjs = new List<FlightObj>();
        /*
        FlightTableTableAdapter adapt = new FlightTableTableAdapter();
        FlightData.FlightTableDataTable table = adapt.GetOutFlightsByDateRange(supplierID, startDate,date);

        foreach (FlightData.FlightTableRow row in table)
        {
            FlightObj flightObj = new FlightObj();
            flightObj.FlightDepartureDate = row.FlightDepartureDate;
            flightObj.DepartureTime = row.DepartureTime;
            flightObj.OutFlightID= row.FlightID;
            flightObjs.Add(flightObj);
        }*/
        return flightObjs;
    }

    public  List<FlightObj> getOutFlightsByDateRangeForward(int supplierID, DateTime date, DateTime endDate)
    {
        List<FlightObj> flightObjs = new List<FlightObj>();

        List<CodeWorkVoyWebService.Models.CubaData.FlightTable> table = flightTable.Where(f => f.UseIt == "Y" && f.SupplierId == supplierID && (f.FlightDepartureDate >= date && f.FlightDepartureDate <= endDate)).OrderBy(f => f.FlightDepartureDate).ToList();
        flightObjs.Add(new FlightObj());
        foreach (CodeWorkVoyWebService.Models.CubaData.FlightTable row in table)
        {
            FlightObj flightObj = new FlightObj();
            flightObj.FlightDepartureDate = Convert.ToDateTime(row.FlightDepartureDate);
            flightObj.DepartureTime = row.DepartureTime;
           
            flightObj.OutFlightID = Convert.ToInt32(row.FlightId);
            flightObjs.Add(flightObj);
        }
        return flightObjs;
    }

    public  List<FlightObj> getOutFlightData(int outFlightID)
    {
        List<FlightObj> flightObjs = new List<FlightObj>();
        /*
        FlightTableTableAdapter adaptOut = new FlightTableTableAdapter();
        FlightData.FlightTableDataTable tableOut = adaptOut.GetOutFlightData(outFlightID);
        DateTime selectedDateTime = new DateTime();
        foreach (FlightData.FlightTableRow row in tableOut)
        {
            FlightObj flightObj = new FlightObj();
            flightObj.FlightDepartureDate = row.FlightDepartureDate;
            flightObj.DepartureTime = row.DepartureTime;
            flightObjs.Add(flightObj);
        }*/
        return flightObjs;
    }

    public  List<FlightObj> getInFlightData(int inFlightID)
    {
        List<FlightObj> flightObjs = new List<FlightObj>();
        /*
        FlightTableINBOUNDTableAdapter adapt = new FlightTableINBOUNDTableAdapter();
        FlightData.FlightTableINBOUNDDataTable table = adapt.GetInFlightData(inFlightID);

        foreach (FlightData.FlightTableINBOUNDRow row in table)
        {
            FlightObj flightObj = new FlightObj();
            flightObj.FlightDepartureDate = row.FlightDepartureDate;
            flightObj.DepartureTime = row.DepartureTime;
            flightObjs.Add(flightObj);
        }*/

        return flightObjs;
    }

    public  List<FlightObj> getInFlightsByDateRangeForward(int supplierID, DateTime date, DateTime endDate)
    {
        List<FlightObj> flightObjs = new List<FlightObj>();

        List<CodeWorkVoyWebService.Models.CubaData.FlightTableInbound> table = flightInboundTable.Where(f => f.UseIt == "Y" && f.SupplierId == supplierID && (f.FlightDepartureDate >= date && f.FlightDepartureDate <= endDate)).OrderBy(f => f.FlightDepartureDate).ToList();
        flightObjs.Add(new FlightObj());
        foreach (CodeWorkVoyWebService.Models.CubaData.FlightTableInbound row in table)
        {
            FlightObj flightObj = new FlightObj();
            flightObj.FlightDepartureDate = Convert.ToDateTime(row.FlightDepartureDate);
            flightObj.DepartureTime = row.DepartureTime;
            flightObj.InFlightID = Convert.ToInt32(row.InboundFlightId);
            flightObjs.Add(flightObj);
        }
        return flightObjs;
    }
}
