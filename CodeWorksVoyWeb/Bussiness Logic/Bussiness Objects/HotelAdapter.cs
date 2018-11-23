using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;

using System.Collections.Generic;
using System.Text;
using CodeWorkVoyWebService.Models.CubaData;
using CodeWorkVoyWebService.Models.VoyagerReserve;
using CodeWorkVoyWebService.Bussiness_Logic.DataObjects;
using CodeWorkVoyWebService.Bussiness_Logic.Bussiness_Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;
/// <summary>
/// Summary description for HotelAdapter
/// </summary>
public class HotelAdapter : IHotelAdapter

{
    //private readonly CubaDataContext _context;
    private readonly List<CodeWorkVoyWebService.Models.CubaData.Hotels> hotelsTable;
    private readonly List<CodeWorkVoyWebService.Models.CubaData.ContractRates> contractRatesTable;
    private readonly List<CodeWorkVoyWebService.Models.CubaData.AccommodationDescription> accommodationDescriptionTable;
    private readonly List<CodeWorkVoyWebService.Models.CubaData.AccommodationRoomSpecification> accommodationRoomSpecificationTable;
    private readonly List<CodeWorkVoyWebService.Models.CubaData.AccommodationCharacteristics> accommodationCharacteristicsTable;
    private readonly List<CodeWorkVoyWebService.Models.CubaData.AccommodationAllInclusiveFacilities> accommodationAllInclusiveFacilitiesTable;
    private readonly List<CodeWorkVoyWebService.Models.CubaData.AccommodationSelfCater> accommodationSelfCaterTable;

    // private readonly VoyagerReserveContext _contextRes;
    private readonly IPlaceAdapter _placeAdapter;
    private readonly IPicturesAdapter _picturesAdapter;
    private readonly IVoyResAdapter _voyResAdapter;
    public HotelAdapter(CubaDataContext context, IMemoryCache cache, IVoyResAdapter voyResAdapter, IPicturesAdapter picturesAdapter, IPlaceAdapter placeAdapter)
    {
        hotelsTable = FactoryUtils.CheckCache<CodeWorkVoyWebService.Models.CubaData.Hotels>(ref cache, context, hotelsTable, "HotelsTable");
        accommodationDescriptionTable = FactoryUtils.CheckCache<CodeWorkVoyWebService.Models.CubaData.AccommodationDescription>(ref cache, context, accommodationDescriptionTable, "AccommodationDescriptionTable");
        accommodationRoomSpecificationTable = FactoryUtils.CheckCache<CodeWorkVoyWebService.Models.CubaData.AccommodationRoomSpecification>(ref cache, context, accommodationRoomSpecificationTable, "AccommodationRoomSpecificationTable");
        accommodationCharacteristicsTable = FactoryUtils.CheckCache<CodeWorkVoyWebService.Models.CubaData.AccommodationCharacteristics>(ref cache, context, accommodationCharacteristicsTable, "AccommodationCharacteristicsTable");
        accommodationAllInclusiveFacilitiesTable = FactoryUtils.CheckCache<CodeWorkVoyWebService.Models.CubaData.AccommodationAllInclusiveFacilities>(ref cache, context, accommodationAllInclusiveFacilitiesTable, "AccommodationAllInclusiveFacilitiesTable");
        accommodationSelfCaterTable = FactoryUtils.CheckCache<CodeWorkVoyWebService.Models.CubaData.AccommodationSelfCater>(ref cache, context, accommodationSelfCaterTable, "AccommodationSelfCaterTable");

        contractRatesTable = FactoryUtils.CheckCache<CodeWorkVoyWebService.Models.CubaData.ContractRates>(ref cache, context, contractRatesTable, "ContractRatesTable");




        //_context = context;
        _picturesAdapter = picturesAdapter;
        _placeAdapter = placeAdapter;
    
        _voyResAdapter = voyResAdapter;
    }


