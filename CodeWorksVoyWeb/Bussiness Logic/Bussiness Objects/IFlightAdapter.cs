using System;
using System.Collections.Generic;

public interface IFlightAdapter
{
    List<FlightObj> getAirlines(int countryFlag);
    string getAirportName(string airportCode);
    List<AirportObj> getAirportsByAID(int supplierID);
    string getDefaultAirport(int supplierID);
    List<FlightObj> getInFlightData(int inFlightID);
    List<FlightObj> getInFlightsByDateRangeForward(int supplierID, DateTime startDate, DateTime endDate);
    List<FlightObj> getOutFlightData(int outFlightID);
    List<FlightObj> getOutFlightsByDateRange(int supplierID, DateTime date, DateTime startDate);
    List<FlightObj> getOutFlightsByDateRangeForward(int supplierID, DateTime date, DateTime endDate);
}