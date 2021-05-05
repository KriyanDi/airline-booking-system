namespace AirlineBookingSystem.Additional
{
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
        InvalidFlightDetailsFailure,

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
