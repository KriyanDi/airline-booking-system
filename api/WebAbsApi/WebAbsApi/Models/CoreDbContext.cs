using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAbsApi.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Airline> Airlines { get; set; }
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<AvailFlight> AvailFlights { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<FlightSection> FlightSections { get; set; }
        public virtual DbSet<FlightsInformation> FlightsInformations { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Seatclass> Seatclasses { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ABSDB;Data Source=KDIMITROVET\\SQLEXPRESS");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROLE_ACCOUNT");
            });

            modelBuilder.Entity<Airline>(entity =>
            {
                entity.Property(e => e.Airline_Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.Property(e => e.Airport_Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsFixedLength(true);
            });

            modelBuilder.Entity<AvailFlight>(entity =>
            {
                entity.ToView("AVAIL_FLIGHTS");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.Property(e => e.FlightId).ValueGeneratedNever();

                entity.Property(e => e.FlightNumber).IsFixedLength(true);

                entity.HasOne(d => d.Airline)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.AirlineId)
                    .HasConstraintName("FK_AIRLINE_FLIGHT");

                entity.HasOne(d => d.DestAirport)
                    .WithMany(p => p.FlightDestAirports)
                    .HasForeignKey(d => d.DestAirportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DESTINATION_AIRPORT_FLIGHT");

                entity.HasOne(d => d.OrigAirport)
                    .WithMany(p => p.FlightOrigAirports)
                    .HasForeignKey(d => d.OrigAirportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORIGIN_AIRPORT_FLIGHT");
            });

            modelBuilder.Entity<FlightSection>(entity =>
            {
                entity.Property(e => e.FlightSectionId).ValueGeneratedNever();

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.FlightSections)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK_FLIGHT_FLIGHT_SECTION");

                entity.HasOne(d => d.Seatclass)
                    .WithMany(p => p.FlightSections)
                    .HasForeignKey(d => d.SeatclassId)
                    .HasConstraintName("FK_SEATCLASS_FLIGHT_SECTION");
            });

            modelBuilder.Entity<FlightsInformation>(entity =>
            {
                entity.ToView("FLIGHTS_INFORMATION");

                entity.Property(e => e.Dest).IsFixedLength(true);

                entity.Property(e => e.FlightNumber).IsFixedLength(true);

                entity.Property(e => e.Orig).IsFixedLength(true);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.Property(e => e.SeatId).ValueGeneratedNever();

                entity.Property(e => e.Col).IsFixedLength(true);

                entity.HasOne(d => d.FlightSection)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => d.FlightSectionId)
                    .HasConstraintName("FK_FLIGHT_SECTION_SEAT");
            });

            modelBuilder.Entity<Seatclass>(entity =>
            {
                entity.Property(e => e.SeatclassId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.TicketId).ValueGeneratedNever();

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_ACCOUNT_TICKET");

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.SeatId)
                    .HasConstraintName("FK_SEAT_TICKET");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
