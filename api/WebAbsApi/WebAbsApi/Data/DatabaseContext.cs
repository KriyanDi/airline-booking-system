using Microsoft.EntityFrameworkCore;

namespace WebAbsApi.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Airport>()
                .HasIndex(e => e.Name)
                .IsUnique(true);

            builder.Entity<Airport>().HasData(
                new Airport
                {
                    Id = 1,
                    Name = "AAY"
                },
                new Airport
                {
                    Id = 2,
                    Name = "ABA"
                },
                new Airport
                {
                    Id = 3,
                    Name = "MAC"
                },
                new Airport
                {
                    Id = 4,
                    Name = "FSD"
                },
                new Airport
                {
                    Id = 5,
                    Name = "ZAG"
                });

            builder.Entity<Airline>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasIndex(e => e.Name).IsUnique(true);
            });

            builder.Entity<Airline>().HasData(
                new Airline
                {
                    Id = 1,
                    Name = "DELTA"
                },
                new Airline
                {
                    Id = 2,
                    Name = "SSSKY"
                },
                new Airline
                {
                    Id = 3,
                    Name = "FLYSS"
                },
                new Airline
                {
                    Id = 4,
                    Name = "ARB"
                },
                new Airline
                {
                    Id = 5,
                    Name = "WIZZ"
                });

            builder.Entity<Flight>().HasData(
                new Flight
                {
                    Id = 1,
                    FlightNumber = "111111111",
                    Date = new System.DateTime(2021, 5, 13),
                    AirlineId = 2,
                    OriginId = 1,
                    DestinationId = 5
                },
                new Flight
                {
                    Id = 2,
                    FlightNumber = "211111111",
                    Date = new System.DateTime(2021, 5, 20),
                    AirlineId = 2,
                    OriginId = 5,
                    DestinationId = 1
                }
                );

            builder.Entity<Flight>()
                .HasOne(e => e.OriginAirport)
                .WithMany(e => e.OriginToFlights)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.Entity<Flight>()
                .HasOne(e => e.DestinationAirport)
                .WithMany(e => e.DestinationToFlights)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Flight> Flights { get; set; }
    }
}
