using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using System.Collections.Generic;

using System.Text;
using CodeWorkVoyWebService.Models.CubaData;
using CodeWorkVoyWebService.Models.VoyagerReserve;

/// <summary>
/// Summary description for PriceCalc
/// </summary>
public class PriceService : IPriceService
{
    private IPlaceAdapter _placeAdapter;
    private IHotelAdapter _hotelAdapter;
    private ISessionObject sessionObject;
    private CubaDataContext _context;
    private VoyagerReserveContext _contextRes;

    public ISessionObject SessionObject { get => sessionObject; set => sessionObject = value; }

    public PriceService(VoyagerReserveContext contextRes, IPlaceAdapter placeAdapter, IHotelAdapter hotelAdapter, CubaDataContext context)
    {
        _contextRes = contextRes;
        _placeAdapter = placeAdapter;
        _hotelAdapter = hotelAdapter;
       
        _context = context;
    }

    public DateTime getFlightDate()
    {
        DateTime newStartDate = SessionObject.Flight.StartDate;
        return newStartDate;
    }

    public decimal getPrice()
    {
        decimal hotelPrice = 0;
        decimal apt = 0;
        decimal repCharge = 0;
        decimal xFer = 0;
        decimal psc = 0;
        decimal xFerTemp = 0;
        try
        {
            //PriceCalc priceCalc = new PriceCalc();

            SessionObject.Flight.FlightCost = getFlightCost(SessionObject.Flight.OutFlightID, SessionObject.Flight.SupplierID);
            repCharge = getRepPrice();
            apt = getAptCharge(SessionObject.Flight.SupplierID);
            psc = getPSC(SessionObject.Flight.SupplierID, SessionObject.SelectedDepAirportCode);


            string startDateStr = SessionObject.Flight.StartDate.ToShortDateString();
            DateTime startDate = DateTime.Parse(startDateStr);
            startDate = startDate.AddMinutes(-1);
            DateTime endDate;
            int i = 0;
            foreach (PRSelection selection in SessionObject.PRSelections)
            {
                if (selection.HotelID != 0)
                {
                    int currentHotelID = selection.HotelID;
                    endDate = startDate.AddDays(selection.Nights);

                    // check if there is a price for the hotel.

                    // Set old price if no prices found.

                    if (_hotelAdapter.getPriceCount(currentHotelID, startDate, endDate) != selection.Nights)
                    {
                        SessionObject.PRSelections[i].OldPrice = true;
                    }
                    i++;
                    startDate = endDate;
                }
            }
            //if (flag) RightBarLabel.Text = hotelWarnStr + "</h3>";



            HotelPriceObj hotelPriceObj = getHotelPrice(SessionObject.Flight.StartDate, SessionObject.PRSelections);
            hotelPrice = hotelPriceObj.Price;
            string str = "Flight Cost= " + SessionObject.Flight.FlightCost + "<br/>APT=" + apt + "<br/>PSC=" + psc + "<br/><br/>Total Hotel Cost=" + hotelPrice + "<br/>" + hotelPriceObj.PriceDetail + "<br/><br/>Transfer Details>";
            List<TransferNode> transferNodes = SessionObject.TransferNodes;
            List<TransferPriceObj> transPriceObjs = getTransferPriceObj(transferNodes);
            int j = 0;

            foreach (TransferPriceObj transPriceObj in transPriceObjs)
            {
                if (!transferNodes[j].WithCar)
                {

                    xFer += transPriceObj.ItemPrice1 + transPriceObj.ItemPrice2 + transPriceObj.ItemPrice3 + transPriceObj.ItemPrice4 + transPriceObj.TransferPrice1 + transPriceObj.TransferPrice2 + transPriceObj.TransferPrice3 + transPriceObj.TransferPrice4;
                    xFerTemp = transPriceObj.ItemPrice1 + transPriceObj.ItemPrice2 + transPriceObj.ItemPrice3 + transPriceObj.ItemPrice4 + transPriceObj.TransferPrice1 + transPriceObj.TransferPrice2 + transPriceObj.TransferPrice3 + transPriceObj.TransferPrice4;

                    str += "<br/>" + transPriceObj.Description + " = " + xFerTemp;
                }
                else
                {
                    str += "<br/>" + transPriceObj.Description + " = No cost";
                }
                j++;
            }

            decimal multiplier;
            // We use a different multiplyer for the cost if the flight cost is zero ie hotels only
            if (SessionObject.Flight.FlightCost == 1)
            {
                multiplier = getPriceMultiplier(999);
            }
            else
            {
                multiplier = getPriceMultiplier(SessionObject.PRSelections.Count);
            }

            SessionObject.PriceBrakeDown = str + "<br/><br/>Repcharge=" + repCharge + "<br/>Total cost (No markup)" + (hotelPrice + SessionObject.Flight.FlightCost + xFer + apt + repCharge + psc);


            SessionObject.TotalCost = (hotelPrice + SessionObject.Flight.FlightCost + xFer) * multiplier + apt + repCharge + psc;
            return SessionObject.TotalCost;
        }
        catch {
            // Not catching exceptions as we want to be able to bypass price calc when things are not ready.
            return 0;
        }

    }



