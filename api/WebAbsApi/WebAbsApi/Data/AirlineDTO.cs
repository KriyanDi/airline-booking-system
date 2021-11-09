using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAbsApi.Data
{
    public class CreateAirlineDTO
    {
        public string Name { get; set; }
    }

    public class AirlineDTO : CreateAirlineDTO
    {
        public Guid Airline_Id { get; set; }
    }
}
