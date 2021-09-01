using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

    public class FlightShortDTO : CreateFlightDTO
    {
        public int Id { get; set; }
    }

    public class FlightDTO : FlightShortDTO
    {
        public AirlineShortDTO Airline { get; set; }
        public AirportShortDTO OriginAirport { get; set; }
        public AirportShortDTO DestinationAirport { get; set; }

        public ICollection<FlightSectionShortDTO> FlightSections { get; set; }
        public ICollection<TicketDTO> Tickets { get; set; }
    }
}
