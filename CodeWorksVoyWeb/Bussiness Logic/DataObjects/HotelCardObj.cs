using CodeWorkVoyWebService.Bussiness_Logic.DataObjects;
using CodeWorkVoyWebService.Models.CubaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWorksVoyWebService.Bussiness_Logic.DataObjects
{
    public class HotelCardObj : CardObj
    {
        private int placeNameId;
        private CodeWorkVoyWebService.Models.CubaData.AccommodationRoomSpecification accommodationRoomSpecification;
        private CodeWorkVoyWebService.Models.CubaData.AccommodationDescription accommodationDescription;
        private CodeWorkVoyWebService.Models.CubaData.AccommodationCharacteristics accommodationCharacteristics;
        private CodeWorkVoyWebService.Models.CubaData.AccommodationSelfCater accommodationSelfCater;
        private CodeWorkVoyWebService.Models.CubaData.AccommodationAllInclusiveFacilities accommodationAllInclusiveFacilities;
        public AccommodationRoomSpecification AccommodationRoomSpecification { get => accommodationRoomSpecification; set => accommodationRoomSpecification = value; }
        public AccommodationDescription AccommodationDescription { get => accommodationDescription; set => accommodationDescription = value; }
        public AccommodationCharacteristics AccommodationCharacteristics { get => accommodationCharacteristics; set => accommodationCharacteristics = value; }
        public AccommodationSelfCater AccommodationSelfCater { get => accommodationSelfCater; set => accommodationSelfCater = value; }
        public AccommodationAllInclusiveFacilities AccommodationAllInclusiveFacilities { get => accommodationAllInclusiveFacilities; set => accommodationAllInclusiveFacilities = value; }
        public int PlaceNameId { get => placeNameId; set => placeNameId = value; }
    }
}