    public HotelCardObj getCardFromHotel(int hotelId)
    {

        HotelCardObj card = new HotelCardObj();

        var countryId = hotelsTable  // your starting point - table in the "from" statement
          .Join(_placeAdapter.PlacesTable, // the source table of the inner join
          h => h.Place,
          p => p.PlaceName,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
                                   // Select the foreign key (the second part of the "on" clause)
             (h, p) => new { H = h, P = p }) // selection
          .Where(joined => joined.H.HotelId == hotelId).Select(s => s.P.CountryId).First();
        CodeWorkVoyWebService.Models.CubaData.Hotels hotel = this.getHotelEntity(hotelId);

        //ToDo sort out Hotels table so its got placeIDs
        // card.CountryId = _placeAdapter.getCountryId(Convert.ToInt32(hotel.PlaceId));
        if (countryId != null)
        {
            card.Country = _voyResAdapter.GetCountryById(Convert.ToInt32(countryId));

            card.CountryId = Convert.ToInt32(countryId);
        }
        card.Id = hotelId;
        card.Title = hotel.Hotel;
        card.HotelFeatures = "";
        card.Panel1 = "";
        card.Panel2 = "";
        card.Panel3 = "";
        card.Subtitle = hotel.Place;

        // We are just skipping if there is no data
        try {
            CodeWorkVoyWebService.Models.CubaData.AccommodationRoomSpecification roomSpec = accommodationRoomSpecificationTable.Where(a => a.AccommodationId == hotelId).First();
            card.AccommodationRoomSpecification = roomSpec;
        }
        catch { }
       
        try
        {
            CodeWorkVoyWebService.Models.CubaData.AccommodationDescription accomDescTable = accommodationDescriptionTable.Where(a => a.AccommodationId == hotelId).First();
            card.AccommodationDescription = accomDescTable;
        }
        catch { }
       
        try
        {
            CodeWorkVoyWebService.Models.CubaData.AccommodationCharacteristics accomCharTable = accommodationCharacteristicsTable.Where(a => a.AccommodationId == hotelId).First();
            card.AccommodationCharacteristics = accomCharTable;
        }
        catch { }
        try {
            CodeWorkVoyWebService.Models.CubaData.AccommodationAllInclusiveFacilities accomAllIncTable = accommodationAllInclusiveFacilitiesTable.Where(a => a.AccommodationId == hotelId).First();
            card.AccommodationAllInclusiveFacilities = accomAllIncTable;
        }
        catch { }

       
        try {
            CodeWorkVoyWebService.Models.CubaData.AccommodationSelfCater accomSelfTable = accommodationSelfCaterTable.Where(a => a.AccommodationId == hotelId).First();
            card.AccommodationSelfCater = accomSelfTable;
        }
        catch { }
       
        card.Longitude = hotel.Longitude;
        card.Latitude = hotel.Latitude;
        if (card.Latitude == null) card.Latitude = "0";
        if (card.Longitude == null) card.Longitude = "0";
        List<string> pictures = _picturesAdapter.getHotelPics(Convert.ToInt32(hotelId));
      
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

        return card;
    }
    public int getHotelID(string hotel)
    {
        return hotelsTable.Where(h => h.Hotel == hotel).Select(h => h.HotelId).First();
        /*HotelsTableAdapter adapt = new HotelsTableAdapter();
        HotelData.HotelsDataTable table = adapt.GetHotelIDByName(hotel);
        foreach (HotelData.HotelsRow row in table)
        {
            return row.HotelID;
        }
        return 1;
        */
    }

    public string getHotelName(int hotelID)
    {
        /*
        HotelsTableAdapter adapt = new HotelsTableAdapter();
        HotelData.HotelsDataTable table = adapt.GetHotelNameByID(hotelID);
        foreach (HotelData.HotelsRow row in table) {
            return row.Hotel;
        }*/
        return hotelsTable.Where(h => h.HotelId == hotelID).Select(h => h.Hotel).First();
    }

    public CodeWorkVoyWebService.Models.CubaData.Hotels getHotelEntity(int hotelId)
    {

        CodeWorkVoyWebService.Models.CubaData.Hotels row;

        row = hotelsTable.Where(h => h.HotelId == hotelId).First();

        return row;

    }

