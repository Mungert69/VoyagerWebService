using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HotelPriceObj
/// </summary>
public class HotelPriceObj
{
    private decimal price;

    public decimal Price
    {
        get { return price; }
        set { price = value; }
    }

    private string priceDetail;

    public string PriceDetail
    {
        get { return priceDetail; }
        set { priceDetail = value; }
    }
}
