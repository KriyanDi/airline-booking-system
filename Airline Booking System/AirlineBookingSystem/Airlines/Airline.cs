namespace AirlineBookingSystem
{
    public class Airline
    {
        #region Constructors
        public Airline(string name)
        {
            Name = name;
        }
        public Airline(Airline other) : this(other.Name)
        {
        }
        #endregion

        #region Properties
        public string Name { get; set; }
        #endregion

        #region Equation Methods
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
        #endregion

        #region Other Overridden Method
        public override string ToString() => $"{Name}";
        #endregion
    }
}
