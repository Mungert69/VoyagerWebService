using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using System.Collections.Generic;

using System.Text;
using CodeWorksVoyWebService.Models.CubaData;
using CodeWorksVoyWebService.Models.VoyagerReserve;
using CodeWorksVoyWebService.Models.WebData;
using Microsoft.Extensions.Configuration;
using CodeWorksVoyWebService.Bussiness_Logic.Bussiness_Objects;
using Microsoft.Extensions.Caching.Memory;

/// <summary>
/// Summary description for PriceCalc
/// </summary>
public class PriceService : IPriceService
{
    private readonly List<CodeWorksVoyWebService.Models.VoyagerReserve.Suppliers> suppliersTable;
    private readonly List<CodeWorksVoyWebService.Models.CubaData.PriceMultiplyier> priceMultiplyierTable;
    private readonly List<CodeWorksVoyWebService.Models.CubaData.FlightCosts> flightCostsTable;
    private readonly List<CodeWorksVoyWebService.Models.CubaData.Psc> pscTable;
    private readonly List<CodeWorksVoyWebService.Models.CubaData.PricesOther> pricesOtherTable;
    private readonly List<CodeWorksVoyWebService.Models.CubaData.Aptrates> aptRatesTable;
    private readonly List<CodeWorksVoyWebService.Models.CubaData.TransferLogic> transferLogicTable;
    private readonly List<CodeWorksVoyWebService.Models.CubaData.DefaultTransfers> defaultTransfersTable;
    private IPlaceAdapter _placeAdapter;
    private IHotelAdapter _hotelAdapter;
    private IFlightAdapter _flightAdapter;
    private ITransferAdapter _transferAdapter;
    private IUserItinAdapter _userItinAdapter;
    private ISessionObject sessionObject;
    private CubaDataContext _context;
    //private VoyagerReserveContext _contextRes;
    private WebDataContext _contextWeb;
    private IConfiguration _configuration;

    public ISessionObject SessionObject { get => sessionObject; set => sessionObject = value; }

    public PriceService(IMemoryCache cache,IConfiguration configuration, VoyagerReserveContext contextRes, IPlaceAdapter placeAdapter, IHotelAdapter hotelAdapter, IFlightAdapter flightAdapter,ITransferAdapter transferAdapter, IUserItinAdapter userItinAdapter, CubaDataContext context, WebDataContext contextWeb)
    {
        suppliersTable = FactoryUtils.CheckCache<CodeWorksVoyWebService.Models.VoyagerReserve.Suppliers>(ref cache, contextRes, suppliersTable, "SuppliersTable");
        priceMultiplyierTable = FactoryUtils.CheckCache<CodeWorksVoyWebService.Models.CubaData.PriceMultiplyier>(ref cache, context, priceMultiplyierTable, "PriceMultiplyierTable");
        flightCostsTable = FactoryUtils.CheckCache<CodeWorksVoyWebService.Models.CubaData.FlightCosts>(ref cache, context, flightCostsTable, "FlightCostsTable");
        pscTable = FactoryUtils.CheckCache<CodeWorksVoyWebService.Models.CubaData.Psc>(ref cache, context, pscTable, "PscTable");
        pricesOtherTable = FactoryUtils.CheckCache<CodeWorksVoyWebService.Models.CubaData.PricesOther>(ref cache, context, pricesOtherTable, "PricesOtherTable");
        aptRatesTable = FactoryUtils.CheckCache<CodeWorksVoyWebService.Models.CubaData.Aptrates>(ref cache, context, aptRatesTable, "AptRatesTable");
        transferLogicTable = FactoryUtils.CheckCache<CodeWorksVoyWebService.Models.CubaData.TransferLogic>(ref cache, context, transferLogicTable, "TransferLogicTable");
        defaultTransfersTable = FactoryUtils.CheckCache<CodeWorksVoyWebService.Models.CubaData.DefaultTransfers>(ref cache, context, defaultTransfersTable, "DefaultTransfersTable");

        _configuration = configuration;
        //_contextRes = contextRes;
        _placeAdapter = placeAdapter;
        _hotelAdapter = hotelAdapter;
        _flightAdapter = flightAdapter;
        _transferAdapter = transferAdapter;
        _userItinAdapter = userItinAdapter;
        _contextWeb = contextWeb;
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

        CodeWorksVoyWebService.Models.CubaData.PriceMultiplyier row= priceMultiplyierTable.Where(p => p.Id == centers).First();
        multiplier = Convert.ToDecimal(row.Multiplier);
        return multiplier;
    }

