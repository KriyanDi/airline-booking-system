using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAbsApi.Models.ValidationAttributes;

namespace WebAbsApi.Models
{
    public class CreateFlightSectionDTO
    {
        [Required]
        public int FlightId { get; set; }

        [Required]
        [SeatClass(ErrorMessage = "Invalid seatclass!")]
        public string SeatClass { get; set; }
    }

    public class UpdateFlightSectionDTO : CreateFlightSectionDTO
    {

    }

    public class FlightSectionShortDTO : CreateFlightSectionDTO
    {
        public int Id { get; set; }
        public ICollection<SeatShortDTO> Seats { get; set; }
    }

    public class FlightSectionDTO : FlightSectionShortDTO
    {
        public FlightShortDTO Flight { get; set; }
        
        public ICollection<TicketDTO> Tickets { get; set; }
    }
}
