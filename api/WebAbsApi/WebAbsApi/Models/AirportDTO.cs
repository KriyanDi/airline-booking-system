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

    public class AirportDTO : CreateAirportDTO
    {
        public int AirportId { get; set; }
    }
}
