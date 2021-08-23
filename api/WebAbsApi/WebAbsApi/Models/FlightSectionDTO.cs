using System.ComponentModel.DataAnnotations;
using WebAbsApi.Data;
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

    public class FlightSectionDTO : CreateFlightSectionDTO
    {
        public int Id { get; set; }
        public FlightDTO Flight { get; set; }
        
        //public ICollection<Seat> Seats { get; set; }
    }
}
