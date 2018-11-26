using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItinTemplateObj
/// </summary>
public class ItinTemplateObj
{


    public ItinTemplateObj( int adminItinID, int templateTypeId, decimal price, int timeId)
    {

        this.adminItinID = adminItinID;
        this.templateTypeId = TemplateTypeId;
        this.price = price;
        this.timeId = timeId;
    }

    private int timeId;

    private decimal price;

    private int  templateTypeId;

    private int countID;

    public int CountID
    {
        get { return countID; }
        set { countID = value; }
    }

    private int adminItinID;

    public int AdminItinID
    {
        get { return adminItinID; }
        set { adminItinID = value; }
    }

    private string accordianName;

    public string AccordianName
    {
        get { return accordianName; }
        set { accordianName = value; }
    }

    private int indexOrder;

    public int IndexOrder
    {
        get { return indexOrder; }
        set { indexOrder = value; }
    }

    private string pageTitle;

    public string PageTitle
    {
        get { return pageTitle; }
        set { pageTitle = value; }
    }

    private string pageDescription;

    public string PageDescription
    {
        get { return pageDescription; }
        set { pageDescription = value; }
    }

    private string templateType;

    public string TemplateType
    {
        get { return templateType; }
        set { templateType = value; }
    }

    private string fileName;

    public string FileName
    {
        get { return fileName; }
        set { fileName = value; }
    }

    private bool suppressPrice;

    public bool SuppressPrice
    {
        get { return suppressPrice; }
        set { suppressPrice = value; }
    }

    private string notes;

    public string Notes
    {
        get { return notes; }
        set { notes = value; }
    }

    private int displayOrder;

    public ItinTemplateObj()
    {
    }

    public int DisplayOrder
    {
        get { return displayOrder; }
        set { displayOrder = value; }
    }

    public int TemplateTypeId { get => templateTypeId; set => templateTypeId = value; }
    public decimal Price { get => price; set => price = value; }
    public int TimeId { get => timeId; set => timeId = value; }
}
