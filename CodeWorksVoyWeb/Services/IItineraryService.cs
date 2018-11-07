namespace CodeWorkVoyWebService.Services
{
    public interface IItineraryService
    {
        ISessionObject SessionObject { get; set; }

        void addFinalTransferNode(int prevPlaceID);
        void addHotel();
        void addPlace(int prevPlaceID);
        void addTransferNode(int prevPlaceID);
        void deleteHR(int placeID);
        void deleteLastHR();
        void deleteLastTransferNode();
    }
}