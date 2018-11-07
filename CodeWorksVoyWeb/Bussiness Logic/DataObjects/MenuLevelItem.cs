using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MenuLevel1Item
/// </summary>
public class MenuLevelItem
{

    private int priority;

    public int Priority
    {
        get { return priority; }
        set { priority = value; }
    }
    private bool visible;

    public bool Visible
    {
        get { return visible; }
        set { visible = value; }
    }

    private string level;

    public string Level
    {
        get { return level; }
        set { level = value; }
    }
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private string path;

    public string Path
    {
        get { return path; }
        set { path = value; }
    }
}
