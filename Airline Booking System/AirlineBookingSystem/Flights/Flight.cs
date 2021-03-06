using AirlineBookingSystem.Airlines;
using AirlineBookingSystem.Airports;
using AirlineBookingSystem.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem
{
    public class Flight
    {
        #region Fields
        private FlightInformation _information;
        private List<FlightSection> _flightSections;
        #endregion

        #region Constructors
        public Flight(string airlineName, string originatingAirport, string destinationAirport, string flightNumber, DateTime departureDate)
        {
            InitializeDataMembers(airlineName, originatingAirport, destinationAirport, flightNumber, departureDate);
        }
        public Flight(Flight other)
        {
            InitializeDataMembersFrom(other);
        }
        #endregion

        #region Properties
        public FlightInformation Information
        {
            get => new FlightInformation(_information);
            private set => _information = value;
        }
        public List<FlightSection> FlightSections
        {
            get
            {
                List<FlightSection> flightSectionsCopy = null;

                if (_flightSections != null)
                {
                    flightSectionsCopy = new List<FlightSection>();
                    for (int i = 0; i < _flightSections.Count; i++)
                    {
                        flightSectionsCopy.Add(new FlightSection(_flightSections[i]));
                    }
                }

                return flightSectionsCopy;
            }
            set
            {
                if (value != null)
                {
                    List<FlightSection> flightSectionsCopy = new List<FlightSection>();
                    for (int i = 0; i < value.Count; i++)
                    {
                        flightSectionsCopy.Add(new FlightSection(value[i]));
                    }

                    _flightSections = flightSectionsCopy;
                }
            }
        }
        public FlightInformation InformationReference => _information;
        public List<FlightSection> FlightSectionsReference => _flightSections;
        #endregion

        #region Methods
        public FlightOperation AddFlightSection(FlightSection section)
        {
            if (!DoFlightSectionsContain(section))
            {
                _flightSections.Add(new FlightSection(section));

                return FlightOperation.Succeded;
            }
            else
            {
                Console.WriteLine("Error: Such section already exists.");

                return FlightOperation.InvalidSectionAlreadyExistsFailure;
            }
        }
        public void ChangeFlightInformationId(string uniqueId)
        {
            _information.Id = uniqueId;
        }
        #endregion

        #region Help Methods
        private void InitializeDataMembers(string airlineName, string originatingAirport, string destinationAirport, string flightNumber, DateTime departureDate)
        {
            InitializeInformation(airlineName, originatingAirport, destinationAirport, flightNumber, departureDate, string.Empty);
            InitializeFlightSections();
        }
        private void InitializeInformation(string airlineName, string originatingAirport, string destinationAirport, string flightNumber, DateTime departureDate, string id)
        {
            ValidateAirlineAndAirports(airlineName, originatingAirport, destinationAirport);

            Information = new FlightInformation(airlineName, originatingAirport, destinationAirport, flightNumber, departureDate, id);
        }
        private static void ValidateAirlineAndAirports(string airlineName, string originatingAirport, string destinationAirport)
        {
            if (ValidationRules.AirlineName(airlineName) != AirlineOperation.Succeded)
            {
                Console.WriteLine("Flight was not created!");

                throw new ArgumentException(AirlineExceptionMessages.invalidName);
            }
            else if (ValidationRules.AirportName(originatingAirport) != AirportOperation.Succeded)
            {
                Console.WriteLine("Flight was not created!");

                throw new ArgumentException(AirportExceptionMessages.invalidName);
            }
            else if (ValidationRules.AirportName(destinationAirport) != AirportOperation.Succeded)
            {
                Console.WriteLine("Flight was not created!");

                throw new ArgumentException(AirportExceptionMessages.invalidName);
            }
            else if (originatingAirport == destinationAirport)
            {
                throw new ArgumentException(FlightExceptionMessages.invalidMatchingOriginatingDestinationAirports);
            }
        }

        private void InitializeFlightSections()
        {
            FlightSections = new List<FlightSection>();
        }
        private void InitializeDataMembersFrom(Flight other)
        {
            Information = new FlightInformation(other.Information);
            FlightSections = other.FlightSections;
        }

        private bool DoFlightSectionsContain(FlightSection section)
        {
            bool result = false;

            if (_flightSections != null)
            {
                for (int i = 0; i < _flightSections.Count; i++)
                {
                    if (_flightSections[i].SeatClass == section.SeatClass)
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }
        #endregion

        #region Equation Methods
        public override bool Equals(object obj)
        {
            if (obj is Flight flight)
            {
                bool areFlightSectionsExact = true;
                for (int i = 0; i < _flightSections.Count; i++)
                {
                    if (!_flightSections[i].Equals(flight.FlightSections[i]))
                    {
                        areFlightSectionsExact = false;
                        break;
                    }
                }

                return _information.Equals(flight.Information) &&
                       areFlightSectionsExact;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            int hashCode = -479622268;
            hashCode = hashCode * -1521134295 + EqualityComparer<FlightInformation>.Default.GetHashCode(_information);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<FlightSection>>.Default.GetHashCode(_flightSections);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<FlightSection>>.Default.GetHashCode(FlightSections);
            hashCode = hashCode * -1521134295 + EqualityComparer<FlightInformation>.Default.GetHashCode(Information);
            return hashCode;
        }
        public static bool operator ==(Flight lhs, Flight rhs) => lhs.Equals(rhs);
        public static bool operator !=(Flight lhs, Flight rhs) => !(lhs == rhs);
        #endregion

        #region Other Overridden Methods
        public override string ToString()
        {
            string information = $"{_information}";

            string flightSections = "";
            foreach (FlightSection section in _flightSections)
            {
                flightSections = flightSections + section.ToString() + "\n";
            }

            return information + "\n" + flightSections;
        }
        #endregion
    }
}
