using System;

namespace AirlineBookingSystem
{
    public class FlightSection
    {
        public FlightSection(SeatClass seatClass, int rows, int cols)
        {
            SeatClass = seatClass;
            Capacity = rows * cols;
            InitializeSeats(rows, cols);
        }

        public SeatClass SeatClass { get; set; }
        public int Capacity { get; set; }
        public int Booked { get; set; }
        public Seat[,] Seats { get; set; }

        public bool HasAvailableSeats() => Booked < Capacity;
        public bool BookSeat(int rows, char cols)
        {
            try
            {
                if (!Seats[rows - 1, cols - 'A'].IsBooked)
                {
                    Seats[rows - 1, cols - 'A'].IsBooked = true;
                    Booked++;
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
        public override string ToString() => $"{SeatClass} Booked:{Booked} Capacity:{Capacity}";
    }
}