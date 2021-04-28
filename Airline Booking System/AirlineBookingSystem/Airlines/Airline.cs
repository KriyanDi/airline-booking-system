using AirlineBookingSystem.Airlines;
using AirlineBookingSystem.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            if (obj is Airline airline)
            {
                bool areFlightsExact = true;
                for (int i = 0; i < _flights.Count; i++)
                {
                    if (!_flights[i].Equals(airline.Flights[i]))
                    {
                        areFlightsExact = false;
                        break;
                    }
                }

                return _name == airline._name &&
                      _flights.Count == airline.Flights.Count &&
                      areFlightsExact;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            int hashCode = 1536774888;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Flight>>.Default.GetHashCode(_flights);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Flight>>.Default.GetHashCode(Flights);
            return hashCode;
        }
        public static bool operator ==(Airline lhs, Airline rhs) => lhs.Equals(rhs);
        public static bool operator !=(Airline lhs, Airline rhs) => !(lhs == rhs);
        #endregion

        #region Other Overridden Method
        public override string ToString()
        {
            return $"{Name}";
        }
        #endregion
    }
}
