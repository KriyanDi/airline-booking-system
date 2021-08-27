using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAbsApi.Data
{
    public class FlightSection
    {
        public int Id { get; set; }

        public string SeatClass { get; set; }

        [ForeignKey(nameof(Flight))]
        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        public ICollection<Seat> Seats { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
