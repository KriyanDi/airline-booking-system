using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAbsApi.Data
{
    public class Ticket
    {
        public int Id { get; set; }

        [ForeignKey(nameof(ApiUser))]
        public string UserId { get; set; }
        public ApiUser ApiUser { get; set; }

        [ForeignKey(nameof(Flight))]
        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        [ForeignKey(nameof(FlightSection))]
        public int FlightSectionId { get; set; }
        public FlightSection FlightSection { get; set; }

        [ForeignKey(nameof(Seat))]
        public int SeatId { get; set; }
        public Seat Seat { get; set; }
    }
}
