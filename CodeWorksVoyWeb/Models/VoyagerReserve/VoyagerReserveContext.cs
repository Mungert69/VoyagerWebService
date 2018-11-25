using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CodeWorksVoyWebService.Models.VoyagerReserve
{
    public partial class VoyagerReserveContext : DbContext
    {
        public VoyagerReserveContext()
        {
        }

        public VoyagerReserveContext(DbContextOptions<VoyagerReserveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AirlineNotes> AirlineNotes { get; set; }
        public virtual DbSet<BookValueInfo> BookValueInfo { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<CustomersEmail> CustomersEmail { get; set; }
        public virtual DbSet<EnqSource> EnqSource { get; set; }
        public virtual DbSet<SpecialInterests> SpecialInterests { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<System> System { get; set; }

        // Unable to generate entity type for table 'dbo.Destinations'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.EnquiryAdditionalItems'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.EnquiryHotelNights'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.EnquiryPassengerFlights'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.EnquiryPassengers'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.EnquiryTransfers'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.HolType'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Providers'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ProviderTypes'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SupplierTypes'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Users'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DefaultConfNotes'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.EmailTypes'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.BookingCompany'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.LocalAgent'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DefaultTransferNotes'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.AirlineConnectorNeeded'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DEVELOP\\CODEWORKS;Database=VoyagerReserve;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirlineNotes>(entity =>
            {
                entity.HasKey(e => e.AirlineId);

                entity.Property(e => e.AirlineId)
                    .HasColumnName("AirlineID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AirlineName).HasMaxLength(50);

                entity.Property(e => e.NoteText).HasColumnType("ntext");
            });

            modelBuilder.Entity<BookValueInfo>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.Property(e => e.BookingId)
                    .HasColumnName("BookingID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AptcostTotal).HasColumnName("APTCostTotal");

                entity.Property(e => e.AptpriceTotal).HasColumnName("APTPriceTotal");

                entity.Property(e => e.BalanceDueDate).HasColumnType("datetime");

                entity.Property(e => e.BookDate).HasColumnType("datetime");

                entity.Property(e => e.BookStatus).HasMaxLength(1);

                entity.Property(e => e.ConfirmClient).HasMaxLength(15);

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasMaxLength(10);

                entity.Property(e => e.DueToTcoast).HasColumnName("DueToTCoast");

                entity.Property(e => e.EnquiryId).HasColumnName("EnquiryID");

                entity.Property(e => e.Product).HasMaxLength(15);

                entity.Property(e => e.PsccostTotal).HasColumnName("PSCCostTotal");

                entity.Property(e => e.PscpriceTotal).HasColumnName("PSCPriceTotal");

                entity.Property(e => e.TcoastInvoice)
                    .HasColumnName("TCoastInvoice")
                    .HasMaxLength(10);

                entity.Property(e => e.TicketsReceived).HasMaxLength(15);

                entity.Property(e => e.TicketsSent).HasMaxLength(15);

                entity.Property(e => e.TotalCccharges).HasColumnName("TotalCCCharges");

                entity.Property(e => e.TravelDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.Property(e => e.CountryId)
                    .HasColumnName("CountryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryName).HasMaxLength(100);
            });

            modelBuilder.Entity<CustomersEmail>(entity =>
            {
                entity.HasKey(e => e.Cid);

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.ClientNotes).HasColumnType("ntext");

                entity.Property(e => e.Country).HasMaxLength(30);

                entity.Property(e => e.County).HasMaxLength(30);

                entity.Property(e => e.CustomerAddress).HasMaxLength(50);

                entity.Property(e => e.CustomerAddress2).HasMaxLength(50);

                entity.Property(e => e.CustomerFirstName).HasMaxLength(20);

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasMaxLength(10);

                entity.Property(e => e.CustomerLastName).HasMaxLength(30);

                entity.Property(e => e.CustomerTitle).HasMaxLength(6);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.EnqNotes).HasColumnType("ntext");

                entity.Property(e => e.FamiliarName).HasMaxLength(50);

                entity.Property(e => e.FamilyName).HasMaxLength(30);

                entity.Property(e => e.Fax).HasMaxLength(20);

                entity.Property(e => e.FirstEnquiry).HasColumnType("datetime");

                entity.Property(e => e.LastBusiness).HasColumnType("datetime");

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.Property(e => e.MailStatus).HasMaxLength(10);

                entity.Property(e => e.MaritalStatus).HasMaxLength(10);

                entity.Property(e => e.MobileTelephone).HasMaxLength(20);

                entity.Property(e => e.Notes)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationName).HasMaxLength(30);

                entity.Property(e => e.PartnersName).HasMaxLength(30);

                entity.Property(e => e.Postcode).HasMaxLength(20);

                entity.Property(e => e.PreferredPhone).HasColumnName("preferredPhone");

                entity.Property(e => e.Telephonenumberhome).HasMaxLength(20);

                entity.Property(e => e.Telephonenumberwork).HasMaxLength(20);

                entity.Property(e => e.Town).HasMaxLength(30);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WeekNo).HasMaxLength(5);
            });

            modelBuilder.Entity<EnqSource>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Source).HasMaxLength(30);
            });

            modelBuilder.Entity<SpecialInterests>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Interest).HasMaxLength(30);
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.Property(e => e.SupplierId)
                    .HasColumnName("SupplierID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.Address3).HasMaxLength(50);

                entity.Property(e => e.ContactName).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(20);

                entity.Property(e => e.Currency).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.Locate).HasMaxLength(20);

                entity.Property(e => e.PaymentArrangements).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.PostCode).HasMaxLength(10);

                entity.Property(e => e.SupplierName).HasMaxLength(50);

                entity.Property(e => e.SupplierType).HasMaxLength(50);

                entity.Property(e => e.Town).HasMaxLength(20);
            });

            modelBuilder.Entity<System>(entity =>
            {
                entity.HasKey(e => e.EnquiryId);

                entity.Property(e => e.EnquiryId)
                    .HasColumnName("EnquiryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdultId).HasColumnName("AdultID");

                entity.Property(e => e.AgentId).HasColumnName("AgentID");

                entity.Property(e => e.Aptrate).HasColumnName("APTrate");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.BrochureId).HasColumnName("BrochureID");

                entity.Property(e => e.ChildId).HasColumnName("ChildID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DoAptsellfromId).HasColumnName("DoAPTSELLFromID");

                entity.Property(e => e.DoNewXferFromId).HasColumnName("DoNewXferFromID");

                entity.Property(e => e.DoPscfromId).HasColumnName("DoPSCFromID");

                entity.Property(e => e.InfantPrice).HasColumnType("money");

                entity.Property(e => e.NewAddId).HasColumnName("NewAddID");

                entity.Property(e => e.NewNoteId).HasColumnName("NewNoteID");

                entity.Property(e => e.Tccadd).HasColumnName("TCCAdd");

                entity.Property(e => e.TccaddZero).HasColumnName("TCCAddZero");

                entity.Property(e => e.Two2Room).HasMaxLength(1);

                entity.Property(e => e.Vatrate).HasColumnName("VATRate");

                entity.Property(e => e.VoyPc).HasColumnName("VoyPC");

                entity.Property(e => e.Xact).HasColumnName("XAct");
            });
        }
    }
}
