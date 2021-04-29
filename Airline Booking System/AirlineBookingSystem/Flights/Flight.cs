using System;

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
            DepartureDate = departureDate;
            Id = "";
        }
        public Flight(Flight other) : this(other.AirlineName, other.OriginatingAirport, other.DestinationAirport, other.FlightNumber, other.DepartureDate)
        {

        }

        public string AirlineName { get; set; }
        public string OriginatingAirport { get; set; }
        public string DestinationAirport { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Id { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Flight flight &&
                AirlineName == flight.AirlineName &&
                OriginatingAirport == flight.OriginatingAirport &&
                DestinationAirport == flight.DestinationAirport &&
                FlightNumber == flight.FlightNumber &&
                DepartureDate == flight.DepartureDate &&
                Id == flight.Id;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Flight lhs, Flight rhs) => lhs.Equals(rhs);
        public static bool operator !=(Flight lhs, Flight rhs) => !(lhs == rhs);

        public override string ToString() => $"{AirlineName} {OriginatingAirport} {DestinationAirport} {FlightNumber} {DepartureDate} {Id}";
    }
}
