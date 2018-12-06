using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;

using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Globalization;
using CodeWorksVoyWebService.Models.CubaData;
using CodeWorksVoyWebService.Models.WebData;
using CodeWorksVoyWebService.Models.UserData;
using CodeWorksVoyWebService.Bussiness_Logic.Bussiness_Objects;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Summary description for UserItinAdapter
/// </summary>
public class UserItinAdapter : IUserItinAdapter
{

    private readonly WebDataContext _contextAdmin;
    private readonly List<CodeWorksVoyWebService.Models.WebData.AdminItinTemplates> adminItinTemplatesTable;
    private readonly List<CodeWorksVoyWebService.Models.WebData.UserItinerary> adminUserItineraryTable;
    private readonly List<CodeWorksVoyWebService.Models.WebData.ItinPlaces> adminItinPlacesTable;
    private readonly List<CodeWorksVoyWebService.Models.WebData.UserTransfers> adminUserTransfersTable;

   // private readonly UserDataContext _contextUser;
    private bool adminTemplate;


    public UserItinAdapter(IMemoryCache cache, WebDataContext contextAdmin)
    {
        adminItinTemplatesTable = FactoryUtils.CheckCache<CodeWorksVoyWebService.Models.WebData.AdminItinTemplates>(ref cache, contextAdmin, adminItinTemplatesTable, "AdminItinTemplatesTable");

        adminUserItineraryTable = FactoryUtils.CheckCache<CodeWorksVoyWebService.Models.WebData.UserItinerary>(ref cache, contextAdmin, adminUserItineraryTable, "AdminUserItineraryTable");
        adminItinPlacesTable = FactoryUtils.CheckCache<CodeWorksVoyWebService.Models.WebData.ItinPlaces>(ref cache, contextAdmin, adminItinPlacesTable, "AdminItinPlacesTable");
        adminUserTransfersTable = FactoryUtils.CheckCache<CodeWorksVoyWebService.Models.WebData.UserTransfers>(ref cache, contextAdmin, adminUserTransfersTable, "AdminUserTransfersTable");

       
        _contextAdmin = contextAdmin;
        //_contextUser = contextUser;
    }




    public List<TransferNode> getTransfersNodes(int ItinId)
    {
        List<TransferNode> transferNodeObjs = new List<TransferNode>();


       
            List<CodeWorksVoyWebService.Models.WebData.UserTransfers> table = adminUserTransfersTable.Where(u => u.ItinId == ItinId).ToList();
            List<int> transferIDs = new List<int>();
            foreach (CodeWorksVoyWebService.Models.WebData.UserTransfers row in table)
            {
                TransferNode userObj = new TransferNode();
                userObj.TransferID = Convert.ToInt32(row.TransferId);
                userObj.WithCar = row.WithCar;
                transferNodeObjs.Add(userObj);
            }
       


        return transferNodeObjs;
    }

    public List<PRSelection> getItinPlaces(int itinID)
    {
        List<PRSelection> userPlaceObjs = new List<PRSelection>();

       
            List<CodeWorksVoyWebService.Models.WebData.ItinPlaces> tableItinP = adminItinPlacesTable.Where(u => u.ItinId == itinID).ToList();

            foreach (CodeWorksVoyWebService.Models.WebData.ItinPlaces rowItinP in tableItinP)
            {
                PRSelection userPlaceObj = new PRSelection();
                userPlaceObj.Hotel = rowItinP.Hotel;
                userPlaceObj.HotelID = Convert.ToInt32(rowItinP.HotelId);
                userPlaceObj.Nights = Convert.ToInt32(rowItinP.Nights);
                userPlaceObj.Place = rowItinP.Place;
                userPlaceObj.PlaceID = Convert.ToInt32(rowItinP.PlaceId);
                userPlaceObjs.Add(userPlaceObj);

            }

       


        return userPlaceObjs;
    }




     public CodeWorksVoyWebService.Models.WebData.UserItinerary getAdminItin(int userItinID)
    {
        CodeWorksVoyWebService.Models.WebData.UserItinerary userItin;

        userItin = adminUserItineraryTable.Where(u => u.UserItinId == userItinID).First();


        return userItin;
    }

