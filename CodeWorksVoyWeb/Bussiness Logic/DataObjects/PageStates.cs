using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PageStates
/// </summary>
public class PageStates


{
    private bool buttonToggle = false;

    private int numRowsIdeas;

    public int NumRowsIdeas
    {
        get { return numRowsIdeas; }
        set { numRowsIdeas = value; }
    }

    private bool navigateUrlOn;

    public bool NavigateUrlOn
    {
        get { return navigateUrlOn; }
        set { navigateUrlOn = value; }
    }
    private bool altHoverOn;

    public bool AltHoverOn
    {
        get { return altHoverOn; }
        set { altHoverOn = value; }
    }

    private bool adminTemplate;

    public bool AdminTemplate
    {
        get { return adminTemplate; }
        set { adminTemplate = value; }
    }

    private bool deleteSelections;

    public bool DeleteSelections
    {
        get { return deleteSelections; }
        set { deleteSelections = value; }
    }

    private bool skipFlights;

    public bool SkipFlights
    {
        get { return skipFlights; }
        set { skipFlights = value; }
    }

    private bool flightSelected;

    public bool FlightSelected
    {
        get { return flightSelected; }
        set { flightSelected = value; }
    }

    private bool startSelected;

    public bool StartSelected
    {
        get { return startSelected; }
        set { startSelected = value; }
    }
    private bool firstPlaceSelected;

    public bool FirstPlaceSelected
    {
        get { return firstPlaceSelected; }
        set { firstPlaceSelected = value; }
    }

    private bool finishSelected;

    public bool FinishSelected
    {
        get { return finishSelected; }
        set { finishSelected = value; }
    }

    private bool isTemplate;

    public bool IsTemplate
    {
        get { return isTemplate; }
        set { isTemplate = value; }
    }

    private bool isTemplateMode;

    public bool IsTemplateMode
    {
        get { return isTemplateMode; }
        set { isTemplateMode = value; }
    }

    private bool adminMode;

    public bool AdminMode
    {
        get { return adminMode; }
        set { adminMode = value; }
    }

    private bool hotelAdded;

    public bool HotelAdded
    {
        get { return hotelAdded; }
        set { hotelAdded = value; }
    }

    public bool ButtonToggle
    {
        get
        {
            return buttonToggle;
        }

        set
        {
            buttonToggle = value;
        }
    }
}
