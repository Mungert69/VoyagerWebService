using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using System.Collections.Generic;
using System.Text;
using CodeWorksVoyWebService.Models.CubaData;
using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;
using CodeWorksVoyWebService.Models.VoyagerReserve;
using CodeWorksVoyWebService.Bussiness_Logic.Bussiness_Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

/// <summary>
/// Summary description for PlaceAdapter
/// </summary>
public class PicturesAdapter : IPicturesAdapter
{
    // private readonly CubaDataContext _context;
    private readonly List<CodeWorksVoyWebService.Models.CubaData.Pictures> picturesTable;
    private readonly VoyagerReserveContext _contextRes;
    //private IMemoryCache _cache;

    public PicturesAdapter(CubaDataContext context, IMemoryCache cache, VoyagerReserveContext reserveContext)
    {
        picturesTable = FactoryUtils.CheckCache<CodeWorksVoyWebService.Models.CubaData.Pictures>(ref cache, context, picturesTable, "PicturesTable");

        _contextRes = reserveContext;
        _contextRes.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;


    }

    public List<string> getHotelPics(int selectedHotelID)
    {
        List<string> table;

        table = picturesTable.Where(p => p.AccommodationId == selectedHotelID).OrderBy(p => p.OrderNo).Select(s => s.PicFilename).ToList();

        return table;


    }
    public List<string> getPlacePics(int selectedPlaceID)
    {
        List<string> table;

         table = picturesTable.Where(p => p.PlaceId== selectedPlaceID).OrderBy(p=>p.OrderNo).Select(s=> s.PicFilename).ToList();

        return table;


    }
    public string getPlacePicName(int placeID)
    {

        string selectedImage = "";
        /*
        ResortDataTableAdapters.PicturesTableAdapter adaptPic = new ResortDataTableAdapters.PicturesTableAdapter();
        ResortData.PicturesDataTable tablePic = adaptPic.GetData(placeID);
        foreach (ResortData.PicturesRow row in tablePic)
        {
            selectedImage = "Images/Images-PlacesHotels/" + (string)row.PicFilename;
            //string ext = picName.Substring(picName.LastIndexOf("."));
            //string dest = picName.Substring(0, picName.LastIndexOf(".")) + "-view" + ext;
            break;
        }*/
        return selectedImage;
    }
}