    public List<CodeWorksVoyWebService.Models.WebData.AdminItinTemplates> getAdminTemplateItins(int templateTypeId)
    {
        List<CodeWorksVoyWebService.Models.WebData.AdminItinTemplates> adminTemplates;

        adminTemplates = adminItinTemplatesTable.Where(a => a.TemplateTypeId == templateTypeId).ToList();


        return adminTemplates;
    }

    public List<CodeWorksVoyWebService.Models.WebData.UserItinerary> getAllAdminItins()
    {
        List<CodeWorksVoyWebService.Models.WebData.UserItinerary> userItins;

        userItins = adminUserItineraryTable.ToList();


        return userItins;
    }


    public void insertUserItin(List<TransferNode> transferNodes, List<PRSelection> prSelections, ISessionObject sessionObject, string user)
    {
        CodeWorksVoyWebService.Models.WebData.UserItinerary userItinerary = new CodeWorksVoyWebService.Models.WebData.UserItinerary();
        //int itinID = Convert.ToInt32(getMaxItinId()) + 1;
        _contextAdmin.UserItinerary.Add(userItinerary);
        _contextAdmin.SaveChanges();
        int userItinId = userItinerary.UserItinId;

        _contextAdmin.UserItinerary.Attach(userItinerary);
        userItinerary.ItinId = userItinId;
       userItinerary.Uuid=user;
        userItinerary.OutFlightId = sessionObject.Flight.OutFlightID;
        userItinerary.InFlightId = sessionObject.Flight.InFlightID;
        userItinerary.DepAirport = sessionObject.Flight.DepartAirport;
        userItinerary.DepartTime = sessionObject.Flight.StartDate;
        userItinerary.ReturnTime = sessionObject.Flight.EndDate;
        userItinerary.Nights = sessionObject.SelectedNights;
        userItinerary.Airline = sessionObject.Flight.Supplier;
        userItinerary.AirlineId = sessionObject.Flight.SupplierID;
        userItinerary.TotalCost = sessionObject.TotalCost;
        userItinerary.PriceDateStamp = DateTime.Now;

        StringBuilder itinNameBuilder = new StringBuilder(); ;
        foreach (PRSelection selection in prSelections)
        {
            itinNameBuilder.Append(selection.Place.Substring(0, 3) + "-");
        }
        string itinName = itinNameBuilder.ToString().Substring(0, itinNameBuilder.ToString().Length - 1);
        if (itinName.Length > 16) itinName.Substring(0, 16);
        userItinerary.ItinName = itinName;

        
        _contextAdmin.Entry(userItinerary).State = EntityState.Modified;
        _contextAdmin.SaveChanges();



        foreach (PRSelection selection in prSelections)
        {
            CodeWorksVoyWebService.Models.WebData.ItinPlaces itinPlaces = new CodeWorksVoyWebService.Models.WebData.ItinPlaces();

            itinPlaces.ItinId = userItinId;
            itinPlaces.Place = selection.Place;
            itinPlaces.PlaceId = selection.PlaceID;
            itinPlaces.Hotel = selection.Hotel;
            itinPlaces.Nights = selection.Nights;
            itinPlaces.HotelId = selection.HotelID;
            _contextAdmin.ItinPlaces.Add(itinPlaces);
        }
        _contextAdmin.SaveChanges();

        foreach (TransferNode transferNode in transferNodes)
        {
            CodeWorksVoyWebService.Models.WebData.UserTransfers userTransfers = new CodeWorksVoyWebService.Models.WebData.UserTransfers();
            userTransfers.ItinId = userItinId;
            userTransfers.TransferId = transferNode.TransferID;
            userTransfers.WithCar = transferNode.WithCar;
            _contextAdmin.UserTransfers.Add(userTransfers);
        }
        _contextAdmin.SaveChanges();

    }



    public string getTemplateTypeByAdminItinID(int AdminItinID)
    {
        /*
        TemplateFlagsTableAdapter tourAdapter = new TemplateFlagsTableAdapter();
        AdminItinData.TemplateFlagsDataTable table = tourAdapter.GetDataByAdminItinID(AdminItinID);
        foreach (AdminItinData.TemplateFlagsRow row in table)
        {
            return row.TemplateType;
        }*/
        return "";

    }

    public bool getSightseeingFlag(int AdminItinID)
    {
        /*
        TemplateFlagsTableAdapter tourAdapter = new TemplateFlagsTableAdapter();
        AdminItinData.TemplateFlagsDataTable table = tourAdapter.GetDataByAdminItinID(AdminItinID);
        foreach (AdminItinData.TemplateFlagsRow row in table)
        {
            return row.Sightseeing;
        }*/
        return false;

    }

