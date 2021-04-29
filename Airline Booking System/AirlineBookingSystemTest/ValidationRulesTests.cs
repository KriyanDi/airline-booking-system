using AirlineBookingSystem;
using AirlineBookingSystem.Additional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AirlineBookingSystemTest
{
    public class ValidationRulesTests
    {
        #region Airport Name Validation
        [Fact]
        public void AirportName_NullName_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected = ValidationOperation.InvalidNameNullFailure;
            string nullStr = null;

            // Act
            ValidationOperation actual = ValidationRules.AirportName(nullStr);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AirportName_HasLongerThanThreeLettersName_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected = ValidationOperation.InvalidNameLenghtFailure;

            // Act
            ValidationOperation actual = ValidationRules.AirportName("AAAA");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AirportName_HasShorterThanThreeLettersName_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected = ValidationOperation.InvalidNameLenghtFailure;

            // Act
            ValidationOperation actual = ValidationRules.AirportName("AA");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AirportName_ContainsNotOnlyCapitalLetters_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected = ValidationOperation.InvalidNameFormatFailure;

            // Act
            ValidationOperation actual = ValidationRules.AirportName("AA4");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AirportName_ValidName_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected = ValidationOperation.Succeded;

            // Act
            ValidationOperation actual = ValidationRules.AirportName("ASD");

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region Airline Name Validation
        [Fact]
        public void AirlineName_NullName_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected = ValidationOperation.InvalidNameNullFailure;
            string nullStr = null;

            // Act
            ValidationOperation actual = ValidationRules.AirlineName(nullStr);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AirlineName_LongerThanSixLetters_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected = ValidationOperation.InvalidNameLenghtFailure;

            // Act
            ValidationOperation actual = ValidationRules.AirlineName("A43AA2");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AirlineName_ShorterThanOneLetter_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected = ValidationOperation.InvalidNameLenghtFailure;

            // Act
            ValidationOperation actual = ValidationRules.AirlineName("");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AirlineName_HasOtherSymbols_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected = ValidationOperation.InvalidNameFormatFailure;

            // Act
            ValidationOperation actual = ValidationRules.AirlineName("A23#@");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AirlineName_ValidName_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected = ValidationOperation.Succeded;

            // Act
            ValidationOperation actual = ValidationRules.AirlineName("SOS3");

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region Seats Validation
        [Fact]
        public void SeatRowsNumber_BiggerThanOneHunder_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected = ValidationOperation.InvalidSeatRowsFailure;

            // Act
            ValidationOperation actual = ValidationRules.SeatsRowsNumber(101);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SeatRowsNumber_LessThanOne_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected = ValidationOperation.InvalidSeatRowsFailure;

            // Act
            ValidationOperation actual = ValidationRules.SeatsRowsNumber(0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SeatRowsNumber_Valid_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected = ValidationOperation.Succeded;

            // Act
            ValidationOperation actual = ValidationRules.SeatsRowsNumber(23);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SeatsColsLetter_LetterBiggerThanJ_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected = ValidationOperation.InvalidSeatColsFailure;

            // Act
            ValidationOperation actual = ValidationRules.SeatsColsLetter('K');

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SeatsColsLetter_LessThanA_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected = ValidationOperation.InvalidSeatColsFailure;

            // Act
            ValidationOperation actual = ValidationRules.SeatsColsLetter('g');

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SeatsColsLetter_Valid_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected = ValidationOperation.Succeded;

            // Act
            ValidationOperation actual = ValidationRules.SeatsColsLetter('B');

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SeatsColsNumber_LetterBiggerThanJ_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected = ValidationOperation.InvalidSeatColsFailure;

            // Act
            ValidationOperation actual = ValidationRules.SeatsColsNumber(11);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SeatsColsNumber_LessThanA_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected = ValidationOperation.InvalidSeatColsFailure;

            // Act
            ValidationOperation actual = ValidationRules.SeatsColsNumber(0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SeatsColsNumber_Valid_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected = ValidationOperation.Succeded;

            // Act
            ValidationOperation actual = ValidationRules.SeatsColsNumber(5);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SeatsRowsCols_InvalidRow_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected1 = ValidationOperation.InvalidSeatRowsFailure;
            ValidationOperation expected2 = ValidationOperation.InvalidSeatRowsFailure;

            // Act
            ValidationOperation actual1 = ValidationRules.SeatsRowsCols((101, 'J'));
            ValidationOperation actual2 = ValidationRules.SeatsRowsCols(101, 10);

            // Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
        }

        [Fact]
        public void SeatsRowsCols_InvalidCol_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected1 = ValidationOperation.InvalidSeatColsFailure;
            ValidationOperation expected2 = ValidationOperation.InvalidSeatColsFailure;

            // Act
            ValidationOperation actual1 = ValidationRules.SeatsRowsCols((10, 'K'));
            ValidationOperation actual2 = ValidationRules.SeatsRowsCols(10, 52);

            // Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
        }

        [Fact]
        public void SeatsRowsCols_Valid_ShouldPassTest()
        {
            // Arrange
            ValidationOperation expected1 = ValidationOperation.Succeded;
            ValidationOperation expected2 = ValidationOperation.Succeded;

            // Act
            ValidationOperation actual1 = ValidationRules.SeatsRowsCols((10, 'J'));
            ValidationOperation actual2 = ValidationRules.SeatsRowsCols(10, 4);

            // Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
        }
        #endregion

        #region Flight Number Validation
        [Fact]
        public void FlightNumber_ContainingNotOnlyNumbers_ShouldPassTest()
        {
            // Arrange 
            ValidationOperation expected = ValidationOperation.InvalidFlightNumberContainsNotOnlyNumbersFailure;

            // Act
            ValidationOperation actual = ValidationRules.FlightNumber("122334KFD");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FlightNumber_Valid_ShouldPassTest()
        {
            // Arrange 
            ValidationOperation expected = ValidationOperation.Succeded;

            // Act
            ValidationOperation actual = ValidationRules.FlightNumber("122334");

            // Assert
            Assert.Equal(expected, actual);
        } 
        #endregion
    }
}
