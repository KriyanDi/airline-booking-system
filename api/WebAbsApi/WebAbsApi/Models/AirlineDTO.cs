using System.Collections.Generic;
using WebAbsApi.Models.ValidationAttributes;

namespace WebAbsApi.Models
{
    public class CreateAirlineDTO
    {
        [AirlineName(ErrorMessage = "Name should contains between 1 and 5 capital letters or numbers.")]
        public string Name { get; set; }
    }

    public class UpdateAirlineDTO : CreateAirlineDTO
    {
    }

    public class AirlineShortDTO : CreateAirlineDTO
    {
        public int Id { get; set; }
    }

    public class AirlineDTO : AirlineShortDTO
    {
        public ICollection<FlightShortDTO> Flights { get; set; }
    }
}
