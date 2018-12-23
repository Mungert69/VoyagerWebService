using CodeWorksVoyWebService.Bussiness_Logic.Bussiness_Objects;
using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;
using CodeWorksVoyWebService.Bussiness_Logic.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorksVoyWebService.Bussiness_Logic.DataObjects
{
    public class TripCardObj : CardObj
    {
        private List<PRSelection> pRSelections;
        private decimal price = 0;
        private string pricesStr = "";
        private DateTime travelDate;
        private int itinId;
        private int nights = 0;
        private int stages=0;
        private List<PlaceObj> placeObjs;
            private List<DatePriceObj> datePriceObjs;

        public TripCardObj()
        {
        }

        public int ItinId { get => itinId; set => itinId = value; }
        public decimal Price { get => price; set => price = value; }
        public DateTime TravelDate { get => travelDate; set => travelDate = value; }

        public string PricesStr { get => pricesStr; set => pricesStr = value; }
        public int Nights { get => nights; set => nights = value; }
        public int Stages { get => stages; set => stages = value; }
        public List<PlaceObj> PlaceObjs { get => placeObjs; set => placeObjs = value; }
        public List<DatePriceObj> DatePriceObjs { get => datePriceObjs; set => datePriceObjs = value; }


        public void setCardFromItinerary(int userItinId, int templateTypeId, IUserItinAdapter userItinAdapter, bool createTestJsonFiles)
        {

           
            CodeWorksVoyWebService.Models.WebData.UserItinerary userItin = userItinAdapter.getAdminItin(userItinId);
            if (createTestJsonFiles) JsonUtils.writeJsonObjectToFile("userItin.json", userItin);

            base.Id = userItin.UserItinId;
            itinId = (int)userItin.ItinId;
            base.Title = userItin.ItinName;
            base.DescriptionShort = userItin.Seotext;
            base.Longitude = "";
            base.Latitude = "";
            base.CountryId = 0;
            base.Country = "";
            base.TypeId = templateTypeId;


            List<string> strList = new List<string>();
            strList.Add("");
            base.PicFileName = strList.ElementAt(0);

            base.PicFileNames = strList;

        }

        public void getPriceString(IPriceService priceService) {
            List<ItinTemplateTimeObj> itinTemplatePrices = priceService.getItinTemplatePrices(base.Id);
            List<ItinTemplateTimeObj> sortedList = itinTemplatePrices.OrderBy(o => o.TimeID).ToList();
            StringBuilder str = new StringBuilder();
            foreach (ItinTemplateTimeObj obj in sortedList) {
                str.Append(obj.TimeIdName + " £" + Convert.ToInt32(obj.Price) + "  ");
            }
            pricesStr = str.ToString();
        }

        public List<PRSelection> setPRSeletions(IUserItinAdapter userItinAdapter, ICardAdapter cardAdapter)
        {

            pRSelections = userItinAdapter.getItinPlaces(itinId);
            pRSelections = cardAdapter.updateSelectionWithCards(pRSelections);
            getNights(pRSelections);
            stages = pRSelections.Count;
            getPlaceObjs(pRSelections);
            getTripPics(pRSelections);
            return pRSelections;

        }
        public void setPRSeletions(List<PRSelection> pRSelections)
        {

            getNights(pRSelections);
            stages = pRSelections.Count;
            getPlaceObjs(pRSelections);
            getTripPics(pRSelections);

        }
        public void getDatePriceObjs(IPriceService priceService)
        {
            List<ItinTemplateTimeObj> itinTemplatePrices = priceService.getItinTemplatePrices(base.Id);
            List<ItinTemplateTimeObj> sortedList = itinTemplatePrices.OrderBy(o => o.TimeID).ToList();
            List<DatePriceObj> datePriceObjs = new List<DatePriceObj>();
            DatePriceObj datePriceObj;
            foreach (ItinTemplateTimeObj obj in sortedList)
            {
                datePriceObj=new DatePriceObj(obj.Price, obj.TimeIdName);
                datePriceObjs.Add(datePriceObj);
            }
            DatePriceObjs = datePriceObjs;
        }
        public void getNights(List<PRSelection> pRSelections) {
            int totalNights = 0;
            foreach (PRSelection selection in pRSelections) {
                totalNights += selection.Nights;
            }
            Nights=totalNights;
        }

        public void  getPlaceObjs(List<PRSelection> pRSelections) {

           List<PlaceObj> placeObjs=new List<PlaceObj>();
            PlaceObj placeObj;
            foreach (PRSelection selection in pRSelections)
            {
                placeObj = new PlaceObj();
                placeObj.PlaceName = selection.Place;
                placeObj.PlaceID = selection.PlaceID;
                placeObjs.Add(placeObj);
            }
            PlaceObjs = placeObjs ;
        }

        public void getTripPics(List<PRSelection> pRSelections) {
            List<string> fileNames = new List<string>();
            PlaceCardObj placeCard;
            foreach (PRSelection selection in pRSelections)
            {
                placeCard = selection.PlaceCard ;
                foreach (String fileName in placeCard.PicFileNames) {
                    fileNames.Add(fileName);
                }
               
               
            }
            base.PicFileNames=fileNames;
        }

    }
}
