using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CodeWorksVoyWebService.Models.WebData
{
    public partial class WebDataContext : DbContext
    {
        public WebDataContext()
        {
        }

        public WebDataContext(DbContextOptions<WebDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminItinTemplates> AdminItinTemplates { get; set; }
        public virtual DbSet<Card> Card { get; set; }
        public virtual DbSet<CardElementCardsPerRow> CardElementCardsPerRow { get; set; }
        public virtual DbSet<CardElementCategories> CardElementCategories { get; set; }
        public virtual DbSet<CardElementCountry> CardElementCountry { get; set; }
        public virtual DbSet<CardElementDescription> CardElementDescription { get; set; }
        public virtual DbSet<CardElementDetailLevel> CardElementDetailLevel { get; set; }
        public virtual DbSet<CardElementGroup> CardElementGroup { get; set; }
        public virtual DbSet<CardElementHotelFeatures> CardElementHotelFeatures { get; set; }
        public virtual DbSet<CardElementId> CardElementId { get; set; }
        public virtual DbSet<CardElementImageDisplay> CardElementImageDisplay { get; set; }
        public virtual DbSet<CardElementImageTemplate> CardElementImageTemplate { get; set; }
        public virtual DbSet<CardElementPlace> CardElementPlace { get; set; }
        public virtual DbSet<CardElementPlaceFeatures> CardElementPlaceFeatures { get; set; }
        public virtual DbSet<CardElementTags> CardElementTags { get; set; }
        public virtual DbSet<CardElementTitle> CardElementTitle { get; set; }
        public virtual DbSet<CardElementTripFlightAirline> CardElementTripFlightAirline { get; set; }
        public virtual DbSet<CardElementTripFlightAirport> CardElementTripFlightAirport { get; set; }
        public virtual DbSet<CardElementTripFlightDeparture> CardElementTripFlightDeparture { get; set; }
        public virtual DbSet<CardElementTripFlightReturn> CardElementTripFlightReturn { get; set; }
        public virtual DbSet<CardElementTripFlightTemplate> CardElementTripFlightTemplate { get; set; }
        public virtual DbSet<CardElementTripHotelsListTemplate> CardElementTripHotelsListTemplate { get; set; }
        public virtual DbSet<CardElementTripNightCount> CardElementTripNightCount { get; set; }
        public virtual DbSet<CardElementTripPlaceCount> CardElementTripPlaceCount { get; set; }
        public virtual DbSet<CardElementTripPlaceListTemplate> CardElementTripPlaceListTemplate { get; set; }
        public virtual DbSet<CardElementTripPrice> CardElementTripPrice { get; set; }
        public virtual DbSet<CardElementViewDetails> CardElementViewDetails { get; set; }
        public virtual DbSet<CubaMenuMaster> CubaMenuMaster { get; set; }
        public virtual DbSet<HotSpots> HotSpots { get; set; }
        public virtual DbSet<ItinPlaces> ItinPlaces { get; set; }
        public virtual DbSet<ItinTemplateTimeId> ItinTemplateTimeId { get; set; }
        public virtual DbSet<ItinTemplateTimeIdescorted> ItinTemplateTimeIdescorted { get; set; }
        public virtual DbSet<ItinTemplateTimeIdlookup> ItinTemplateTimeIdlookup { get; set; }
        public virtual DbSet<MapGroups> MapGroups { get; set; }
        public virtual DbSet<MenuLevel1> MenuLevel1 { get; set; }
        public virtual DbSet<MenuLevel2> MenuLevel2 { get; set; }
        public virtual DbSet<MenuLevel3> MenuLevel3 { get; set; }
        public virtual DbSet<MenuLevel4> MenuLevel4 { get; set; }
        public virtual DbSet<PageParameters> PageParameters { get; set; }
        public virtual DbSet<PictureGroups> PictureGroups { get; set; }
        public virtual DbSet<SettingsCategory> SettingsCategory { get; set; }
        public virtual DbSet<SettingsCategoryStore> SettingsCategoryStore { get; set; }
        public virtual DbSet<SettingsCodeBlock> SettingsCodeBlock { get; set; }
        public virtual DbSet<SettingsColumnColour> SettingsColumnColour { get; set; }
        public virtual DbSet<SettingsComponents> SettingsComponents { get; set; }
        public virtual DbSet<SettingsFont> SettingsFont { get; set; }
        public virtual DbSet<SettingsFontColour> SettingsFontColour { get; set; }
        public virtual DbSet<SettingsFontLetterspacing> SettingsFontLetterspacing { get; set; }
        public virtual DbSet<SettingsFontSize> SettingsFontSize { get; set; }
        public virtual DbSet<SettingsFontTexttransform> SettingsFontTexttransform { get; set; }
        public virtual DbSet<SettingsFontWeight> SettingsFontWeight { get; set; }
        public virtual DbSet<SettingsFontWordwrap> SettingsFontWordwrap { get; set; }
        public virtual DbSet<SettingsPosition> SettingsPosition { get; set; }
        public virtual DbSet<SettingsStageTitle> SettingsStageTitle { get; set; }
        public virtual DbSet<SettingsTags> SettingsTags { get; set; }
        public virtual DbSet<SettingsTagsStore> SettingsTagsStore { get; set; }
        public virtual DbSet<SettingsTextAlign> SettingsTextAlign { get; set; }
        public virtual DbSet<SettingsWebLinks> SettingsWebLinks { get; set; }
        public virtual DbSet<TemplateTypes> TemplateTypes { get; set; }
        public virtual DbSet<TripStagePictures> TripStagePictures { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<UserItinerary> UserItinerary { get; set; }
        public virtual DbSet<UserTransfers> UserTransfers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=Develop\\Codeworks;Database=WebData;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminItinTemplates>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.AccordianName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AdminItinId).HasColumnName("AdminItinID");

                entity.Property(e => e.CountId).HasColumnName("CountID");

                entity.Property(e => e.Country).HasMaxLength(10);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.PageDescription).IsUnicode(false);

                entity.Property(e => e.PageTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TemplateTypeId).HasColumnName("TemplateTypeID");
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.Card1ElementBookmarkStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementCategoriesStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementCountryStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementDescriptionMaxCharacters).HasMaxLength(50);

                entity.Property(e => e.Card1ElementDescriptionStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementGroupStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementHotelFeaturesStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementId).HasColumnName("Card1ElementID");

                entity.Property(e => e.Card1ElementIdstyle)
                    .HasColumnName("Card1ElementIDStyle")
                    .IsUnicode(false);

                entity.Property(e => e.Card1ElementPlaceFeaturesStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementPlaceStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementShareStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementTagsStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementTitleStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementTripFlightAirlineStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementTripFlightAirportStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementTripFlightDepartureStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementTripFlightReturnStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementTripFlightTemplateStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementTripHotelsListStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementTripNightCountStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementTripPlaceCountStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementTripPlacesListStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementTripPriceStyle).IsUnicode(false);

                entity.Property(e => e.Card1ElementViewDetailsStyle).IsUnicode(false);
            });

            modelBuilder.Entity<CardElementCardsPerRow>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementCategories>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementCountry>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementDescription>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementDetailLevel>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementGroup>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementHotelFeatures>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementId>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.ToTable("CardElementID");

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementImageDisplay>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementImageTemplate>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementPlace>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementPlaceFeatures>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementTags>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementTitle>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementTripFlightAirline>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementTripFlightAirport>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementTripFlightDeparture>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementTripFlightReturn>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementTripFlightTemplate>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementTripHotelsListTemplate>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementTripNightCount>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementTripPlaceCount>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementTripPlaceListTemplate>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementTripPrice>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardElementViewDetails>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<CubaMenuMaster>(entity =>
            {
                entity.HasKey(e => e.Pkey);

                entity.ToTable("CubaMenuMASTER");

                entity.Property(e => e.Country).HasMaxLength(10);

                entity.Property(e => e.FileType).HasMaxLength(255);

                entity.Property(e => e.IndexPath).HasMaxLength(255);

                entity.Property(e => e.InfopageName)
                    .HasColumnName("INFOPageName")
                    .HasMaxLength(255);

                entity.Property(e => e.MapGroupType).HasMaxLength(255);

                entity.Property(e => e.MenuLevel1).HasMaxLength(255);

                entity.Property(e => e.MenuLevel2).HasMaxLength(255);

                entity.Property(e => e.MenuLevel3).HasMaxLength(255);

                entity.Property(e => e.MenuLevel4).HasMaxLength(255);

                entity.Property(e => e.PictureGroupType).HasMaxLength(255);

                entity.Property(e => e.Priority).HasDefaultValueSql("((99))");

                entity.Property(e => e.Seo1).HasColumnName("SEO1");

                entity.Property(e => e.Seo2).HasColumnName("SEO2");

                entity.Property(e => e.UseIt)
                    .IsRequired()
                    .HasColumnName("use it")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.VisableOnMenu)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<HotSpots>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.HotSpotName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ImageId).HasColumnName("ImageID");
            });

            modelBuilder.Entity<ItinPlaces>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.Country).HasMaxLength(10);

                entity.Property(e => e.Element1).IsUnicode(false);

                entity.Property(e => e.Element1Colour).HasMaxLength(10);

                entity.Property(e => e.Element1Width).HasMaxLength(10);

                entity.Property(e => e.Element2).IsUnicode(false);

                entity.Property(e => e.Element2Colour).HasMaxLength(10);

                entity.Property(e => e.Element2Width).HasMaxLength(10);

                entity.Property(e => e.Element3).IsUnicode(false);

                entity.Property(e => e.Element3Colour).HasMaxLength(10);

                entity.Property(e => e.Element3Width).HasMaxLength(10);

                entity.Property(e => e.Element4).IsUnicode(false);

                entity.Property(e => e.Element4Colour).HasMaxLength(10);

                entity.Property(e => e.Element4Width).HasMaxLength(10);

                entity.Property(e => e.Element5).IsUnicode(false);

                entity.Property(e => e.Element5Colour).HasMaxLength(10);

                entity.Property(e => e.Element5Width).HasMaxLength(10);

                entity.Property(e => e.Element6).IsUnicode(false);

                entity.Property(e => e.Element6Colour).HasMaxLength(10);

                entity.Property(e => e.Element6Width).HasMaxLength(10);

                entity.Property(e => e.Hotel)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.ItinId).HasColumnName("ItinID");

                entity.Property(e => e.Place)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PlaceId).HasColumnName("PlaceID");

                entity.Property(e => e.Seotext)
                    .HasColumnName("SEOText")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Seotitle)
                    .HasColumnName("SEOTitle")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StageTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TourStageAccommodation).IsUnicode(false);

                entity.Property(e => e.TourStageMealBasis)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<ItinTemplateTimeId>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.ToTable("ItinTemplateTimeID");

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.TimeId).HasColumnName("TimeID");

                entity.Property(e => e.UserItinId).HasColumnName("UserItinID");
            });

            modelBuilder.Entity<ItinTemplateTimeIdescorted>(entity =>
            {
                entity.ToTable("ItinTemplateTimeIDEscorted");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Country).HasMaxLength(10);

                entity.Property(e => e.ItinName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.TemplateName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TimeId).HasColumnName("TimeID");

                entity.Property(e => e.TimeName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItinTemplateTimeIdlookup>(entity =>
            {
                entity.HasKey(e => e.TimeRangeName);

                entity.ToTable("ItinTemplateTimeIDlookup");

                entity.Property(e => e.TimeRangeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.TimeId).HasColumnName("TimeID");
            });

            modelBuilder.Entity<MapGroups>(entity =>
            {
                entity.HasKey(e => e.MapGroupType);

                entity.Property(e => e.MapGroupType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuLevel1>(entity =>
            {
                entity.HasKey(e => e.Id1);

                entity.Property(e => e.Id1)
                    .HasColumnName("ID1")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryItem).HasDefaultValueSql("((0))");

                entity.Property(e => e.Country).HasMaxLength(10);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PathLevel)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuLevel2>(entity =>
            {
                entity.HasKey(e => new { e.Id1, e.Id2 });

                entity.Property(e => e.Id1).HasColumnName("ID1");

                entity.Property(e => e.Id2).HasColumnName("ID2");

                entity.Property(e => e.CategoryItem).HasDefaultValueSql("((0))");

                entity.Property(e => e.Country).HasMaxLength(10);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PathLevel)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuLevel3>(entity =>
            {
                entity.HasKey(e => new { e.Id1, e.Id2, e.Id3 });

                entity.Property(e => e.Id1).HasColumnName("ID1");

                entity.Property(e => e.Id2).HasColumnName("ID2");

                entity.Property(e => e.Id3).HasColumnName("ID3");

                entity.Property(e => e.CategoryItem).HasDefaultValueSql("((0))");

                entity.Property(e => e.Country).HasMaxLength(10);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PathLevel)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuLevel4>(entity =>
            {
                entity.HasKey(e => new { e.Id1, e.Id2, e.Id3, e.Id4 });

                entity.Property(e => e.Id1).HasColumnName("ID1");

                entity.Property(e => e.Id2).HasColumnName("ID2");

                entity.Property(e => e.Id3).HasColumnName("ID3");

                entity.Property(e => e.Id4).HasColumnName("ID4");

                entity.Property(e => e.CategoryItem).HasDefaultValueSql("((0))");

                entity.Property(e => e.Country).HasMaxLength(10);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PathLevel)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PageParameters>(entity =>
            {
                entity.HasKey(e => e.PathLevel);

                entity.Property(e => e.PathLevel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FileType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IndexPath)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InfoPageName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MapGroupType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PictureGroupType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Seo1)
                    .HasColumnName("SEO1")
                    .IsUnicode(false);

                entity.Property(e => e.Seo2)
                    .HasColumnName("SEO2")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PictureGroups>(entity =>
            {
                entity.HasKey(e => e.PictureGroupType);

                entity.Property(e => e.PictureGroupType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SettingsCategory>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.Category).IsUnicode(false);

                entity.Property(e => e.CategoryData).IsUnicode(false);
            });

            modelBuilder.Entity<SettingsCategoryStore>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.Category).IsUnicode(false);

                entity.Property(e => e.TripId).HasColumnName("TripID");
            });

            modelBuilder.Entity<SettingsCodeBlock>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.SettingsCodeBlock1)
                    .HasColumnName("SettingsCodeBlock")
                    .IsUnicode(false);

                entity.Property(e => e.SettingsCodeBlockData).IsUnicode(false);

                entity.Property(e => e.SettingsCodeBlockE1w)
                    .HasColumnName("SettingsCodeBlockE1W")
                    .HasMaxLength(10);

                entity.Property(e => e.SettingsCodeBlockStageOrder).HasMaxLength(10);

                entity.Property(e => e.SettingsCodeBlockStageTitle).IsUnicode(false);
            });

            modelBuilder.Entity<SettingsColumnColour>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.ColumnColour).IsUnicode(false);

                entity.Property(e => e.ColumnColourData).IsUnicode(false);
            });

            modelBuilder.Entity<SettingsComponents>(entity =>
            {
                entity.HasKey(e => e.Pkey);

                entity.Property(e => e.Pkey).ValueGeneratedNever();

                entity.Property(e => e.ComponentCardTripId).HasColumnName("ComponentCardTripID");

                entity.Property(e => e.ComponentPageDetailPanel1Height).HasMaxLength(10);

                entity.Property(e => e.ComponentPageDetailPanel2Height).HasMaxLength(10);

                entity.Property(e => e.ComponentPageDetailPanel3Height).HasMaxLength(10);

                entity.Property(e => e.ComponentPageIndexPanel2MenuDetailScale).IsUnicode(false);

                entity.Property(e => e.ComponentPageWelcomePanel1Content).HasMaxLength(10);

                entity.Property(e => e.DetailScale).HasMaxLength(10);

                entity.Property(e => e.TemplateTypeId)
                    .HasColumnName("TemplateTypeID")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<SettingsFont>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.Font).IsUnicode(false);

                entity.Property(e => e.FontData).IsUnicode(false);
            });

            modelBuilder.Entity<SettingsFontColour>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.FontColour).IsUnicode(false);

                entity.Property(e => e.FontColourData).IsUnicode(false);
            });

            modelBuilder.Entity<SettingsFontLetterspacing>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");
            });

            modelBuilder.Entity<SettingsFontSize>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.FontSize).IsUnicode(false);

                entity.Property(e => e.FontSizeData).IsUnicode(false);
            });

            modelBuilder.Entity<SettingsFontTexttransform>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.FontTexttransform).IsUnicode(false);

                entity.Property(e => e.FontTexttransformData).IsUnicode(false);
            });

            modelBuilder.Entity<SettingsFontWeight>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.FontWeight).IsUnicode(false);

                entity.Property(e => e.FontWeightData).IsUnicode(false);
            });

            modelBuilder.Entity<SettingsFontWordwrap>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.SettingsFontWordwrap1)
                    .HasColumnName("SettingsFontWordwrap")
                    .IsUnicode(false);

                entity.Property(e => e.SettingsFontWordwrapData).IsUnicode(false);
            });

            modelBuilder.Entity<SettingsPosition>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey)
                    .HasColumnName("pKey")
                    .ValueGeneratedNever();

                entity.Property(e => e.SettingsPosition1)
                    .HasColumnName("SettingsPosition")
                    .IsUnicode(false);

                entity.Property(e => e.SettingsPositionData).IsUnicode(false);
            });

            modelBuilder.Entity<SettingsStageTitle>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.StageTitleData).IsUnicode(false);
            });

            modelBuilder.Entity<SettingsTags>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.Tag).IsUnicode(false);

                entity.Property(e => e.TagCountry).IsUnicode(false);

                entity.Property(e => e.TagData).IsUnicode(false);
            });

            modelBuilder.Entity<SettingsTagsStore>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.Tag).IsUnicode(false);

                entity.Property(e => e.TripId).HasColumnName("TripID");
            });

            modelBuilder.Entity<SettingsTextAlign>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.TextAlign).IsUnicode(false);

                entity.Property(e => e.TextAlignData).IsUnicode(false);
            });

            modelBuilder.Entity<SettingsWebLinks>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.WebLinks).IsUnicode(false);

                entity.Property(e => e.WebLinksData).IsUnicode(false);
            });

            modelBuilder.Entity<TemplateTypes>(entity =>
            {
                entity.HasKey(e => e.TemplateTypeId);

                entity.Property(e => e.TemplateTypeId).HasColumnName("TemplateTypeID");

                entity.Property(e => e.ButtonCopy).IsUnicode(false);

                entity.Property(e => e.ButtonHeading).IsUnicode(false);

                entity.Property(e => e.ButtonName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ButtonPath).IsUnicode(false);

                entity.Property(e => e.Country).HasMaxLength(10);

                entity.Property(e => e.DefaultView).HasDefaultValueSql("((1))");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.TemplateType)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TemplateTypeMenuGroup).HasMaxLength(10);

                entity.Property(e => e.Templated).HasDefaultValueSql("((1))");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tour).HasDefaultValueSql("((0))");

                entity.Property(e => e.TripGroupDescriptionLong).IsUnicode(false);

                entity.Property(e => e.TripGroupDescriptionShort).IsUnicode(false);

                entity.Property(e => e.TripGroupImageBanner).IsUnicode(false);

                entity.Property(e => e.TripGroupTag).IsUnicode(false);
            });

            modelBuilder.Entity<TripStagePictures>(entity =>
            {
                entity.HasKey(e => e.PictureId);

                entity.Property(e => e.PictureId).HasColumnName("PictureID");

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.Format).HasMaxLength(1);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PicFilename)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StageId).HasColumnName("StageID");

                entity.Property(e => e.Web).HasMaxLength(1);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserItinerary>(entity =>
            {
                entity.HasKey(e => e.UserItinId);

                entity.Property(e => e.UserItinId).HasColumnName("UserItinID");

                entity.Property(e => e.Airline).HasMaxLength(20);

                entity.Property(e => e.AirlineId).HasColumnName("AirlineID");

                entity.Property(e => e.Airport)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Country).HasMaxLength(10);

                entity.Property(e => e.DepAirport)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DepartTime).HasColumnType("datetime");

                entity.Property(e => e.InFlightId).HasColumnName("InFlightID");

                entity.Property(e => e.ItinId).HasColumnName("ItinID");

                entity.Property(e => e.ItinName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OutFlightId).HasColumnName("OutFlightID");

                entity.Property(e => e.PriceDateStamp).HasColumnType("datetime");

                entity.Property(e => e.ReturnTime).HasColumnType("datetime");

                entity.Property(e => e.Seotext)
                    .HasColumnName("SEOText")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Seotitle)
                    .HasColumnName("SEOTitle")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TotalCost).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.TourDepartureDates).IsUnicode(false);

                entity.Property(e => e.TourFlightInfo).IsUnicode(false);

                entity.Property(e => e.TourNotes).IsUnicode(false);

                entity.Property(e => e.TourPrice).IsUnicode(false);

                entity.Property(e => e.TripTag)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasMaxLength(36)
                    .HasDefaultValueSql("('$admintemplate$')");
            });

            modelBuilder.Entity<UserTransfers>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.ItinId).HasColumnName("ItinID");

                entity.Property(e => e.Test)
                    .HasColumnName("test")
                    .HasMaxLength(10);

                entity.Property(e => e.TransferId).HasColumnName("TransferID");
            });
        }
    }
}
