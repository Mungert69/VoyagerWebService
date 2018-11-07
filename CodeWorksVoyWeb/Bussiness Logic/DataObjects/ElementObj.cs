using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ElementObj
/// </summary>
public class ElementObj
{

    private string text;
    private string colour;
    private string width;

    public string Text
    {
        get
        {
            return text;
        }

        set
        {
            text = value;
        }
    }

    public string Colour
    {
        get
        {
            return colour;
        }

        set
        {
            colour = value;
        }
    }

    public string Width
    {
        get
        {
            return width;
        }

        set
        {
            width = value;
        }
    }

    public ElementObj()
    {
        text = "";
        colour = "";
        width = "";
        //
        // TODO: Add constructor logic here
        //
    }
}