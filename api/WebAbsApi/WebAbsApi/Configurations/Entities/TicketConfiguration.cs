using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAbsApi.Data;

namespace WebAbsApi.Configurations.Entities
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasIndex(e => new { e.UserId, e.FlightId, e.FlightSectionId, e.SeatId}).IsUnique(true);
            builder.HasOne(e => e.FlightSection).WithMany(e => e.Tickets).OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(e => e.Seat).WithOne(e => e.Ticket).OnDelete(DeleteBehavior.ClientNoAction);

            //builder.HasData(
            //   new Ticket
            //   {
            //        UserId = ,
            //        FlightId = ,
            //        FlightSectionId = ,
            //        SeatId = , 
            //   });
        }
    }
}
