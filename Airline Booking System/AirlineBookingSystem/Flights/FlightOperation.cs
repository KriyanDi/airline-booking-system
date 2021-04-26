using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Flights
{
    public enum FlightOperation
    {
        // Basic
        Succeded,
        Failed,

        // Sections in Flight
        InvalidSectionAlreadyExistsFailure
    }
}
