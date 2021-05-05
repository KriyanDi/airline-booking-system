using AirlineBookingSystem.Additional;
using System.Collections.Generic;

namespace AirlineBookingSystem
{
    public interface ISystemManageable
    {
        OperationResult CreateAirport(string airportName);
        OperationResult CreateAirline(string airlineName);
        OperationResult CreateFlight(string airlineName, string fromAirport, string toAirport, int year, int month, int day, string id);
        OperationResult CreateSection(string airlineName, string flightId, int rows, int cols, SeatClass seatClass);
        List<Flight> FindAvailableFlights(string originatingAirport, string destionationAirport);
        OperationResult BookSeat(string airlineName, string flightNumber, SeatClass seatClass, int rows, char cols);
        void DisplaySystemDetails();
    }
}