    public decimal getPriceMultiplier(int centers)
    {
        decimal multiplier = 1.30M;

        CodeWorkVoyWebService.Models.CubaData.PriceMultiplyier row= _context.PriceMultiplyier.Where(p => p.Id == centers).First();
        multiplier = Convert.ToDecimal(row.Multiplier);
        return multiplier;
    }

    public decimal getFlightCost(int outFlightID, int supplierId)
    {
        decimal flightCost = 0;


        List<CodeWorkVoyWebService.Models.CubaData.FlightCosts> tableOut = _context.FlightCosts.Where(f => f.FlightId == outFlightID && f.UseIt == "Y").ToList();
        //DateTime selectedDateTime = new DateTime();
        foreach (CodeWorkVoyWebService.Models.CubaData.FlightCosts row in tableOut)
        {
            flightCost = Convert.ToDecimal(row.Cost);
        }
        if (flightCost == 0) {
            List<CodeWorkVoyWebService.Models.VoyagerReserve.Suppliers> suppTable = _contextRes.Suppliers.Where(s => s.SupplierId == supplierId).ToList();

            foreach (CodeWorkVoyWebService.Models.VoyagerReserve.Suppliers row in suppTable)
            {
                flightCost = Convert.ToDecimal(row.DefaultPrice);
            }
        }

        return flightCost;
    }

    public decimal getPSC(int supplierID, string airportCode)
    {
        List<CodeWorkVoyWebService.Models.CubaData.Psc> table = _context.Psc.Where(p => p.DepAirport == airportCode && p.SupplierId == supplierID).ToList();
        foreach (CodeWorkVoyWebService.Models.CubaData.Psc row in table)
        {
            return Convert.ToDecimal(row.Dep);
        }
        return 0;
    }

    public decimal getRepPrice()
    {
        // Get Rep Charge.
        decimal repCharge = 0;


        CodeWorkVoyWebService.Models.CubaData.PricesOther row = _context.PricesOther.Where(p => p.Name == "RepCharge").First();

        repCharge = Convert.ToDecimal(row.Price);

        return repCharge;
    }

    public decimal getAptCharge(int supplierID)
    {

        // Set apt to supplierID apt price.
        decimal apt = 0;

        CodeWorkVoyWebService.Models.CubaData.Aptrates row = _context.Aptrates.Where(a => a.TaxCode == "ZZ" && a.SupplierId == supplierID).OrderByDescending(a => a.StartDate).First();

        apt = Convert.ToDecimal(row.Aptrate);

        // If apt is zero lookup the default apt price;
        if (apt == 0)
        {
            row = _context.Aptrates.Where(a => a.TaxCode == "ZZ" && a.SupplierId == 0).OrderByDescending(a => a.StartDate).First();
            apt = Convert.ToDecimal(row.Aptrate);
        }
        // If apt still zero use default of 350;

        if (apt == 0) apt = 350;
        return apt;
    }

