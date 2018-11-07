using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;

/// <summary>
/// Summary description for TransferNode
/// </summary>
public class TransferNode
{

    private int transferID;

    public int TransferID
    {
        get { return transferID; }
        set { transferID = value; }
    }

    private bool withCar;

    public bool WithCar
    {
        get { return withCar; }
        set { withCar = value; }
    }


    public TransferNode() { }

	public TransferNode(int transferID, bool withCar)
	{
        this.transferID = transferID;
        this.withCar = withCar;
	}
}
