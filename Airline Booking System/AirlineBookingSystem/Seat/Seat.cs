using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Seat
{
    public class Seat
    {
        #region Fields
        private (int row, char col) _id;
        private bool _isBooked;
        #endregion

        #region Constructors
        /// <summary>
        /// General purpouse
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isBooked"></param>
        public Seat((int row, char col) id, bool isBooked)
        {
            Id = id;
            IsBooked = isBooked;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="other"></param>
        public Seat(Seat other) : this(other.Id, other.IsBooked)
        {
        }
        #endregion

        #region Properties
        public (int row, char col) Id
        {
            get => _id;
            set
            {
                if (IsLetterBetweenAAndJ(value.col))
                {
                    _id = value;
                }
                else
                {
                    throw new ArgumentException("Seat column should be char between A and J.");
                }
            }
        }

        public bool IsBooked
        {
            get => _isBooked;
            set => _isBooked = value;
        }
        #endregion

        #region Help Methods
        private static bool IsLetterBetweenAAndJ(char value)
        {
            return ('A' <= value) && (value <= 'J');
        }
        #endregion
    }
}
