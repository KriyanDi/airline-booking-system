using AirlineBookingSystem.Additional;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirlineBookingSystem
{
    public class FlightSection
    {
        #region Constructors
        public FlightSection(SeatClass seatClass, int rows, int cols)
        {
            SeatClass = seatClass;
            InitializeSeats(rows, cols);
        }
        #endregion

        #region Properties
        public SeatClass SeatClass { get; set; }
        [SeatSection]
        public List<Seat> Seats { get; set; }
        public int CountAvailableSeats => Seats.Count(seat => !seat.IsBooked);
        public int CountOccupiedSeats => Seats.Count - CountAvailableSeats;
        #endregion

        #region Methods
        public bool HasAvailableSeats() => Seats.Any(seat => !seat.IsBooked);
        public bool BookSeat(int rows, char cols)
        {
            for (int i = 0; i < Seats.Count; i++)
            {
                if (Seats[i].Id == (rows, cols))
                {
                    if (!Seats[i].IsBooked)
                    {
                        Seats[i].IsBooked = true;
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
        private void InitializeSeats(int rows, int cols)
        {
            Seats = new List<Seat>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Seats.Add(new Seat((i + 1, Convert.ToChar(65 + (j % cols))), false));
                }
            }
        }
        #endregion

        #region Other Overridden Methods
        public override string ToString() => $"{SeatClass} ALL: {Seats.Count} AVLBL: {CountAvailableSeats} OCCPD: {CountOccupiedSeats}";
        #endregion
    }
}
