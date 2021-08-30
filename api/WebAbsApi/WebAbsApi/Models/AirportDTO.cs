using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAbsApi.Models.ValidationAttributes;

namespace WebAbsApi.Models
{
    public class CreateAirportDTO
    {
        [Required]
        [AirportName(ErrorMessage = "Name should contains exact 3 capital letters")]
        public string Name { get; set; }
    }

    public class UpdateAirportDTO : CreateAirportDTO
    {
    }

    public class AirportDTO : CreateAirportDTO
    {
        public int Id { get; set; }

        public ICollection<FlightDTO> OriginToFlights { get; set; }
        public ICollection<FlightDTO> DestinationToFlights { get; set; }
    }
}
