namespace AirlineBookingSystem
{
    public interface IModifyData
    {
        void BookSeat(string airline, string flightId, SeatClass seatClass, int row, char col);
    }
}