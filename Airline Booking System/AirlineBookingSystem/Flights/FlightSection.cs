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
        public Seat[,] Seats { get; set; }
        public int CountAvailableSeats
        {
            get
            {
                int sum = 0;

                for (int i = 0; i < Seats.GetLength(0); i++)
                {
                    for (int j = 0; j < Seats.GetLength(1); j++)
                    {
                        if (!Seats[i, j].IsBooked)
                        {
                            sum++;
                        }
                    }
                }

                return sum;
            }
        }
        public int CountOccupiedSeats => Seats.Length - CountAvailableSeats;
        #endregion

        #region Methods
        public bool HasAvailableSeats()
        {
            for (int i = 0; i < Seats.GetLength(0); i++)
            {
                for (int j = 0; j < Seats.GetLength(1); j++)
                {
                    if (!Seats[i, j].IsBooked)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public bool BookSeat(int rows, char cols)
        {
            try
            {
                if (!Seats[rows - 1, cols - 'A'].IsBooked)
                {
                    Seats[rows - 1, cols - 'A'].IsBooked = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion

        #region Help Methods
        private void InitializeSeats(int rows, int cols)
        {
            Seats = new Seat[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Seats[i, j] = new Seat((i + 1, Convert.ToChar(65 + (j % cols))), false);
                }
            }
        }
        #endregion

        #region Other Overridden Methods
        public override string ToString() => $"{SeatClass} ALL: {Seats.Length} AVLBL: {CountAvailableSeats} OCCPD: {CountOccupiedSeats}";
        #endregion
    }
}
