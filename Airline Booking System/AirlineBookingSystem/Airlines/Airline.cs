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

        public override string ToString() => $"{Name}";
    }
}
