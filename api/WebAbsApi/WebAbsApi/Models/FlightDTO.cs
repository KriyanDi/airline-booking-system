using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAbsApi.Data;

namespace WebAbsApi.Models
{
    public class CreateFlightDTO
    {
        [Required]
        public string FlightNumber { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int AirlineId { get; set; }

        [Required]
        public int OriginId { get; set; }

        [Required]
        public int DestinationId { get; set; }
    }

    public class UpdateFlightDTO : CreateFlightDTO
    {
    }

    public class FlightDTO : CreateFlightDTO
    {
        public int Id { get; set; }
        public AirlineDTO Airline { get; set; }
        public AirportDTO OriginAirport { get; set; }
        public AirportDTO DestinationAirport { get; set; }

        public ICollection<FlightSectionDTO> FlightSections { get; set; }
        public ICollection<TicketDTO> Tickets { get; set; }
    }
}
