using AirlineBookingSystem.Additional;
using System.Collections.Generic;

namespace AirlineBookingSystem
{
    public interface ISystemManageable
    {
        SystemManagerOperation CreateAirport([AirportName] string airportName);
        SystemManagerOperation CreateAirline([AirlineName] string airlineName);
        SystemManagerOperation CreateFlight(string airlineName, string fromAirport, string toAirport, int year, int month, int day, [FlightNumber] string id);
        SystemManagerOperation CreateSection(string airlineName, string flightId, int rows, int cols, SeatClass seatClass);
        List<Flight> FindAvailableFlights(string originatingAirport, string destionationAirport);
        SystemManagerOperation BookSeat(string airlineName, string flightNumber, SeatClass seatClass, int rows, char cols);
        void DisplaySystemDetails();
    }
}