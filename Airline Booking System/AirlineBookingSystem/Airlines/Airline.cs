using AirlineBookingSystem.Additional;

namespace AirlineBookingSystem
{
    public class Airline
    {
        private static int _counter;

        public Airline(string name)
        {
            Name = name;
            Id = _counter++;
        }
        public Airline(Airline other) : this(other.Name) { }

        public int Id { get; set; }
        [AirlineName]
        public string Name { get; set; }

        public override string ToString() => $"{Name}";
    }
}
