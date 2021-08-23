using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAbsApi.Data;

namespace WebAbsApi.Configurations.Entities
{
    public class FlightSectionConfiguration : IEntityTypeConfiguration<FlightSection>
    {
        public void Configure(EntityTypeBuilder<FlightSection> builder)
        {
            builder
                .HasIndex(e => e.SeatClass)
                .IsUnique(true);

            // Flight can contain only one section of certain type
            builder.HasIndex(e => new { e.FlightId, e.SeatClass }).IsUnique(true);

            builder
                .HasData(
                new FlightSection
                {
                    Id = 1,
                    SeatClass = "ECONOMY",
                    FlightId = 1
                },
                new FlightSection
                {
                    Id = 2,
                    SeatClass = "FIRST",
                    FlightId = 1
                },
                new FlightSection
                {
                    Id = 3,
                    SeatClass = "ECONOMY",
                    FlightId = 2
                }
                );
        }
    }
}