    public HotelPriceObj getHotelPrice(DateTime intDate, List<PRSelection> prSelections)
    {
        String str = "";
        // Get hotel prices.
        HotelPriceObj hotelObj = new HotelPriceObj();

        decimal oldPriceMultiplier = 0.1M;
        decimal hotelPrice = 0;
        string startDateStr = intDate.ToShortDateString();
        DateTime startDate = DateTime.Parse(startDateStr);
        startDate = startDate.AddMinutes(-1);
        DateTime endDate;
        //ContractRatesTableAdapter adaptPrices;
        List<CodeWorkVoyWebService.Models.CubaData.ContractRates> tablePrices;
        foreach (PRSelection selection in prSelections)
        {
            if (selection.HotelID != 0)
            {
                if (selection.OldPrice)
                {
                    startDate = startDate.AddDays(-365);
                }
                int currentHotelID = selection.HotelID;
                endDate = startDate.AddDays(selection.Nights);

                // Get hotel price.
                //adaptPrices = new ContractRatesTableAdapter();
                tablePrices = _context.ContractRates.Where(c => c.HotelId == currentHotelID && (c.StartDate >= startDate && c.StartDate <= endDate)).ToList();
                decimal tempPrice = 0;
                foreach (CodeWorkVoyWebService.Models.CubaData.ContractRates row in tablePrices)
                {
                    if (selection.OldPrice)
                    {
                        hotelPrice += Convert.ToDecimal(row.NetRate) + Convert.ToDecimal(row.NetRate) * oldPriceMultiplier;
                        tempPrice += Convert.ToDecimal(row.NetRate) + Convert.ToDecimal(row.NetRate) * oldPriceMultiplier;
                    }
                    else
                    {
                        hotelPrice += Convert.ToDecimal(row.NetRate);
                        tempPrice += Convert.ToDecimal(row.NetRate);
                    }
                }
                str += selection.Hotel + " = " + tempPrice + " ";
                if (selection.OldPrice)
                {
                    endDate = endDate.AddDays(365);
                }
                startDate = endDate;
            }
        }
        hotelObj.Price = hotelPrice;
        hotelObj.PriceDetail = str;

        return hotelObj;
    }


    public List<TransferPriceObj> getTransferPriceObj(List<TransferNode> _transferNodes)
    {
        List<TransferNode> transferNodes = _transferNodes;
        List<TransferPriceObj> transferPriceObjs = new List<TransferPriceObj>();

        // Get Transfer Price
        List<CodeWorkVoyWebService.Models.CubaData.TransferLogic> transTable;

        //DefaultTransfersTableAdapter defAdapt = new DefaultTransfersTableAdapter();
        foreach (TransferNode transNode in transferNodes)
        {

            transTable = _context.TransferLogic.Where(t => t.Id == transNode.TransferID).ToList();
            foreach (CodeWorkVoyWebService.Models.CubaData.TransferLogic transRow in transTable)
            {
                TransferPriceObj transferPriceObj = new TransferPriceObj();
                transferPriceObj.Description = transRow.Origin + " - " + transRow.Destination;
                transferPriceObj.ItemPrice1 = Convert.ToDecimal(transRow.ItemPrice1);
                transferPriceObj.ItemPrice2 = Convert.ToDecimal(transRow.ItemPrice2);
                transferPriceObj.ItemPrice3 = Convert.ToDecimal(transRow.ItemPrice3);
                transferPriceObj.ItemPrice4 = Convert.ToDecimal(transRow.ItemPrice4);

                transferPriceObj.TransferPrice1 = getTransferPrice(Convert.ToInt32(transRow.GroundId1));
                transferPriceObj.TransferPrice2 = getTransferPrice(Convert.ToInt32(transRow.GroundId2));

                transferPriceObj.TransferPrice3 = getTransferPrice(Convert.ToInt32(transRow.GroundId3));
                transferPriceObj.TransferPrice4 = getTransferPrice(Convert.ToInt32(transRow.GroundId4));
                transferPriceObjs.Add(transferPriceObj);
            }

        }

        return transferPriceObjs;
    }

