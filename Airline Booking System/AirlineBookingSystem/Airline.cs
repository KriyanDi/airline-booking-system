using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AirlineBookingSystem
{
    public class Airline
    {
        #region Fields
        private string _name;
        private List<Flight> _flights;
        #endregion

        #region Constructors
        public Airline(string name)
        {
            InitializeDataMembers(name);
        }
        public Airline(Airline other) : this(other.Name)
        {
            InitializeDataMembersFrom(other);
        }
        #endregion

        #region Properties
        public string Name => _name;
        public List<Flight> Flights
        {
            get
            {
                List<Flight> flightsCopy = null;

                if (_flights != null)
                {
                    flightsCopy = new List<Flight>();
                    for (int i = 0; i < _flights.Count; i++)
                    {
                        flightsCopy.Add(new Flight(_flights[i]));
                    }
                }

                return flightsCopy;
            }

            set
            {
                List<Flight> flightsCopy = null;

                if (value != null)
                {
                    flightsCopy = new List<Flight>();
                    for (int i = 0; i < value.Count; i++)
                    {
                        flightsCopy.Add(new Flight(value[i]));
                    }
                }

                _flights = flightsCopy;
            }
        }
        public List<Flight> FlightsReference => _flights;
        #endregion

        #region Methods
        public AirlineOperation ChangeName(string airlineName)
        {
            AirlineOperation result = ValidationRules.AirlineName(airlineName);

            switch (result)
            {
                case AirlineOperation.Succeded:
                    _name = airlineName;
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
        public AirlineOperation AddFlight(Flight flight)
        {
            if (ValidateNewFlight(flight) == AirlineOperation.Succeded)
            {
                ProceedAddingTheFlight(flight);

                return AirlineOperation.Succeded;
            }
            else
            {
                return AirlineOperation.AddingFlightFailure;
            }
        }
        public bool AddFlightSectionToFlight(FlightSection section, string flightId)
        {
            if (TryAddNewSectionToFlight(section, flightId) == AirlineOperation.Succeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Equation Methods
        public override bool Equals(object obj)
        {
            if (obj is Airline airline)
            {
                bool areFlightsExact = true;
                for (int i = 0; i < _flights.Count; i++)
                {
                    if (!_flights[i].Equals(airline.Flights[i]))
                    {
                        areFlightsExact = false;
                        break;
                    }
                }

                return _name == airline._name &&
                      _flights.Count == airline.Flights.Count &&
                      areFlightsExact;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            int hashCode = 1536774888;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Flight>>.Default.GetHashCode(_flights);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Flight>>.Default.GetHashCode(Flights);
            return hashCode;
        }
        public static bool operator ==(Airline lhs, Airline rhs) => lhs.Equals(rhs);
        public static bool operator !=(Airline lhs, Airline rhs) => !(lhs == rhs);
        #endregion

        #region Help Methods
        private void InitializeDataMembers(string name)
        {
            InitializeName(name);
            InitializeFlights();
        }
        private void InitializeName(string name)
        {
            if (ChangeName(name) != AirlineOperation.Succeded)
            {
                Console.WriteLine("Airline was not created!");

                throw new ArgumentException(AirlineExceptionMessages.invalidName);
            }
        }
        private void InitializeFlights()
        {
            _flights = new List<Flight>();
        }

        private void InitializeDataMembersFrom(Airline other)
        {
            Flights = other.Flights;
        }

        private AirlineOperation ValidateNewFlight(Flight flight)
        {
            if (IsFlightAirlineMatchingWithAirlineName(flight))
            {
                if (!DoesFlightMatchWithOtherFlightByFlightNumber(flight))
                {
                    return AirlineOperation.Succeded;
                }
                else
                {
                    Console.WriteLine("This Flight matches by flight number with other flight.");

                    return AirlineOperation.InvalidFlightMatchingFlighNumberFailure;
                }
            }
            else
            {
                return AirlineOperation.InvalidAirportNotMathingAirlineFailure;
            }
        }
        private bool IsFlightAirlineMatchingWithAirlineName(Flight flight)
        {
            bool areMatching = flight.InformationReference.AirlineName == _name;

            return areMatching;
        }
        private bool DoesFlightMatchWithOtherFlightByFlightNumber(Flight flight)
        {
            bool findMatch = false;

            foreach (Flight currentFlight in Flights)
            {
                if (flight.Information.FlightNumber == currentFlight.Information.FlightNumber)
                {
                    findMatch = true;
                    break;
                }
            }

            return findMatch;
        }
        private void ProceedAddingTheFlight(Flight flight)
        {
            Flight flightCopy = new Flight(flight);

            SetUniqueFlightIdForThisAirline(flightCopy);

            _flights.Add(new Flight(flightCopy));
        }
        private void SetUniqueFlightIdForThisAirline(Flight flightCopy)
        {
            flightCopy.InformationReference.Id = $"{_name}{_flights.Count + 1:D5}";
        }
        private AirlineOperation TryAddNewSectionToFlight(FlightSection section, string flightId)
        {
            if(_flights != null)
            {
                for (int i = 0; i < _flights.Count; i++)
                {
                    if (_flights[i].InformationReference.FlightNumber == flightId)
                    {
                        if (_flights[i].AddFlightSection(section) == FlightOperation.Succeded)
                        {
                            return AirlineOperation.Succeded;
                        }
                    }
                }
            }
            
            return AirlineOperation.Failed;
        }
        #endregion

        #region Other Overridden Method
        public override string ToString()
        {
            string name = $"{_name}";

            string flights = "";
            foreach (Flight flight in _flights)
            {
                flights = flights + flight.ToString() + "\n";
            }

            return name + "\n" + flights;
        }
        #endregion
    }
}
