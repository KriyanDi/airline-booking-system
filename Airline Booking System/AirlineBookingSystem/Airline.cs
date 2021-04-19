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
        #region Fields
        private string _name;
        #endregion

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
        public string Name
        {
            get => _name;
            set
            {
                if (value != null)
                {
                    if (value.HasLengthMoreThanOneAndLessThanSix())
                    {
                        if (value.HasOnlyCapitalLettersAndNumbers())
                        {
                            _name = value;
                        }
                        else
                        {
                            throw new ArgumentException("Airline name should contain only capital letters and numbers.");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Airline name should be between 1 and 5 symbols long.");
                    }
                }
                else
                {
                    throw new ArgumentNullException("Airline name can not be null.");
                }
            }
        }
        #endregion
    }
}