    public bool getTourFlag(int AdminItinID)
    {
        /*
        TemplateFlagsTableAdapter tourAdapter = new TemplateFlagsTableAdapter();
        AdminItinData.TemplateFlagsDataTable table = tourAdapter.GetDataByAdminItinID(AdminItinID);
        foreach (AdminItinData.TemplateFlagsRow row in table)
        {
            return row.Tour;
        }
        */
        return false;
    }
    public SEOItinObj getSEOAdminUserItin(int UserItinID)
    {
        SEOItinObj seoItinObj = new SEOItinObj();
        /*AdminUserItineraryTableAdapter adminUserItinAdapter = new AdminUserItineraryTableAdapter();
        AdminItinData.AdminUserItineraryDataTable table = adminUserItinAdapter.GetDataByID(UserItinID);
        
        foreach (AdminItinData.AdminUserItineraryRow row in table)
        {
            
            seoItinObj.SEOText = row.SEOText;
            seoItinObj.SEOTitle = row.SEOTitle;
            seoItinObj.TourDepartureDates = row.TourDepartureDates;
            seoItinObj.TourFlightInfo = row.TourFlightInfo;
            seoItinObj.TourNotes= row.TourNotes;
            seoItinObj.TourPrice = row.TourPrice;


        }
        */
        return seoItinObj;

    }

    public List<String> getTripStagePicFileNames(int stageID)
    {
        List<String> picObjs = new List<String>();
        /*
         TripStagePicturesTableAdapter picAdapter = new TripStagePicturesTableAdapter();
        AdminItinData.TripStagePicturesDataTable table = picAdapter.GetDataByID(stageID);
        String picObj;
        int counter = 0;
        foreach (AdminItinData.TripStagePicturesRow row in table)
        {
            picObj = row.PicFilename;          
            picObjs.Add(picObj);
            counter++;
            if (counter == 8) break;
        }
        if (counter < 8) {
            for (int i = 0; i < (8 - counter); i++) {
                picObjs.Add("");
            }
        }
        */
        return picObjs;

    }

    public List<ElementObj> getRowElementText(int stageID)
    {
        List<ElementObj> eleObjs = new List<ElementObj>();
        /*
        AdminItinPlacesTableAdapter eleAdapter = new AdminItinPlacesTableAdapter();
        AdminItinData.AdminItinPlacesDataTable table = eleAdapter.GetDataByStageID(stageID);
        ElementObj eleObj;
        int counter = 0;
        foreach (AdminItinData.AdminItinPlacesRow row in table)
        {
            eleObj = new ElementObj();
            if (row.Element1 != "" && row.Element1 != "IMAGE")
            {
                eleObj.Text = row.Element1;
                eleObj.Width = row.Element1Width;
                eleObj.Colour = row.Element1Colour;
                eleObjs.Add(eleObj);
                counter++;
            }
            else {
                eleObj.Width = row.Element1Width;
                eleObj.Colour = row.Element1Colour;
                eleObjs.Add(eleObj);
            }

            eleObj = new ElementObj();
            if (row.Element2 != "" && row.Element2 != "IMAGE")
            {
                eleObj.Text = row.Element2;
                eleObj.Width = row.Element2Width;
                eleObj.Colour = row.Element2Colour;
                eleObjs.Add(eleObj);
                counter++;
            }
            else
            {
                eleObj.Width = row.Element2Width;
                eleObj.Colour = row.Element2Colour;
                eleObjs.Add(eleObj);
            }

            eleObj = new ElementObj();
            if (row.Element3 != "" && row.Element3 != "IMAGE")
            {
                eleObj.Text = row.Element3;
                eleObj.Width = row.Element3Width;
                eleObj.Colour = row.Element3Colour;
                eleObjs.Add(eleObj);
                counter++;
            }
            else
            {
                eleObj.Width = row.Element3Width;
                eleObj.Colour = row.Element3Colour;
                eleObjs.Add(eleObj);
            }

            eleObj = new ElementObj();
            if (row.Element4 != "" && row.Element4 != "IMAGE")
            {
                eleObj.Text = row.Element4;
                eleObj.Width = row.Element4Width;
                eleObj.Colour = row.Element4Colour;
                eleObjs.Add(eleObj);
                counter++;
            }
            else
            {
                eleObj.Width = row.Element4Width;
                eleObj.Colour = row.Element4Colour;
                eleObjs.Add(eleObj);
            }

            eleObj = new ElementObj();
            if (row.Element5 != "" && row.Element5 != "IMAGE")
            {
                eleObj.Text = row.Element5;
                eleObj.Width = row.Element5Width;
                eleObj.Colour = row.Element5Colour;
                eleObjs.Add(eleObj);
                counter++;
            }
            else
            {
                eleObj.Width = row.Element5Width;
                eleObj.Colour = row.Element5Colour;
                eleObjs.Add(eleObj);
            }

            eleObj = new ElementObj();
            if (row.Element6 != "" && row.Element6 != "IMAGE")
            {
                eleObj.Text = row.Element6;
                eleObj.Width = row.Element6Width;
                eleObj.Colour = row.Element6Colour;
                eleObjs.Add(eleObj);
                counter++;
            }
            else
            {
                eleObj.Width = row.Element6Width;
                eleObj.Colour = row.Element6Colour;
                eleObjs.Add(eleObj);
            }


            break;
        }
       */
        return eleObjs;

    }


