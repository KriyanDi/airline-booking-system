namespace AirlineBookingSystem.Additional
{
    public enum ValidationOperation
    {
        // Basic
        Succeded,

        // Airport Airline Name
        InvalidNameLenghtFailure,
        InvalidNameNullFailure,
        InvalidNameFormatFailure,

        // Sections in Flight
        InvalidFlightNumberContainsNotOnlyNumbersFailure,

        // Rows Cols
        InvalidSeatRowsFailure,
        InvalidSeatColsFailure,
    }

    public enum SystemManagerOperation
    {
        // Basic
        Succeded,

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

        // Seat
        BookingSeatFailure,

        // Invalid argument
        InvalidAirportFormatFailure,
        InvalidAirlineFormatFailure,
        InvalidRowsColsFailure
    }
}
