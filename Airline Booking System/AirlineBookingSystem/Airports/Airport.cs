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

        public override string ToString() => $"{Name}";
    }
}
