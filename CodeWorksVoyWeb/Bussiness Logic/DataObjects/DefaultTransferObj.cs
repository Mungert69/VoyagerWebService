using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DefaultTransferObj
/// </summary>
public class DefaultTransferObj
{
    private int transferID;

    public int TransferID
    {
        get { return transferID; }
        set { transferID = value; }
    }
    private string origination;

    public string Origination
    {
        get { return origination; }
        set { origination = value; }
    }
    private string destination;

    public string Destination
    {
        get { return destination; }
        set { destination = value; }
    }
    private int type;

    public int Type
    {
        get { return type; }
        set { type = value; }
    }
    private decimal price;

    public decimal Price
    {
        get { return price; }
        set { price = value; }
    }
}
