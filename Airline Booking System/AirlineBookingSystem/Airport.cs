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
        public string Name
        {
            get => _name;
            set
            {
                if(value != null)
                {
                    if (value.HasLengthThree())
                    {
                        if (value.HasOnlyCapitalLetters())
                        {
                            _name = value;
                        }
                        else
                        {
                            throw new ArgumentException("Airport name should contain only capital letters.");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Airport name should be 3 letters long.");
                    }
                }
                else
                {
                    throw new ArgumentNullException("Airport name can not be null.");
                }
            }
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
            Name = name;
        } 
        #endregion
    }
}
