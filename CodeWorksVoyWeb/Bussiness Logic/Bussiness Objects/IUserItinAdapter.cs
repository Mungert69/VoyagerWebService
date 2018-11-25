using System;
using System.Collections.Generic;
using CodeWorksVoyWebService.Models.UserData;
using CodeWorksVoyWebService.Models.WebData;

public interface IUserItinAdapter
{
    bool AdminTemplate { get; set; }

    void deleteUserItin(int itinID);
    CodeWorksVoyWebService.Models.WebData.UserItinerary getAdminItin(int userItinID);
    List<AdminItinTemplates> getAdminTemplateItins(int templateTypeId);
    List<CodeWorksVoyWebService.Models.WebData.UserItinerary> getAllAdminItins();
    List<ItinTemplateObj> getAllItinTemplates();
    List<PRSelection> getItinHotels(int itinID);
    int getItinID(int userItinID);
    List<PRSelection> getItinPlaces(int itinID);
    string getItinStr(SessionObject session);
    ItinTemplateObj getItinTemplate(string templateType, int countID);
    int getMaxUserID();
    List<string> getRowElementPicFileNames(int stageID, int element);
    List<ElementObj> getRowElementText(int stageID);
    List<SEOItinObj> getSEOAdminItinPlaces(int ItinID);
    SEOItinObj getSEOAdminUserItin(int UserItinID);
    bool getSightseeingFlag(int AdminItinID);
    TemplateTypeObj getTemplateType(string templateType);
    string getTemplateTypeByAdminItinID(int AdminItinID);
    List<TemplateTypeObj> getTemplateTypes();
    string getTitleStr(SessionObject session, string typeStr);
    bool getTourFlag(int AdminItinID);
    List<TransferNode> getTransfersNodes(int ItinId);
    List<string> getTripStagePicFileNames(int stageID);
    List<ItinTemplateObj> getTypeItinTemplates(string type);
    UserItinObj getUserAdminItin(int userItinID);
    CodeWorksVoyWebService.Models.UserData.UserItinerary getUserItin(int userItinID);
    UserItinObj getUserItinEntity(int userItinID);
    List<UserItinObj> getUserItins(int userID);
    void insertTransferNodes(List<TransferNode> transferNodes, int itinID);
    ItinIntObj insertUserItin(List<PRSelection> prSelections, int userID, int outFlightID, int inFlightID, string selectedDepAirport, DateTime startDate, DateTime endDate, int selectedNights, string supplier, decimal totalCost, int supplierID, string depAirport);
    void updateUserItin(int userItinID, int userID);
}