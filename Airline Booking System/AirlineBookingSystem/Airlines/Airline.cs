using AirlineBookingSystem.Additional;

namespace AirlineBookingSystem
{
    public class Airline
    {
        public Airline(string name)
        {
            Name = name;
        }

        [AirlineName]
        public string Name { get; set; }

        public override string ToString() => $"{Name}";
    }
}
