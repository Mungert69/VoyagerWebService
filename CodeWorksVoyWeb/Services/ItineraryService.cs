using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWorksVoyWebService.Services
{
    public class ItineraryService : IItineraryService
    {
        private readonly ITransferAdapter _transferAdapter;
        private readonly IPlaceAdapter _placeAdapter;
        private ISessionObject sessionObject;

        public ISessionObject SessionObject { get => sessionObject; set => sessionObject = value; }

        public ItineraryService(ITransferAdapter transferAdapter, IPlaceAdapter placeAdapter)
        {
            _transferAdapter = transferAdapter;
            _placeAdapter = placeAdapter;
        }

        public void deleteLastTransferNode()
        {
            List<TransferNode> tempNodes = SessionObject.TransferNodes;
            if (tempNodes.Count == 0) return;
            tempNodes.RemoveAt(tempNodes.Count - 1);
            // Not sure if this works!
        }


        public void deleteLastHR()
        {
            List<PRSelection> tempSelections = SessionObject.PRSelections;
            if (tempSelections.Count == 0) return;
            tempSelections.RemoveAt(tempSelections.Count - 1);
            // Not sure if this works!
        }

        public void deleteHR(int placeID)
        {
            List<PRSelection> tempSelections = SessionObject.PRSelections;
            int index = 0;
            foreach (PRSelection selection in (SessionObject.PRSelections))
            {
                if (selection.PlaceID == placeID)
                {


                    tempSelections.Remove(selection);
                    break;
                }
                index++;
            }

            SessionObject.PRSelections = tempSelections;
        }

        public void addPlace(int prevPlaceID)
        {
            if (SessionObject.PRSelections == null) SessionObject.PRSelections = new List<PRSelection>();
            List<PRSelection> tempSelections = SessionObject.PRSelections;
            // Add the place only if it is not already stored in session.

            if (prevPlaceID == SessionObject.SelectedPlaceID)
            {
                return;
            }

            PRSelection selection = new PRSelection();
            selection.Place = SessionObject.SelectedPlace;
            selection.PlaceID = SessionObject.SelectedPlaceID;
            selection.HotelID = 0;
            selection.Hotel = "";
            tempSelections.Add(selection);
            SessionObject.PRSelections = tempSelections;
            SessionObject.SelectedIndex = tempSelections.Count - 1;

            SessionObject.PrevPlaceID = SessionObject.SelectedPlaceID;
            SessionObject.IsCarHire = _placeAdapter.isPlaceCarHire(SessionObject.SelectedPlaceID);

        }




        public void addHotel()
        {
            List<PRSelection> tempSelections = SessionObject.PRSelections;

            // Add the hotel to the place at selected index.


            if (SessionObject.PRSelections[SessionObject.SelectedIndex].PlaceID == SessionObject.SelectedPlaceID)
            {
                tempSelections[SessionObject.SelectedIndex].Hotel = SessionObject.SelectedHotel;
                tempSelections[SessionObject.SelectedIndex].HotelID = SessionObject.SelectedHotelID;
                if (tempSelections[SessionObject.SelectedIndex].Nights == 0) tempSelections[SessionObject.SelectedIndex].Nights = 1;
                SessionObject.PRSelections = tempSelections;
            }
        }


        public void addTransferNode(int prevPlaceID)
        {
            
            int transferID = _transferAdapter.getTransferID(prevPlaceID, SessionObject.SelectedPlaceID, SessionObject.WithCar);
            List<TransferNode> tempNodes = SessionObject.TransferNodes;
            tempNodes.Add(new TransferNode(transferID, SessionObject.WithCar));
            SessionObject.TransferNodes = tempNodes;
        }

        public void addFinalTransferNode(int prevPlaceID)
        {
            
            int transferID = _transferAdapter.getTransferID(SessionObject.PRSelections[SessionObject.PRSelections.Count - 1].PlaceID, prevPlaceID, SessionObject.WithCar);
            List<TransferNode> tempNodes = SessionObject.TransferNodes;
            tempNodes.Add(new TransferNode(transferID, SessionObject.WithCar));
            SessionObject.TransferNodes = tempNodes;
        }



    }
}
