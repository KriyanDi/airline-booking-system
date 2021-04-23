using System;
using System.Collections.Generic;

namespace AirlineBookingSystem
{
    public class FlightInformation
    {
        #region Fields
        private string _airlineName;
        private string _originatingAirport;
        private string _destinationAirport;
        private string _flightNumber;
        private DateTime _departureDate;
        private string _id;
        #endregion

        #region Constructors
        public FlightInformation(string airlineName, string originatingAirport, string destinationAirport, string flightNumber, DateTime departureDate, string id)
        {
            InitializeDataMembers(airlineName, originatingAirport, destinationAirport, flightNumber, departureDate, id);
        }
        public FlightInformation(FlightInformation other) : this(other.AirlineName, other.OriginatingAirport, other.DestinationAirport, other.FlightNumber, other.DepartureDate, other.Id)
        {
        }
        #endregion

        #region Properties
        public string AirlineName
        {
            get => _airlineName;
            private set
            {
                if (ValidationRules.AirlineName(value))
                {
                    _airlineName = value;
                }
            }
        }
        public string OriginatingAirport
        {
            get => _originatingAirport;
            private set
            {
                if (ValidationRules.AirportName(value))
                {
                    _originatingAirport = value;
                }
            }
        }
        public string DestinationAirport
        {
            get => _destinationAirport;
            private set
            {
                if (ValidationRules.AirportName(value))
                {
                    _destinationAirport = value;
                }
            }
        }
        public string FlightNumber
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

        #region Equation Methods
        public override bool Equals(object obj)
        {
            if (obj is FlightInformation information)
            {

                return _airlineName == information.AirlineName &&
                       _originatingAirport == information.OriginatingAirport &&
                       _destinationAirport == information.DestinationAirport &&
                       _flightNumber == information.FlightNumber &&
                       _departureDate == information.DepartureDate &&
                       _id == information.Id;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return 495827395 + EqualityComparer<string>.Default.GetHashCode(_airlineName);
        }
        public static bool operator ==(FlightInformation lhs, FlightInformation rhs) => lhs.Equals(rhs);
        public static bool operator !=(FlightInformation lhs, FlightInformation rhs) => !(lhs == rhs);
        #endregion

        #region Help Methods
        private void InitializeDataMembers(string airlineName, string originatingAirport, string destinationAirport, string flightNumber, DateTime departureDate, string id)
        {
            AirlineName = airlineName;
            OriginatingAirport = originatingAirport;
            DestinationAirport = destinationAirport;
            FlightNumber = flightNumber;
            DepartureDate = departureDate;
            Id = id;
        }
        #endregion

        #region Other Overridden Methods
        public override string ToString() => $"{_airlineName} {_originatingAirport} {_destinationAirport} {_flightNumber} {_departureDate.Date} {_id}";
        #endregion
    }
}