    public string getHotelRoomSpec(int hid)
    {
        StringBuilder str = new StringBuilder("");
        /*
         AccommodationRoomSpecificationTableAdapter adapt = new AccommodationRoomSpecificationTableAdapter();
         HotelData.AccommodationRoomSpecificationDataTable table = adapt.GetHotelRoomDataByID(hid);
         foreach (HotelData.AccommodationRoomSpecificationRow row in table) { 
         
           
             if (row.RoomSharing){
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Room Sharing<p>" + row.RoomSharingNOTE );

            } 
             if (row.PrivateBathroom){
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Private Bathroom<p>" + row.PrivateBathroomNOTE );
            
             } 
             if (row.AirConditioning){
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Air Conditioning<p>" + row.AirConditioningNOTE ); 
            
             } 
             if (row.CeilingFan){
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Ceiling Fan<p>" + row.CeilingFanNOTE );

            } 
             if (row.SatelliteTV){
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Satellite TV<p>" + row.SatelliteTVNOTE );

            } 
             if (row.CDPlayer){
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>CD Player<p>" + row.CDPLayerNote );

            } 
             if (row.Telephone){
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Telephone<p>" + row.TelephoneNOTE );

            } 
             if (row.Hairdryer){
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Hair dryer<p>" + row.HairdryerNOTE );

            } 
             if (row.MiniBar){
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Mini Bar<p>" + row.MiniBarNOTE );

            } 
             if (row.MiniFridge){
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Mini Fridge<p>" + row.MiniFridgeNote );

            } 
              if (row.LivingArea){
                  str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Living Area<p>" + row.LivingAreaNOTE );

            } 
              if (row.Terrace_Balcony){
                  str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Terrace/Balcony<p>" + row._Terrace_BalconyNOTE );

            } 
              if (row.DiningArea){
                  str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Dining Area<p>" + row.DiningAreaNOTE );

            } 
              if (row.SeaviewAvailable){
                  str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Seaview Available<p>" + row.SeaviewAvailableNOTE );

            } 
             if (row.LakeView){
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Lake View<p>" + row.LakeViewNote );

            } 
             if (row.Kitchen){
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Kitchen<p>" + row.KitchenNOTE );

            } 
             if (row.Kitchenette){
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Kitchenette<p>" + row.KitchenetteNOTE );

            }

                 if (row.PrivatePool){
                     str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Private Pool<p>" + row.PrivatePoolNOTE );

            } 
                 if (row.PrivateGarden){
                     str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Internet<p>" + row.PrivateGardenNOTE );

            } 
                 if (row.IroningFacilities){
                     str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Ironing Facilities<p>" + row.IroningFacilitiesNOTE );

            } 
                 if (row.Safe){
                     str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Safe<p>" + row.SafeNOTE );

            } 
                 if (row.NoSmokingRoomAvailable){
                     str.Append("<p> <l class='DiscriptionHotelLabelTitle'>No Smoking Room Available<p>" + row.NoSmokingRoomAvailableNOTE );

            } 
              if (row.Hammocks){
                  str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Hammocks<p>" + row.HammocksNOTE );

            } 
              if (row.OtherFacilities){
                  str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Other Facilities<p>" + row.OtherFacilitiesNOTE );

            }

         }
      */
        return str.ToString();
    }



    public string getHotelAllInc(int hid)
    {
        StringBuilder str = new StringBuilder();
        /*
         AccommodationAllInclusiveFacilitiesTableAdapter adapt = new AccommodationAllInclusiveFacilitiesTableAdapter();
         HotelData.AccommodationAllInclusiveFacilitiesDataTable table = adapt.GetAllIncDataByID(hid);

         foreach (HotelData.AccommodationAllInclusiveFacilitiesRow row in table)
         {



             if (row.BuffetMeals)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Buffet Meals<p>" + row.BuffetMealsNOTE );

            }
             if (row.ALaCarte)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>ALaCarte<p>" + row.ALaCarteNOTE );

            }
             if (row.Snacks)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Snacks<p>" + row.SnacksNOTE );

            }
             if (row.LocalDrinks)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Local Drinks<p>" + row.LocalDrinksNOTE );

            }

             if (row.InternationalDrinks)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>International Drinks<p>" + row.InternationalDrinksNOTE );

            }
             if (row.DaytimeActivities)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Daytime Activities<p>" + row.DaytimeActivitiesNOTE );

            }
             if (row.AIEveningEntertainment)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Evening Entertainment<p>" + row.AIEveningEntertainmentNOTE );

            }

             if (row.NonMotorisedWatersports)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Non Motorised Watersports<p>" + row.NonMotorisedWatersportsNOTE );

            }
             if (row.MotorisedWatersports)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Motorised Watersports<p>" + row.MotorisedWatersportsNOTE );

            }
             
         }*/
        return str.ToString();
    }



