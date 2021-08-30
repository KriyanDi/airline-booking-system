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

    public class SeatDTO : CreateSeatDTO
    {
        public int Id { get; set; }
        public FlightSection FlightSection { get; set; }
        public TicketDTO Ticket { get; set; }
    }
}
