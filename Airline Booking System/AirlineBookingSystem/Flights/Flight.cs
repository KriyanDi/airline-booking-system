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
        #region Constructors
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
        #endregion

        #region Properties
        public string AirlineName { get; set; }
        public string OriginatingAirport { get; set; }
        public string DestinationAirport { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Id { get; set; }
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
        public override string ToString() => $"{AirlineName} {OriginatingAirport} {DestinationAirport} {FlightNumber} {DepartureDate} {Id}";
        #endregion
    }
}
