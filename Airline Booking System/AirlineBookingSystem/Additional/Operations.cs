using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Additional
{
    public enum ValidationOperation
    {
        // Basic
        Succeded,
        Failed,

        // Airport Airline Name
        InvalidNameLenghtFailure,
        InvalidNameNullFailure,
        InvalidNameFormatFailure,

        // Flight
        InvalidFlightMatchingFlighNumberFailure,
        InvalidAirportNotMathingAirlineFailure,
        AddingFlightFailure,

        // Sections in Flight
        InvalidSectionAlreadyExistsFailure,
        InvalidFlightNumberContainsNotOnlyNumbersFailure,

        // Rows Cols
        InvalidSeatRowsFailure,
        InvalidSeatColsFailure,
    }
   
    public enum SystemManagerOperation
    {
        // Basic
        Succeded,
        Failed,

        // Create
        InvalidNameAirportExistFailure,
        InvalidNameAirlineExistFailure,

        //Flight
        InvalidFlightNumberExistsFailure,

        // Data
        UnexistingAirportFailure,
        UnexistingAirlineFailure,
        UnexistingFlightFailure,

        // Section
        UnexsistingSectionFailure,
        UnexsistingSeatClassFailure,
        InvalidSectionExistsFailure,

        // Seat
        BookingSeatFailure,

        // Invalid argument
        InvalidAirportFormatFailure,
        InvalidAirlineFormatFailure,
        InvalidFlightIdFormatFailure,
        InvalidRowsColsFailure
    }
}
