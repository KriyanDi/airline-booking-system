using AirlineBookingSystem.Airlines;
using AirlineBookingSystem.Airports;
using AirlineBookingSystem.Flights;
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
        public string AirlineName => _airlineName;
        public string OriginatingAirport => _originatingAirport;
        public string DestinationAirport => _destinationAirport;
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

        #region Methods
        public AirlineOperation ChangeAirline(string airlineName)
        {
            AirlineOperation result = ValidationRules.AirlineName(airlineName);

            switch (result)
            {
                case AirlineOperation.Succeded:
                    _airlineName = airlineName;
                    break;
                case AirlineOperation.InvalidNameFormatFailure:
                    Console.WriteLine("Error: Airline name should contain only capital letters and numbers.");
                    break;
                case AirlineOperation.InvalidNameLenghtFailure:
                    Console.WriteLine("Error: Airline name should be between 1 and 5 symbols long.");
                    break;
                case AirlineOperation.InvalidNameNullFailure:
                    Console.WriteLine("Error: Airline name can not be null.");
                    break;
                default:
                    break;
            }

            return result;
        }
        public AirportOperation ChangeOriginatingAirport(string airportName)
        {
            AirportOperation result = ValidationRules.AirportName(airportName);

            switch (result)
            {
                case AirportOperation.Succeded:
                    _originatingAirport = airportName;
                    break;
                case AirportOperation.InvalidNameLenghtFailure:
                    Console.WriteLine("Error: Airport name should be exact 3 letters long.");
                    break;
                case AirportOperation.InvalidNameNullFailure:
                    Console.WriteLine("Error: Airport name can not be null.");
                    break;
                case AirportOperation.InvalidNameFormatFailure:
                    Console.WriteLine("Error: Airport name should contain only capital letters.");
                    break;
            }

            return result;
        }
        public AirportOperation ChangeDestinationAirport(string airportName)
        {
            AirportOperation result = ValidationRules.AirportName(airportName);

            switch (result)
            {
                case AirportOperation.Succeded:
                    _destinationAirport = airportName;
                    break;
                case AirportOperation.InvalidNameLenghtFailure:
                    Console.WriteLine("Error: Airport name should be exact 3 letters long.");
                    break;
                case AirportOperation.InvalidNameNullFailure:
                    Console.WriteLine("Error: Airport name can not be null.");
                    break;
                case AirportOperation.InvalidNameFormatFailure:
                    Console.WriteLine("Error: Airport name should contain only capital letters.");
                    break;
            }

            return result;
        }

        public FlightInformationOperation ChangeFlighNumber(string flightNumber)
        {
            FlightInformationOperation result = ValidationRules.FlightNumber(flightNumber);

            switch (result)
            {
                case FlightInformationOperation.Succeded:
                    _flightNumber = flightNumber;
                    break;
                case FlightInformationOperation.InvalidFlightNumberContainsNotOnlyNumbersFailure:
                    Console.WriteLine("Error: Flight number should contain only numbers");
                    break;
            }

            return result;
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
            InitializeAirlineName(airlineName);
            InitializeOriginatingAirport(originatingAirport);
            InitializeDestinationAirport(destinationAirport);
            InitializeFlightNumber(flightNumber);
            DepartureDate = departureDate;
            Id = id;
        }

        private void InitializeFlightNumber(string flightNumber)
        {
            if (ChangeFlighNumber(flightNumber) != FlightInformationOperation.Succeded)
            {
                Console.WriteLine("Flight Information was not created!");

                throw new ArgumentException(FlightInformationExceptionMessages.invalidFlightNumber);
            }
        }

        private void InitializeOriginatingAirport(string originatingAirport)
        {
            if (ChangeOriginatingAirport(originatingAirport) != AirportOperation.Succeded)
            {
                Console.WriteLine("Flight Information was not created!");

                throw new ArgumentException(AirportExceptionMessages.invalidName);
            }
        }
        private void InitializeDestinationAirport(string destinationAirport)
        {
            if (ChangeDestinationAirport(destinationAirport) != AirportOperation.Succeded)
            {
                Console.WriteLine("Flight information was not created!");

                throw new ArgumentException(AirportExceptionMessages.invalidName);
            }
        }
        private void InitializeAirlineName(string airlineName)
        {
            if (ChangeAirline(airlineName) != AirlineOperation.Succeded)
            {
                Console.WriteLine("Flight Information was not created!");

                throw new ArgumentException(AirlineExceptionMessages.invalidName);
            }
        }
        #endregion

        #region Other Overridden Methods
        public override string ToString() => $"{_airlineName} {_originatingAirport} {_destinationAirport} {_flightNumber} {_departureDate.Date} {_id}";
        #endregion
    }
}