    public bool isHotelAllInc(int hid)
    {
        /*
         if (getHotelBoardBasis(hid) != "AI") { return false; }*/
        return true;
    }


    public string getHotelFac(int hid)
    {
        StringBuilder str = new StringBuilder("");
        /*
         AccommodationDescriptionTableAdapter adapt =new AccommodationDescriptionTableAdapter();
         HotelData.AccommodationDescriptionDataTable table = adapt.GetHotelDecriptionByHID(hid);
         

         foreach (HotelData.AccommodationDescriptionRow row in table)
         {


             if (row.ThirdAdultShare)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Third Adult Share<p>" + row.ThirdAdultShareNOTE );

            }
             if (row.FourthAdultShare)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Fourth Adult Share<p>" + row.FourthAdultShareNOTE );

            }
             if (row.Honeymoon)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'><b>Honeymoon<p>" + row.HoneymoonCopy + row.HoneymoonDeal );

            }
             
             if (row.ChildrensFacilities)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Childrens Facilities<p>" + row.ChildrensFacilitiesNOTE );

            }
             if (row.ChildrensDiscount)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Child discount<p>" + row.ChildrensDiscountNOTE );

            }
             if (row.Pool)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Pool<p>" + row.PoolNOTE );

            }
             if (row.Jacuzzi)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Jacuzzi<p>" + row.JacuzziNOTE );

            }
             if (row.Restaurant)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Restaurant<p>" + row.RestaurantNOTE );

            }
             if (row.Bar)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Bar<p>" + row.BarNOTE );

            }
             if (row.RoomService)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Room Service<p>" + row.RoomServiceNOTE );

            }
             if (row.BeachTowelsProvided)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Beach Towels Provided<p>" + row.BeachTowelsProvidedNOTE );

            }
  
             if (row.CarRental)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Car Rental<p>" + row.CarRentalNOTE );

            }
             if (row.ToursDesk)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Tours Desk<p>" + row.ToursDeskNOTE );

            }
             if (row.EveningEntertainment)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Evening Entertainment<p>" + row.EveningEntertainmentNote );

            }
             if (row.Nightclub)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Night club<p>" + row.NightclubNote );

            }
             if (row.Shops)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Shops<p>" + row.ShopsNOTE );

            }
             if (row.MoneyExchange)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Money Exchange<p>" + row.MoneyExchangeNOTE );

            }
             if (row.DisabledFacilities)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Disabled Facilities<p>" + row.DisabledFacilitiesNOTE );

            }
             if (row.Concierge)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Concierge<p>" + row.ConciergeNOTE );

            }
             if (row.SportsFacilities)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Sports Facilities<p>" + row.SportsFacilitiesNOTE );

            }
             if (row.Watersports)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Water sports<p>" + row.WatersportsNOTE );

            }
 
             if (row.ScubaDiving)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Scuba Diving<p>" + row.ScubaDivingNOTE );

            }
             if (row.Tennis)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Tennis<p>" + row.TennisNOTE );

            }
             if (row.Gymnasium)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Gymnasium<p>" + row.GymnasiumNOTE );

            }
             if (row.Golf)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Spa<p>" + row.GolfNOTE );

            }
             if (row.Horseriding)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Horse riding<p>" + row.HorseridingNOTE );

            }
             if (row.Squash)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>WiFi<p>" + row.SquashNOTE );

            }
             if (row.OtherFacilities)
             {
                 str.Append("<p> <l class='DiscriptionHotelLabelTitle'>Other Facilities<p>" + row.OtherFacilitiesNote );

            }

            


         }
         */
        return str.ToString();
    }

    public int getPriceCount(int currentHotelID, DateTime startDate, DateTime endDate)
    {
        int count = 0;
        /*
        ContractRatesTableAdapter adaptPrices = new ContractRatesTableAdapter();
        HotelData.ContractRatesDataTable tablePrices = adaptPrices.GetHotelPrices(currentHotelID, startDate, endDate);
        return tablePrices.Rows.Count;*/
        try
        {
            count = contractRatesTable.Where(c => c.HotelId == currentHotelID && (c.StartDate >= startDate && c.StartDate <= endDate)).Count();
        }
        catch { }
        return count;
    }



