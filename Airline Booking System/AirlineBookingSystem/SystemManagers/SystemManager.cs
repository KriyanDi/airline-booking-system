using AirlineBookingSystem.Additional;
using System;
using System.Collections.Generic;

namespace AirlineBookingSystem
{
    public class SystemManager
    {
        #region Fields
        private Dictionary<string, Airport> _airports;
        private Dictionary<string, Airline> _airlines;
        private Dictionary<string, Flight> _flights;
        private Dictionary<string, List<FlightSection>> _flightSections;
        #endregion

        #region Constructors
        public SystemManager()
        {
            InitializeDataMembers();
        }
        #endregion

        #region Methods
        public SystemManagerOperation CreateAirport(string airportName)
        {
            if (ValidationRules.AirportName(airportName) != ValidationOperation.Succeded)
            {
                return SystemManagerOperation.InvalidAirportFormatFailure;
            }

            if (!_airports.ContainsKey(airportName))
            {
                _airports.Add(airportName, new Airport(airportName));

                return SystemManagerOperation.Succeded;
            }
            else
            {
                Console.WriteLine($"Error: Airport {airportName} already exists!");

                return SystemManagerOperation.InvalidNameAirportExistFailure;
            }
        }
        public SystemManagerOperation CreateAirline(string airlineName)
        {
            if (ValidationRules.AirlineName(airlineName) != ValidationOperation.Succeded)
            {
                return SystemManagerOperation.InvalidAirlineFormatFailure;
            }

            if (!_airlines.ContainsKey(airlineName))
            {
                _airlines.Add(airlineName, new Airline(airlineName));

                return SystemManagerOperation.Succeded;
            }
            else
            {
                Console.WriteLine($"Error: Airline {airlineName} already exists!");

                return SystemManagerOperation.InvalidNameAirlineExistFailure;
            }
        }
        public SystemManagerOperation CreateFlight(string airlineName, string fromAirport, string toAirport, int year, int month, int day, string id)
        {
            if (!_airlines.ContainsKey(airlineName))
            {
                Console.WriteLine("Error: Airline does not exist.");

                return SystemManagerOperation.UnexistingAirlineFailure;
            }

            if (!_airports.ContainsKey(fromAirport))
            {
                Console.WriteLine("Error: Originating Airport does not exist.");

                return SystemManagerOperation.UnexistingAirportFailure;
            }

            if (!_airports.ContainsKey(toAirport))
            {
                Console.WriteLine("Error: Destination Airport does not exist.");

                return SystemManagerOperation.UnexistingAirportFailure;
            }

            if (!_flights.ContainsKey(id))
            {
                _flights.Add(id, new Flight(airlineName, fromAirport, toAirport, id, new DateTime(year, month, day)));
                _flightSections.Add(id, new List<FlightSection>());

                return SystemManagerOperation.Succeded;
            }
            else
            {
                Console.WriteLine("Error: Flight with such flight number number exists.");

                return SystemManagerOperation.InvalidFlightNumberExistsFailure;
            }
        }
        public SystemManagerOperation CreateSection(string airlineName, string flightId, int rows, int cols, SeatClass seatClass)
        {
            if (ValidationRules.SeatsRowsCols(rows, cols) != ValidationOperation.Succeded)
            {
                return SystemManagerOperation.InvalidRowsColsFailure;
            }
            if (ValidationRules.FlightNumber(flightId) != ValidationOperation.Succeded)
            {
                return SystemManagerOperation.InvalidFlightIdFormatFailure;
            }

            if (!_airlines.ContainsKey(airlineName))
            {
                Console.WriteLine("Error: Airline does not exist.");

                return SystemManagerOperation.UnexistingAirlineFailure;
            }

            if (!_flights.ContainsKey(flightId))
            {
                Console.WriteLine($"Error: Airline {airlineName} does not contain such flight!");

                return SystemManagerOperation.UnexistingFlightFailure;
            }

            if (!_flightSections.ContainsKey(flightId))
            {
                Console.WriteLine("Error: Flight does not have flight sections.");

                return SystemManagerOperation.InvalidFlightSectionEmptyFailure;
            }

            if (!_flightSections[flightId].Exists(flightSection => flightSection.SeatClass == seatClass))
            {
                _flightSections[flightId].Add(new FlightSection(seatClass, rows, cols));

                return SystemManagerOperation.Succeded;
            }
            else
            {
                Console.WriteLine($"Error: Flight contain section {seatClass}!");

                return SystemManagerOperation.InvalidSectionExistsFailure;
            }
        }
        public List<Flight> FindAvailableFlights(string fromAirport, string toAirport)
        {
            List<Flight> availableFlights = new List<Flight>();

            if (!_airports.ContainsKey(fromAirport))
            {
                Console.WriteLine($"Error: Airport {fromAirport} does not exist.");

                return availableFlights;
            }

            if (!_airports.ContainsKey(toAirport))
            {
                Console.WriteLine($"Error: Airport {toAirport} does not exist.");

                return availableFlights;
            }

            foreach (var flight in _flights)
            {
                if (flight.Value.OriginatingAirport == fromAirport &&
                    flight.Value.DestinationAirport == toAirport &&
                    _flightSections.ContainsKey(flight.Key))
                {
                    if (_flightSections[flight.Key].Exists(flightSection => flightSection.HasAvailableSeats()))
                    {
                        availableFlights.Add(flight.Value);
                    }
                }
            }

            return availableFlights;
        }
        public SystemManagerOperation BookSeat(string airlineName, string flightNumber, SeatClass seatClass, int rows, char cols)
        {
            if (ValidationRules.SeatsRowsCols((rows, cols)) != ValidationOperation.Succeded)
            {
                return SystemManagerOperation.InvalidRowsColsFailure;
            }

            if (!_airlines.ContainsKey(airlineName))
            {
                Console.WriteLine("Error: Airline does not exist!");

                return SystemManagerOperation.UnexistingAirlineFailure;
            }

            if (!_flights.ContainsKey(flightNumber))
            {
                Console.WriteLine("Error: Flight does not exist.");

                return SystemManagerOperation.UnexistingFlightFailure;
            }

            if (!_flightSections.ContainsKey(flightNumber))
            {
                Console.WriteLine($"Error: Flight does not contain any sections.");

                return SystemManagerOperation.UnexsistingSeatClassFailure;
            }

            if (_flightSections[flightNumber].Exists(flightNum => flightNum.SeatClass == seatClass) &&
                _flightSections[flightNumber].Find(flightNum => flightNum.SeatClass == seatClass).BookSeat(rows, cols))
            {

                return SystemManagerOperation.Succeded;
            }
            else
            {
                Console.WriteLine("Error: Could not book seat.");

                return SystemManagerOperation.BookingSeatFailure;
            }
        }
        public void DisplaySystemDetails() => Console.WriteLine(this.ToString());
        #endregion

