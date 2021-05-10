using AirlineBookingSystem.Additional;
using System.Collections.Generic;

namespace AirlineBookingSystem
{
    public interface ISystemManageable
    {
        OperationResult CreateAirport(Airport airport);
        OperationResult CreateAirline(Airline airline);
        OperationResult CreateFlight(Flight flight);
        OperationResult CreateSection(string airlineName, string flightId, FlightSection section);
        List<Flight> FindAvailableFlights(string originatingAirport, string destionationAirport);
        OperationResult BookSeat(string airlineName, string flightNumber, SeatClass seatClass, int rows, char cols);
        void DisplaySystemDetails();
    }
}