    public int getHotelRating(int hid)
    {
        /*
       HotelDBarTableAdapter adaptDBar = new HotelDBarTableAdapter();
            HotelData.HotelDBarDataTable tableDBar = adaptDBar.GetDataByID(hid);
            foreach (HotelData.HotelDBarRow row in tableDBar)
            {
                return Convert.ToInt32(row.Star);
            }*/
        return 0;
    }

    public string getHotelBoardBasis(int hid)
    {
        /*
        Hotels1TableAdapter adapt = new Hotels1TableAdapter();
        HotelData.Hotels1DataTable table = adapt.GetDataBBByID(hid);
        foreach (HotelData.Hotels1Row row in table)
        {
            return row.BoardBasis;
        }
        */
        return "";
    }


    public List<HotelObj> getAllHotels()
    {
        List<HotelObj> hotelObjs = new List<HotelObj>();

        //ToDo countries
        List<CodeWorkVoyWebService.Models.CubaData.Hotels> table = hotelsTable.Where(h => h.UseIt == "Y").Take(100).ToList();
        foreach (CodeWorkVoyWebService.Models.CubaData.Hotels row in table)
        {
            hotelObjs.Add(new HotelObj(row.Hotel, row.HotelId));
        }

        return hotelObjs;
    }


    public List<HotelObj> getHotels(int selectedPlaceID)
    {
        List<HotelObj> hotelObjs = new List<HotelObj>();


        //PlaceAdapter placeAdapter = new PlaceAdapter();
        string placeName = _placeAdapter.getPlaceName(selectedPlaceID);
        List<CodeWorkVoyWebService.Models.CubaData.Hotels> table = hotelsTable.Where(h => h.Place == placeName && h.UseIt == "Y").ToList();
        foreach (CodeWorkVoyWebService.Models.CubaData.Hotels row in table)
        {
            hotelObjs.Add(new HotelObj(row.Hotel, row.HotelId));
        }

        return hotelObjs;
    }

    public string getOnMouse(int hotelID, string hotel, string place)
    {
        string shortDesc;
        List<string> barValues = new List<string>();
        string blank = " ";

        List<string> hotelBar = getHotelDetailBar(hotelID);

        string strPounds = "";
        int count = 0;
        try
        {
            count = Convert.ToInt32(hotelBar[0]);
        }
        // dont catch exception just use value of 1
        catch (Exception e) { }
        for (int j = 0; j < count; j++) { strPounds += "£"; }
        barValues = getHotelDetailBar(hotelID);

        shortDesc = getHotelShortDesc(hotelID);

        string onmouseover = "popup('  <img class=hyperLinkTipHotelINFOImage src=" + getHotelPicName(hotelID) + " <br/><p class=hyperLinkTipHotelINFOTitle>" + hotel + "</p> <p class=hyperLinkTipHotelINFOTourColour2>" + barValues[1] + " - " + barValues[2] + " - " + barValues[3] + " - " + strPounds + "</p>  <p class=hyperLinkTipHotelINFOTourPlaceName>" + place + "</p> <p class=hyperLinkTipHotelINFOText>" + shortDesc + "</p>', '300px ');";





        return onmouseover;

    }






    public string getOnMouseImages(int hotelID)
    {
        string onmouseover = "popup(' <table>";
        List<string> picObjs = _picturesAdapter.getHotelPics(hotelID);
        if (picObjs.Count >= 4)
        {
            onmouseover += "<tr>";
            for (int i = 0; i < 2; i++)
            {
                onmouseover += "<td><img class=TRIPHOVERTripdetailsPlaceImageviewer src=images/images-PlacesHotels/" + picObjs[i] + "></td>";
            }
            onmouseover += "</tr>";
            onmouseover += "<tr>";
            for (int i = 2; i < 4; i++)
            {
                onmouseover += "<td><img class=TRIPHOVERTripdetailsPlaceImageviewer src=images/images-PlacesHotels/" + picObjs[i] + "></td>";
            }
            onmouseover += "</tr>";

        }
        onmouseover += "</table> ', '535px');";
        return onmouseover;

    }


