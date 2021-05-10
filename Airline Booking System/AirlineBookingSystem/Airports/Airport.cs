using AirlineBookingSystem.Additional;

namespace AirlineBookingSystem
{
    public class Airport
    {
        private static int _counter;

        public Airport(string name)
        {
            Name = name;
            Id = _counter++;
        }
        public Airport(Airport other) : this(other.Name) { }

        public int Id { get; set; }
        [AirportName]
        public string Name { get; set; }

        public override string ToString() => $"{Name}";
    }
}
