using AirlineBookingSystem.Additional;
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
        
        [AirlineName]
        public string AirlineName { get; set; }
        [AirportName]
        public string OriginatingAirport { get; set; }
        [AirportName]
        public string DestinationAirport { get; set; }
        [FlightNumber]
        public string FlightNumber { get; set; }
        public Dictionary<SeatClass, FlightSection> FlightSections { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Id { get; set; }

        public override string ToString() => $"{AirlineName} {OriginatingAirport} {DestinationAirport} {FlightNumber} {DepartureDate} {Id}";
    }
}
