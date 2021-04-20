using System;

namespace AirlineBookingSystem
{
    public class FlightInformation
    {
        #region Fields
        private string _airlineName;
        private string _originatingAirport;
        private string _destinationAirport;
        private int _flightNumber;
        private DateTime _departureDate;
        private string _id;

        public FlightInformation(string airlineName, string originatingAirport, string destinationAirport, int flightNumber, DateTime departureDate, string id)
        {
            AirlineName = airlineName;
            OriginatingAirport = originatingAirport;
            DestinationAirport = destinationAirport;
            FlightNumber = flightNumber;
            DepartureDate = departureDate;
            Id = id;
        }
        public FlightInformation(FlightInformation other):this(other.AirlineName,other.OriginatingAirport, other.DestinationAirport,other.FlightNumber, other.DepartureDate, other.Id)
        {
        }
        #endregion

        #region Properties
        public string AirlineName
        {
            get => _airlineName;
            private set => _airlineName = value;
        }
        public string OriginatingAirport
        {
            get => _originatingAirport;
            private set => _originatingAirport = value;
        }
        public string DestinationAirport
        {
            get => _destinationAirport;
            private set => _destinationAirport = value;
        }
        public int FlightNumber
        {
            get => _flightNumber;
            private set => _flightNumber = value;
        }
        public DateTime DepartureDate
        {
            get => _departureDate;
            private set => _departureDate = value;
        }
        public string Id
        {
            get => _id;
            set => _id = value;
        }
        #endregion
    }
}