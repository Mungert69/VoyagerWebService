using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;

/// <summary>
/// Summary description for PicObj
/// </summary>
public class PicObj
{
    private string fileName;

    private string thumbName;

    public string ThumbName
    {
        get { return thumbName; }
        set { thumbName = value; }
    }

    private bool isImage;

    public bool IsImage
    {
        get { return isImage; }
        set { isImage = value; }
    }

    public string FileName
    {
        get { return fileName; }
        set { fileName = value; }
    }
    private string caption;

    public string Caption
    {
        get { return caption; }
        set { caption = value; }
    }

  

    public PicObj(string fileName, string caption)
    {
        this.fileName = fileName;
        this.caption = caption;
    
    }

    public PicObj() { }
	
}
