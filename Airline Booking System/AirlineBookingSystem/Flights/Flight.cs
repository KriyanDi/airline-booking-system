using System;
using System.Collections.Generic;

namespace AirlineBookingSystem
{
    public class Flight
    {
        public Flight(string airlineName, string originatingAirport, string destinationAirport, string flightNumber, DateTime departureDate)
        {
            AirlineName = airlineName;
            OriginatingAirport = originatingAirport;
            DestinationAirport = destinationAirport;
            FlightNumber = flightNumber;
            FlightSections = new Dictionary<SeatClass, FlightSection>();
            DepartureDate = departureDate;
            Id = "";
        }

        public string AirlineName { get; set; }
        public string OriginatingAirport { get; set; }
        public string DestinationAirport { get; set; }
        public string FlightNumber { get; set; }
        public Dictionary<SeatClass, FlightSection> FlightSections { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Id { get; set; }

        public override string ToString() => $"{AirlineName} {OriginatingAirport} {DestinationAirport} {FlightNumber} {DepartureDate} {Id}";
    }
}
