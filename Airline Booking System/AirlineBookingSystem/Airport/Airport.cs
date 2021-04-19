using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Airport
{
    public class Airport
    {
        #region Fields
        private string _name;
        #endregion

        #region Constructors
        /// <summary>
        /// General purpouse constructor
        /// </summary>
        /// <param name="name"></param>
        public Airport(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="other"></param>
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
                    if (HasLenghtThree(value))
                    {
                        if (HasOnlyCapitalLetters(value))
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

        #region Help Methods
        private static bool HasOnlyCapitalLetters(string value)
        {
            return Regex.IsMatch(value, @"^[A-Z]+$");
        }

        private static bool HasLenghtThree(string value)
        {
            return value.Length == 3;
        }
        #endregion
    }
}
