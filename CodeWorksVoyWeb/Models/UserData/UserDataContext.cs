using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CodeWorkVoyWebService.Models.UserData
{
    public partial class UserDataContext : DbContext
    {
        public UserDataContext()
        {
        }

        public UserDataContext(DbContextOptions<UserDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ItinPlaces> ItinPlaces { get; set; }
        public virtual DbSet<UserItinerary> UserItinerary { get; set; }
        public virtual DbSet<UserTransfers> UserTransfers { get; set; }

        // Unable to generate entity type for table 'dbo.UserInfo'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=Develop\\Codeworks;Database=UserData;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItinPlaces>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.Hotel)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.ItinId).HasColumnName("ItinID");

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PlaceId).HasColumnName("PlaceID");
            });

            modelBuilder.Entity<UserItinerary>(entity =>
            {
                entity.HasKey(e => e.UserItinId);

                entity.Property(e => e.UserItinId).HasColumnName("UserItinID");

                entity.Property(e => e.Airline)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.AirlineId).HasColumnName("AirlineID");

                entity.Property(e => e.Airport)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

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

                entity.Property(e => e.TotalCost).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<UserTransfers>(entity =>
            {
                entity.HasKey(e => e.PKey);

                entity.Property(e => e.PKey).HasColumnName("pKey");

                entity.Property(e => e.ItinId).HasColumnName("ItinID");

                entity.Property(e => e.TransferId).HasColumnName("TransferID");
            });
        }
    }
}
