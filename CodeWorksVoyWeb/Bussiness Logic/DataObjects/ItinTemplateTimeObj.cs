using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItinTemplateTimeObj
/// </summary>
public class ItinTemplateTimeObj
{

    private int userItinID;

    public int UserItinID
    {
        get { return userItinID; }
        set { userItinID = value; }
    }
    private int timeID;

    public int TimeID
    {
        get { return timeID; }
        set { timeID = value; }
    }
    private decimal price;

    public decimal Price
    {
        get { return price; }
        set { price = value; }
    }

    private int templateTypeID;

    public int TemplateTypeID
    {
        get { return templateTypeID; }
        set { templateTypeID = value; }
    }

    private int countID;

    public int CountID
    {
        get { return countID; }
        set { countID = value; }
    }

    private string templateType;

    public string TemplateType
    {
        get { return templateType; }
        set { templateType = value; }
    }

}
