namespace AirlineBookingSystem
{
    public class Airline
    {
        public Airline(string name)
        {
            Name = name;
        }
        public Airline(Airline other) : this(other.Name)
        {
        }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return (obj is Airline airline) &&
                Name == airline.Name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Airline lhs, Airline rhs) => lhs.Equals(rhs);
        public static bool operator !=(Airline lhs, Airline rhs) => !(lhs == rhs);

        public override string ToString() => $"{Name}";
    }
}
