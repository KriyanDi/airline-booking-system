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
        ExsistingSectionFailure,
        UnexsistingSeatClassFailure,
        InvalidSectionExistsFailure,
        InvalidSectionDoesNotExist,

        // Seat
        BookingSeatFailure,

        // Invalid argument
        InvalidAirportFormatFailure,
        InvalidAirlineFormatFailure,
        InvalidFlightIdFormatFailure,
        InvalidRowsColsFailure,
        InvalidFlightSectionEmptyFailure
    }
}