    public decimal getFlightCost(int outFlightID, int supplierId)
    {
        decimal flightCost = 0;


        List<CodeWorksVoyWebService.Models.CubaData.FlightCosts> tableOut = flightCostsTable.Where(f => f.FlightId == outFlightID && f.UseIt == "Y").ToList();
        //DateTime selectedDateTime = new DateTime();
        foreach (CodeWorksVoyWebService.Models.CubaData.FlightCosts row in tableOut)
        {
            flightCost = Convert.ToDecimal(row.Cost);
        }
        if (flightCost == 0) {
            List<CodeWorksVoyWebService.Models.VoyagerReserve.Suppliers> suppTable = suppliersTable.Where(s => s.SupplierId == supplierId).ToList();

            foreach (CodeWorksVoyWebService.Models.VoyagerReserve.Suppliers row in suppTable)
            {
                flightCost = Convert.ToDecimal(row.DefaultPrice);
            }
        }

        return flightCost;
    }

    public decimal getPSC(int supplierID, string airportCode)
    {
        List<CodeWorksVoyWebService.Models.CubaData.Psc> table = pscTable.Where(p => p.DepAirport == airportCode && p.SupplierId == supplierID).ToList();
        foreach (CodeWorksVoyWebService.Models.CubaData.Psc row in table)
        {
            return Convert.ToDecimal(row.Dep);
        }
        return 0;
    }

    public decimal getRepPrice()
    {
        // Get Rep Charge.
        decimal repCharge = 0;


        CodeWorksVoyWebService.Models.CubaData.PricesOther row = pricesOtherTable.Where(p => p.Name == "RepCharge").First();

        repCharge = Convert.ToDecimal(row.Price);

        return repCharge;
    }

