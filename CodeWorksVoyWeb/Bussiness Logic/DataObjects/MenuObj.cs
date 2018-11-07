using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MenuObj
/// </summary>
public class MenuObj
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
    private string path;

    public string Path
    {
        get { return path; }
        set { path = value; }
    }

    private string menuLevel1;

    public string MenuLevel1
    {
        get { return menuLevel1; }
        set { menuLevel1 = value; }
    }
    private string menuLevel2;

    public string MenuLevel2
    {
        get { return menuLevel2; }
        set { menuLevel2 = value; }
    }
    private string menuLevel3;

    public string MenuLevel3
    {
        get { return menuLevel3; }
        set { menuLevel3 = value; }
    }
    private string menuLevel4;

    public string MenuLevel4
    {
        get { return menuLevel4; }
        set { menuLevel4 = value; }
    }
    private bool useIt;

    public bool UseIt
    {
        get { return useIt; }
        set { useIt = value; }
    }
    private string infoPageName;

    public string InfoPageName
    {
        get { return infoPageName; }
        set { infoPageName = value; }
    }
    private string fileType;

    public string FileType
    {
        get { return fileType; }
        set { fileType = value; }
    }
    private string mapGroupType;

    public string MapGroupType
    {
        get { return mapGroupType; }
        set { mapGroupType = value; }
    }
    private string pictureGroupType;

    public string PictureGroupType
    {
        get { return pictureGroupType; }
        set { pictureGroupType = value; }
    }
    private string seo1;

    public string Seo1
    {
        get { return seo1; }
        set { seo1 = value; }
    }
    private string seo2;

    public string Seo2
    {
        get { return seo2; }
        set { seo2 = value; }
    }

    private string indexPath;

    public string IndexPath
    {
        get { return indexPath; }
        set { indexPath = value; }
    }
}
