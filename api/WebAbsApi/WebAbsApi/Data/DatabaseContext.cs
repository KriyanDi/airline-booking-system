using Microsoft.EntityFrameworkCore;

namespace WebAbsApi.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Airports
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

            // Airlines
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
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Airline> Airlines { get; set; }
    }
}
