using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAbsApi.Data;

namespace WebAbsApi.Configurations.Entities
{
    public class AirlineConfiguration : IEntityTypeConfiguration<Airline>
    {
        public void Configure(EntityTypeBuilder<Airline> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Name).IsUnique(true);

            // Airline <-o Flight
            builder
                .HasMany(e => e.Flights)
                .WithOne(e => e.Airline)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
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
    }
}
