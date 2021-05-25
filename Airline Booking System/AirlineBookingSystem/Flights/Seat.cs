namespace AirlineBookingSystem
{
    public class Seat
    {
        public Seat((int rows, char cols) id, bool isBooked)
        {
            Id = id;
            IsBooked = isBooked;
        }

        public (int rows, char cols) Id { get; set; }
        public bool IsBooked { get; set; }
    }
}