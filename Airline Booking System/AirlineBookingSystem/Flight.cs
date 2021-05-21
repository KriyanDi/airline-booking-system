using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirlineBookingSystem
{
    public class Flight
    {
        private static int _counter = 0;

        public Flight(string airlineName, string originatingAirport, string destinationAirport, string flightNumber, DateTime departureDate)
        {
            Id = _counter++;
            AirlineName = airlineName;
            OriginatingAirport = originatingAirport;
            DestinationAirport = destinationAirport;
            FlightNumber = flightNumber;
            FlightSections = new Dictionary<SeatClass, FlightSection>();
            DepartureDate = departureDate;
        }

        public int Id { get; set; }
        [RegularExpression(@"^[A-Z0-9]{1,5}$", ErrorMessage = "Error: Airline name should be with more than zero and less than six alphanumeric capital symbols long.")]
        public string AirlineName { get; set; }
        [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "Error: Airport name should be exact three capital letters long.")]
        public string OriginatingAirport { get; set; }
        [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "Error: Airport name should be exact three capital letters long.")]
        public string DestinationAirport { get; set; }
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Error: Flight number should contain only numerics.")]
        public string FlightNumber { get; set; }
        public Dictionary<SeatClass, FlightSection> FlightSections { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}