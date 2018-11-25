using CodeWorksVoyWebService.Bussiness_Logic.DataObjects;
using CodeWorksVoyWebService.Models.CubaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWorksVoyWebService.Bussiness_Logic.DataObjects
{
    public class HotelCardObj : CardObj
    {
        private string hotelFeatures;
        private int placeNameId;
        private CodeWorksVoyWebService.Models.CubaData.AccommodationRoomSpecification accommodationRoomSpecification;
        private CodeWorksVoyWebService.Models.CubaData.AccommodationDescription accommodationDescription;
        private CodeWorksVoyWebService.Models.CubaData.AccommodationCharacteristics accommodationCharacteristics;
        private CodeWorksVoyWebService.Models.CubaData.AccommodationSelfCater accommodationSelfCater;
        private CodeWorksVoyWebService.Models.CubaData.AccommodationAllInclusiveFacilities accommodationAllInclusiveFacilities;
        public AccommodationRoomSpecification AccommodationRoomSpecification { get => accommodationRoomSpecification; set => accommodationRoomSpecification = value; }
        public AccommodationDescription AccommodationDescription { get => accommodationDescription; set => accommodationDescription = value; }
        public AccommodationCharacteristics AccommodationCharacteristics { get => accommodationCharacteristics; set => accommodationCharacteristics = value; }
        public AccommodationSelfCater AccommodationSelfCater { get => accommodationSelfCater; set => accommodationSelfCater = value; }
        public AccommodationAllInclusiveFacilities AccommodationAllInclusiveFacilities { get => accommodationAllInclusiveFacilities; set => accommodationAllInclusiveFacilities = value; }
        public int PlaceNameId { get => placeNameId; set => placeNameId = value; }
        public string HotelFeatures { get => hotelFeatures; set => hotelFeatures = value; }
    }
}