    private decimal getTransferPrice(int groundID) {
        try { 
        decimal price = Convert.ToDecimal(_context.DefaultTransfers.Where(d => d.TransferId == groundID).Select(d => d.Price).First());
        return price;
    }
    catch (Exception e){return 0;}
       
    }

    public int getNearestTimeID()
    {
        /*
        ItinTemplateTimeIDlookupTableAdapter adaptLookup = new ItinTemplateTimeIDlookupTableAdapter();
        PriceData.ItinTemplateTimeIDlookupDataTable tableLookup = adaptLookup.GetData();
        DateTime now = DateTime.Now;
        int intM = now.Month;
        int timeID = 1;
        int lowestDays = 365;
        foreach (PriceData.ItinTemplateTimeIDlookupRow row in tableLookup)
        {
            int intD = row.Date.Month;
            if (intD == intM)
            {

                timeID = row.TimeID;
                break;
            }
        }
        return timeID;
        */
        return 0;
    }

    public List<DateTime> getTimeIDDates()
    {
        List<DateTime> timeObjs = new List<DateTime>();
        /*
        ItinTemplateTimeIDlookupTableAdapter adapt = new ItinTemplateTimeIDlookupTableAdapter();
        PriceData.ItinTemplateTimeIDlookupDataTable table = adapt.GetData();

        foreach (PriceData.ItinTemplateTimeIDlookupRow row in table)
        {
            DateTime timeObj = new DateTime();

            timeObj = row.Date;
            timeObjs.Add(timeObj);
        }*/
        return timeObjs;
    }


    public List<DateTime> getTimeIDDatesAdjusted()
    {
        List<DateTime> timeObjs = new List<DateTime>();
        /*
        ItinTemplateTimeIDlookupTableAdapter adapt = new ItinTemplateTimeIDlookupTableAdapter();
        PriceData.ItinTemplateTimeIDlookupDataTable table = adapt.GetData();
        int nowTimeID = getNearestTimeID();
        foreach (PriceData.ItinTemplateTimeIDlookupRow row in table)
        {
            DateTime timeObj = new DateTime();
            if (row.TimeID < nowTimeID) { timeObj = row.Date.AddYears(1); }
            else { timeObj = row.Date; }

            timeObjs.Add(timeObj);
        }*/
        return timeObjs;
    }




    public List<ItinTemplateTimeObj> getItinTemplatePrices(int userItinID)
    {
        List<ItinTemplateTimeObj> timeObjs = new List<ItinTemplateTimeObj>();
        /*
        ItinTemplateTimeIDTableAdapter adapt = new ItinTemplateTimeIDTableAdapter();
        PriceData.ItinTemplateTimeIDDataTable table = adapt.GetDataByUserItinID(userItinID);
        int timeID = getNearestTimeID();
        foreach (PriceData.ItinTemplateTimeIDRow row in table)
        {
            ItinTemplateTimeObj timeObj = new ItinTemplateTimeObj();
            if (row.TimeID < timeID)
            {
                timeObj.Price = row.Price * 1.0M;
            }
            else
            {
                timeObj.Price = row.Price;
            }
            timeObj.TimeID = row.TimeID;
            timeObjs.Add(timeObj);
        }*/
        return timeObjs;
    }




    public List<ItinTemplateTimeObj> getItinTemplateTimeObjsEscorted(int timeID)
    {
        List<ItinTemplateTimeObj> timeObjs = new List<ItinTemplateTimeObj>();
        /*
        ItinTemplateTimeIDEscortedTableAdapter adapt = new ItinTemplateTimeIDEscortedTableAdapter();
        PriceData.ItinTemplateTimeIDEscortedDataTable table = adapt.GetDataByTimeID(timeID);
        foreach (PriceData.ItinTemplateTimeIDEscortedRow row in table)
        {
            ItinTemplateTimeObj timeObj = new ItinTemplateTimeObj();
            timeObj.TemplateType = row.TemplateName;

            if (row.TimeID < timeID)
            {
                timeObj.Price = row.Price * 1.0M;
            }
            else
            {
                timeObj.Price = row.Price;
            }

            timeObj.TimeID = row.TimeID;
            timeObjs.Add(timeObj);
        }*/
        return timeObjs;
    }


