using AirlineBookingSystem;
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
        public void Constructor_InvalidSeatColumn_ShouldThrowException()
        {
            // Arrange
            ArgumentException expected = new ArgumentException($"Seat column should be char between {ValidationRules.MIN_COLS_LETTER} and {ValidationRules.MAX_COLS_LETTER}.");

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
        public void Constructor_InvalidSeatRow_ShouldThrowException()
        {
            // Arrange
            ArgumentException expected = new ArgumentException($"Seat row should be number between {ValidationRules.MIN_ROWS} and {ValidationRules.MAX_ROWS}.");

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
