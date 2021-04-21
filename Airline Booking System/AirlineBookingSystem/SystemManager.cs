using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem
{
    public class SystemManager
    {
        #region Fields
        private List<Airport> _airports;
        private List<Airline> _airlines;
        #endregion

        #region Constructors
        public SystemManager()
        {
            _airports = new List<Airport>();
            _airlines = new List<Airline>();
        }
        #endregion

        #region Properties
        public List<Airport> Airports
        {
            get
            {
                List<Airport> airportsCopy = null;

                if (_airports != null)
                {
                    airportsCopy = new List<Airport>();
                    for (int i = 0; i < _airports.Count; i++)
                    {
                        airportsCopy.Add(new Airport(_airports[i]));
                    }
                }

                return airportsCopy;
            }
        }
        public List<Airline> Airlines
        {
            get
            {
                List<Airline> airlinesCopy = null;

                if (_airlines != null)
                {
                    airlinesCopy = new List<Airline>();
                    for (int i = 0; i < _airlines.Count; i++)
                    {
                        airlinesCopy.Add(new Airline(_airlines[i]));
                    }
                }

                return airlinesCopy;
            }
        }
        #endregion

        #region Methods
        public void CreateAirport(string airportName)
        {
            if (!DoesAirportExist(airportName))
            {
                _airports.Add(new Airport(airportName));
            }
            else
            {
                throw new ArgumentException($"Airport {airportName} already exists!");
            }
        }
        public void CreateAirline(string airlineName)
        {
            if (!DoesAirlineExist(airlineName))
            {
                _airlines.Add(new Airline(airlineName));
            }
            else
            {
                throw new ArgumentException($"Airline {airlineName} already exists!");
            }
        }
        public void CreateFlight(string airlineName, string fromAirport, string toAirport, int year, int month, int day, string id)
        {
            if (DoesAirlineExist(airlineName))
            {
                if (DoesAirportExist(fromAirport))
                {
                    if (DoesAirportExist(toAirport))
                    {
                        Flight flight = new Flight(airlineName, fromAirport, toAirport, id, new DateTime(year, month, day));

                        for (int i = 0; i < _airlines.Count; i++)
                        {
                            if (_airlines[i].Name == airlineName)
                            {
                                _airlines[i].AddFlight(flight);
                                break;
                            }
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Destination Airport does not exist!");
                    }
                }
                else
                {
                    throw new ArgumentException("Originating Airport does not exist!");
                }
            }
            else
            {
                throw new ArgumentException("Airline does not exist!");
            }
        }
        public void CreateSection(string airlineName, string flightId, int rows, int cols, SeatClass seatClass)
        {
            if (DoesAirlineExist(airlineName))
            {
                for (int i = 0; i < _airlines.Count; i++)
                {
                    if (_airlines[i].Name == airlineName)
                    {
                        if (_airlines[i].AddFlightSectionToFlight(new FlightSection(seatClass, rows, cols), flightId))
                        {
                            break;
                        }
                        else
                        {
                            throw new ArgumentException($"Airline {airlineName} does not contain such flight!");
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("Airline does not exist!");
            }
        }

        #endregion

        #region Help Methods
        private bool DoesAirportExist(string airportName)
        {
            bool exists = false;

            foreach (Airport airport in _airports)
            {
                if (airport.Name == airportName)
                {
                    exists = true;
                    break;
                }
            }

            return exists;
        }
        private bool DoesAirlineExist(string airlineName)
        {
            bool exists = false;

            foreach (Airline airline in _airlines)
            {
                if (airline.Name == airlineName)
                {
                    exists = true;
                    break;
                }
            }

            return exists;
        }
        private bool DoesFlightExist(string airlineName, string flightId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
