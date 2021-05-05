﻿using AirlineBookingSystem.Additional;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirlineBookingSystem
{
    public class SystemManager : ISystemManageable
    {
        #region Fields
        private Dictionary<string, Airport> _airports;
        private Dictionary<string, Airline> _airlines;
        private Dictionary<string, Flight> _flights;
        #endregion

        #region Constructors
        public SystemManager()
        {
            _airports = new Dictionary<string, Airport>();
            _airlines = new Dictionary<string, Airline>();
            _flights = new Dictionary<string, Flight>();
        }
        #endregion

        #region Methods
        public OperationResult CreateAirport(string airportName)
        {
            switch (_airports.ContainsKey(airportName))
            {
                case true:
                    {
                        Console.WriteLine($"Error: Airport {airportName} already exists!");
                        return OperationResult.AirportNameExistFailure;
                    }
                case false:
                    {
                        _airports.Add(airportName, new Airport(airportName));
                        return OperationResult.Succeded;
                    }
                default: return OperationResult.Failed;
            }
        }
        public OperationResult CreateAirline(string airlineName)
        {
            switch (_airlines.ContainsKey(airlineName))
            {
                case true:
                    {
                        Console.WriteLine($"Error: Airline {airlineName} already exists!");
                        return OperationResult.InvalidNameAirlineExistFailure;
                    }
                case false:
                    {
                        _airlines.Add(airlineName, new Airline(airlineName));
                        return OperationResult.Succeded;
                    }
                default: return OperationResult.Failed;
            }
        }

        public OperationResult CreateFlight(string airlineName, string fromAirport, string toAirport, int year, int month, int day, string id)
        {
            if (!_airlines.ContainsKey(airlineName))
            {
                Console.WriteLine("Error: Airline does not exist.");
                return OperationResult.UnexistingAirlineFailure;
            }

            if (!_airports.ContainsKey(fromAirport) || !_airports.ContainsKey(toAirport))
            {
                Console.WriteLine("Error: Unexisting Airport.");
                return OperationResult.UnexistingAirportFailure;
            }

            if (!_flights.ContainsKey(id))
            {
                _flights.Add(id, new Flight(airlineName, fromAirport, toAirport, id, new DateTime(year, month, day)));
                return OperationResult.Succeded;
            }
            else
            {
                Console.WriteLine("Error: Flight with such flight number number exists.");
                return OperationResult.InvalidFlightNumberExistsFailure;
            }
        }
        public OperationResult CreateSection(string airlineName, string flightId, int rows, int cols, SeatClass seatClass)
        {
            if (!_airlines.ContainsKey(airlineName))
            {
                Console.WriteLine("Error: Airline does not exist.");
                return OperationResult.UnexistingAirlineFailure;
            }

            if (!_flights.ContainsKey(flightId))
            {
                Console.WriteLine($"Error: Airline {airlineName} does not contain such flight!");
                return OperationResult.UnexistingFlightFailure;
            }

            if (_flights.ContainsKey(flightId) && _flights[flightId].AirlineName != airlineName)
            {
                Console.WriteLine($"Error: Airline {airlineName} does not contain such flight!");
                return OperationResult.UnexistingFlightFailure;
            }

            if (!_flights[flightId].FlightSections.ContainsKey(seatClass))
            {
                _flights[flightId].FlightSections.Add(seatClass, new FlightSection(seatClass, rows, cols));
                return OperationResult.Succeded;
            }
            else
            {
                Console.WriteLine($"Error: Flight contain section {seatClass}!");
                return OperationResult.ExsistingSectionFailure;
            }
        }

        public List<Flight> FindAvailableFlights(string originatingAirport, string destionationAirport)
        {
            List<Flight> availableFlights = new List<Flight>();

            if (!_airports.ContainsKey(originatingAirport))
            {
                Console.WriteLine($"Error: Airport {originatingAirport} does not exist.");
                return availableFlights;
            }

            if (!_airports.ContainsKey(destionationAirport))
            {
                Console.WriteLine($"Error: Airport {destionationAirport} does not exist.");
                return availableFlights;
            }

            foreach (var flight in _flights.Values)
            {
                if (flight.OriginatingAirport == originatingAirport && flight.DestinationAirport == destionationAirport)
                {
                    foreach (FlightSection section in flight.FlightSections.Values)
                    {
                        if (section.HasAvailableSeats())
                        {
                            availableFlights.Add(flight);
                            break;
                        }
                    }
                }
            }

            return availableFlights;
        }
        public OperationResult BookSeat(string airlineName, string flightNumber, SeatClass seatClass, int rows, char cols)
        {
            if (!_airlines.ContainsKey(airlineName))
            {
                Console.WriteLine("Error: Airline does not exist!");
                return OperationResult.UnexistingAirlineFailure;
            }

            if (!_flights.ContainsKey(flightNumber))
            {
                Console.WriteLine("Error: Flight does not exist.");
                return OperationResult.UnexistingFlightFailure;
            }

            if (_flights.ContainsKey(flightNumber) && _flights[flightNumber].AirlineName != airlineName)
            {
                Console.WriteLine("Error: Flight does not exist.");
                return OperationResult.UnexistingFlightFailure;
            }

            if (_flights[flightNumber].FlightSections.Count == 0)
            {
                Console.WriteLine($"Error: Flight does not contain any sections.");
                return OperationResult.UnexsistingSeatClassFailure;
            }

            if (_flights[flightNumber].FlightSections.ContainsKey(seatClass) &&
                _flights[flightNumber].FlightSections[seatClass].BookSeat(rows, cols))
            {
                return OperationResult.Succeded;
            }
            else
            {
                Console.WriteLine("Error: Could not book seat.");
                return OperationResult.BookingSeatFailure;
            }
        }
        public void DisplaySystemDetails() => Console.WriteLine(this.ToString());
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

            return "System Details: \n\n" + "Airports: \n" + airportsAll + "\n" + "Airlines: \n" + airlinesAll + "\n" + "Flights: \n" + flightsAll + "\n";
        }
        #endregion
    }
}