    public List<String> getRowElementPicFileNames(int stageID, int element)
    {
        List<String> picObjs = new List<String>();
        /*
        TripStagePicturesTableAdapter picAdapter = new TripStagePicturesTableAdapter();
        AdminItinData.TripStagePicturesDataTable table = picAdapter.GetDataByElementID(stageID,element);
        String picObj;
        int counter = 0;
        foreach (AdminItinData.TripStagePicturesRow row in table)
        {
            picObj = row.PicFilename;
            picObjs.Add(picObj);
            counter++;
            if (counter == 8) break;
        }
        if (counter < 8)
        {
            for (int i = 0; i < (8 - counter); i++)
            {
                picObjs.Add("");
            }
        }*/
        return picObjs;

    }


    public List<SEOItinObj> getSEOAdminItinPlaces(int ItinID)
    {
        List<SEOItinObj> seoItinObjs = new List<SEOItinObj>();
        /*
        AdminItinPlacesTableAdapter adminItinPlacesAdapter = new AdminItinPlacesTableAdapter();
        AdminItinData.AdminItinPlacesDataTable table = adminItinPlacesAdapter.GetDataByIDOrdered(ItinID);
        SEOItinObj seoItinObj;
        foreach (AdminItinData.AdminItinPlacesRow row in table)
        {
            seoItinObj = new SEOItinObj();
            seoItinObj.SEOText = row.SEOText;
            seoItinObj.SEOTitle = row.SEOTitle;
            seoItinObj.TourStageAccommodation= row.TourStageAccommodation;
            seoItinObj.TourStageMealBasis = row.TourStageMealBasis;
            seoItinObj.TourStageNote = row.TourStageNote;
            seoItinObj.StageID = row.StageID;

            seoItinObjs.Add(seoItinObj);
        }
        */
        return seoItinObjs;

    }
    public string getItinStr(SessionObject session)
    {
        StringBuilder str = new StringBuilder();
        /*
             UserItinObj userItinObj = getUserItin(session.UserItinID);

             int itinID = 0;
             ItinTemplateObj ItinTemplate = new ItinTemplateObj();
             UserItinAdapter userPlacesAdapter;
             List<PRSelection> PRSelections = new List<PRSelection>();

             string flightDate;
             string flightTime;
             string flightReturnDate;
             string flightReturnTime;

             int nights = 0;

             flightDate = userItinObj.DepartTime.ToShortDateString();
             flightTime = userItinObj.DepartTime.ToShortTimeString();
             flightReturnDate = userItinObj.ReturnTime.ToShortDateString();
             flightReturnTime = userItinObj.ReturnTime.ToShortTimeString();
             userItinObj = getUserItin(userItinObj.UserItinID);
                 itinID = userItinObj.ItinID;
             userPlacesAdapter = new UserItinAdapter(session.PageStates.AdminTemplate);
             PRSelections = userPlacesAdapter.getItinPlaces(itinID);
             foreach (PRSelection selection in PRSelections)
             {
                 str.Append(selection.Place + ", ");
                 nights += selection.Nights;
             }
             str.Remove(str.Length - 2, 2);
             str.Append(" - Departure " + flightDate + " " + flightTime);
             str.Append(" - Return " + flightReturnDate + " " + flightReturnTime);
             */
        return str.ToString();
    }

