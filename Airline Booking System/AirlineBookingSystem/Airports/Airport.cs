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
        #region Fields
        private string _name;
        #endregion

        #region Constructors
        public Airport(string name)
        {
            InitializeDataMembers(name);
        }
        public Airport(Airport other) : this(other.Name)
        {
        }
        #endregion

        #region Properties
        public string Name => _name;
        #endregion

        #region Methods
        public AirportOperation ChangeName(string airportName)
        {
            AirportOperation result = ValidationRules.AirportName(airportName);

            switch (result)
            {
                case AirportOperation.Succeded:
                    _name = airportName;
                    break;
                case AirportOperation.InvalidNameLenghtFailure:
                    Console.WriteLine("Error: Airport name should be exact 3 letters long.");
                    break;
                case AirportOperation.InvalidNameNullFailure:
                    Console.WriteLine("Error: Airport name can not be null.");
                    break;
                case AirportOperation.InvalidNameFormatFailure:
                    Console.WriteLine("Error: Airport name should contain only capital letters.");
                    break;
            }

            return result;
        }
        #endregion

        #region Equations Methods
        public override bool Equals(object obj)
        {
            return obj is Airport airport &&
                   _name == airport.Name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Airport lhs, Airport rhs) => lhs.Equals(rhs);
        public static bool operator !=(Airport lhs, Airport rhs) => !(lhs == rhs);
        #endregion
        
        #region Help Methods
        private void InitializeDataMembers(string name)
        {
            InitializeName(name);
        }
        private void InitializeName(string name)
        {
            if (ChangeName(name) != AirportOperation.Succeded)
            {
                Console.WriteLine("Airport was not created!");

                throw new ArgumentException(AirportExceptionMessages.invalidName);
            }
        }
        #endregion

        #region Other Overridden Methods
        public override string ToString() => $"{_name}"; 
        #endregion
    }
}
