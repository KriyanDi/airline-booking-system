using AirlineBookingSystem.Airports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AirlineBookingSystem
{
    public class Airport
    {
        #region Constructors
        public Airport(string name)
        {
            Name = name;
        }
        public Airport(Airport other) : this(other.Name)
        {
        }
        #endregion

        #region Properties
        public string Name { get; set; }
        #endregion

        #region Equations Methods
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
        #endregion

        #region Other Overridden Methods
        public override string ToString() => $"{Name}";
        #endregion
    }
}