    public string getTitleStr(SessionObject session, String typeStr)
    {
        StringBuilder str = new StringBuilder();
        /*
          UserItinObj userItinObj = getUserItin(session.UserItinID);
          DateTime flightDate;
          flightDate= userItinObj.DepartTime;
          int itinID = 0;

          ItinTemplateObj ItinTemplate = new ItinTemplateObj();
          UserItinAdapter userPlacesAdapter;
          List<PRSelection> PRSelections = new List<PRSelection>();

          int nights = 0;

          userItinObj = getUserItin(userItinObj.UserItinID);

          string price = String.Format("{0:£#,0}", userItinObj.TotalCost);
          itinID = userItinObj.ItinID;
          userPlacesAdapter = new UserItinAdapter(session.PageStates.AdminTemplate);
          PRSelections = userPlacesAdapter.getItinPlaces(itinID);
          string places = "";
          foreach (PRSelection selection in PRSelections)
          {
              nights += selection.Nights;
              places += " "+selection.Place + " >";

          }
          places = places.TrimEnd('>');

          str.Append(session.Country +" "+ typeStr+ " trip " + nights + " nts " + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(flightDate.Month) + " - " + PRSelections.Count + " Places - " + places + " - " + session.UserItinID);
          */
        return str.ToString();
    }


    public List<TemplateTypeObj> getTemplateTypes()
    {
        TemplateTypeObj templateTypeObj;
        List<TemplateTypeObj> templateTypeObjs = new List<TemplateTypeObj>();
        /*
        TemplateTypesTableAdapter templateAdapter=new TemplateTypesTableAdapter();
        AdminItinData.TemplateTypesDataTable table=templateAdapter.GetData();
        foreach (AdminItinData.TemplateTypesRow row in table){
             templateTypeObj = new TemplateTypeObj();
             templateTypeObj.Count = row.Count;
             templateTypeObj.Description = row.Description;
             templateTypeObj.SuppressPrive = row.SuppressPrice;
             templateTypeObj.TemplateType = row.TemplateType;
             templateTypeObj.TemplateTypeID = row.TemplateTypeID;
             templateTypeObj.Title = row.Title;
             templateTypeObj.DisplayOrder = row.DisplayOrder;
             templateTypeObj.ButtonName = row.ButtonName;
             templateTypeObj.ButtonHeading = row.ButtonHeading;
             templateTypeObj.TripGroupDescriptionShort = row.TripGroupDescriptionShort;
            templateTypeObj.TripGroupDescriptionLong = row.TripGroupDescriptionLong;
            templateTypeObj.TripGroupImageBanner = row.TripGroupImageBanner;
            templateTypeObj.ButtonPath = row.ButtonPath;
             templateTypeObj.Templated = row.Templated;
            templateTypeObj.Tour = row.Tour;
             templateTypeObjs.Add(templateTypeObj);
        }
        */
        return templateTypeObjs;


    }

    public List<PRSelection> getItinHotels(int itinID)
    {
        throw new NotImplementedException();
    }

    public TemplateTypeObj getTemplateType(string templateType)
    {
        TemplateTypeObj templateTypeObj = new TemplateTypeObj();
        /*
        TemplateTypesTableAdapter templateAdapter = new TemplateTypesTableAdapter();
        AdminItinData.TemplateTypesDataTable table = templateAdapter.GetDataByTemplateType(templateType);
        foreach (AdminItinData.TemplateTypesRow row in table)
        {
            templateTypeObj.Count = row.Count;
            templateTypeObj.Description = row.Description;
            templateTypeObj.SuppressPrive = row.SuppressPrice;
            templateTypeObj.TemplateType = row.TemplateType;
            templateTypeObj.TemplateTypeID = row.TemplateTypeID;
            templateTypeObj.Title = row.Title;
            templateTypeObj.DisplayOrder = row.DisplayOrder;
            templateTypeObj.ButtonName = row.ButtonName;
            templateTypeObj.ButtonHeading = row.ButtonHeading;
            templateTypeObj.TripGroupDescriptionShort = row.TripGroupDescriptionShort;
            templateTypeObj.TripGroupDescriptionLong = row.TripGroupDescriptionLong;
            templateTypeObj.TripGroupImageBanner = row.TripGroupImageBanner;
            templateTypeObj.ButtonPath = row.ButtonPath;
            templateTypeObj.Templated = row.Templated;
            templateTypeObj.Tour = row.Tour;
            templateTypeObj.Sightseeing = row.Sightseeing;
      

        }
        */
        return templateTypeObj;


    }


