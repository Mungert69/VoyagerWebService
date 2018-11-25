using System;
using System.Collections.Generic;
using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;
using CodeWorksVoyWebService.Models.CubaData;

public interface IHotelAdapter
{
    List<HotelObj> getAllHotels();
    HotelCardObj getCardFromHotel(int hotelId);
    string getHotelAllInc(int hid);
    string getHotelBoardBasis(int hid);
    string getHotelDesc(int selectedHotelID);
    List<string> getHotelDetailBar(int hotelID);
    Hotels getHotelEntity(int hotelId);
    string getHotelFac(int hid);
    int getHotelID(string hotel);
    string getHotelName(int hotelID);
    string getHotelPicName(int selectedHotelID);
    int getHotelRating(int hid);
    string getHotelRoomSpec(int hid);
    List<HotelObj> getHotels(int selectedPlaceID);
    string getHotelSEO(int selectedHotelID);
    string getHotelShortDesc(int selectedHotelID);
    string getOnMouse(int hotelID, string hotel, string place);
    string getOnMouseImages(int hotelID);
    int getPriceCount(int currentHotelID, DateTime startDate, DateTime endDate);
    bool isHotelAllInc(int hid);
}