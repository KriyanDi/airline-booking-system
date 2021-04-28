using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Additional
{
    public enum AirportOperation
    {
        // Basic
        Succeded,
        Failed,

        // Airport Name
        InvalidNameLenghtFailure,
        InvalidNameNullFailure,
        InvalidNameFormatFailure
    }
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
    public enum FlightOperation
    {
        // Basic
        Succeded,
        Failed,

        // Sections in Flight
        InvalidSectionAlreadyExistsFailure
        InvalidFlightNumberContainsNotOnlyNumbersFailure
    }
    public enum SeatOperation
    {
        // Basic
        Succeded,
        Failed,

        // Rows Cols
        InvalidSeatRowsFailure,
        InvalidSeatColsFailure
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
    }
}
