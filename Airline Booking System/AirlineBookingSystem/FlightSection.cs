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
        public FlightSection(SeatClass seatClass, int row, int col)
        {
            SeatClass = seatClass;
            Seats = new List<Seat>();
            InitializeSeats(row, col);
        }

        public FlightSection(FlightSection other)
        {
            SeatClass = other.SeatClass;
            InitializeSeats(other.Seats);
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
        #endregion

        #region Methods
        public bool HasAvailableSeats()
        {
            bool result = false;

            foreach (Seat seat in _seats)
            {
                if(!seat.IsBooked)
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
        #endregion

        #region Help Methods
        private void InitializeSeats(int row, int col)
        {
            if (AreValidRowCol(row, col))
            {
                for (int i = 0; i < row; i++)
                {
                    (int row, char col) seatId = (i + 1, Convert.ToChar(65 + (i % col)));
                    _seats.Add(new Seat(seatId, false));
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
        private static bool AreValidRowCol(int row, int col)
        {
            bool isRowValid = (1 <= row && row <= 100);

            bool isColValid = (1 <= col && col <= 10);

            return  isRowValid && isColValid;
        }
        #endregion
    }
}
