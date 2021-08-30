using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAbsApi.Data;

namespace WebAbsApi.Configurations.Entities
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder
                .HasIndex(e => new { e.FlightSectionId, e.Row, e.Column }).IsUnique(true);

            // Seat <-o Ticket
            builder
                .HasOne(e => e.Ticket)
                .WithOne(e => e.Seat)
                .OnDelete(DeleteBehavior.Cascade);

            for (int i = 0; i < 5; i++)
            {
                foreach (var letter in new List<char> { 'A', 'B', 'C', 'D' })
                {
                    builder.HasData(
                   new Seat
                   {
                       Id = i + 1 + 65 - letter + new Random().Next(1,10000),
                       Row = i.ToString(),
                       Column = letter.ToString(),
                       IsBooked = false,
                       FlightSectionId = 1
                   });
                }
            }
        }
    }
}
