using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using System.Collections.Generic;

using System.Data.SqlClient;
using CodeWorkVoyWebService.Models.CubaData;
using Microsoft.EntityFrameworkCore;
using CodeWorkVoyWebService.Bussiness_Logic.Bussiness_Objects;
using Microsoft.Extensions.Caching.Memory;
using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;
/// <summary>
/// Summary description for TransferAdapter
/// </summary>
public class TransferAdapter : ITransferAdapter
{
    //private readonly CubaDataContext _context;
    private readonly IPlaceAdapter _placeAdapter;
    private readonly List<CodeWorkVoyWebService.Models.CubaData.TransferLogic> transferLogicTable;
    public TransferAdapter(IMemoryCache cache,CubaDataContext context, IPlaceAdapter placeAdapter)
	{
        transferLogicTable = FactoryUtils.CheckCache<CodeWorkVoyWebService.Models.CubaData.TransferLogic>(ref cache, context, transferLogicTable, "TransferLogicTable");

        //_context = context;
        _placeAdapter = placeAdapter;
    }


    public List<string> getTransferStrings(List<TransferNode> transferNodes) {
        List<string> transferStrings = new List<string>();
        foreach (TransferNode node in transferNodes)
        {
            transferStrings.Add(getTransfers(node.TransferID).TransferItem1);
        }
        return transferStrings;
    }

    public List<TransferNodeItem> getTransferNodeItems(List<TransferNode> transferNodes)
    {
        List<TransferNodeItem> transferNodeItems = new List<TransferNodeItem>();
        TransferNodeItem transferNodeItem;
        foreach (TransferNode node in transferNodes)
        {
            transferNodeItem = new TransferNodeItem();
            transferNodeItem.TransferID = node.TransferID;
            transferNodeItem.WithCar = node.WithCar;
            transferNodeItem.TransferItem = getTransfers(node.TransferID);
            transferNodeItems.Add(transferNodeItem);
        }
        return transferNodeItems;
    }
    public void setDefaultTransfer(string placeOrigin, string placeDestination) {
        /*
        DefaultTransfersTableAdapter adapt = new DefaultTransfersTableAdapter();
        adapt.InsertQuery(placeOrigin, placeDestination, 3,0);
        */
    }

    public  int getTransferID(int prevPlaceID, int selectedPlaceID, bool withCar)
    {
        
       // PlaceAdapter placeAdapter = new PlaceAdapter();
        string origin = _placeAdapter.getPlaceName(prevPlaceID);
        string destination = _placeAdapter.getPlaceName(selectedPlaceID);
        int transferID;
        if (withCar) {
            transferID = transferLogicTable.Where(t => t.Origin == origin && t.Destination == destination && t.PossibleAsCarHire == true).Select(t => t.Id).First();

        }
        else {
            transferID = transferLogicTable.Where(t => t.Origin == origin && t.Destination == destination && t.PossibleAsTransfer == true).Select(t => t.Id).First();


        }
        return transferID;
        
       
    }

    public int getTransferCount(string origination, string destination) {
        /*
        DefaultTransfersTableAdapter adapt = new DefaultTransfersTableAdapter();
        return Convert.ToInt32(adapt.ScalarQuery(origination, destination));
        */
        return 0;
       
    }


    public List<int> getNextHops(int originID, bool withCar)
    {
        string origin = _placeAdapter.getPlaceName(originID);
        return getListOfHops(origin, withCar);
    }


    private List<int> getListOfHops(string origin,bool withCar) {
        List<int> hops = new List<int>();
        List<string> destPlaceNames;
        if (!withCar)
        {
            //TODO check if there is another way rather than using zoomLevel to filterd airports from possible transfers
            destPlaceNames = transferLogicTable.Join(_placeAdapter.PlacesTable, t => t.Destination, p => p.PlaceName, (t, p) => new { T = t, P = p }).Where(joined => joined.T.PossibleAsTransfer == true && joined.T.Origin == origin && joined.P.ZoomLevel > 0).Select(s => s.T.Destination).ToList();

        }
        else
        {
            destPlaceNames = transferLogicTable.Join(_placeAdapter.PlacesTable, t => t.Destination, p => p.PlaceName, (t, p) => new { T = t, P = p }).Where(joined => joined.T.PossibleAsCarHire == true && joined.T.Origin == origin && joined.P.ZoomLevel > 0).Select(s => s.T.Destination).ToList();

        }
        int tempName;
        foreach (string row in destPlaceNames)
        {
            tempName = _placeAdapter.getPlaceNameID(row);

            hops.Add(tempName);
        }
        return hops;

    }

