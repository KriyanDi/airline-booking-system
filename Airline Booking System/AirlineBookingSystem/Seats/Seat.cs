namespace AirlineBookingSystem
{
    public class Seat
    { 
        public Seat((int rows, char cols) id, bool isBooked)
        {
            Id = id;
            IsBooked = isBooked;
        }
        public Seat(Seat other) : this(other.Id, other.IsBooked)
        {
        }

        public (int rows, char cols) Id { get; set; }
        public bool IsBooked { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Seat seat &&
                   Id == seat.Id &&
                   IsBooked == seat.IsBooked;
        }
        public override int GetHashCode()
        {
            int hashCode = -1850583607;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + IsBooked.GetHashCode();
            return hashCode;
        }
        public static bool operator ==(Seat lhs, Seat rhs) => lhs.Equals(rhs);
        public static bool operator !=(Seat lhs, Seat rhs) => !(lhs == rhs);

        public override string ToString() => $"ROW: {Id.rows} COL: {Id.cols} BOOKED: {IsBooked}";
    }
}
