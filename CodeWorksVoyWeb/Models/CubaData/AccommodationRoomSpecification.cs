using System;
using System.Collections.Generic;

namespace CodeWorkVoyWebService.Models.CubaData
{
    public partial class AccommodationRoomSpecification
    {
        public int Pkey { get; set; }
        public int? AccommodationId { get; set; }
        public string AccommodationName { get; set; }
        public string RoomType { get; set; }
        public string NumberOfRooms { get; set; }
        public string GeneralCopy { get; set; }
        public bool ContractRoomBasis { get; set; }
        public bool RoomSharing { get; set; }
        public bool PrivateBathroom { get; set; }
        public bool AirConditioning { get; set; }
        public bool CeilingFan { get; set; }
        public bool SatelliteTv { get; set; }
        public bool Cdplayer { get; set; }
        public bool Telephone { get; set; }
        public bool Hairdryer { get; set; }
        public bool MiniBar { get; set; }
        public bool MiniFridge { get; set; }
        public bool LivingArea { get; set; }
        public bool TerraceBalcony { get; set; }
        public bool DiningArea { get; set; }
        public bool SeaviewAvailable { get; set; }
        public bool LakeView { get; set; }
        public bool Kitchen { get; set; }
        public bool Kitchenette { get; set; }
        public bool PrivatePool { get; set; }
        public bool PrivateGarden { get; set; }
        public bool IroningFacilities { get; set; }
        public bool Safe { get; set; }
        public bool NoSmokingRoomAvailable { get; set; }
        public bool Hammocks { get; set; }
        public bool OtherFacilities { get; set; }
        public string RoomSharingNote { get; set; }
        public string AirConditioningNote { get; set; }
        public string CeilingFanNote { get; set; }
        public string PrivateBathroomNote { get; set; }
        public string HairdryerNote { get; set; }
        public string SatelliteTvnote { get; set; }
        public string CdplayerNote { get; set; }
        public string MiniBarNote { get; set; }
        public string MiniFridgeNote { get; set; }
        public string LivingAreaNote { get; set; }
        public string TerraceBalconyNote { get; set; }
        public string SeaviewAvailableNote { get; set; }
        public string LakeViewNote { get; set; }
        public string KitchenNote { get; set; }
        public string KitchenetteNote { get; set; }
        public string DiningAreaNote { get; set; }
        public string PrivatePoolNote { get; set; }
        public string PrivateGardenNote { get; set; }
        public string IroningFacilitiesNote { get; set; }
        public string SafeNote { get; set; }
        public string NoSmokingRoomAvailableNote { get; set; }
        public string HammocksNote { get; set; }
        public string TelephoneNote { get; set; }
        public string OtherFacilitiesNote { get; set; }
    }
}
