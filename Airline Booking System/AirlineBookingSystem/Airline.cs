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
            Name = name;
            _flights = new List<Flight>();
        }
        public Airline(Airline other) : this(other.Name)
        {
            Flights = other.Flights;
        }
        #endregion

        #region Properties
        public string Name
        {
            get => _name;
            set
            {
                if(ValidationRules.AirlineName(value))
                {
                    _name = value;
                }
            }
        }
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
        public bool AddFlight(Flight flight)
        {
            Flight flightCopy = new Flight(flight);

            flightCopy.InformationReference.Id = $"{Name}{(_flights.Count + 1):D5}";

            if (_flights == null)
            {
                _flights = new List<Flight>();
            }

            if (!DoesFlightMatchWithOtherFlightByFlightNumber(flight))
            {
                _flights.Add(new Flight(flightCopy));
            }
            else
            {
                throw new ArgumentException("This Flight matches by flight number with other flight!");
            }

            return true;
        }
        public bool AddFlightSectionToFlight(FlightSection section, string flightId)
        {
            bool successfullyAdded = false;

            for (int i = 0; i < _flights.Count; i++)
            {
                if (_flights[i].InformationReference.FlightNumber == flightId)
                {
                    _flights[i].AddFlightSection(section);
                    successfullyAdded = true;
                    break;
                }
            }

            return successfullyAdded;
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
        private bool DoesFlightMatchWithOtherFlightByFlightNumber(Flight flight)
        {
            bool match = false;

            foreach (Flight currentFlight in Flights)
            {
                if (flight.Information.FlightNumber == currentFlight.Information.FlightNumber)
                {
                    match = true;
                    break;
                }
            }

            return match;
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
