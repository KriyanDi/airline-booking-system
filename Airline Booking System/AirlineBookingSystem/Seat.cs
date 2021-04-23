﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem
{
    public class Seat
    {
        #region Fields
        private (int rows, char cols) _id;
        private bool _isBooked;
        #endregion

        #region Constructors
        public Seat((int rows, char cols) id, bool isBooked)
        {
            InitializeDataMembers(id, isBooked);
        }
        public Seat(Seat other) : this(other.Id, other.IsBooked)
        {
        }
        #endregion

        #region Properties
        public (int rows, char cols) Id
        {
            get => _id;
            set
            {
                if (ValidationRules.SeatsRowsCols(value.rows, value.cols))
                {
                    _id = value;
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
        private void InitializeDataMembers((int rows, char cols) id, bool isBooked)
        {
            Id = id;
            IsBooked = isBooked;
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

        #region Other Overridden Methods
        public override string ToString() => $"ROW: {_id.rows} COL: {_id.cols} BOOKED: {_isBooked}";
        #endregion
    }
}
