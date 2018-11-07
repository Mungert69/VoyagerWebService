using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;

/// <summary>
/// Summary description for TransferFilter
/// </summary>
public class TransferFilter
{

    private int numberOfCentres = 0;

    public int NumberOfCentres
    {
        get { return numberOfCentres; }
        set { numberOfCentres = value; }
    }
     private bool possibleByCar = false;

     public bool PossibleByCar
     {
         get { return possibleByCar; }
         set { possibleByCar = value; }
     }
 private bool possibleByTransfers = false;

 public bool PossibleByTransfers
 {
     get { return possibleByTransfers; }
     set { possibleByTransfers = value; }
 }
    private bool possibleByCombination = false;

    public bool PossibleByCombination
    {
        get { return possibleByCombination; }
        set { possibleByCombination = value; }
    }
    private bool havanaAndEnvirons = false;

    public bool HavanaAndEnvirons
    {
        get { return havanaAndEnvirons; }
        set { havanaAndEnvirons = value; }
    }
    private bool havanaAndSouthCoast = false;

    public bool HavanaAndSouthCoast
    {
        get { return havanaAndSouthCoast; }
        set { havanaAndSouthCoast = value; }
    }
    private bool easternCuba = false;

    public bool EasternCuba
    {
        get { return easternCuba; }
        set { easternCuba = value; }
    }
    private bool havanaAndIslands = false;

    public bool HavanaAndIslands
    {
        get { return havanaAndIslands; }
        set { havanaAndIslands = value; }
    }
    private bool wholeIsland = false;

    public bool WholeIsland
    {
        get { return wholeIsland; }
        set { wholeIsland = value; }
    }
    private bool beach = false;

    public bool Beach
    {
        get { return beach; }
        set { beach = value; }
    }
    private bool d7 = false;

    public bool D7
    {
        get { return d7; }
        set { d7 = value; }
    }
    private bool d10 = false;

    public bool D10
    {
        get { return d10; }
        set { d10 = value; }
    }
    private bool d14 = false;

    public bool D14
    {
        get { return d14; }
        set { d14 = value; }
    }
    private bool d17 = false;

    public bool D17
    {
        get { return d17; }
        set { d17 = value; }
    }
    private bool d21 = false;

    public bool D21
    {
        get { return d21; }
        set { d21 = value; }
    }
	
}