    public decimal getAptCharge(int supplierID)
    {

        // Set apt to supplierID apt price.
        decimal apt = 0;

        CodeWorksVoyWebService.Models.CubaData.Aptrates row = aptRatesTable.Where(a => a.TaxCode == "ZZ" && a.SupplierId == supplierID).OrderByDescending(a => a.StartDate).First();

        apt = Convert.ToDecimal(row.Aptrate);

        // If apt is zero lookup the default apt price;
        if (apt == 0)
        {
            row = aptRatesTable.Where(a => a.TaxCode == "ZZ" && a.SupplierId == 0).OrderByDescending(a => a.StartDate).First();
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
        List<CodeWorksVoyWebService.Models.CubaData.ContractRates> tablePrices;
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
                foreach (CodeWorksVoyWebService.Models.CubaData.ContractRates row in tablePrices)
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
        List<CodeWorksVoyWebService.Models.CubaData.TransferLogic> transTable;

        foreach (TransferNode transNode in transferNodes)
        {
            transTable = transferLogicTable.Where(t => t.Id == transNode.TransferID).ToList();
            foreach (CodeWorksVoyWebService.Models.CubaData.TransferLogic transRow in transTable)
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
        decimal price = Convert.ToDecimal(defaultTransfersTable.Where(d => d.TransferId == groundID).Select(d => d.Price).First());
        return price;
    }
    catch (Exception e){return 0;}
       
    }

    public int getNearestTimeID()
    {

        List<CodeWorksVoyWebService.Models.WebData.ItinTemplateTimeIdlookup> tableTimeIdLookup = _contextWeb.ItinTemplateTimeIdlookup.ToList();
        DateTime now = DateTime.Now;
        DateTime tempTime;
        int intM = now.Month;
        int timeID = 1;
        int lowestDays = 365;
        foreach (CodeWorksVoyWebService.Models.WebData.ItinTemplateTimeIdlookup row in tableTimeIdLookup)
        {
            int intD = Convert.ToDateTime(row.Date).Month;
            if (intD == intM)
            {

                timeID = Convert.ToInt32(row.TimeId);
                break;
            }
        }
        return timeID;
    }

    public List<DateTime> getTimeIDDates()
    {
        List<DateTime> timeObjs = new List<DateTime>();
        
       List<CodeWorksVoyWebService.Models.WebData.ItinTemplateTimeIdlookup> tableTimeIdLookup = _contextWeb.ItinTemplateTimeIdlookup.ToList();


        foreach (CodeWorksVoyWebService.Models.WebData.ItinTemplateTimeIdlookup row in tableTimeIdLookup)
        {
            DateTime timeObj = new DateTime();

            timeObj = Convert.ToDateTime(row.Date);
            timeObjs.Add(timeObj);
        }
        return timeObjs;
    }


    public List<DateTime> getTimeIDDatesAdjusted()
    {
        List<DateTime> timeObjs = new List<DateTime>();
        
           int nowTimeID = getNearestTimeID();
       List<CodeWorksVoyWebService.Models.WebData.ItinTemplateTimeIdlookup> tableTimeIdLookup = _contextWeb.ItinTemplateTimeIdlookup.ToList();


        foreach (CodeWorksVoyWebService.Models.WebData.ItinTemplateTimeIdlookup row in tableTimeIdLookup)
        {      
            DateTime timeObj = new DateTime();
            if (row.TimeId < nowTimeID) { timeObj = Convert.ToDateTime(row.Date).AddYears(1); }
            else { timeObj = Convert.ToDateTime(row.Date); }

            timeObjs.Add(timeObj);
        }
        return timeObjs;
    }




    public List<ItinTemplateTimeObj> getItinTemplatePrices(int userItinId)
    {
        List<ItinTemplateTimeObj> timeObjs = new List<ItinTemplateTimeObj>();

        List<CodeWorksVoyWebService.Models.WebData.ItinTemplateTimeId> tableTimeId= _contextWeb.ItinTemplateTimeId.Where(t => t.UserItinId == userItinId).ToList();

        int timeID = getNearestTimeID();
        foreach (CodeWorksVoyWebService.Models.WebData.ItinTemplateTimeId row in tableTimeId)
        {
            ItinTemplateTimeObj timeObj = new ItinTemplateTimeObj();
            if (row.TimeId < timeID)
            {
                timeObj.Price = Convert.ToDecimal(row.Price) * 1.0M;
            }
            else
            {
                timeObj.Price = Convert.ToDecimal(row.Price);
            }
            timeObj.TimeID = Convert.ToInt32(row.TimeId);
            timeObjs.Add(timeObj);
        }
        return timeObjs;
    }




    public List<ItinTemplateTimeObj> getItinTemplateTimeObjsEscorted(int timeId)
    {
        List<ItinTemplateTimeObj> timeObjs = new List<ItinTemplateTimeObj>();
        List<CodeWorksVoyWebService.Models.WebData.ItinTemplateTimeIdescorted> tableTimeId = _contextWeb.ItinTemplateTimeIdescorted.Where(t => t.TimeId == timeId).ToList();

        int timeID = getNearestTimeID();
        foreach (CodeWorksVoyWebService.Models.WebData.ItinTemplateTimeIdescorted row in tableTimeId)
        {
            ItinTemplateTimeObj timeObj = new ItinTemplateTimeObj();
            timeObj.TemplateType = row.TemplateName;
            if (row.TimeId < timeID)
            {
                timeObj.Price = Convert.ToDecimal(row.Price) * 1.0M;
            }
            else
            {
                timeObj.Price = Convert.ToDecimal(row.Price);
            }
            timeObj.TimeID = Convert.ToInt32(row.TimeId);
            timeObjs.Add(timeObj);
        }
        return timeObjs;
    }


    public List<ItinTemplateTimeObj> getItinTemplateTimeObjs(int timeId)
    {
        List<ItinTemplateTimeObj> timeObjs = new List<ItinTemplateTimeObj>();
        int timeID = getNearestTimeID();

        List<CodeWorksVoyWebService.Models.WebData.AdminItinTemplates> tableAdminTemplates= _contextWeb.AdminItinTemplates.ToList();
        List<CodeWorksVoyWebService.Models.WebData.TemplateTypes> tableTemplateTypes = _contextWeb.TemplateTypes.ToList();
        List<CodeWorksVoyWebService.Models.WebData.ItinTemplateTimeId> tableTimeIds = _contextWeb.ItinTemplateTimeId.ToList();

        var joinedTable = tableAdminTemplates  // your starting point - table in the "from" statement
                  .Join(tableTimeIds, // the source table of the inner join
                  a => a.AdminItinId,
                  t => t.UserItinId,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
                                            // Select the foreign key (the second part of the "on" clause)
                     (a, t) => new { A = a, T = t }) // selection
                  .Where(joined => joined.T.TimeId == timeId).Select(s => new ItinTemplateObj( (int)s.A.AdminItinId ,(int)s.A.TemplateTypeId, (decimal)s.T.Price, (int)s.T.TimeId)).ToList();
        foreach (var row in joinedTable)
        {
            
            CodeWorksVoyWebService.Models.WebData.TemplateTypes templateTypeRow = tableTemplateTypes.Where(t => t.TemplateTypeId==row.TemplateTypeId ).First();
            ItinTemplateTimeObj timeObj = new ItinTemplateTimeObj();
            timeObj.TemplateType = templateTypeRow.TemplateType;
            timeObj.TemplateTypeID = row.TemplateTypeId;
            timeObj.CountID = row.CountID;
            if (row.TimeId < timeID)
            {
                timeObj.Price = row.Price * 1.0M;
            }
            else
            {
                timeObj.Price = row.Price;
            }
            timeObj.UserItinID = row.AdminItinID;
            timeObj.TimeID = row.TimeId;
            timeObjs.Add(timeObj);
        }
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
        List<CodeWorksVoyWebService.Models.WebData.ItinTemplateTimeIdlookup> tableLookup = _contextWeb.ItinTemplateTimeIdlookup.ToList();
        List<CodeWorksVoyWebService.Models.WebData.ItinTemplateTimeId> tableDel = _contextWeb.ItinTemplateTimeId.ToList();
        _contextWeb.ItinTemplateTimeId.RemoveRange(tableDel);
        _contextWeb.SaveChanges();
        // ItinTemplateTimeIDTableAdapter adaptWrite = new ItinTemplateTimeIDTableAdapter();
        //adaptWrite.DeleteQuery();

        CodeWorksVoyWebService.Models.WebData.ItinTemplateTimeId timeIdEntity;
        List<CodeWorksVoyWebService.Models.WebData.ItinTemplateTimeId> tableWrite = _contextWeb.ItinTemplateTimeId.ToList();

        List<CodeWorksVoyWebService.Models.WebData.AdminItinTemplates> tableTemplate = _contextWeb.AdminItinTemplates.ToList();

        //AdminTemplatesTableAdapter adaptTemplate = new AdminTemplatesTableAdapter();
        //AdminItinData.AdminTemplatesDataTable tableTemplate = adaptTemplate.GetData();

        _userItinAdapter.AdminTemplate = true;


         SessionObject.Flight.SupplierID=Convert.ToInt16(_configuration.GetSection("AppConfiguration")["DefaultFlightSupplierIDForTemplatePriceCalc"]);
       
        StringBuilder str = new StringBuilder();

        foreach (CodeWorksVoyWebService.Models.WebData.AdminItinTemplates rowTemplate in tableTemplate)
        {

            foreach (CodeWorksVoyWebService.Models.WebData.ItinTemplateTimeIdlookup rowLookup in tableLookup)
            {
                try
                {
                    CodeWorksVoyWebService.Models.WebData.UserItinerary userItin = _userItinAdapter.getAdminItin(Convert.ToInt32(rowTemplate.AdminItinId));
                    int itinID = userItin.ItinId;
                    SessionObject.PRSelections = _userItinAdapter.getItinPlaces(itinID);
                    SessionObject.TransferNodes = _userItinAdapter.getTransfersNodes(itinID);

                    DateTime useDate = adjustDate(Convert.ToDateTime(rowLookup.Date));
                    if (rowLookup.TimeId == 4 && rowLookup.TimeId == 14) {
                        int distance = 7;
                        if (rowLookup.TimeId == 4) distance = 24;

                        SessionObject.Flight.StartDate = getFlightDate(useDate, distance, true, SessionObject.Flight.SupplierID);
                 
                    }
                    else
                    {
                        SessionObject.Flight.StartDate = getFlightDate(useDate, 3, false, SessionObject.Flight.SupplierID);
                    }
                        int totalNights = 0;
                    foreach (PRSelection selection in SessionObject.PRSelections)
                    {
                        totalNights += selection.Nights;
                    }
                    SessionObject.Flight.EndDate = SessionObject.Flight.StartDate.AddDays(totalNights);

                   

                    List<FlightObj> flightObjs = _flightAdapter.getOutFlightsByDateRange(SessionObject.Flight.SupplierID, SessionObject.Flight.StartDate, SessionObject.Flight.StartDate);
                    SessionObject.Flight.OutFlightID = 0;
                    foreach (FlightObj row in flightObjs)
                    {

                        SessionObject.Flight.OutFlightID = row.OutFlightID;
                        break;
                    }
                
                    getPrice();
                  
                    string debugStr = SessionObject.PriceBrakeDown;

                    timeIdEntity = new CodeWorksVoyWebService.Models.WebData.ItinTemplateTimeId();
                    timeIdEntity.TimeId= rowLookup.TimeId;
                    timeIdEntity.UserItinId = (int)rowTemplate.AdminItinId;
                    timeIdEntity.Price = SessionObject.TotalCost;
                    tableWrite.Add(timeIdEntity);
                  
                    if (SessionObject.Flight.FlightCost == 0) {
                        str.Append("<br/>Successfully update price where IndexName=" + rowTemplate.AccordianName + " Date range=" + rowLookup.TimeRangeName + "<span STYLE='color : #FF0000;'> Price=" + SessionObject.TotalCost + "</span> Date used was : " + SessionObject.Flight.StartDate);
                 
                    }
                    else
                    {
                        str.Append("<br/>Successfully update price where IndexName=" + rowTemplate.AccordianName + " Date range=" + rowLookup.TimeRangeName + " Price=" + SessionObject.TotalCost + " Date used was : " + SessionObject.Flight.StartDate);
                    }
                    str.Append("<br/>"+debugStr+"<br/>");
                    }
                catch (Exception ex)
                {
                    str.Append("<br/>Failed to  update price where IndexName=" + rowTemplate.AccordianName + " Date range=" + rowLookup.TimeRangeName + "<br/>Error was : " + ex.Message);
                }

            }
        }
      
        _contextWeb.ItinTemplateTimeId.AddRange(tableWrite);
        _contextWeb.SaveChanges();
        return str.ToString();
          
    }

    private DateTime getFlightDate(DateTime startDate, int distance, bool highest, int supplierID)
    {
        
        DateTime date = new DateTime();
        
       
        date = getFlightID(startDate, distance,highest, supplierID);
        if (!highest && date!=DateTime.MinValue) return date;

        date = getFlightID(startDate.AddYears(-1), distance,highest, supplierID);
        if (!highest && date != DateTime.MinValue) return date;
        
        return date;
    }

    private DateTime getFlightID(DateTime startDate, int distance, bool highest, int supplierID) {
        DateTime date = new DateTime();
        DateTime highDate = new DateTime();
        
        int outFlightID = 0;
        decimal highPrice=0;

        for (int i = 0; i < distance; i++)
        {
            date = startDate.AddDays(i);
            List<FlightObj> flightObjs = _flightAdapter.getOutFlightsByDateRange(supplierID, date, date);
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
            flightObjs = _flightAdapter.getOutFlightsByDateRange(supplierID, date, date);
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
        }
        return highDate;
    }
}