    public List<string> getHotelDetailBar(int hotelID)
    {
        List<string> barValues = new List<string>();
        /*
        HotelDataTableAdapters.HotelDBarTableAdapter adapt = new HotelDataTableAdapters.HotelDBarTableAdapter();
        HotelData.HotelDBarDataTable table = adapt.GetDataByID(hotelID);

        foreach (HotelData.HotelDBarRow row in table)
        {
            barValues.Add(row.Star);

            if (row.Modern) barValues.Add("Modern");
            if (row.Heritage) barValues.Add("Heritage");
            if (row.SmallHotel) barValues.Add("Small Hotel");
            if (row.MediumHotel) barValues.Add("Medium Hotel");
            if (row.LargeHotel) barValues.Add("Large Hotel");
            if (row.OwnerManaged) barValues.Add("Owner Managed");
            if (row.BeachArea) barValues.Add("Beach Area");
            if (row.BeachFront) barValues.Add("Beach Front");
            if (row.CityCentre) barValues.Add("City Centre");
            if (row.CityOutskirts) barValues.Add("City Outskirts");
            if (row.TownCentre) barValues.Add("Town Centre");
            if (row.TownOutskirts) barValues.Add("Town Outskirts");
            if (row.Countryside) barValues.Add("Countryside");
            if (row.Eco) barValues.Add("Eco");
            if (row.Rustic) barValues.Add("Rustic");
            if (row.Hacienda) barValues.Add("Hacienda");
            if (row.BB) barValues.Add("B&B");
            if (row.Business) barValues.Add("Business");
            if (row.HistoricCentre) barValues.Add("Historic Centre");
            if (row.FarmStay) barValues.Add("Lakeside");
            if (row.Cabana) barValues.Add("Mayan Site");
            if (row.Casa) barValues.Add("Casa");
            if (row.Coastal) barValues.Add("Coastal");
            break;
        }
        barValues.Add("");
        barValues.Add("");
        barValues.Add("");
        barValues.Add("");
        barValues.Add("");
        */
        return barValues;
    }

    public string getHotelShortDesc(int selectedHotelID)
    {

        string desc = "";
        /*
        AccommodationDescriptionTableAdapter adapt = new AccommodationDescriptionTableAdapter();
        HotelData.AccommodationDescriptionDataTable table = adapt.GetHotelDecriptionByHID(selectedHotelID);
        foreach (HotelData.AccommodationDescriptionRow row in table)
        {
            desc = row.HotelBriefDescription;
        }*/
        return desc;
    }

    public string getHotelDesc(int selectedHotelID)
    {

        string desc = "";
        /*
        AccommodationDescriptionTableAdapter adapt = new AccommodationDescriptionTableAdapter();
        HotelData.AccommodationDescriptionDataTable table = adapt.GetHotelDecriptionByHID(selectedHotelID);
        foreach (HotelData.AccommodationDescriptionRow row in table)
        {
            desc = row.DescriptionNOTE;
        }*/
        return desc;

    }

    public string getHotelSEO(int selectedHotelID)
    {

        string desc = "";
        /*
        AccommodationDescriptionTableAdapter adapt = new AccommodationDescriptionTableAdapter();
        HotelData.AccommodationDescriptionDataTable table = adapt.GetHotelDecriptionByHID(selectedHotelID);
        foreach (HotelData.AccommodationDescriptionRow row in table)
        {
            desc = row.DescriptionNOTE;
        }*/
        return desc;

    }




    public string getHotelPicName(int selectedHotelID)
    {
        string selectedImage = "";
        /*
        HotelDataTableAdapters.PicturesTableAdapter adaptPic = new HotelDataTableAdapters.PicturesTableAdapter();
        HotelData.PicturesDataTable tablePic = adaptPic.GetPicturesByHID(selectedHotelID);
        foreach (HotelData.PicturesRow row in tablePic)
        {
            selectedImage = "Images/Images-PlacesHotels/" + (string)row.PicFilename;
            //string ext = picName.Substring(picName.LastIndexOf("."));
            //string dest = picName.Substring(0, picName.LastIndexOf(".")) + "-view" + ext;
            break;
        }*/
        return selectedImage;

    }
}
