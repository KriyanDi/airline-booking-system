using System;
using System.Collections.Generic;

namespace AirlineBookingSystem
{
    public class DataBase
    {
        public Dictionary<string, Airport> Airports { get; set; }
        public Dictionary<string, Airline> Airlines { get; set; }
        public Dictionary<string, Flight> Flights { get; set; }

        public DataBase()
        {
            Airports = new Dictionary<string, Airport>();
            Airlines = new Dictionary<string, Airline>();
            Flights = new Dictionary<string, Flight>();
        }

        public void AddElement(object obj)
        {
            switch (obj)
            {
                case Airport airport:
                    if (!Airports.ContainsKey(airport.Name)) { Airports.Add(airport.Name, airport); } else { Console.WriteLine("DataBase: Airport already exists error."); };
                    break;
                case Airline airline:
                    if (!Airlines.ContainsKey(airline.Name)) { Airlines.Add(airline.Name, airline); } else { Console.WriteLine("DataBase: Airline already exists error."); };
                    break;
                case Flight flight:
                    if (!Flights.ContainsKey(flight.FlightNumber)) { Flights.Add(flight.FlightNumber, flight); } else { Console.WriteLine("DataBase: Flight already exists error"); };
                    break;
                default:
                    Console.WriteLine("Invalid Type Object!");
                    break;
            }
        }

        public override string ToString()
        {
            string result = "";

            result = result + '\n';
            result = result + "Airports\n";
            foreach (var airport in Airports.Values) result = result + airport.ToString() + '\n';
            result = result + '\n';

            result = result + "Airlines\n";
            foreach (var airline in Airlines.Values) result = result + airline.ToString() + '\n';
            result = result + '\n';

            result = result + "Flights\n";
            foreach (var flight in Flights.Values) result = result + flight.ToString() + '\n';
            result = result + '\n';

            return result;
        }
    }
}