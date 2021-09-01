using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
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

            int counter = 1;
            for (int i = 1; i <= 5; i++)
            {
                foreach (var letter in new List<char> { 'A', 'B', 'C', 'D' })
                {
                    builder.HasData(
                   new Seat
                   {
                       Id = counter++,
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
