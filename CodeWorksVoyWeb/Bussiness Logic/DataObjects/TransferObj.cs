using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Transfer
/// </summary>
public class TransferObj
{
    

    private int id;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
   private string origin;

   public string Origin
   {
       get { return origin; }
       set { origin = value; }
   }
private string destination;

public string Destination
{
    get { return destination; }
    set { destination = value; }
}
private float drivingTime;

public float DrivingTime
{
    get { return drivingTime; }
    set { drivingTime = value; }
}
private int distance;

public int Distance
{
    get { return distance; }
    set { distance = value; }
}
private bool possibleAsTransfer;

public bool PossibleAsTransfer
{
    get { return possibleAsTransfer; }
    set { possibleAsTransfer = value; }
}
private bool possibleAsCarHire;

public bool PossibleAsCarHire
{
    get { return possibleAsCarHire; }
    set { possibleAsCarHire = value; }
}
private bool combinationRequired;

public bool CombinationRequired
{
    get { return combinationRequired; }
    set { combinationRequired = value; }
}
private string transferNote;

public string TransferNote
{
    get { return transferNote; }
    set { transferNote = value; }
}
private string transferItem1="";

public string TransferItem1
{
    get { return transferItem1; }
    set { transferItem1 = value; }
}
private bool item1Included;

public bool Item1Included
{
    get { return item1Included; }
    set { item1Included = value; }
}
private string carOrder1;

public string CarOrder1
{
    get { return carOrder1; }
    set { carOrder1 = value; }
}
private string transferItem2;

public string TransferItem2
{
    get { return transferItem2; }
    set { transferItem2 = value; }
}
private bool item2Included;

public bool Item2Included
{
    get { return item2Included; }
    set { item2Included = value; }
}
private string carOrder2;

public string CarOrder2
{
    get { return carOrder2; }
    set { carOrder2 = value; }
}
private string transferItem3;

public string TransferItem3
{
    get { return transferItem3; }
    set { transferItem3 = value; }
}
private bool item3Included;

public bool Item3Included
{
    get { return item3Included; }
    set { item3Included = value; }
}
private string carOrder3;

public string CarOrder3
{
    get { return carOrder3; }
    set { carOrder3 = value; }
}
private string transferItem4;

public string TransferItem4
{
    get { return transferItem4; }
    set { transferItem4 = value; }
}
private bool item4Included;

public bool Item4Included
{
    get { return item4Included; }
    set { item4Included = value; }
}
private string carOrder4;

public string CarOrder4
{
    get { return carOrder4; }
    set { carOrder4 = value; }
}
private string carHireCopy1;

public string CarHireCopy1
{
    get { return carHireCopy1; }
    set { carHireCopy1 = value; }
}
private string carHireCopy2;

public string CarHireCopy2
{
    get { return carHireCopy2; }
    set { carHireCopy2 = value; }
}
private string carHireCopy3;

public string CarHireCopy3
{
    get { return carHireCopy3; }
    set { carHireCopy3 = value; }
}
private string carOrder5;

public string CarOrder5
{
    get { return carOrder5; }
    set { carOrder5 = value; }
}
private string carOrder6;

public string CarOrder6
{
    get { return carOrder6; }
    set { carOrder6 = value; }
}
private string carOrder7;

public string CarOrder7
{
    get { return carOrder7; }
    set { carOrder7 = value; }
}
private bool originCarRentalOffice;

public bool OriginCarRentalOffice
{
    get { return originCarRentalOffice; }
    set { originCarRentalOffice = value; }
}
private bool destinationCarRentalOffice;

public bool DestinationCarRentalOffice
{
    get { return destinationCarRentalOffice; }
    set { destinationCarRentalOffice = value; }
}
private decimal transferPrice;

public decimal TransferPrice
{
    get { return transferPrice; }
    set { transferPrice = value; }
}
private decimal flyDrivePrice;

public decimal FlyDrivePrice
{
    get { return flyDrivePrice; }
    set { flyDrivePrice = value; }
}
private string collectDrop;

public string CollectDrop
{
    get { return collectDrop; }
    set { collectDrop = value; }
}
private string carOrder8;

public string CarOrder8
{
    get { return carOrder8; }
    set { carOrder8 = value; }
}
private bool notPossible;

public bool NotPossible
{
    get { return notPossible; }
    set { notPossible = value; }
}
private decimal totalPrice;

public decimal TotalPrice
{
    get { return totalPrice; }
    set { totalPrice = value; }
}
private decimal itemPrice1;

public decimal ItemPrice1
{
    get { return itemPrice1; }
    set { itemPrice1 = value; }
}
private decimal itemPrice2;

public decimal ItemPrice2
{
    get { return itemPrice2; }
    set { itemPrice2 = value; }
}
private decimal itemPrice3;

public decimal ItemPrice3
{
    get { return itemPrice3; }
    set { itemPrice3 = value; }
}
private decimal itemPrice4;

public decimal ItemPrice4
{
    get { return itemPrice4; }
    set { itemPrice4 = value; }
}
private int flightID1;

public int FlightID1
{
    get { return flightID1; }
    set { flightID1 = value; }
}
private int flightID2;

public int FlightID2
{
    get { return flightID2; }
    set { flightID2 = value; }
}
private int flightID3;

public int FlightID3
{
    get { return flightID3; }
    set { flightID3 = value; }
}
private int flightID4;

public int FlightID4
{
    get { return flightID4; }
    set { flightID4 = value; }
}
private int groundID1;

public int GroundID1
{
    get { return groundID1; }
    set { groundID1 = value; }
}
private int groundID2;

public int GroundID2
{
    get { return groundID2; }
    set { groundID2 = value; }
}
private int groundID3;

public int GroundID3
{
    get { return groundID3; }
    set { groundID3 = value; }
}
private int groundID4;

public int GroundID4
{
    get { return groundID4; }
    set { groundID4 = value; }
}
}
