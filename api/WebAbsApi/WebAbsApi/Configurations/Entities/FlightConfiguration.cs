using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAbsApi.Data;

namespace WebAbsApi.Configurations.Entities
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder
                .HasIndex(e => e.FlightNumber)
                .IsUnique(true);

            // Flight <-o FlightSection
            builder
                .HasMany(e => e.FlightSections)
                .WithOne(e => e.Flight)
                .OnDelete(DeleteBehavior.Cascade);

            // Flight <-o Ticket
            builder
                .HasMany(e => e.Tickets)
                .WithOne(e => e.Flight)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
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

        }
    }
}