    public List<ItinTemplateTimeObj> getItinTemplateTimeObjs(int timeID)
    {
        List<ItinTemplateTimeObj> timeObjs = new List<ItinTemplateTimeObj>();
        /*
        ItinTemplateTimeIDTableAdapter adapt = new ItinTemplateTimeIDTableAdapter();
        PriceData.ItinTemplateTimeIDDataTable table = adapt.GetDataTimeObjsByTimeID(timeID);
        foreach (PriceData.ItinTemplateTimeIDRow row in table)
        {
            ItinTemplateTimeObj timeObj = new ItinTemplateTimeObj();
            timeObj.TemplateType = row.TemplateType;
            timeObj.TemplateTypeID = row.TemplateTypeID;
            timeObj.CountID = row.CountID;
            if (row.TimeID < timeID)
            {
                timeObj.Price = row.Price * 1.0M;
            }
            else
            {
                timeObj.Price = row.Price;
            }
            timeObj.UserItinID = row.UserItinID;
            timeObj.TimeID = row.TimeID;
            timeObjs.Add(timeObj);
        }*/
        return timeObjs;
    }

    public DateTime adjustDate(DateTime adjustDate){
     DateTime now = DateTime.Now;
     DateTime adjustedDate = new DateTime(now.Year, adjustDate.Month, adjustDate.Day);
                    if (now < adjustedDate) { return adjustDate; }
                    else {
                        now = now.AddYears(1);
                        return  new DateTime(now.Year, adjustDate.Month, adjustDate.Day);
                  
                    }
    }

    public string updateItinTemplatePrices()
    {
        /*
        ItinTemplateTimeIDlookupTableAdapter adaptLookup = new ItinTemplateTimeIDlookupTableAdapter();
        PriceData.ItinTemplateTimeIDlookupDataTable tableLookup = adaptLookup.GetData();
        ItinTemplateTimeIDTableAdapter adaptWrite = new ItinTemplateTimeIDTableAdapter();
        adaptWrite.DeleteQuery();

        AdminTemplatesTableAdapter adaptTemplate = new AdminTemplatesTableAdapter();
        AdminItinData.AdminTemplatesDataTable tableTemplate = adaptTemplate.GetData();

        UserItinAdapter userItinAdapt = new UserItinAdapter(true);

        SessionObjects _sessionObjects = new SessionObjects();
         _sessionObjects.Flight.SupplierID=Convert.ToInt16(Configuration.GetSection("AppConfiguration")["DefaultFlightSupplierIDForTemplatePriceCalc"]);
       
        StringBuilder str = new StringBuilder();

        foreach (AdminItinData.AdminTemplatesRow rowTemplate in tableTemplate)
        {

            foreach (PriceData.ItinTemplateTimeIDlookupRow rowLookup in tableLookup)
            {
                try
                {
                    UserItinObj userItinObj = userItinAdapt.getUserItin(Convert.ToInt32(rowTemplate.AdminItinID));
                    int itinID = userItinObj.ItinID;
                    UserItinAdapter userPlacesAdapter = new UserItinAdapter(true);
                    _sessionObjects.PRSelections = userPlacesAdapter.getItinPlaces(itinID);
                    TransferAdapter transAdapt = new TransferAdapter();
                    _sessionObjects.TransferNodes = transAdapt.getTransfersNodes(itinID, true);

                    DateTime useDate = adjustDate(rowLookup.Date);
                    if (rowLookup.TimeID == 4 && rowLookup.TimeID == 14) {
                        int distance = 7;
                        if (rowLookup.TimeID == 4) distance = 24;

                        _sessionObjects.Flight.StartDate = getFlightDate(useDate, distance, true, _sessionObjects.Flight.SupplierID);
                 
                    }
                    else
                    {
                        _sessionObjects.Flight.StartDate = getFlightDate(useDate, 3, false, _sessionObjects.Flight.SupplierID);
                    }
                        int totalNights = 0;
                    foreach (PRSelection selection in _sessionObjects.PRSelections)
                    {
                        totalNights += selection.Nights;
                    }
                    _sessionObjects.Flight.EndDate = _sessionObjects.Flight.StartDate.AddDays(totalNights);

                   
                    FlightAdapter flightAdapter = new FlightAdapter();
                    List<FlightObj> flightObjs = flightAdapter.getOutFlightsByDateRange(_sessionObjects.Flight.SupplierID, _sessionObjects.Flight.StartDate, _sessionObjects.Flight.StartDate);
                    _sessionObjects.Flight.OutFlightID = 0;
                    foreach (FlightObj row in flightObjs)
                    {

                        _sessionObjects.Flight.OutFlightID = row.OutFlightID;
                        break;
                    }

                    getPrice(_sessionObjects);
                    string debugStr = _sessionObjects.PriceBrakeDown;
                    adaptWrite.InsertQuery(rowTemplate.AdminItinID, rowLookup.TimeID, _sessionObjects.TotalCost);
                    if (_sessionObjects.Flight.FlightCost == 0) {
                        str.Append("<br/>Successfully update price where IndexName=" + rowTemplate.AccordianName + " Date range=" + rowLookup.TimeRangeName + "<span STYLE='color : #FF0000;'> Price=" + _sessionObjects.TotalCost + "</span> Date used was : " + _sessionObjects.Flight.StartDate);
                 
                    }
                    else
                    {
                        str.Append("<br/>Successfully update price where IndexName=" + rowTemplate.AccordianName + " Date range=" + rowLookup.TimeRangeName + " Price=" + _sessionObjects.TotalCost + " Date used was : " + _sessionObjects.Flight.StartDate);
                    }
                    str.Append("<br/>"+debugStr+"<br/>");
                    }
                catch (Exception ex)
                {
                    str.Append("<br/>Failed to  update price where IndexName=" + rowTemplate.AccordianName + " Date range=" + rowLookup.TimeRangeName + "<br/>Error was : " + ex.Message);
                }

            }
        }
        
        return str.ToString();*/
            return "";
    }

