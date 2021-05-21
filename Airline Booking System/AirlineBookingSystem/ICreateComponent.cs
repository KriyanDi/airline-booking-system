namespace AirlineBookingSystem
{
    public interface ICreateComponent
    {
        void CreateAirport(string name);
        void CreateAirline(string name);
        void CreateFlight(string airline, string orig, string dest, int year, int month, int day, string id);
        void CreateSection(string airline, string flightId, int rows, int cols, SeatClass seatClass);
    }
}