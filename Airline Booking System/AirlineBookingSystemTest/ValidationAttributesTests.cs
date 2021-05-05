using AirlineBookingSystem;
using AirlineBookingSystem.Additional;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AirlineBookingSystemTest
{
    public class ValidationAttributesTests
    {
        #region Airport Name Validation
        [Fact]
        public void AirportName_NullName_ShouldPassTest()
        {
            // Arrange
            string strNull = null;

            // Assert
            Assert.False(IsAirportNameValid(strNull));
        }

        [Fact]
        public void AirportName_HasLongerThanThreeLettersName_ShouldPassTest()
        {
            Assert.False(IsAirportNameValid("AAAA"));
        }

        [Fact]
        public void AirportName_HasShorterThanThreeLettersName_ShouldPassTest()
        {
            Assert.False(IsAirportNameValid("AA"));
        }

        [Fact]
        public void AirportName_ContainsNotOnlyCapitalLetters_ShouldPassTest()
        {
            Assert.False(IsAirportNameValid("AA4"));
        }

        [Fact]
        public void AirportName_ValidName_ShouldPassTest()
        {
            Assert.True(IsAirportNameValid("ASD"));
        }

        private static bool IsAirportNameValid([AirportName] string airportName)
        {
            Airport airport = new Airport(airportName);
            if (Validator.TryValidateObject(airport, new ValidationContext(airport), new List<ValidationResult>(), true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Airline Name Validation
        [Fact]
        public void AirlineName_NullName_ShouldPassTest()
        {
            string nullStr = null;
            Assert.False(IsAirlineNameValid(nullStr));
        }

        [Fact]
        public void AirlineName_LongerThanSixLetters_ShouldPassTest()
        {
            Assert.False(IsAirlineNameValid("A43AA2"));
        }

        [Fact]
        public void AirlineName_ShorterThanOneLetter_ShouldPassTest()
        {
            Assert.False(IsAirlineNameValid(""));
        }

        [Fact]
        public void AirlineName_HasOtherSymbols_ShouldPassTest()
        {
            Assert.False(IsAirlineNameValid("A23#@"));
        }

        [Fact]
        public void AirlineName_ValidName_ShouldPassTest()
        {
            Assert.True(IsAirlineNameValid("SOS3"));
        }

        private static bool IsAirlineNameValid(string airlineName)
        {
            Airline airline = new Airline(airlineName);
            if (Validator.TryValidateObject(airline, new ValidationContext(airline), new List<ValidationResult>(), true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region SeatSection Validation
        [Fact]
        public void SeatSection_BiggerThanOneHunder_ShouldPassTest()
        {
            Assert.False(IsSeatSectionValid(101, 2));
        }

        [Fact]
        public void SeatSection_LessThanOne_ShouldPassTest()
        {
            Assert.False(IsSeatSectionValid(0, 2));
        }

        [Fact]
        public void SeatSection_Valid_ShouldPassTest()
        {
            Assert.True(IsSeatSectionValid(34, 2));
        }

        [Fact]
        public void SeatSection_InvalidRow_ShouldPassTest()
        {
            Assert.False(IsSeatSectionValid(200, 4));
        }

        [Fact]
        public void SeatSection_InvalidCol_ShouldPassTest()
        {
            Assert.False(IsSeatSectionValid(10, 15));
        }

        private static bool IsSeatSectionValid(int rows, int cols)
        {
            FlightSection section = new FlightSection(SeatClass.BUSINESS, rows, cols);

            if (Validator.TryValidateObject(section, new ValidationContext(section), new List<ValidationResult>(), true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Flight Number Validation
        [Fact]
        public void FlightNumber_ContainingNotOnlyNumbers_ShouldPassTest()
        {
            Assert.False(IsFlightNumberValid("12SDFD444"));
        }

        [Fact]
        public void FlightNumber_Valid_ShouldPassTest()
        {
            Assert.True(IsFlightNumberValid("122334"));
        }

        private static bool IsFlightNumberValid(string number)
        {
            Flight flight = new Flight("AAA", "ASD", "DSA", number, new DateTime(1998, 2, 2));
            if (Validator.TryValidateObject(flight, new ValidationContext(flight), new List<ValidationResult>(), true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