    private DateTime getFlightDate(DateTime startDate, int distance, bool highest, int supplierID)
    {
        
        DateTime date = new DateTime();
        /*
        FlightAdapter flightAdapter = new FlightAdapter();

        date = getFlightID(startDate, distance,highest, supplierID);
        if (!highest && date!=DateTime.MinValue) return date;

        date = getFlightID(startDate.AddYears(-1), distance,highest, supplierID);
        if (!highest && date != DateTime.MinValue) return date;
        */
        return date;
    }

    private DateTime getFlightID(DateTime startDate, int distance, bool highest, int supplierID) {
        DateTime date = new DateTime();
        DateTime highDate = new DateTime();
        /*
        int outFlightID = 0;
        decimal highPrice=0;
        DateTime highDate = new DateTime();
        FlightAdapter flightAdapter = new FlightAdapter();
        for (int i = 0; i < distance; i++)
        {
            date = startDate.AddDays(i);
            List<FlightObj> flightObjs = flightAdapter.getOutFlightsByDateRange(supplierID, date, date);
            outFlightID = 0;
            if (flightObjs.Count > 0)
            {

                foreach (FlightObj row in flightObjs)
                {

                    outFlightID = row.OutFlightID;

                }
                if (!highest)
                {
                    highDate = date;
                    break;
                }
                else {
                    decimal price=getFlightCost(outFlightID,supplierID);
                    if (price > highPrice) {
                        highPrice = price;
                        highDate = date;
                    };
                }
                
            }
            date = startDate.AddDays(-i);
            flightObjs = flightAdapter.getOutFlightsByDateRange(supplierID, date, date);
            outFlightID = 0;
            if (flightObjs.Count > 0)
            {

                foreach (FlightObj row in flightObjs)
                {

                    outFlightID = row.OutFlightID;

                }
                if (!highest) { 
                    highDate = date;
                    break; }
                else
                {
                    decimal price = getFlightCost(outFlightID,supplierID);
                    if (price > highPrice)
                    {
                        highPrice = price;
                        highDate = date;
                    };
                }
            }
        }*/
        return highDate;
    }
}
