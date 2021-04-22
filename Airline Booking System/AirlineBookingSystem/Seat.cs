using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem
{
    public class Seat
    {
        #region Fields
        private (int row, char col) _id;
        private bool _isBooked;
        #endregion

        #region Constructors
        public Seat((int row, char col) id, bool isBooked)
        {
            InitializeDataMembers(id, isBooked);
        }
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
        private void InitializeDataMembers((int row, char col) id, bool isBooked)
        {
            Id = id;
            IsBooked = isBooked;
        }
        private static bool IsLetterBetweenAAndJ(char value)
        {
            return ('A' <= value) && (value <= 'J');
        }
        #endregion

        #region Equation Methods
        public override bool Equals(object obj)
        {
            return obj is Seat seat &&
                   Id == seat.Id &&
                   IsBooked == seat.IsBooked;
        }
        public override int GetHashCode()
        {
            int hashCode = -1858130102;
            hashCode = hashCode * -1521134295 + _id.GetHashCode();
            hashCode = hashCode * -1521134295 + _isBooked.GetHashCode();
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + IsBooked.GetHashCode();
            return hashCode;
        }
        public static bool operator ==(Seat lhs, Seat rhs) => lhs.Equals(rhs);
        public static bool operator !=(Seat lhs, Seat rhs) => !(lhs == rhs); 
        #endregion

    }
}
