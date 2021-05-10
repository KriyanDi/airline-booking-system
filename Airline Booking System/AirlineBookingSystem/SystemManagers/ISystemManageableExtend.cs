using AirlineBookingSystem.Additional;

namespace AirlineBookingSystem.SystemManagers
{
    interface ISystemManageableExtend : ISystemManageable
    {
        OperationResult CreateAirport(string airportName);
        OperationResult CreateAirline(string airlineName);
        OperationResult CreateFlight(string airlineName, string fromAirport, string toAirport, int year, int month, int day, string id);
        OperationResult CreateSection(string airlineName, string flightId, int rows, int cols, SeatClass seatClass);
    }
}
