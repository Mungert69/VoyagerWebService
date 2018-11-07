using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWorkVoyWebService.Models.WebData;

namespace CodeWorkVoyWebService.Bussiness_Logic.DataObjects
{
    public class CardObj 
    {
        private int id;
        private int itinId;
        private string title;
        private string pureHtml;
        private string subtitle;
        private string catagory;
        private string tag;
        private string panel1;
        private string panel2;
        private string panel3;
        private string panel4;
        private string panel5;
        private string panel6;
        private string panel7;
        private string panel8;
        private string panel9;
        private List<string> picFileNames;
        private string picFileName;
        private string descriptionShort;
        private string descriptionLong;
        private string country;
        private string placeFeatures;
        private string hotelFeatures;
        private string longitude;
        private string latitude;
        private int countryId;
        private int typeId;


        public string Title { get => title; set => title = value; }
         public string Country { get => country; set => country = value; }
       
        public string Longitude { get => longitude; set => longitude = value; }
        public string Latitude { get => latitude; set => latitude = value; }
        public int Id { get => id; set => id = value; }
        public int CountryId { get => countryId; set => countryId = value; }
        public int ItinId { get => itinId; set => itinId = value; }
        public int TypeId { get => typeId; set => typeId = value; }


        public string DescriptionShort { get => descriptionShort; set => descriptionShort = value; }
        public string DescriptionLong { get => descriptionLong; set => descriptionLong = value; }
        public string PicFileName { get => picFileName; set => picFileName = value; }
        public List<string> PicFileNames { get => picFileNames; set => picFileNames = value; }
      
        public string Subtitle { get => subtitle; set => subtitle = value; }
        public string Catagory { get => catagory; set => catagory = value; }
        public string Tag { get => tag; set => tag = value; }
        public string Panel1 { get => panel1; set => panel1 = value; }
        public string Panel2 { get => panel2; set => panel2 = value; }
        public string Panel3 { get => panel3; set => panel3 = value; }
        public string Panel4 { get => panel4; set => panel4 = value; }
        public string Panel5 { get => panel5; set => panel5 = value; }
        public string Panel6 { get => panel6; set => panel6 = value; }
        public string Panel7 { get => panel7; set => panel7 = value; }
        public string Panel8 { get => panel8; set => panel8 = value; }
        public string Panel9 { get => panel9; set => panel9 = value; }
        public string PureHtml { get => pureHtml; set => pureHtml = value; }
        public string PlaceFeatures { get => placeFeatures; set => placeFeatures = value; }
        public string HotelFeatures { get => hotelFeatures; set => hotelFeatures = value; }
    }

   

}
