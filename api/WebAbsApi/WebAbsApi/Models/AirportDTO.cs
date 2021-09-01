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

    public class AirportShortDTO : CreateAirportDTO
    {
        public int Id { get; set; }
    }

    public class AirportDTO : AirportShortDTO
    { 
        public ICollection<FlightShortDTO> OriginToFlights { get; set; }
        public ICollection<FlightShortDTO> DestinationToFlights { get; set; }
    }
}