    public UserItinAdapter(bool adminTemplateParam)
    {
        /*
        adaptUserScalar = new UserItineraryScalarsTableAdapter();
        adaptUserItin = new UserItineraryTableAdapter();
        adaptUserAdminItin = new UserAdminItineraryTableAdapter();
        adaptItinPlaces = new ItinPlacesTableAdapter();
        adaptTemplate = new AdminTemplatesTableAdapter();
        adaptUserTransfer = new UserTransfersTableAdapter();
        adminTemplate = adminTemplateParam;
       
        if (adminTemplate)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebDataConnectionString"].ConnectionString;

            adaptUserScalar.Connection = conn;
            adaptUserItin.Connection = conn;
            adaptUserAdminItin.Connection = conn;
            adaptItinPlaces.Connection = conn;
            adaptTemplate.Connection = conn;
            adaptUserTransfer.Connection = conn;
        }
        */
    }

    public int getMaxUserID()
    {


        //return Convert.ToInt32(adaptUserScalar.GetMaxUserID());
        return 0;

    }

    public int getItinID(int userItinID)
    {

        //return Convert.ToInt32(adaptUserScalar.GetItinID(userItinID));
        return 0;
    }

    public ItinTemplateObj getItinTemplate(string templateType, int countID)
    {
        int count;
        /*
        AdminItinData.AdminTemplatesDataTable table = adaptTemplate.GetDataByCountAndType(templateType,countID);
        foreach (AdminItinData.AdminTemplatesRow row in table)
        {
            ItinTemplateObj templateObj = new ItinTemplateObj();
            templateObj.AccordianName = row.AccordianName;
            templateObj.AdminItinID = row.AdminItinID;
            templateObj.TemplateType = row.TemplateType;
            templateObj.CountID = row.CountID;
            count = row.CountID;
            templateObj.FileName = row.TemplateType + "_" + count;
            templateObj.PageTitle = row.PageTitle;
            templateObj.PageDescription = row.PageDescription;
            templateObj.Notes = row.Notes;
            return templateObj;
        }*/
        return new ItinTemplateObj();
    }

    public List<ItinTemplateObj> getAllItinTemplates()
    {
        List<ItinTemplateObj> templateObjs = new List<ItinTemplateObj>();
        int count;
        /*
        AdminItinData.AdminTemplatesDataTable table = adaptTemplate.GetData();
        foreach (AdminItinData.AdminTemplatesRow row in table)
        {
            ItinTemplateObj templateObj = new ItinTemplateObj();
            templateObj.AccordianName = row.AccordianName;
            templateObj.AdminItinID = row.AdminItinID;
            templateObj.TemplateType = row.TemplateType;
            templateObj.CountID = row.CountID;
            count = row.CountID;
            templateObj.FileName = row.TemplateType + "_" + count;
            templateObj.PageTitle = row.PageTitle;
            templateObj.PageDescription = row.PageDescription;
            templateObj.Notes = row.Notes;
                    templateObjs.Add(templateObj);
        }*/
        return templateObjs;
    }


    public List<ItinTemplateObj> getTypeItinTemplates(string type)
    {
        List<ItinTemplateObj> templateObjs = new List<ItinTemplateObj>();
        /*
        AdminItinData.AdminTemplatesDataTable table = adaptTemplate.GetDataByTemplateType(type);
        int count;
        foreach (AdminItinData.AdminTemplatesRow row in table)
        {
            ItinTemplateObj templateObj = new ItinTemplateObj();
            templateObj.AccordianName = row.AccordianName;
            templateObj.AdminItinID= row.AdminItinID;
            templateObj.TemplateType= row.TemplateType;
            templateObj.CountID = row.CountID;
            count = row.CountID;
            templateObj.FileName= row.TemplateType+"_"+count;
            templateObj.PageTitle= row.PageTitle;
            templateObj.PageDescription = row.PageDescription;
            templateObj.SuppressPrice = row.SuppressPrice;
            templateObj.Notes = row.Notes;
            templateObj.DisplayOrder = row.DisplayOrder;
                        templateObjs.Add(templateObj);
            
        }*/
        return templateObjs;
    }



