using System;
using System.Collections.Generic;

public interface ISessionObject
{
    int AgentID { get; set; }
    int ArrivalAirportID { get; }
    bool ChooseMode { get; set; }
    string Country { get; }
    int CountryFlag { get; }
    int DefaultPlaceID { get; }
    int DepartAirportID { get; }
    bool DisplayFlightPanel { get; set; }
    bool FirePageEvent { get; set; }
    int FlashState { get; set; }
    FlightObj Flight { get; set; }
    FlightStates FlightStates { get; set; }
    bool IsAdmin { get; set; }
    bool IsAgent { get; set; }
    bool IsCarHire { get; set; }
    bool IsPlaceSelected { get; set; }
    bool IsSuperUser { get; set; }
    bool IsTemplateChanged { get; set; }
    ItinTemplateObj ItinTemplate { get; set; }
    PageStates PageStates { get; set; }
    bool PickUpCarAtAirport { get; }
    int PicPos { get; set; }
    int PicPosMax { get; set; }
    PlaceStates PlaceStates { get; set; }
    string PrevLevel { get; set; }
    int PrevPlaceID { get; set; }
    string PriceBrakeDown { get; set; }
    List<PRSelection> PRSelections { get; set; }
    bool pulse { get; set; }
    string ReturnPage { get; set; }
    string SelectedArvAirport { get; set; }
    DateTime SelectedDate { get; set; }
    string SelectedDepAirport { get; set; }
    string SelectedDepAirportCode { get; set; }
    string SelectedHotel { get; set; }
    int SelectedHotelID { get; set; }
    string SelectedImage { get; set; }
    int SelectedIndex { get; set; }
    string SelectedInfo { get; set; }
    int SelectedLevel1Item { get; set; }
    int SelectedLevel2Item { get; set; }
    int SelectedLevel3Item { get; set; }
    int SelectedLevel4Item { get; set; }
    int SelectedNights { get; set; }
    string SelectedPlace { get; set; }
    int SelectedPlaceID { get; set; }
    bool ShowPrices { get; set; }
    bool tick { get; set; }
    int TickCount { get; set; }
    int TimeID { get; set; }
    decimal TotalCost { get; set; }
    TransferFilter TransferFilter { get; set; }
    List<TransferNode> TransferNodes { get; set; }
    int UserID { get; set; }
    int UserItinID { get; set; }
    bool ViewPDFMode { get; set; }
    bool WithCar { get; set; }

    bool containsPlaceID(int placeID);
}