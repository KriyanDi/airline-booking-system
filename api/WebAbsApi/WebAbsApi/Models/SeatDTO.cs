using System;
using System.ComponentModel.DataAnnotations;
using WebAbsApi.Data;
using WebAbsApi.Models.ValidationAttributes;

namespace WebAbsApi.Models
{
    public class CreateSeatDTO
    {
        [Required]
        [SeatRow]
        public string Row { get; set; }

        [Required]
        [SeatColumn]
        public string Column { get; set; }

        [Required]
        public bool IsBooked { get; set; }

        [Required]
        public int FlightSectionId { get; set; }
    }

    public class UpdateSeatDTO : CreateSeatDTO
    {

    }

    public class SeatShortDTO
    {
        public int Id { get; set; }
        public string Row { get; set; }
        public string Column { get; set; }
        public bool IsBooked { get; set; }
    }

    public class SeatDTO : SeatShortDTO
    {
        public FlightSectionShortDTO FlightSection { get; set; }
        public TicketDTO Ticket { get; set; }
    }
}
