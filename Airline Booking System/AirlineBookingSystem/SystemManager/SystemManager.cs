using System;
using System.Collections.Generic;

namespace AirlineBookingSystem
{
    public class SystemManager : ISystemManageable
    {
        private DataBase dataBase;

        public SystemManager()
        {
            dataBase = new DataBase();
        }

        public void BookSeat(string airline, string flightId, SeatClass seatClass, int row, char col)
        {
            try
            {
                if (!dataBase.Flights[flightId].FlightSections[seatClass].BookSeat(row, col)) Console.WriteLine("Book Seat: Seat already booked");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Book Seat: {ex.Message}");
            }
        }

        public void CreateAirline(string name)
        {
            try
            {
                dataBase.AddElement(new Airline(name));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Create Airline: {ex.Message}");
            }
        }

        public void CreateAirport(string name)
        {
            try
            {
                dataBase.AddElement(new Airport(name));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Create Airport: {ex.Message}");
            }
        }

        public void CreateFlight(string airline, string orig, string dest, int year, int month, int day, string id)
        {
            try
            {
                dataBase.AddElement(new Flight(airline, orig, dest, id, new DateTime(year, month, day)));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Create Flight: {ex.Message}");
            }
        }

        public void CreateSection(string airline, string flightId, int rows, int cols, SeatClass seatClass)
        {
            try
            {
                if (dataBase.Flights[flightId].AirlineName == airline && !dataBase.Flights[flightId].FlightSections.ContainsKey(seatClass))
                {
                    dataBase.Flights[flightId].FlightSections.Add(seatClass, new FlightSection(seatClass, rows, cols));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Create Section: {ex.Message}");
                throw;
            }
        }

        public void DisplaySystemDetails() => Console.WriteLine(dataBase);

        public List<Flight> FindAvailableFlights(string orig, string dest)
        {
            var availableFlights = new List<Flight>();

            foreach (var flight in dataBase.Flights.Values)
            {
                if (flight.OriginatingAirport == orig && flight.DestinationAirport == dest && flight.HasAvailableSeats()) availableFlights.Add(flight);
            }

            return availableFlights;
        }
    }
}