using System.Collections.Generic;
using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;
using CodeWorkVoyWebService.Models.CubaData;

public interface IPlaceAdapter
{
    List<Places> PlacesTable { get; }

    string getAirportName(int airportID);
    List<PlaceObj> getAirports();
    PlaceCardObj getCardFromPlace(int placeId);
    string getCountryByName(string placeName);
    int getCountryId(int placeNameId);
    string getPlaceEat(int selectedPlaceID);
    Places getPlaceEntity(int placeNameId);
    string getPlaceExc(int selectedPlaceID);
    string getPlaceGetting(int selectedPlaceID);
    string getPlaceInfo(int selectedPlaceID);
    string getPlaceName(int placeID);
    int getPlaceNameID(string placeName);
    string getPlaceNight(int selectedPlaceID);
    string getPlacePicName(int placeID);
    List<string> getPlacePics(int selectedPlaceID);
    List<PlaceObj> getPlaces(bool orderAlphabetic, int countryId);
    List<PlaceObj> getPlacesByCountry(int countryID);
    string getPlaceSEO(int selectedPlaceID);
    string getPlaceShortInfo(int selectedPlaceID);
    bool isPlaceCarHire(int placeNameID);
}