namespace AirlineBookingSystem.Additional
{
    public enum OperationResult
    {
        // Basic
        Succeded,
        Failed,

        // Create
        AirportNameExistFailure,
        AirlineNameExistsFailure,

        // Flight
        FlightNumberExistsFailure,
        InvalidFlightDetailsFailure,

        // Data
        UnexistingAirportFailure,
        UnexistingAirlineFailure,
        UnexistingFlightFailure,

        // Section
        SectionExistsFailure,
        UnexsistingSeatClassFailure,
        SectionParametersFailure,

        // Seat
        BookingSeatFailure,

        // Invalid argument
        InvalidAirportFormatFailure,
        InvalidAirlineFormatFailure,
    }
}
