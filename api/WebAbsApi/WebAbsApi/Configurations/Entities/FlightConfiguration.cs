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

            builder
                .HasOne(e => e.OriginAirport)
                .WithMany(e => e.OriginToFlights)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder
                .HasOne(e => e.DestinationAirport)
                .WithMany(e => e.DestinationToFlights)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
