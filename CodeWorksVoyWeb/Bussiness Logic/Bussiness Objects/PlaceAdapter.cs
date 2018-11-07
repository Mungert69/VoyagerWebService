using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using System.Collections.Generic;
using System.Text;
using CodeWorkVoyWebService.Models.CubaData;
using CodeWorkVoyWebService.Bussiness_Logic.DataObjects;
using CodeWorkVoyWebService.Models.VoyagerReserve;
using CodeWorkVoyWebService.Bussiness_Logic.Bussiness_Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;

/// <summary>
/// Summary description for PlaceAdapter
/// </summary>
public class PlaceAdapter : IPlaceAdapter
{
   // private readonly CubaDataContext _context;
   private readonly List<CodeWorkVoyWebService.Models.CubaData.Places> placesTable;
    private readonly List<CodeWorkVoyWebService.Models.CubaData.AirportNodes> airportNodesTable;
    private readonly VoyagerReserveContext _contextRes;
    private readonly IPicturesAdapter _picturesAdapter;
    private readonly IVoyResAdapter _voyResAdapter;
    //private IMemoryCache _cache;
    public List<CodeWorkVoyWebService.Models.CubaData.Places> PlacesTable{ get => placesTable; }
    public PlaceAdapter(CubaDataContext context, IMemoryCache cache,IVoyResAdapter voyResAdapter ,VoyagerReserveContext reserveContext, IPicturesAdapter picturesAdapter)
    {
        placesTable = FactoryUtils.CheckCache<CodeWorkVoyWebService.Models.CubaData.Places>(ref cache, context, placesTable, "PlacesTable");
        airportNodesTable = FactoryUtils.CheckCache<CodeWorkVoyWebService.Models.CubaData.AirportNodes>(ref cache, context, airportNodesTable, "AirportNodesTable");


        _voyResAdapter = voyResAdapter;
        _picturesAdapter = picturesAdapter;
        _contextRes = reserveContext;
        _contextRes.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
       
  

    }

   
    public PlaceCardObj getCardFromPlace(int placeId)
    {

        PlaceCardObj card = new PlaceCardObj();
        
        var place = this.getPlaceEntity(placeId);
        card.Id = placeId;
        card.Title = place.PlaceName;
        card.PlaceFeatures = "Feature1 - Feature2 - Feature3 - Feature4";
        card.Panel1 = "Excursions";
        card.Panel2 = "Food";
        card.Panel3 = "Getting There";
        card.Panel4 = "Hotels";
        card.Panel5 = "Beaches";
        card.DescriptionShort=place.PlaceBriefDescription;
        card.DescriptionLong = place.Copy1;
        card.Longitude = place.Longitude;
        card.Latitude = place.Latitude;
        if (card.Latitude == null) card.Latitude = "0";
        if (card.Longitude == null) card.Longitude = "0";
        
        if (place.CountryId != null) {
           
                card.Country = _voyResAdapter.GetCountryById(Convert.ToInt32(place.CountryId));

                card.CountryId = Convert.ToInt32(place.CountryId);
           
        }
        //card.Country = this.getCountryById(place.PlaceNameId);

        List<string> pictures = this.getPlacePics(Convert.ToInt32(placeId));
      
        if (pictures.Count > 0)
        {
            card.PicFileName = pictures.ElementAt(0);
            card.PicFileNames = pictures;
        }
        else
        {
            List<string> strList = new List<string>();
            strList.Add("");
            card.PicFileName = strList.ElementAt(0);
            card.PicFileNames = strList;
        }
        card.CountryId = Convert.ToInt32(place.CountryId);
        
        return card;
    }


    public List<PlaceObj> getAirports()
    {
        List<PlaceObj> placeObjs = new List<PlaceObj>();
        /*
        AirportNodesTableAdapter adapt = new AirportNodesTableAdapter();
       
        ResortData.AirportNodesDataTable table = adapt.GetAirports(true,true);

        foreach (ResortData.AirportNodesRow row in table)
        {
            PlaceObj placeObj = new PlaceObj();
            placeObj.PlaceID = row.NodeID;
            placeObj.PlaceName = row.AirportName;          
            placeObjs.Add(placeObj);
         
        }
        */
        return placeObjs;
    }

