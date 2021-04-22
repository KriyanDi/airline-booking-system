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
            InitializeDataMembers();
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
        public List<Airport> AirportsReference => _airports;
        public List<Airline> AirlinesReference => _airlines;
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
            int airlineId = -1;
            if (SetIndexWithAirlineIndexIfAirlineExists(ref airlineId, airlineName))
            {
                if (DoesAirportExist(fromAirport))
                {
                    if (DoesAirportExist(toAirport))
                    {
                        _airlines[airlineId].AddFlight(new Flight(airlineName, fromAirport, toAirport, id, new DateTime(year, month, day)));
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
            int airlineId = -1;
            if (SetIndexWithAirlineIndexIfAirlineExists(ref airlineId, airlineName))
            {
                if (!_airlines[airlineId].AddFlightSectionToFlight(new FlightSection(seatClass, rows, cols), flightId))
                {
                    throw new ArgumentException($"Airline {airlineName} does not contain such flight!");
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
        #endregion

        #region Help Methods
        private void InitializeDataMembers()
        {
            _airports = new List<Airport>();
            _airlines = new List<Airline>();
        }
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
                .FlightsReference[flightId]
                .FlightSectionsReference[sectionId]
                .BookSeat(row, col);
        }

        private void SetAvailableFlights(string fromAirport, string toAirport, List<Flight> availableFlights)
        {
            TourEveryAirportAndAddItsFlightsIfTheyHaveAvailableSeats(fromAirport, toAirport, availableFlights);
        }
        private void TourEveryAirportAndAddItsFlightsIfTheyHaveAvailableSeats(string fromAirport, string toAirport, List<Flight> availableFlights)
        {
            for (int arilineIndex = 0; arilineIndex < _airlines.Count; arilineIndex++)
            {
                TourEveryFlightAndAddItIfItHasAvailableSeats(fromAirport, toAirport, availableFlights, arilineIndex);
            }
        }
        private void TourEveryFlightAndAddItIfItHasAvailableSeats(string fromAirport, string toAirport, List<Flight> availableFlights, int arilineIndex)
        {
            for (int flightIndex = 0; flightIndex < _airlines[arilineIndex].Flights.Count; flightIndex++)
            {
                TourEveryFlightSectionAndAddFlightIfItHasAvailableSeats(fromAirport, toAirport, availableFlights, arilineIndex, flightIndex);
            }
        }
        private void TourEveryFlightSectionAndAddFlightIfItHasAvailableSeats(string fromAirport, string toAirport, List<Flight> availableFlights, int airlineIndex, int flightIndex)
        {
            for (int flightSectionIndex = 0; flightSectionIndex < _airlines[airlineIndex].Flights[flightIndex].FlightSections.Count; flightSectionIndex++)
            {
                if (CanFlightBeAddedToAvailableFlightsList(fromAirport, toAirport, airlineIndex, flightIndex, flightSectionIndex))
                {
                    availableFlights.Add(new Flight(_airlines[airlineIndex].Flights[flightIndex]));
                }
            }
        }
        private bool CanFlightBeAddedToAvailableFlightsList(string fromAirport, string toAirport, int airlineIndex, int flightIndex, int flightSectionIndex)
        {
            return DoesFlightMeetsTheGivenRequierments(airlineIndex, flightIndex, toAirport, fromAirport) && HasFlightAvailableSeatsInThisFlightSection(airlineIndex, flightIndex, flightSectionIndex);
        }
        private bool HasFlightAvailableSeatsInThisFlightSection(int airlineIndex, int flightIndex, int flightSectionIndex)
        {
            return _airlines[airlineIndex].Flights[flightIndex].FlightSections[flightSectionIndex].HasAvailableSeats();
        }
        private bool DoesFlightMeetsTheGivenRequierments(int airlineIndex, int flightIndex, string toAirport, string fromAirport)
        {
            bool matchingOriginatingAirport =
                _airlines[airlineIndex]
                .Flights[flightIndex]
                .Information
                .OriginatingAirport == fromAirport;

            bool matchingDestinationAirport =
                _airlines[airlineIndex]
                .Flights[flightIndex]
                .Information
                .DestinationAirport == toAirport;

            return matchingOriginatingAirport && matchingDestinationAirport;


        }
        #endregion
    }
}
