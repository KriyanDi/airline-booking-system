using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAbsApi.Models.ValidationAttributes;

namespace WebAbsApi.Models
{
    public class CreateAirlineDTO
    {
        [AirlineName]
        public string Name { get; set; }
    }

    public class UpdateAIrlineDTO : CreateAirlineDTO
    {
    }

    public class AirlineDTO : CreateAirlineDTO
    {
        public int Id { get; set; }
        public ICollection<FlightDTO> Flights { get; set; }
    }
}
