using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CodeWorkVoyWebService.Models.CubaData
{
    public partial class CubaDataContext : DbContext
    {
        public CubaDataContext()
        {
        }

        public CubaDataContext(DbContextOptions<CubaDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccommodationAllInclusiveFacilities> AccommodationAllInclusiveFacilities { get; set; }
        public virtual DbSet<AccommodationCharacteristics> AccommodationCharacteristics { get; set; }
        public virtual DbSet<AccommodationDescription> AccommodationDescription { get; set; }
        public virtual DbSet<AccommodationRoomSpecification> AccommodationRoomSpecification { get; set; }
        public virtual DbSet<AccommodationSelfCater> AccommodationSelfCater { get; set; }
        public virtual DbSet<AirChildDiscount> AirChildDiscount { get; set; }
        public virtual DbSet<AirportCodes> AirportCodes { get; set; }
        public virtual DbSet<AirportNodes> AirportNodes { get; set; }
        public virtual DbSet<Airports> Airports { get; set; }
        public virtual DbSet<Aptrates> Aptrates { get; set; }
        public virtual DbSet<BoardUpgradeRates> BoardUpgradeRates { get; set; }
        public virtual DbSet<ContractRates> ContractRates { get; set; }
        public virtual DbSet<ContractRules> ContractRules { get; set; }
        public virtual DbSet<CurrencyExchange> CurrencyExchange { get; set; }
        public virtual DbSet<DefaultAirports> DefaultAirports { get; set; }
        public virtual DbSet<DefaultTransfers> DefaultTransfers { get; set; }
        public virtual DbSet<DynamicPictures> DynamicPictures { get; set; }
        public virtual DbSet<FlightCosts> FlightCosts { get; set; }
        public virtual DbSet<FlightOptions> FlightOptions { get; set; }
        public virtual DbSet<FlightTable> FlightTable { get; set; }
        public virtual DbSet<FlightTableInbound> FlightTableInbound { get; set; }
        public virtual DbSet<Hotels> Hotels { get; set; }
        public virtual DbSet<Pictures> Pictures { get; set; }
        public virtual DbSet<Places> Places { get; set; }
        public virtual DbSet<PriceMultiplyier> PriceMultiplyier { get; set; }
        public virtual DbSet<PricesOther> PricesOther { get; set; }
        public virtual DbSet<PrintMessages> PrintMessages { get; set; }
        public virtual DbSet<ProfileTable> ProfileTable { get; set; }
        public virtual DbSet<Psc> Psc { get; set; }
        public virtual DbSet<RoomUpgradeRates> RoomUpgradeRates { get; set; }
        public virtual DbSet<TransferLogic> TransferLogic { get; set; }
        public virtual DbSet<Transfers> Transfers { get; set; }
        public virtual DbSet<TransfersOther> TransfersOther { get; set; }
        public virtual DbSet<XferCosts> XferCosts { get; set; }

        // Unable to generate entity type for table 'dbo.InformationItem'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PlaceTypeChecklist'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ProductGroup'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.XLOOKAccomStandardCategories'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.XLOOKAccomTypesCategories'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.XLOOKBoardBasisCategories'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.XLOOKGeneralCategoryNumbers'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.XLOOKGeneralItemVentura'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.XLOOKInformationItemTypeCategories'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.EarlyMorning'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.XLOOKPlaceItemCategories'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.XLOOKPlaceName'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.XLOOKPlaceTypeCategories'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.RoomUpgrades'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.XLOOKregion'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.XLOOKSupplier'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.XXLOOKGeneralItemCategories'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.NewDomesticFlightCosts'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.NewDomesticFlights'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PaymentType'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PaymentTypeLookUp'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Allocations'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.BoardUpgrades'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.HotSpots'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Images'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.XLookDefaultTransferTypes'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Prices'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.AdditionalItemTypes'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.HotelNotes'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.RoomTypeDeletes'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=Develop\\Codeworks;Database=CubaData;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccommodationAllInclusiveFacilities>(entity =>
            {
                entity.HasKey(e => e.Aikey);

                entity.Property(e => e.Aikey).HasColumnName("AIkey");

                entity.Property(e => e.AccommodationId).HasColumnName("AccommodationID");

                entity.Property(e => e.AccommodationName).HasMaxLength(50);

                entity.Property(e => e.AieveningEntertainment).HasColumnName("AIEveningEntertainment");

                entity.Property(e => e.AieveningEntertainmentNote)
                    .HasColumnName("AIEveningEntertainmentNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.AiscubaDiving).HasColumnName("AIScubaDiving");

                entity.Property(e => e.AiscubaDivingNote)
                    .HasColumnName("AIScubaDivingNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.AlaCarte).HasColumnName("ALaCarte");

                entity.Property(e => e.AlaCarteNote)
                    .HasColumnName("ALaCarteNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.BuffetMealsNote)
                    .HasColumnName("BuffetMealsNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.DaytimeActivitiesNote)
                    .HasColumnName("DaytimeActivitiesNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.InternationalDrinksNote)
                    .HasColumnName("InternationalDrinksNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.LocalDrinksNote)
                    .HasColumnName("LocalDrinksNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.MotorisedWatersportsNote)
                    .HasColumnName("MotorisedWatersportsNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.NonMotorisedWatersportsNote)
                    .HasColumnName("NonMotorisedWatersportsNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.OtherFeaturesNote)
                    .HasColumnName("OtherFeaturesNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.SnacksNote)
                    .HasColumnName("SnacksNOTE")
                    .HasColumnType("ntext");
            });

            modelBuilder.Entity<AccommodationCharacteristics>(entity =>
            {
                entity.HasKey(e => e.Ackey);

                entity.Property(e => e.Ackey).HasColumnName("ACkey");

                entity.Property(e => e.AccommodationId).HasColumnName("AccommodationID");

                entity.Property(e => e.AccommodationlName).HasMaxLength(50);

                entity.Property(e => e.Bb).HasColumnName("BB");

                entity.Property(e => e.TownCentre).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<AccommodationDescription>(entity =>
            {
                entity.HasKey(e => e.AccommodationId);

                entity.Property(e => e.AccommodationId)
                    .HasColumnName("AccommodationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccommodationName).HasMaxLength(50);

                entity.Property(e => e.AccommodationStandard).HasMaxLength(50);

                entity.Property(e => e.AccommodationType).HasMaxLength(50);

                entity.Property(e => e.AgeRestriction).HasColumnName("Age Restriction");

                entity.Property(e => e.BarNote)
                    .HasColumnName("BarNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.BeachTowelsProvidedNote)
                    .HasColumnName("BeachTowelsProvidedNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.BoardBasisNote)
                    .HasColumnName("BoardBasisNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.BoardUpgradeAvailable1).HasMaxLength(50);

                entity.Property(e => e.BoardUpgradeAvailable2).HasMaxLength(50);

                entity.Property(e => e.BoardUpgradeAvailable3).HasMaxLength(50);

                entity.Property(e => e.BoardUpgradeAvailable4).HasMaxLength(50);

                entity.Property(e => e.CarRentalNote)
                    .HasColumnName("CarRentalNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.ChildrensDiscountNote)
                    .HasColumnName("ChildrensDiscountNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.ChildrensFacilitiesNote)
                    .HasColumnName("ChildrensFacilitiesNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.ConciergeNote)
                    .HasColumnName("ConciergeNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.ContractBoardBasis).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.DescriptionNote)
                    .HasColumnName("DescriptionNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.DisabledFacilitiesNote)
                    .HasColumnName("DisabledFacilitiesNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.EveningEntertainmentNote).HasColumnType("ntext");

                entity.Property(e => e.FourthAdultShareNote)
                    .HasColumnName("FourthAdultShareNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.GolfNote)
                    .HasColumnName("GolfNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.GymnasiumNote)
                    .HasColumnName("GymnasiumNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.HoneymoonCopy).HasColumnType("ntext");

                entity.Property(e => e.HoneymoonDeal).HasColumnType("ntext");

                entity.Property(e => e.HorseridingNote)
                    .HasColumnName("HorseridingNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.HotelBriefDescription).HasColumnType("ntext");

                entity.Property(e => e.JacuzziNote)
                    .HasColumnName("JacuzziNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.Location).HasMaxLength(150);

                entity.Property(e => e.MoneyExchangeNote)
                    .HasColumnName("MoneyExchangeNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.NightclubNote).HasColumnType("ntext");

                entity.Property(e => e.NumberOfRooms).HasMaxLength(50);

                entity.Property(e => e.NumberOfRoomsNote)
                    .HasColumnName("NumberOfRoomsNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.OfficialRating)
                    .HasColumnName("Official Rating")
                    .HasMaxLength(50);

                entity.Property(e => e.OtherFacilitiesNote).HasColumnType("ntext");

                entity.Property(e => e.OurRating)
                    .HasColumnName("Our Rating")
                    .HasMaxLength(50);

                entity.Property(e => e.Place).HasMaxLength(50);

                entity.Property(e => e.PlaceName).HasMaxLength(50);

                entity.Property(e => e.PoolNote)
                    .HasColumnName("PoolNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.ProductGroup1).HasMaxLength(50);

                entity.Property(e => e.ProductGroup2).HasMaxLength(50);

                entity.Property(e => e.ProductGroup3).HasMaxLength(50);

                entity.Property(e => e.ProductGroup4).HasMaxLength(50);

                entity.Property(e => e.Provider).HasMaxLength(50);

                entity.Property(e => e.Region).HasMaxLength(50);

                entity.Property(e => e.RestaurantNote)
                    .HasColumnName("RestaurantNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.RoomServiceNote)
                    .HasColumnName("RoomServiceNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.ScubaDivingNote)
                    .HasColumnName("ScubaDivingNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.ShopsNote)
                    .HasColumnName("ShopsNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.SportsFacilitiesNote)
                    .HasColumnName("SportsFacilitiesNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.SquashNote)
                    .HasColumnName("SquashNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.TennisNote)
                    .HasColumnName("TennisNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.ThirdAdultShareNote)
                    .HasColumnName("ThirdAdultShareNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.ToursDeskNote)
                    .HasColumnName("ToursDeskNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.UseIt)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.WatersportsNote)
                    .HasColumnName("WatersportsNOTE")
                    .HasColumnType("ntext");
            });

            modelBuilder.Entity<AccommodationRoomSpecification>(entity =>
            {
                entity.HasKey(e => e.Pkey);

                entity.Property(e => e.Pkey).HasColumnName("PKey");

                entity.Property(e => e.AccommodationId).HasColumnName("AccommodationID");

                entity.Property(e => e.AccommodationName).HasMaxLength(50);

                entity.Property(e => e.AirConditioningNote)
                    .HasColumnName("AirConditioningNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.Cdplayer).HasColumnName("CDPlayer");

                entity.Property(e => e.CdplayerNote)
                    .HasColumnName("CDPLayerNote")
                    .HasColumnType("ntext");

                entity.Property(e => e.CeilingFanNote)
                    .HasColumnName("CeilingFanNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.DiningAreaNote)
                    .HasColumnName("DiningAreaNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.GeneralCopy).HasColumnType("ntext");

                entity.Property(e => e.HairdryerNote)
                    .HasColumnName("HairdryerNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.HammocksNote)
                    .HasColumnName("HammocksNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.IroningFacilitiesNote)
                    .HasColumnName("IroningFacilitiesNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.KitchenNote)
                    .HasColumnName("KitchenNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.KitchenetteNote)
                    .HasColumnName("KitchenetteNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.LakeViewNote).HasColumnType("ntext");

                entity.Property(e => e.LivingAreaNote)
                    .HasColumnName("LivingAreaNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.MiniBarNote)
                    .HasColumnName("MiniBarNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.MiniFridgeNote).HasColumnType("ntext");

                entity.Property(e => e.NoSmokingRoomAvailableNote)
                    .HasColumnName("NoSmokingRoomAvailableNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.NumberOfRooms).HasMaxLength(5);

                entity.Property(e => e.OtherFacilitiesNote)
                    .HasColumnName("OtherFacilitiesNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.PrivateBathroomNote)
                    .HasColumnName("PrivateBathroomNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.PrivateGardenNote)
                    .HasColumnName("PrivateGardenNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.PrivatePoolNote)
                    .HasColumnName("PrivatePoolNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.RoomSharingNote)
                    .HasColumnName("RoomSharingNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.RoomType).HasMaxLength(100);

                entity.Property(e => e.SafeNote)
                    .HasColumnName("SafeNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.SatelliteTv).HasColumnName("SatelliteTV");

                entity.Property(e => e.SatelliteTvnote)
                    .HasColumnName("SatelliteTVNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.SeaviewAvailableNote)
                    .HasColumnName("SeaviewAvailableNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.TelephoneNote)
                    .HasColumnName("TelephoneNOTE")
                    .HasColumnType("ntext");

                entity.Property(e => e.TerraceBalcony).HasColumnName("Terrace/Balcony");

                entity.Property(e => e.TerraceBalconyNote)
                    .HasColumnName("Terrace/BalconyNOTE")
                    .HasColumnType("ntext");
            });

            modelBuilder.Entity<AccommodationSelfCater>(entity =>
            {
                entity.HasKey(e => e.Asckey);

                entity.Property(e => e.Asckey).HasColumnName("ASCkey");

                entity.Property(e => e.AccommodationId).HasColumnName("AccommodationID");

                entity.Property(e => e.AccommodationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BathRoomNote)
                    .HasColumnName("BathRoomNOTE")
                    .HasColumnType("text");

                entity.Property(e => e.Bbq).HasColumnName("BBQ");

                entity.Property(e => e.Bbqnote)
                    .HasColumnName("BBQNOTE")
                    .HasColumnType("text");

                entity.Property(e => e.EntertainmentNote)
                    .HasColumnName("EntertainmentNOTE")
                    .HasColumnType("text");

                entity.Property(e => e.HeatingNote)
                    .HasColumnName("HeatingNOTE")
                    .HasColumnType("text");

                entity.Property(e => e.InternetNote)
                    .HasColumnName("InternetNOTE")
                    .HasColumnType("text");

                entity.Property(e => e.KitchenNote)
                    .HasColumnName("KitchenNOTE")
                    .HasColumnType("text");

                entity.Property(e => e.LaundryNote)
                    .HasColumnName("LaundryNOTE")
                    .HasColumnType("text");

                entity.Property(e => e.LinenSuppliedNote)
                    .HasColumnName("LinenSuppliedNOTE")
                    .HasColumnType("text");

                entity.Property(e => e.MiniBarNote)
                    .HasColumnName("MiniBarNOTE")
                    .HasColumnType("text");

                entity.Property(e => e.NoSmokingNote)
                    .HasColumnName("NoSmokingNOTE")
                    .HasColumnType("text");

                entity.Property(e => e.ParkingNote)
                    .HasColumnName("ParkingNOTE")
                    .HasColumnType("text");

                entity.Property(e => e.PlayAreaNote)
                    .HasColumnName("PlayAreaNOTE")
                    .HasColumnType("text");

                entity.Property(e => e.Replace1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShoppingNote)
                    .HasColumnName("ShoppingNOTE")
                    .HasColumnType("text");

                entity.Property(e => e.ShowerNote)
                    .HasColumnName("ShowerNOTE")
                    .HasColumnType("text");

                entity.Property(e => e.SpaSaunaNote)
                    .HasColumnName("SpaSaunaNOTE")
                    .HasColumnType("text");

                entity.Property(e => e.TelephoneNote)
                    .HasColumnName("TelephoneNOTE")
                    .HasColumnType("text");

                entity.Property(e => e.UseIt)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AirChildDiscount>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.Property(e => e.SupplierId)
                    .HasColumnName("SupplierID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<AirportCodes>(entity =>
            {
                entity.HasKey(e => e.Pkey);

                entity.Property(e => e.Pkey).HasColumnName("PKey");

                entity.Property(e => e.AirportCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AirportName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Psc).HasColumnName("PSC");
            });

            modelBuilder.Entity<AirportNodes>(entity =>
            {
                entity.HasKey(e => e.NodeId);

                entity.Property(e => e.NodeId)
                    .HasColumnName("NodeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AirportName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Airports>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.Aid).HasColumnName("AID");

                entity.Property(e => e.Airline)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AirportCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.DepAirport)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Aptrates>(entity =>
            {
                entity.HasKey(e => e.Pkey);

                entity.ToTable("APTRates");

                entity.Property(e => e.Pkey).HasColumnName("PKey");

                entity.Property(e => e.Airline)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Aptrate).HasColumnName("APTRate");

                entity.Property(e => e.AptrateId).HasColumnName("APTRateID");

                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BoardUpgradeRates>(entity =>
            {
                entity.HasKey(e => e.Pkey);

                entity.Property(e => e.Pkey).HasColumnName("PKey");

                entity.Property(e => e.BoardBasis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CnetRate)
                    .HasColumnName("CNetRate")
                    .HasColumnType("money");

                entity.Property(e => e.CurrencyId)
                    .HasColumnName("CurrencyID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.NetRate).HasColumnType("money");

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<ContractRates>(entity =>
            {
                entity.HasKey(e => e.ContractRateId)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.ContractRateId)
                    .HasName("_dta_index_ContractRates_c_7_996198599__K1")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.ContractRateId).HasColumnName("ContractRateID");

                entity.Property(e => e.CnetRate)
                    .HasColumnName("CNetRate")
                    .HasColumnType("money");

                entity.Property(e => e.ContractBoardBasis)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ContractRoomType)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CsingleRate)
                    .HasColumnName("CSingleRate")
                    .HasColumnType("money");

                entity.Property(e => e.CurrencyId)
                    .HasColumnName("CurrencyID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Estimated)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.NetRate).HasColumnType("money");

                entity.Property(e => e.RoomOccupancy).HasDefaultValueSql("((2))");

                entity.Property(e => e.SingleRate).HasColumnType("money");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.Web)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContractRules>(entity =>
            {
                entity.HasKey(e => e.ChildRuleId);

                entity.Property(e => e.ChildRuleId).HasColumnName("ChildRuleID");

                entity.Property(e => e.Cchild1ShareDiscount)
                    .HasColumnName("CChild1ShareDiscount")
                    .HasColumnType("money");

                entity.Property(e => e.Child1ShareDiscount).HasColumnType("money");

                entity.Property(e => e.Child2ShareDiscount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.Child3ShareDiscount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.CownRoomDiscount1)
                    .HasColumnName("COwnRoomDiscount1")
                    .HasColumnType("money");

                entity.Property(e => e.CurrencyId)
                    .HasColumnName("CurrencyID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateStamp).HasColumnType("datetime");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.OwnRoomDiscount1)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OwnRoomDiscount2)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OwnRoomDiscount3)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RoomType)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            });

            modelBuilder.Entity<CurrencyExchange>(entity =>
            {
                entity.HasKey(e => e.CurrencyId);

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.CurrencyName).HasMaxLength(10);
            });

            modelBuilder.Entity<DefaultAirports>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.Property(e => e.SupplierId)
                    .HasColumnName("SupplierID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AirportCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DefaultTransfers>(entity =>
            {
                entity.HasKey(e => e.TransferId);

                entity.Property(e => e.TransferId).HasColumnName("TransferID");

                entity.Property(e => e.Destination)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Origination)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");
            });

            modelBuilder.Entity<DynamicPictures>(entity =>
            {
                entity.HasKey(e => e.PictureId);

                entity.Property(e => e.PictureId).HasColumnName("PictureID");

                entity.Property(e => e.Caption).HasColumnType("ntext");

                entity.Property(e => e.CountryName).HasMaxLength(50);

                entity.Property(e => e.Path).HasMaxLength(255);

                entity.Property(e => e.PicFilename).HasMaxLength(100);

                entity.Property(e => e.ShortTitle).HasMaxLength(50);

                entity.Property(e => e.Web).HasMaxLength(1);
            });

            modelBuilder.Entity<FlightCosts>(entity =>
            {
                entity.HasKey(e => e.Pkey);

                entity.Property(e => e.Pkey).HasColumnName("PKey");

                entity.Property(e => e.AptrateId).HasColumnName("APTRateID");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Description)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Fdate)
                    .HasColumnName("FDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.Fnumber)
                    .HasColumnName("FNumber")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.UseIt)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Web)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlightOptions>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Airport)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Day)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            });

            modelBuilder.Entity<FlightTable>(entity =>
            {
                entity.HasKey(e => e.FlightId);

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.ArrivalAirport)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ArrivalTime)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AvailabilityLastUpdate).HasColumnType("smalldatetime");

                entity.Property(e => e.DepartureAirport)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DepartureTime)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FlightDepartureDate).HasColumnType("smalldatetime");

                entity.Property(e => e.FlightNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FlightType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.OverNight)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.UseIt)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Via1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ViaArrTime)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlightTableInbound>(entity =>
            {
                entity.HasKey(e => e.InboundFlightId);

                entity.ToTable("FlightTableINBOUND");

                entity.Property(e => e.InboundFlightId).HasColumnName("InboundFlightID");

                entity.Property(e => e.ArrivalAirport)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ArrivalTime)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AvailabilityLastUpdate).HasColumnType("smalldatetime");

                entity.Property(e => e.DepartureAirport)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DepartureTime)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FlightDepartureDate).HasColumnType("smalldatetime");

                entity.Property(e => e.FlightNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FlightType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.OverNight)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.UseIt)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Via1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ViaArrTime)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hotels>(entity =>
            {
                entity.HasKey(e => e.Pkey);

                entity.Property(e => e.Pkey).HasColumnName("PKey");

                entity.Property(e => e.Allocation).HasDefaultValueSql("((0))");

                entity.Property(e => e.BoardBasis)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.EnforceMaxShare)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Hotel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HotelAddress1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HotelAddress2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HotelAddress3)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HotelAddress4)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HotelEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.HotelMapReference)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HotelPostCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HotelTelephoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Icon).HasMaxLength(10);

                entity.Property(e => e.IsVilla).HasDefaultValueSql("((0))");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MaxShare).HasDefaultValueSql("((0))");

                entity.Property(e => e.OpDays)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Place)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlaceId).HasColumnName("PlaceID");

                entity.Property(e => e.Ref)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Star)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.UseIt)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Web)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pictures>(entity =>
            {
                entity.HasKey(e => e.PictureId);

                entity.Property(e => e.PictureId).HasColumnName("PictureID");

                entity.Property(e => e.AccommodationId).HasColumnName("AccommodationID");

                entity.Property(e => e.AccommodationName).HasMaxLength(50);

                entity.Property(e => e.Caption).HasColumnType("ntext");

                entity.Property(e => e.CountryName).HasMaxLength(50);

                entity.Property(e => e.Format).HasMaxLength(1);

                entity.Property(e => e.GeneralItemId).HasColumnName("GeneralItemID");

                entity.Property(e => e.IsImage).HasDefaultValueSql("((1))");

                entity.Property(e => e.PicFilename).HasMaxLength(100);

                entity.Property(e => e.PlaceId).HasColumnName("PlaceID");

                entity.Property(e => e.PlaceName).HasMaxLength(50);

                entity.Property(e => e.ProductGroup).HasMaxLength(50);

                entity.Property(e => e.RegionName).HasMaxLength(50);

                entity.Property(e => e.ShortTitle).HasMaxLength(50);

                entity.Property(e => e.Web).HasMaxLength(1);
            });

            modelBuilder.Entity<Places>(entity =>
            {
                entity.HasKey(e => e.PlaceNameId);

                entity.HasIndex(e => e.CarHireOffice)
                    .HasName("_dta_index_Places_6_1495676376__K27");

                entity.Property(e => e.PlaceNameId)
                    .HasColumnName("PlaceNameID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Copy1)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Copy2)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Copy3)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Copy4)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Copy5)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Copy6)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Copy7)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Copy8)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.GeneralItemId).HasColumnName("GeneralItemID");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MapOrder).HasDefaultValueSql("((999))");

                entity.Property(e => e.PlaceBriefDescription).HasColumnType("ntext");

                entity.Property(e => e.PlaceName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShortPlaceName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title1)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Title2)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Title3)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Title4)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Title5)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Title6)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Title7)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Title8)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.UseIt)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.WithAccomm)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Xml)
                    .HasColumnName("XML")
                    .HasColumnType("xml");
            });

            modelBuilder.Entity<PriceMultiplyier>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Multiplier).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<PricesOther>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(6, 2)");
            });

            modelBuilder.Entity<PrintMessages>(entity =>
            {
                entity.HasKey(e => e.Pkey);

                entity.Property(e => e.Pkey).HasColumnName("PKey");

                entity.Property(e => e.Message)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PrintType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfileTable>(entity =>
            {
                entity.HasKey(e => e.RowNumber);

                entity.Property(e => e.ApplicationName).HasMaxLength(128);

                entity.Property(e => e.BinaryData).HasColumnType("image");

                entity.Property(e => e.ClientProcessId).HasColumnName("ClientProcessID");

                entity.Property(e => e.Cpu).HasColumnName("CPU");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.LoginName).HasMaxLength(128);

                entity.Property(e => e.NtuserName)
                    .HasColumnName("NTUserName")
                    .HasMaxLength(128);

                entity.Property(e => e.Spid).HasColumnName("SPID");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.TextData).HasColumnType("ntext");
            });

            modelBuilder.Entity<Psc>(entity =>
            {
                entity.HasKey(e => e.Pkey);

                entity.ToTable("PSC");

                entity.Property(e => e.Pkey).HasColumnName("PKey");

                entity.Property(e => e.Airline)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Arr).HasColumnType("money");

                entity.Property(e => e.Dep).HasColumnType("money");

                entity.Property(e => e.DepAirport)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DestAirport)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            });

            modelBuilder.Entity<RoomUpgradeRates>(entity =>
            {
                entity.HasKey(e => e.Pkey);

                entity.Property(e => e.Pkey).HasColumnName("PKey");

                entity.Property(e => e.CnetRate)
                    .HasColumnName("CNetRate")
                    .HasColumnType("money");

                entity.Property(e => e.CurrencyId)
                    .HasColumnName("CurrencyID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.NetRate).HasColumnType("money");

                entity.Property(e => e.RoomType)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<TransferLogic>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CarHireCopy1).HasColumnType("ntext");

                entity.Property(e => e.CarHireCopy2).HasColumnType("ntext");

                entity.Property(e => e.CarHireCopy3).HasColumnType("ntext");

                entity.Property(e => e.CarOrder1).HasMaxLength(2);

                entity.Property(e => e.CarOrder2).HasMaxLength(50);

                entity.Property(e => e.CarOrder3).HasMaxLength(50);

                entity.Property(e => e.CarOrder4).HasMaxLength(50);

                entity.Property(e => e.CarOrder5).HasMaxLength(2);

                entity.Property(e => e.CarOrder6).HasMaxLength(2);

                entity.Property(e => e.CarOrder7).HasMaxLength(2);

                entity.Property(e => e.CarOrder8).HasMaxLength(50);

                entity.Property(e => e.CollectDrop).HasColumnType("ntext");

                entity.Property(e => e.CombinationRequired).HasDefaultValueSql("((0))");

                entity.Property(e => e.Destination).HasMaxLength(50);

                entity.Property(e => e.DestinationCarRentalOffice).HasDefaultValueSql("((0))");

                entity.Property(e => e.FlightId1)
                    .HasColumnName("FlightID1")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.FlightId2)
                    .HasColumnName("FlightID2")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.FlightId3)
                    .HasColumnName("FlightID3")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.FlightId4)
                    .HasColumnName("FlightID4")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.FlyDrivePrice)
                    .HasColumnType("decimal(8, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GroundId1).HasColumnName("GroundID1");

                entity.Property(e => e.GroundId2).HasColumnName("GroundID2");

                entity.Property(e => e.GroundId3).HasColumnName("GroundID3");

                entity.Property(e => e.GroundId4).HasColumnName("GroundID4");

                entity.Property(e => e.ItemPrice1)
                    .HasColumnType("decimal(8, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ItemPrice2)
                    .HasColumnType("decimal(8, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ItemPrice3)
                    .HasColumnType("decimal(8, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ItemPrice4)
                    .HasColumnType("decimal(8, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Origin).HasMaxLength(50);

                entity.Property(e => e.OriginCarRentalOffice).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("decimal(8, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TransferItem1).HasColumnType("ntext");

                entity.Property(e => e.TransferItem2).HasColumnType("ntext");

                entity.Property(e => e.TransferItem3).HasColumnType("ntext");

                entity.Property(e => e.TransferItem4).HasColumnType("ntext");

                entity.Property(e => e.TransferNote).HasColumnType("ntext");

                entity.Property(e => e.TransferPrice)
                    .HasColumnType("decimal(8, 2)")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Transfers>(entity =>
            {
                entity.HasKey(e => e.TransferId);

                entity.Property(e => e.TransferId).HasColumnName("TransferID");

                entity.Property(e => e.Dest)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DestinationId)
                    .HasColumnName("DestinationID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DropId)
                    .HasColumnName("DropID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DropOff)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DropOffTypeId)
                    .HasColumnName("DropOffTypeID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Origination)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OriginationId)
                    .HasColumnName("OriginationID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PickUp)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PickUpId)
                    .HasColumnName("PickUpID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PickUpTypeId)
                    .HasColumnName("PickUpTypeID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.UseIt)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TransfersOther>(entity =>
            {
                entity.HasKey(e => e.Pkey);

                entity.Property(e => e.Ppoint)
                    .HasColumnName("PPoint")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XferCosts>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Id)
                    .HasName("_dta_index_XferCosts_c_7_887674210__K1")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cnet)
                    .HasColumnName("CNet")
                    .HasColumnType("money");

                entity.Property(e => e.CurrencyId)
                    .HasColumnName("CurrencyID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Days)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Net).HasColumnType("money");

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity.Property(e => e.TransferId).HasColumnName("TransferID");
            });
        }
    }
}
