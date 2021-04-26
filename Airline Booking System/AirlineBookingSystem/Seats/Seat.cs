using AirlineBookingSystem.Seats;
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
        }
        public bool IsBooked
        {
            get => _isBooked;
            set => _isBooked = value;
        }
        #endregion

        #region Methods
        public SeatOperation ChangeId((int rows, char cols) id)
        {
            SeatOperation result = ValidationRules.SeatsRowsCols(id);

            switch (result)
            {
                case SeatOperation.Succeded:
                    _id = id;
                    break;
                case SeatOperation.InvalidSeatRowsFailure:
                    Console.WriteLine($"Error: Seat row should be number between {ValidationRules.MIN_ROWS} and {ValidationRules.MAX_ROWS}.");
                    break;
                case SeatOperation.InvalidSeatColsFailure:
                    Console.WriteLine($"Error: Seat column should be char between {ValidationRules.MIN_COLS_LETTER} and {ValidationRules.MAX_COLS_LETTER}.");
                    break;
            }

            return result;
        }
        #endregion

        #region Help Methods
        private void InitializeDataMembers((int rows, char cols) id, bool isBooked)
        {
            InitializeSeat(id);
            InitializeIsBooked(isBooked);
        }
        private void InitializeSeat((int rows, char cols) id)
        {
            SeatOperation result = ChangeId(id);

            switch (result)
            {
                case SeatOperation.InvalidSeatRowsFailure:
                    Console.WriteLine("Seat was not created");
                    throw new ArgumentException(SeatExceptionMessages.invalidSeatsRows);
                case SeatOperation.InvalidSeatColsFailure:
                    Console.WriteLine("Seat was not created");
                    throw new ArgumentException(SeatExceptionMessages.invalidSeatsCols);
            }
        }
        private void InitializeIsBooked(bool isBooked)
        {
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
