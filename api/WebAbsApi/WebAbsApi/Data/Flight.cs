using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAbsApi.Data
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(nameof(Airline))]
        public int AirlineId { get; set; }
        public Airline Airline { get; set; }

        [ForeignKey(nameof(OriginAirport))]
        public int OriginId { get; set; }
        public Airport OriginAirport { get; set; }

        [ForeignKey(nameof(DestinationAirport))]
        public int DestinationId { get; set; }
        public Airport DestinationAirport { get; set; }

        public ICollection<FlightSection> FlightSections { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
