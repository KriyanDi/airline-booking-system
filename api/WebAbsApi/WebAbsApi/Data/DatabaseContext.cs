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
        }

        public DbSet<Airport> Airports { get; set; }
    }
}
