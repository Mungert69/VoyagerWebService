﻿using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;
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

        private decimal price = 0;
        private string pricesStr = "";
        private DateTime travelDate;
        private int itinId;
        private int nights = 0;
        private int stages=0;
        private List<PlaceObj> placeObjs;
        public int ItinId { get => itinId; set => itinId = value; }
        public decimal Price { get => price; set => price = value; }
        public DateTime TravelDate { get => travelDate; set => travelDate = value; }

        public string PricesStr { get => pricesStr; set => pricesStr = value; }
        public int Nights { get => nights; set => nights = value; }
        public int Stages { get => stages; set => stages = value; }
        public List<PlaceObj> PlaceObjs { get => placeObjs; set => placeObjs = value; }

        public void getPriceString(IPriceService priceService) {
            List<ItinTemplateTimeObj> itinTemplatePrices = priceService.getItinTemplatePrices(base.Id);
            List<ItinTemplateTimeObj> sortedList = itinTemplatePrices.OrderBy(o => o.TimeID).ToList();
            StringBuilder str = new StringBuilder();
            foreach (ItinTemplateTimeObj obj in sortedList) {
                str.Append(obj.TimeIdName + " £" + Convert.ToInt32(obj.Price) + "  ");
            }
            pricesStr = str.ToString();
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
    }
}
