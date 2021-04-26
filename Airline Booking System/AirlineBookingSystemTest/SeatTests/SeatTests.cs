using AirlineBookingSystem;
using AirlineBookingSystem.Seats;
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
            (int rows, char cols) expectedId = (12, 'B');
            bool expectedIsBooked = false;

            // Act
            Seat actual = new Seat((12, 'B'), false);

            // Assert
            Assert.Equal(expectedId, actual.Id);
            Assert.Equal(expectedIsBooked, actual.IsBooked);
        }

        [Fact]
        public void Constructor_InvalidSeatColumn_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException(SeatExceptionMessages.invalidSeatsCols);

            // Act
            ArgumentException actual = null;
            try
            {
                Seat seat = new Seat((13, 'Y'), true);
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void Constructor_InvalidSeatRow_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException(SeatExceptionMessages.invalidSeatsRows);

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
