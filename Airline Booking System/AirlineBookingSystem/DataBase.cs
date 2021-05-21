using System;
using System.Collections.Generic;

namespace AirlineBookingSystem
{
    public class DataBase
    {
        public Dictionary<string, Airport> Airports
        {
            get => default;
            set
            {
            }
        }

        public Dictionary<string, Airline> Airlines
        {
            get => default;
            set
            {
            }
        }

        public Dictionary<string, Flight> Flights
        {
            get => default;
            set
            {
            }
        }

        public void AddElement()
        {
            throw new System.NotImplementedException();
        }
    }
}