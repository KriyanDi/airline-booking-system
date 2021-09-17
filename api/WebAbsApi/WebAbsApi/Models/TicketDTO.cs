using System.ComponentModel.DataAnnotations;
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

    public class TicketDTO: CreateTicketDTO
    {
        public int Id { get; set; }
        public UserDTO ApiUser { get; set; }
        public FlightShortDTO Flight { get; set; }
        public FlightSectionShortDTO FlightSection { get; set; }
        public SeatShortDTO Seat { get; set; }
    }
}