    public List<int> getNextAirportHops(int originID, bool withCar)
    {
        string origin = _placeAdapter.getAirportName(originID);
       
        return getListOfHops(origin,withCar);
    }

    public bool checkLastTransferIsComplete(int airportID, int transferID)
    {

        string destination = _placeAdapter.getAirportName(airportID);
        int count = 0;
       
            count = transferLogicTable.Where(t => t.Id == transferID && t.Destination == destination).Count();

       

        if (count != 0) return true;
        else return false;


    }

    public  bool lastHopAirport(int airportID, int lastPlace, bool withCar) {
        
        string origin = _placeAdapter.getPlaceName(lastPlace);
        string destination = _placeAdapter.getAirportName(airportID);
        int count = 0;
        if (withCar)
        {
            count =transferLogicTable.Where(t => t.PossibleAsCarHire == true && t.Origin == origin && t.Destination == destination).Count();
            
                }
        else
        {
            count = transferLogicTable.Where(t => t.PossibleAsTransfer == true && t.Origin == origin && t.Destination == destination).Count();
        }

        if (count!=0) return true;
        else return false;
        
    
    }
    public TransferObj getTransfers(int transferID) {
        TransferObj transferObj = new TransferObj();
        CodeWorkVoyWebService.Models.CubaData.TransferLogic transfer = transferLogicTable.Where(t => t.Id==transferID).First();
       
            transferObj.CarHireCopy1 = transfer.CarHireCopy1;
            transferObj.CarHireCopy2 = transfer.CarHireCopy2;
            transferObj.CarHireCopy3 = transfer.CarHireCopy3;
            transferObj.CarOrder1 = transfer.CarOrder1;
            transferObj.CarOrder2 = transfer.CarOrder2;
            transferObj.CarOrder3 = transfer.CarOrder3;
            transferObj.CarOrder4 = transfer.CarOrder4;
            transferObj.CarOrder5 = transfer.CarOrder5;
            transferObj.CarOrder6 = transfer.CarOrder6;
            transferObj.CarOrder7 = transfer.CarOrder7;
            transferObj.CarOrder8 = transfer.CarOrder8;
            transferObj.CollectDrop = transfer.CollectDrop;
            transferObj.CombinationRequired = (bool)transfer.CombinationRequired;
            transferObj.Destination = transfer.Destination;
            transferObj.DestinationCarRentalOffice = (bool)transfer.DestinationCarRentalOffice;
            transferObj.Distance = (int)transfer.Distance;
            transferObj.DrivingTime = (float)transfer.DrivingTime;
            transferObj.FlightID1 = (int)transfer.FlightId1;
            transferObj.FlightID2 = (int)transfer.FlightId2;
            transferObj.FlightID3 = (int)transfer.FlightId3;
            transferObj.FlightID4 = (int)transfer.FlightId4;
            transferObj.FlyDrivePrice = (decimal)transfer.FlyDrivePrice;
            transferObj.GroundID1 = (int)transfer.GroundId1;
            transferObj.GroundID2 = (int)transfer.GroundId2;
            transferObj.GroundID3 = (int)transfer.GroundId3;
            transferObj.GroundID4 = (int)transfer.GroundId4;
            transferObj.Id = transfer.Id;
            transferObj.Item1Included = (bool)transfer.Item1Included;
            transferObj.Item2Included = (bool)transfer.Item2Included;
            transferObj.Item3Included = (bool)transfer.Item3Included;
            transferObj.Item4Included = (bool)transfer.Item4Included;
            transferObj.ItemPrice1 = (decimal)transfer.ItemPrice1;
            transferObj.ItemPrice2 = (decimal)transfer.ItemPrice2;
            transferObj.ItemPrice3 = (decimal)transfer.ItemPrice3;
            transferObj.ItemPrice4 = (decimal)transfer.ItemPrice4;
            transferObj.NotPossible = (bool)transfer.NotPossible;
            transferObj.Origin = transfer.Origin;
            transferObj.OriginCarRentalOffice = (bool)transfer.OriginCarRentalOffice;
            transferObj.PossibleAsCarHire = (bool)transfer.PossibleAsCarHire;
            transferObj.PossibleAsTransfer = (bool)transfer.PossibleAsCarHire;
            transferObj.TotalPrice = (decimal)transfer.TotalPrice;
            transferObj.TransferItem1 = transfer.TransferItem1;
            transferObj.TransferItem2 = transfer.TransferItem2;
            transferObj.TransferItem3 = transfer.TransferItem3;
            transferObj.TransferItem4 = transfer.TransferItem4;
            transferObj.TransferNote = transfer.TransferNote;
            transferObj.TransferPrice = (decimal)transfer.TransferPrice;
           
        
        return transferObj;
    }

}
