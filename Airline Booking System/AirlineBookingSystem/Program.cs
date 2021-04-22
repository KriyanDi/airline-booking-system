using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Could not book seat on Row: 5 Col: A!");
            SystemManager system = new SystemManager();

            system.CreateAirport("AAA");
            system.CreateAirport("BBB");

            system.CreateAirline("ASD");

            system.CreateFlight("ASD", "AAA", "BBB", 1992, 4, 5, "1543");

            system.CreateSection("ASD", "1543", 5, 4, SeatClass.BUSINESS);

            system.BookSeat("ASD", "1543", SeatClass.BUSINESS, 5, 'A');
            system.BookSeat("ASD", "1543", SeatClass.BUSINESS, 5, 'A');
        }
    }
}
