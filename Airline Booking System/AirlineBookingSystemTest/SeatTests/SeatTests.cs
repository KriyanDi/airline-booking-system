using AirlineBookingSystem.Seat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AirlineBookingSystemTest.SeatTests
{
    public class SeatTests
    {
        [Fact]
        public void Constructor_ValidSeat_ShouldPassTest()
        {
            // Arrange
            (int row, char col) expectedId = (123, 'B');
            bool expectedIsBooked = false;

            // Act
            Seat actual = new Seat((123, 'B'), false);

            // Assert
            Assert.Equal(expectedId, actual.Id);
            Assert.Equal(expectedIsBooked, actual.IsBooked);
        }

        [Fact]
        public void Constructor_InvalidSeatColumn_ShouldThrowException()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Seat column should be char between A and J.");

            // Act
            ArgumentException actual = null;
            try
            {
                Seat seat = new Seat((123, 'Y'), true);
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }
        
    }
}
