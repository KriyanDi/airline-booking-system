using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Airlines
{
    public enum AirlineOperation
    {
        // Basic
        Succeded,
        Failed,

        // Airline Name
        InvalidNameFormatFailure,
        InvalidNameLenghtFailure,
        InvalidNameNullFailure,

        // Flight
        InvalidFlightMatchingFlighNumberFailure,
        InvalidAirportNotMathingAirlineFailure,
        AddingFlightFailure
    }
}
