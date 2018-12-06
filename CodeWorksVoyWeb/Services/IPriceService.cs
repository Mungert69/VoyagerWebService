using System;
using System.Collections.Generic;

public interface IPriceService
{
    ISessionObject SessionObject { get; set; }

    DateTime adjustDate(DateTime adjustDate);
    void createPriceFromDate(DateTime useDate, int timeId);
    decimal getAptCharge(int supplierID);
    decimal getFlightCost(int outFlightID, int supplierId);
    DateTime getFlightDate();
    HotelPriceObj getHotelPrice(DateTime intDate, List<PRSelection> prSelections);
    List<ItinTemplateTimeObj> getItinTemplatePrices(int userItinId);
    List<ItinTemplateTimeObj> getItinTemplateTimeObjs(int timeId);
    int getNearestTimeID();
    decimal getPrice();
    decimal getPriceMultiplier(int centers);
    decimal getPSC(int supplierID, string airportCode);
    decimal getRepPrice();
    List<DateTime> getTimeIDDates();
    List<DateTime> getTimeIDDatesAdjusted();
    List<TransferPriceObj> getTransferPriceObj(List<TransferNode> _transferNodes);
    string updateItinTemplatePrices();
}