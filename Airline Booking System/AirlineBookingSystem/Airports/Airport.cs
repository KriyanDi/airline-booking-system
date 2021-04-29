namespace AirlineBookingSystem
{
    public class Airport
    {
        public Airport(string name)
        {
            Name = name;
        }
        public Airport(Airport other) : this(other.Name)
        {
        }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Airport airport &&
                   Name == airport.Name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Airport lhs, Airport rhs) => lhs.Equals(rhs);
        public static bool operator !=(Airport lhs, Airport rhs) => !(lhs == rhs);

        public override string ToString() => $"{Name}";
    }
}
