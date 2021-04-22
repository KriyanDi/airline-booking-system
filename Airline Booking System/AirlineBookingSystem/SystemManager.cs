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
        public List<Flight> FindAvailableFlights(string fromAirport, string toAirport)
        {
            List<Flight> availableFlights = new List<Flight>();

            if (DoesAirportExist(fromAirport))
            {
                if (DoesAirportExist(toAirport))
                {
                    SetAvailableFlights(fromAirport, toAirport, availableFlights);
                }
                else
                {
                    throw new ArgumentException($"Airport {toAirport} does not exist!");
                }
            }
            else
            {
                throw new ArgumentException($"Airport {fromAirport} does not exist!");
            }

            return availableFlights;
        }
        public void BookSeat(string airlineName, string flightNumber, SeatClass seatClass, int row, char col)
        {
            int airlineId = -1;
            int flightId = -1;
            int sectionId = -1;

            if (SetIndexWithAirlineIndexIfAirlineExists(ref airlineId, airlineName))
            {
                if (SetIndexWithFlightIndexIfFlightExists(ref flightId, airlineId, flightNumber))
                {
                    if (SetIndexWithFlightSectionIndexIfFlightSectionExists(ref sectionId, flightId, airlineId, seatClass))
                    {
                        if (!TryBookSeat(row, col, airlineId, flightId, sectionId))
                        {
                            throw new ArgumentException($"Could not book seat on Row: {row} Col: {col}!");
                        }
                    }
                    else
                    {
                        throw new ArgumentException($"Flight does not contain section with seat class {seatClass}!");
                    }
                }
                else
                {
                    throw new ArgumentException("Flight does not exist!");
                }
            }
            else
            {
                throw new ArgumentException("Airline does not exist!");
            }
        }
        public List<Airport> GetReferenceAirports() => _airports;
        public List<Airline> GetReferenceAirlines() => _airlines;
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
        private void SetAvailableFlights(string fromAirport, string toAirport, List<Flight> availableFlights)
        {
            for (int arilineIndex = 0; arilineIndex < _airlines.Count; arilineIndex++)
            {
                for (int flightIndex = 0; flightIndex < _airlines[arilineIndex].Flights.Count; flightIndex++)
                {
                    for (int flightSectionIndex = 0; flightSectionIndex < _airlines[arilineIndex].Flights[flightIndex].FlightSections.Count; flightSectionIndex++)
                    {
                        if (_airlines[arilineIndex].Flights[flightIndex].Information.OriginatingAirport == fromAirport &&
                        _airlines[arilineIndex].Flights[flightIndex].Information.DestinationAirport == toAirport &&
                        _airlines[arilineIndex].Flights[flightIndex].FlightSections[flightSectionIndex].HasAvailableSeats())
                        {
                            availableFlights.Add(new Flight(_airlines[arilineIndex].Flights[flightIndex]));
                        }
                    }
                }
            }
        }
        private bool SetIndexWithAirlineIndexIfAirlineExists(ref int airlineId, string airlineName)
        {
            for (int i = 0; i < _airlines.Count; i++)
            {
                if (_airlines[i].Name == airlineName)
                {
                    airlineId = i;
                    return true;
                }
            }

            return false;
        }
        private bool SetIndexWithFlightIndexIfFlightExists(ref int flightId, int airlineId, string flightNumber)
        {
            for (int i = 0; i < _airlines[airlineId].Flights.Count; i++)
            {
                if (_airlines[airlineId].Flights[i].Information.FlightNumber == flightNumber)
                {
                    flightId = i;
                    return true;
                }
            }

            return false;
        }
        private bool SetIndexWithFlightSectionIndexIfFlightSectionExists(ref int sectionId, int flightId, int airlineId, SeatClass seatClass)
        {
            for (int i = 0; i < _airlines[airlineId].Flights[flightId].FlightSections.Count; i++)
            {
                if (_airlines[airlineId].Flights[flightId].FlightSections[i].SeatClass == seatClass)
                {
                    sectionId = i;
                    return true;
                }
            }

            return false;
        }
        private bool TryBookSeat(int row, char col, int airlineId, int flightId, int sectionId)
        {
            return _airlines[airlineId]
                .GetReferenceFlights()[flightId]
                .GetReferenceFlightSections()[sectionId]
                .BookSeat(row, col);
        }
        #endregion
    }
}
