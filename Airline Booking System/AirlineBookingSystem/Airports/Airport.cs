using AirlineBookingSystem.Additional;

namespace AirlineBookingSystem
{
    public class Airport
    {
        public Airport(string name)
        {
            Name = name;
        }

        [AirportName]
        public string Name { get; set; }

        public override string ToString() => $"{Name}";
    }
}
