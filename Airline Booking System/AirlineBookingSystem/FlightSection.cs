using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem
{
    public class FlightSection
    {
        #region Fields
        private SeatClass _seatClass;
        private List<Seat> _seats;
        #endregion

        #region Constructors
        public FlightSection(SeatClass seatClass, int rows, int cols)
        {
            InitializeDataMembers(seatClass, rows, cols);
        }
        public FlightSection(FlightSection other)
        {
            InitializeDataMembersFrom(other);
        }
        #endregion

        #region Properties
        public SeatClass SeatClass
        {
            get => _seatClass;
            set => _seatClass = value;
        }
        public List<Seat> Seats
        {
            get
            {
                List<Seat> seatsCopy = new List<Seat>();
                for (int i = 0; i < _seats.Count; i++)
                {
                    seatsCopy.Add(new Seat(_seats[i]));
                }

                return seatsCopy;
            }
            set
            {
                if (value != null)
                {
                    List<Seat> seatsCopy = new List<Seat>();
                    for (int i = 0; i < value.Count; i++)
                    {
                        seatsCopy.Add(new Seat(_seats[i]));
                    }

                    _seats = seatsCopy;
                }
                else
                {
                    throw new ArgumentNullException("Value can not be null.");
                }
            }
        }
        public List<Seat> SeatReference => _seats;
        public int CountAvailableSeats
        {
            get
            {
                int available = 0;
                for (int i = 0; i < _seats.Count; i++)
                {
                    if(!_seats[i].IsBooked)
                    {
                        available += 1;
                    }
                }

                return available;
            }
        }
        public int CountOccupiedSeats => _seats.Count - CountAvailableSeats;
        #endregion

        #region Methods
        public bool HasAvailableSeats()
        {
            bool result = false;

            foreach (Seat seat in _seats)
            {
                if (!seat.IsBooked)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        public bool BookSeat()
        {
            for (int i = 0; i < _seats.Count; i++)
            {
                if (!_seats[i].IsBooked)
                {
                    _seats[i].IsBooked = true;
                    return true;
                }
            }

            return false;
        }
        public bool BookSeat(int rows, char cols)
        {
            for (int i = 0; i < _seats.Count; i++)
            {
                if (_seats[i].Id == (rows, cols))
                {
                    if (!_seats[i].IsBooked)
                    {
                        _seats[i].IsBooked = true;
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return false;
        }
        #endregion

        #region Help Methods
        private void InitializeDataMembers(SeatClass seatClass, int rows, int cols)
        {
            SeatClass = seatClass;
            Seats = new List<Seat>();
            InitializeSeats(rows, cols);
        }
        private void InitializeDataMembersFrom(FlightSection other)
        {
            SeatClass = other.SeatClass;
            InitializeSeats(other.Seats);
        }
        private void InitializeSeats(int rows, int cols)
        {
            if (AreValidRowCol(rows, cols))
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        (int rows, char cols) seatId = (i + 1, Convert.ToChar(65 + (j % cols)));
                        _seats.Add(new Seat(seatId, false));
                    }
                }
            }
            else
            {
                throw new ArgumentException("Row or Col are invalid.");
            }
        }
        private void InitializeSeats(List<Seat> seats)
        {
            _seats = new List<Seat>();
            for (int i = 0; i < seats.Count; i++)
            {
                _seats.Add(new Seat(seats[i]));
            }
        }
        private static bool AreValidRowCol(int rows, int cols)
        {
            bool isRowValid = (1 <= rows && rows <= 100);

            bool isColValid = (1 <= cols && cols <= 10);

            return isRowValid && isColValid;
        }
        #endregion

        #region Equation Methods
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else if (obj is FlightSection flightSection)
            {
                for (int i = 0; i < Seats.Count; i++)
                {
                    if (!(Seats[i].Equals(flightSection.Seats[i])))
                    {
                        return false;
                    }
                }

                return this.SeatClass == flightSection.SeatClass &&
                       this.Seats.Count == flightSection.Seats.Count &&
                       Seats.SequenceEqual(flightSection.Seats);
            }
            else
            {
                return false;
            }

        }
        public override int GetHashCode()
        {
            int hashCode = -327950722;
            hashCode = hashCode * -1521134295 + _seatClass.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Seat>>.Default.GetHashCode(_seats);
            hashCode = hashCode * -1521134295 + SeatClass.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Seat>>.Default.GetHashCode(Seats);
            return hashCode;
        }
        public static bool operator ==(FlightSection lhs, FlightSection rhs) => lhs.Equals(rhs);
        public static bool operator !=(FlightSection lhs, FlightSection rhs) => !(lhs == rhs);
        #endregion

        #region Other Overridden Methods
        public override string ToString() => $"{_seatClass} ALL: {_seats.Count} AVLBL: {CountAvailableSeats} OCCPD: {CountOccupiedSeats}"; 
        #endregion
    }
}
