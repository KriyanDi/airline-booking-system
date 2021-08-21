﻿using System.Collections.Generic;

namespace WebAbsApi.Data
{
    public class Airline
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }
}
