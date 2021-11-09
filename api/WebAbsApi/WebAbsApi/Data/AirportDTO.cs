using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAbsApi.Data
{
    public class CreateAirportDTO
    {
        public string Name { get; set; }
    }

    public class AirportDTO : CreateAirportDTO
    {
        public Guid Airport_Id { get; set; }
    }
}