    public bool isPlaceCarHire(int placeNameID) {

        // PlacesTableAdapter adapt = new PlacesTableAdapter();
        int count = placesTable.Where(p => p.PlaceNameId == placeNameID && p.CarHireOffice == true).Count();
        if (count == 0) { return false; }
        else
        {
            return true;
        }
        
    }
    public  int getPlaceNameID(string placeName)
    {
        return placesTable.Where(p => p.PlaceName == placeName).Select(p => p.PlaceNameId).First();
        /*PlacesTableAdapter adapt = new PlacesTableAdapter();
        ResortData.PlacesDataTable table = adapt.GetIDByPlacename(placeName);
        foreach (ResortData.PlacesRow row in table)
        {
            return row.PlaceNameID;
        }
        return 0;*/
    }


    public string getPlaceName(int placeID) {
       
        return placesTable.Where(p => p.PlaceNameId == placeID).Select(p => p.PlaceName).First();
    
        
    }

    public  string getAirportName(int airportID)
    {
        return airportNodesTable.Where(a => a.NodeId == airportID).Select(s => s.AirportName).First();
        
    }


    public List<PlaceObj> getPlacesByCountry(int countryID)
    {
        List<PlaceObj> placeObjs = new List<PlaceObj>();
        /*
        PlacesTableAdapter adapt = new PlacesTableAdapter();
        ResortData.PlacesDataTable table;
       
            table = adapt.GetDataByCountryID(countryID);
        

        foreach (ResortData.PlacesRow row in table)
        {
            PlaceObj placeObj = new PlaceObj();
            placeObj.PlaceID = row.PlaceNameID;
            placeObj.PlaceName = row.PlaceName;
            placeObj.ShortPlaceName = row.ShortPlaceName;
            placeObj.MapOrder = row.MapOrder;
            placeObjs.Add(placeObj);
        }*/
        return placeObjs;
    }


    public int getCountryId(int placeNameId)
    {

        int countryId = 0;
        try
        {
            CodeWorkVoyWebService.Models.CubaData.Places place = placesTable.Where(p => p.UseIt == "Y" && p.ZoomLevel > 0 && p.PlaceNameId == placeNameId).First();
            countryId = Convert.ToInt32(place.CountryId);
        }
        catch { }
        return countryId;
    }

    //Bad dont use this method.
    public string getCountryByName(string placeName) {

        string countryName = "";
        try
        {
            CodeWorkVoyWebService.Models.CubaData.Places place = placesTable.Where(p => p.UseIt == "Y" && p.ZoomLevel > 0 && p.PlaceName == placeName).First();
            CodeWorkVoyWebService.Models.VoyagerReserve.Countries country = _contextRes.Countries.Where(c => c.CountryId == place.CountryId).First();
            countryName = country.CountryName;
        }
        catch {}
        return countryName;
    }
/*
    public string getCountryById(int placeNameId)
    {

        string countryName = "";
        try
        {
            CodeWorkVoyWebService.Models.CubaData.Places place = _context.Places.Where(p => p.UseIt == "Y" && p.ZoomLevel > 0 && p.PlaceNameId == placeNameId).First();
            CodeWorkVoyWebService.Models.VoyagerReserve.Countries country = _contextRes.Countries.Where(c => c.CountryId == place.CountryId).First();
            countryName = country.CountryName;
        }
        catch { }
        return countryName;
    }
*/
    public  List<PlaceObj> getPlaces(bool orderAlphabetic){
        List<PlaceObj> placeObjs = new List<PlaceObj>();

        // PlacesTableAdapter adapt = new PlacesTableAdapter();
        List<CodeWorkVoyWebService.Models.CubaData.Places> table;
        
        if (orderAlphabetic) {
            table  = placesTable.Where(p => p.UseIt == "Y"  && p.ZoomLevel>0 ).OrderBy(p => p.PlaceName).ToList();
        }
        else
        {
             table  = placesTable.Where(p => p.UseIt == "Y" && p.ZoomLevel > 0).ToList();
        }

        foreach (CodeWorkVoyWebService.Models.CubaData.Places row in table)
        {
            PlaceObj placeObj = new PlaceObj();
            placeObj.PlaceID = row.PlaceNameId;
            placeObj.PlaceName = row.PlaceName;
            placeObj.ShortPlaceName=row.ShortPlaceName;
            placeObj.MapOrder = Convert.ToInt32(row.MapOrder);
            placeObj.CountryId = Convert.ToInt32(row.CountryId);
            placeObjs.Add(placeObj);
        }
        return placeObjs;
    }


