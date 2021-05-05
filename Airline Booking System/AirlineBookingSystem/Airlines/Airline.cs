namespace AirlineBookingSystem
{
    public class Airline
    {
        public Airline(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public override string ToString() => $"{Name}";
    }
}