    public void updateUserItin(int userItinID, int userID)
    {

        //adaptUserItin.UpdateUserID(userID, userItinID);
    }

  

    public void deleteUserItin(int itinID)
    {
        // adaptUserItin.UpdateUserIDToZero(itinID);
        //adaptItinPlaces.DeleteQuery(itinID);
    }




    public UserItinObj getUserItinEntity(int userItinID)
    {
        UserItinObj itinObj = new UserItinObj();
        /*
        UserItinData.UserItineraryDataTable tableUserItin = adaptUserItin.GetDataByUserItinID(userItinID);

        foreach (UserItinData.UserItineraryRow rowUserItin in tableUserItin)
        {

            itinObj.UserItinID = rowUserItin.UserItinID;
            itinObj.ItinName = rowUserItin.ItinName;
            itinObj.ItinID = rowUserItin.ItinID;
            itinObj.Airline = rowUserItin.Airline;
            itinObj.AirlineID = rowUserItin.AirlineID;
            itinObj.DepartTime = rowUserItin.DepartTime;
            itinObj.InFlightID = rowUserItin.InFlightID;
            itinObj.Nights = rowUserItin.Nights;
            itinObj.OutFlightID = rowUserItin.OutFlightID;
            itinObj.ReturnTime = rowUserItin.ReturnTime;
            itinObj.TotalCost = rowUserItin.TotalCost;
            itinObj.PriceDateStamp = rowUserItin.PriceDateStamp;
            itinObj.DepAirport = rowUserItin.DepAirport;


        }*/
        return itinObj;
    }

    public UserItinObj getUserAdminItin(int userItinID)
    {
        UserItinObj itinObj = new UserItinObj();
        /*
        UserItinData.UserAdminItineraryDataTable tableUserItin = adaptUserAdminItin.GetDataByUserItinID(userItinID);

        foreach (UserItinData.UserAdminItineraryRow rowUserItin in tableUserItin)
        {

            itinObj.UserItinID = rowUserItin.UserItinID;
            itinObj.ItinName = rowUserItin.ItinName;
            itinObj.ItinID = rowUserItin.ItinID;
            itinObj.Airline = rowUserItin.Airline;
            itinObj.AirlineID = rowUserItin.AirlineID;
            itinObj.DepartTime = rowUserItin.DepartTime;
            itinObj.InFlightID = rowUserItin.InFlightID;
            itinObj.Nights = rowUserItin.Nights;
            itinObj.OutFlightID = rowUserItin.OutFlightID;
            itinObj.ReturnTime = rowUserItin.ReturnTime;
            itinObj.TotalCost = rowUserItin.TotalCost;
            itinObj.PriceDateStamp = rowUserItin.PriceDateStamp;
            itinObj.DepAirport = rowUserItin.DepAirport;
            itinObj.TripTag = rowUserItin.TripTag;


        }*/
        return itinObj;
    }


    public List<UserItinObj> getUserItins(int userID)
    {
        List<UserItinObj> itinObjs = new List<UserItinObj>();
        /*
        UserItinData.UserItineraryDataTable tableUserItin = adaptUserItin.GetDataByUserID(userID);

        foreach (UserItinData.UserItineraryRow rowUserItin in tableUserItin)
        {
            UserItinObj itinObj = new UserItinObj();
            itinObj.UserItinID = rowUserItin.UserItinID;
            itinObj.ItinName = rowUserItin.ItinName;
            itinObj.ItinID = rowUserItin.ItinID;
            itinObj.Airline = rowUserItin.Airline;
            itinObj.AirlineID = rowUserItin.AirlineID;
            itinObj.DepartTime = rowUserItin.DepartTime;
            itinObj.InFlightID = rowUserItin.InFlightID;
            itinObj.Nights = rowUserItin.Nights;
            itinObj.OutFlightID = rowUserItin.OutFlightID;
            itinObj.ReturnTime = rowUserItin.ReturnTime;
            itinObj.TotalCost = rowUserItin.TotalCost;
 
            itinObjs.Add(itinObj);

        }*/
        return itinObjs;
    }
}