    public CodeWorkVoyWebService.Models.CubaData.Places getPlaceEntity(int placeNameId)
    {
        
        var row = placesTable.Where(p => p.PlaceNameId==placeNameId).First();

        
        return row;
       
    }


    public string getPlaceExc(int selectedPlaceID)
    {
        StringBuilder info = new StringBuilder("");
        /*
        PlacesTableAdapter adapt = new PlacesTableAdapter();
        ResortData.PlacesDataTable table = adapt.GetPlaceDataByID(selectedPlaceID);
        foreach (ResortData.PlacesRow row in table)
        {    
                info.Append(row.Copy5);
        }
        */
        return info.ToString();
    }

    public string getPlaceEat(int selectedPlaceID)
    {
        StringBuilder info = new StringBuilder("");
        /*
        PlacesTableAdapter adapt = new PlacesTableAdapter();
        ResortData.PlacesDataTable table = adapt.GetPlaceDataByID(selectedPlaceID);
        foreach (ResortData.PlacesRow row in table)
        {
            info.Append(row.Copy4);
        }
        */
        return info.ToString();
    }

    public string getPlaceGetting(int selectedPlaceID)
    {
        StringBuilder info = new StringBuilder("");
        /*
        PlacesTableAdapter adapt = new PlacesTableAdapter();
        ResortData.PlacesDataTable table = adapt.GetPlaceDataByID(selectedPlaceID);
        foreach (ResortData.PlacesRow row in table)
        {
            info.Append(row.Copy6);
        }
        */
        return info.ToString();
    }

    public string getPlaceNight(int selectedPlaceID)
    {
        StringBuilder info = new StringBuilder("");
        /*
        PlacesTableAdapter adapt = new PlacesTableAdapter();
        ResortData.PlacesDataTable table = adapt.GetPlaceDataByID(selectedPlaceID);
        foreach (ResortData.PlacesRow row in table)
        {
            info.Append(row.Copy7);
        }
        */
        return info.ToString();
    }
    public string getPlaceShortInfo(int selectedPlaceID)
    {
        StringBuilder info = new StringBuilder("");
        /*
        PlacesTableAdapter adapt = new PlacesTableAdapter();
        ResortData.PlacesDataTable table = adapt.GetPlaceDataByID(selectedPlaceID);
        foreach (ResortData.PlacesRow row in table)
        {
            info.Append(row.PlaceBriefDescription);
        }
        */
        return info.ToString();
    }

    public string getPlaceSEO(int selectedPlaceID)
    {
        StringBuilder info = new StringBuilder("");
        /*
        PlacesTableAdapter adapt = new PlacesTableAdapter();
        ResortData.PlacesDataTable table = adapt.GetPlaceDataByID(selectedPlaceID);
        foreach (ResortData.PlacesRow row in table)
        {
            info.Append(row.Copy1);
            if (!row.Copy3.Equals(""))
            {
                info.Append("<br><p>  <l class='DiscriptionHotelLabelTitle'>Beaches<p>" + row.Copy3 + "</br>");
            }
            info.Append(row.Copy2);

        }
        */
        return info.ToString();
    }


    public  string getPlaceInfo(int selectedPlaceID)
    {
        StringBuilder info = new StringBuilder("");
        /*
        PlacesTableAdapter adapt = new PlacesTableAdapter();
        ResortData.PlacesDataTable table = adapt.GetPlaceDataByID(selectedPlaceID);
        foreach (ResortData.PlacesRow row in table)
        {
            info.Append(row.Copy1);
            if (!row.Copy3.Equals("")){
             info.Append("<br><p>  <l class='DiscriptionHotelLabelTitle'>Beaches<p>" + row.Copy3 + "</br>");
            }

        }
     */
        return info.ToString();
    }

    public  List<string> getPlacePics(int selectedPlaceID) {

        return _picturesAdapter.getPlacePics(selectedPlaceID);
       

       
    }
    

    public  string getPlacePicName(int placeID) {

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