        #region Help Methods
        private void InitializeDataMembers()
        {
            _airports = new Dictionary<string, Airport>();
            _airlines = new Dictionary<string, Airline>();
            _flights = new Dictionary<string, Flight>();
            _flightSections = new Dictionary<string, List<FlightSection>>();
        }
        #endregion

        #region Other Overridden Methods
        public override string ToString()
        {
            string airportsAll = "";
            foreach (Airport airport in _airports.Values)
            {
                airportsAll += airport.ToString() + "\n";
            }

            string airlinesAll = "";
            foreach (Airline airline in _airlines.Values)
            {
                airlinesAll += airline.ToString() + "\n";
            }

            string flightsAll = "";
            foreach (Flight flight in _flights.Values)
            {
                flightsAll += flight.ToString() + "\n";
            }

            string flightSectionsAll = "";
            foreach (var flightSection in _flightSections)
            {
                string flightNumber = $"{flightSection.Key}";
                string sections = "";
                foreach (FlightSection section in flightSection.Value)
                {
                    sections += section.ToString() + "\n";
                }

                flightSectionsAll += flightNumber + "\n" + sections + "\n";
            }

            return "System Details: \n\n" + "Airports: \n" + airportsAll + "\n" + "Airlines: \n" + airlinesAll + "\n" + "Flights: \n" + flightsAll + "\n" + "Flight Sections: \n" + flightSectionsAll;
        }
        #endregion
    }
}
