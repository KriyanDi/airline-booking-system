using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAbsApi.Data;

namespace WebAbsApi.Configurations.Entities
{
    public class FlightSectionConfiguration : IEntityTypeConfiguration<FlightSection>
    {
        public void Configure(EntityTypeBuilder<FlightSection> builder)
        {
            // Flight can contain only one section of certain type
            builder.HasIndex(e => new { e.FlightId, e.SeatClass }).IsUnique(true);

            // FlightSection <-o Seat
            builder
                .HasMany(e => e.Seats)
                .WithOne(e => e.FlightSection)
                .OnDelete(DeleteBehavior.Cascade);

            // FlightSection <-o Ticket
            builder
                .HasMany(e => e.Tickets)
                .WithOne(e => e.FlightSection)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasData(
                new FlightSection
                {
                    Id = 1,
                    SeatClass = "FIRST",
                    FlightId = 1
                },
                new FlightSection
                {
                    Id = 2,
                    SeatClass = "ECONOMY",
                    FlightId = 1
                },
                new FlightSection
                {
                    Id = 3,
                    SeatClass = "BUSINESS",
                    FlightId = 2
                }
                );
        }
    }
}
