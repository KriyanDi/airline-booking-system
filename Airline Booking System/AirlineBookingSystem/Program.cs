﻿using System;
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

            try
            {
                res.CreateAirport("DE"); //invalid
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            res.CreateAirport("DEH");

            try
            {
                res.CreateAirport("DEN"); //invalid
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            res.CreateAirport("NCE");

            try
            {
                res.CreateAirport("TRIord9"); //invalid
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                res.CreateAirport("DEN"); //invalid
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Create airlines
            res.CreateAirline("DELTA");
            res.CreateAirline("AMER");
            res.CreateAirline("JET");

            try
            {
                res.CreateAirline("DELTA"); //invalid
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            res.CreateAirline("SWEST");

            try
            {
                res.CreateAirline("AMER"); //invalid
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            res.CreateAirline("FRONT");

            try
            {
                res.CreateAirline("FRONTIER"); //invalid
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Create flights
            res.CreateFlight("DELTA", "DEN", "LON", 2009, 10, 10, "123");
            res.CreateFlight("DELTA", "DEN", "DEH", 2009, 8, 8, "567");

            try
            {
                res.CreateFlight("DELTA", "DEN", "NCE", 2010, 9, 8, "567"); //invalid
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            res.CreateFlight("JET", "LON", "DEN", 2009, 5, 7, "123");
            res.CreateFlight("AMER", "DEN", "LON", 2010, 10, 1, "123");
            res.CreateFlight("JET", "DEN", "LON", 2010, 6, 10, "786");
            res.CreateFlight("JET", "DEN", "LON", 2009, 1, 12, "909");

            //Create sections
            res.CreateSection("JET", "123", 2, 2, SeatClass.ECONOMY);

            try
            {
                res.CreateSection("JET", "123", 1, 3, SeatClass.ECONOMY); //invalid
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            res.CreateSection("JET", "123", 2, 3, SeatClass.FIRST);
            res.CreateSection("DELTA", "123", 1, 1, SeatClass.BUSINESS);
            res.CreateSection("DELTA", "123", 1, 2, SeatClass.ECONOMY);

            try
            {
                res.CreateSection("SWSERTT", "123", 5, 5, SeatClass.ECONOMY); //invalid
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            res.DisplaySystemDetails();

            res.FindAvailableFlights("DEN", "LON");

            res.BookSeat("DELTA", "123", SeatClass.BUSINESS, 1, 'A');
            res.BookSeat("DELTA", "123", SeatClass.ECONOMY, 1, 'A');

            try
            {
                res.BookSeat("DELTA", "123", SeatClass.ECONOMY, 1, 'B');
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                res.BookSeat("DELTA", "123", SeatClass.BUSINESS, 1, 'A'); //already booked
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            res.DisplaySystemDetails();

            res.FindAvailableFlights("DEN", "LON");
        }
    }
}
