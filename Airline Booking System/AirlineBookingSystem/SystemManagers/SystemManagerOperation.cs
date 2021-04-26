using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Seats
{
    public enum SystemManagerOperation
    {
        // Basic
        Succeded,
        Failed,

        // Create
        InvalidNameAirportExistFailure,
        InvalidNameAirlineExistFailure,
        AddingFlightFailure,

        // Data
        UnexistingAirportFailure,
        UnexistingAirlineFailure,
        UnexistingFlightFailure,

        // Section
        UnexsistingSectionFailure,
        UnexsistingSeatClassFailure,

        // Seat
        BookingSeatFailure,
    }
}
