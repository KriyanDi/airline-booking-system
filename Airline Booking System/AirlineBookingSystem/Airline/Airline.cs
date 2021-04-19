using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Airline
{
    class Airline
    {
        private string _name;

        public string Name
        {
            get => _name;
            set 
            {
                if (value != null)
                {
                    if (value.HasLengthLessThanSix())
                    {
                        if (value.HasOnlyCapitalLetters())
                        {
                            _name = value;
                        }
                        else
                        {
                            throw new ArgumentException("Airline name should contain only capital letters.");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Airline name should be less than 6 letters long.");
                    }
                }
                else
                {
                    throw new ArgumentNullException("Airline name can not be null.");
                }
            }
        }
    }
}
