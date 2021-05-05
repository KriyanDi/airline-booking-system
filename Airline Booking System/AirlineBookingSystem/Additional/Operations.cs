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
        Failed,

        // Create
        AirportNameExistFailure,
        InvalidNameAirlineExistFailure,

        //Flight
        InvalidFlightNumberExistsFailure,
        InvalidFlightNumberFormatFailure,

        // Data
        UnexistingAirportFailure,
        UnexistingAirlineFailure,
        UnexistingFlightFailure,

        // Section
        ExsistingSectionFailure,
        UnexsistingSeatClassFailure,
        SectionParametersFailure,

        // Seat
        BookingSeatFailure,

        // Invalid argument
        InvalidAirportFormatFailure,
        InvalidAirlineFormatFailure,
        InvalidRowsColsFailure
    }
}
