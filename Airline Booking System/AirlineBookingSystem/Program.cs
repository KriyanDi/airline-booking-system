using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            RunProgram();
        }

        private static void RunProgram()
        {
            SystemManager res = new SystemManager();

            //Create airports
            res.CreateAirport("DEN");
            res.CreateAirport("DFW");
            res.CreateAirport("LON");
            res.CreateAirport("JPN");
            res.CreateAirport("DE"); //invalid 
            res.CreateAirport("DEH");
            res.CreateAirport("DEN"); //invalid
            res.CreateAirport("NCE");
            res.CreateAirport("TRIord9"); //invalid
            res.CreateAirport("DEN"); //invalid

            //Create airlines
            res.CreateAirline("DELTA");
            res.CreateAirline("AMER");
            res.CreateAirline("JET");

            res.CreateAirline("DELTA"); //invalid
            res.CreateAirline("SWEST");
            res.CreateAirline("AMER"); //invalid
            res.CreateAirline("FRONT");
            res.CreateAirline("FRONTIER"); //invalid

            //Create flights
            res.CreateFlight("DELTA", "DEN", "LON", 2009, 10, 10, "123");
            res.CreateFlight("DELTA", "DEN", "DEH", 2009, 8, 8, "567");
            res.CreateFlight("DELTA", "DEN", "NCE", 2010, 9, 8, "567"); //invalid
            res.CreateFlight("JET", "LON", "DEN", 2009, 5, 7, "123");
            res.CreateFlight("AMER", "DEN", "LON", 2010, 10, 1, "123");
            res.CreateFlight("JET", "DEN", "LON", 2010, 6, 10, "786");
            res.CreateFlight("JET", "DEN", "LON", 2009, 1, 12, "909");

            //Create sections
            res.CreateSection("JET", "123", 2, 2, SeatClass.ECONOMY);
            res.CreateSection("JET", "123", 1, 3, SeatClass.ECONOMY); //invalid
            res.CreateSection("JET", "123", 2, 3, SeatClass.FIRST);
            res.CreateSection("DELTA", "123", 1, 1, SeatClass.BUSINESS);
            res.CreateSection("DELTA", "123", 1, 2, SeatClass.ECONOMY);
            res.CreateSection("SWSERTT", "123", 5, 5, SeatClass.ECONOMY); //invalid

            res.DisplaySystemDetails();

            Console.WriteLine("Available Flights:");
            List<Flight> availableFlights = res.FindAvailableFlights("DEN", "LON");
            foreach (Flight flight in availableFlights)
            {
                Console.WriteLine(flight);
            }

            // Book seats
            res.BookSeat("DELTA", "123", SeatClass.BUSINESS, 1, 'A');
            res.BookSeat("DELTA", "123", SeatClass.ECONOMY, 1, 'A');
            res.BookSeat("DELTA", "123", SeatClass.ECONOMY, 1, 'B');
            res.BookSeat("DELTA", "123", SeatClass.BUSINESS, 1, 'A'); //already booked

            res.DisplaySystemDetails();

            Console.WriteLine("Available Flights:");
            availableFlights = res.FindAvailableFlights("DEN", "LON");
            foreach (Flight flight in availableFlights)
            {
                Console.WriteLine(flight);
            }
        }

        private static void PrintAvailableFlights(List<Flight> availableFlightsList)
        {
            Console.WriteLine("Available flights:");
            foreach (Flight flight in availableFlightsList)
            {
                Console.WriteLine(flight);
            }
        }
    }
}
