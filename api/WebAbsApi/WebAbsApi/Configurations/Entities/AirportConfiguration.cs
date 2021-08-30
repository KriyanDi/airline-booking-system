using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAbsApi.Data;

namespace WebAbsApi.Configurations.Entities
{
    public class AirportConfiguration : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder
                .HasIndex(e => e.Name)
                .IsUnique(true);

            // Airport <-o Flight
            builder
               .HasMany(e => e.OriginToFlights)
               .WithOne(e => e.OriginAirport)
               .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(e => e.DestinationToFlights)
                .WithOne(e => e.DestinationAirport)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
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
    }
}
