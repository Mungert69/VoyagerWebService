using System.Collections.Generic;

public interface IPicturesAdapter
{
    List<string> getHotelPics(int selectedHotelID);
    string getPlacePicName(int placeID);
    List<string> getPlacePics(int selectedPlaceID);
}