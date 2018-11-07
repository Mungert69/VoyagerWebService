using System.Collections.Generic;

public interface ITransferAdapter
{
    bool checkLastTransferIsComplete(int airportID, int transferID);
    List<int> getNextAirportHops(int originID, bool withCar);
    List<int> getNextHops(int originID, bool withCar);
    int getTransferCount(string origination, string destination);
    int getTransferID(int prevPlaceID, int selectedPlaceID, bool withCar);
    TransferObj getTransfers(int transferID);
    List<string> getTransferStrings(List<TransferNode> transferNodes);
    bool lastHopAirport(int airportID, int lastPlace, bool withCar);
    void setDefaultTransfer(string placeOrigin, string placeDestination);
}