using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAbsApi.Data;

namespace WebAbsApi.Models
{
    public class CreateTicketDTO
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public int FlightId { get; set; }

        [Required]
        public int FlightSectionId { get; set; }

        [Required]
        public int SeatId { get; set; }
    }

    public class UpdateTicketDTO : CreateTicketDTO
    {

    }

    public class TicketDTO
    {
        public int Id { get; set; }
        public ApiUser ApiUser { get; set; }
        public Flight Flight { get; set; }
        public FlightSection FlightSection { get; set; }
        public Seat Seat { get; set; }
    }
}
