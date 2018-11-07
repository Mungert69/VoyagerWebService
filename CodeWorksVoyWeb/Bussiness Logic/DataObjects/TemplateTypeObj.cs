using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TemplateTypeObj
/// </summary>
public class TemplateTypeObj
{
	public TemplateTypeObj()
	{
		//
		// TODO: Add constructor logic here
		//
	}

  

    private int templateTypeID;

    public int TemplateTypeID
    {
        get { return templateTypeID; }
        set { templateTypeID = value; }
    }
    private string templateType;

    public string TemplateType
    {
        get { return templateType; }
        set { templateType = value; }
    }
    private int count;

    public int Count
    {
        get { return count; }
        set { count = value; }
    }
    private bool suppressPrive;

    public bool SuppressPrive
    {
        get { return suppressPrive; }
        set { suppressPrive = value; }
    }
    private string description;

    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    private string title;

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    private int displayOrder;

    public int DisplayOrder
    {
        get { return displayOrder; }
        set { displayOrder = value; }
    }

    private string buttonName;

    public string ButtonName
    {
        get { return buttonName; }
        set { buttonName = value; }
    }
    private string buttonHeading;

    public string ButtonHeading
    {
        get { return buttonHeading; }
        set { buttonHeading = value; }
    }
    private string tripGroupDescriptionShort;

    public string TripGroupDescriptionShort
    {
        get { return tripGroupDescriptionShort; }
        set { tripGroupDescriptionShort = value; }
    }

    private string tripGroupDescriptionLong;

    public string TripGroupDescriptionLong
    {
        get { return tripGroupDescriptionLong; }
        set { tripGroupDescriptionLong = value; }
    }



    private string tripGroupImageBanner;

    public string TripGroupImageBanner
    {
        get { return tripGroupImageBanner; }
        set { tripGroupImageBanner = value; }
    }

    private string tripTag;

    public string TripTag
    {
        get { return tripTag; }
        set { tripTag = value; }
    }


    private string buttonPath;

    public string ButtonPath
    {
        get { return buttonPath; }
        set { buttonPath = value; }
    }
    private bool templated;

    public bool Templated
    {
        get { return templated; }
        set { templated = value; }
    }

    public bool Tour
    {
        get
        {
            return tour;
        }

        set
        {
            tour = value;
        }
    }
    private bool sightseeing;

    public bool Sightseeing
    {
        get
        {
            return sightseeing;
        }

        set
        {
            sightseeing = value;
        }
    }

    private bool tour;


}