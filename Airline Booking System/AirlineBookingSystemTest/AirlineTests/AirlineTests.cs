using AirlineBookingSystem;
using AirlineBookingSystem.Airlines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AirlineBookingSystemTest.AirlineTests
{
    public class AirlineTests
    {
        [Fact]
        public void Constructor_NullName_ShouldThrowExceptionTest()
        {
            // Arrange
            string nullString = null;
            ArgumentException expected = new ArgumentException(AirlineExceptionMessages.invalidName);

            // Act
            ArgumentException actual = null;
            try
            {
                Airline airline = new Airline(nullString);
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void Constructor_EmptyName_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException(AirlineExceptionMessages.invalidName);

            // Act
            ArgumentException actual = null;
            try
            {
                Airline airline = new Airline("");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void Constructor_LessThanSixLetterNameWithOtherSymbols_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException(AirlineExceptionMessages.invalidName);

            // Act
            ArgumentException actual = null;
            try
            {
                Airline airline = new Airline("AAA-@");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void Constructor_LessThanSixLetterNameWithNumbersAndSmallLetters_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException(AirlineExceptionMessages.invalidName);

            // Act
            ArgumentException actual = null;
            try
            {
                Airline airline = new Airline("123ad");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void Constructor_LessThanSixLetterNameWithNumbersAndCapitalLetters_ShouldPassTest()
        {
            // Arrange
            Airline airline = new Airline("12ASD");
            string expected = "12ASD";

            // Act
            string actual = airline.Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_MoreThanSixLetterName_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException(AirlineExceptionMessages.invalidName);

            // Act
            ArgumentException actual = null;
            try
            {
                Airline airline = new Airline("123asdss");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void CopyConstructor_InstanceOfAirlineClass_ShouldPass()
        {
            // Arrange
            Airline expected = new Airline("TEST");
            expected.AddFlight(new Flight("TEST", "AAA", "BBB", "1234", new DateTime(1987, 3, 3)));
            expected.AddFlight(new Flight("TEST", "AAA", "BBB", "1235", new DateTime(1987, 3, 3)));

            // Act
            Airline actual = new Airline(expected);

            // Assert
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Flights[0], actual.Flights[0]);
            Assert.Equal(expected.Flights[1], actual.Flights[1]);
        }

        [Fact]
        public void NameProperty_NullName_ShouldPassTest()
        {
            // Arrange
            string nullString = null;
            Airline airline = new Airline("AS234");
            string expected = "AS234";

            // Act
            airline.ChangeName(nullString);
            string actual = airline.Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NameProperty_EmptyName_ShouldPassTest()
        {
            // Arrange
            Airline airline = new Airline("AS234");
            string expected = "AS234";

            // Act
            airline.ChangeName("");
            string actual = airline.Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NameProperty_LessThanSixLetterNameWithOtherSymbols_ShouldPassTest()
        {
            // Arrange
            Airline airline = new Airline("AS234");
            string expected = "AS234";

            // Act
            airline.ChangeName("AA_@");
            string actual = airline.Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NameProperty_LessThanSixLetterNameWithNumbersAndSmallLetters_ShouldPassTest()
        {
            // Arrange
            Airline airline = new Airline("AS234");
            string expected = "AS234";

            // Act
            airline.ChangeName("123sd");
            string actual = airline.Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NameProperty_MoreThanSixLetterName_ShouldThrowExceptionTest()
        {
            // Arrange
            Airline airline = new Airline("AS234");
            string expected = "AS234";

            // Act
            airline.ChangeName("123asdss");
            string actual = airline.Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddFlight_AddingThreeFlights_ShouldPassTest()
        {
            // Arrange
            Flight flight1 = new Flight("DELTA", "QWE", "RTY", "143222", new DateTime(1992, 3, 3));
            Flight flight2 = new Flight("DELTA", "QWE", "RTY", "123221", new DateTime(1992, 3, 3));
            Flight flight3 = new Flight("DELTA", "QWE", "RTY", "143220", new DateTime(1992, 3, 3));

            Airline airline = new Airline("DELTA");

            // Act
            airline.AddFlight(flight1);
            airline.AddFlight(flight2);
            airline.AddFlight(flight3);

            Assert.Equal("DELTA00001", airline.Flights[0].Information.Id);
            Assert.Equal("DELTA00002", airline.Flights[1].Information.Id);
            Assert.Equal("DELTA00003", airline.Flights[2].Information.Id);
        }

        [Fact]
        public void AddFlight_AddingTwoDifferentFlightButWithSameFlightNumber_ShouldPassTest()
        {
            // Arrange
            AirlineOperation expected = AirlineOperation.AddingFlightFailure;
            Airline airline = new Airline("QWE");
            airline.AddFlight(new Flight("QWE", "WER", "ERT", "13243", new DateTime(3002, 3, 2)));

            // Act
            AirlineOperation actual = airline.AddFlight(new Flight("QWE", "RRR", "TTT", "13243", new DateTime(3000, 3, 2)));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddFlightSectionToFlight_AddingFlightSectionToExistingFlight_ShouldPassTest()
        {
            // Arrange
            bool expected = true;
            Airline airline = new Airline("SSS");
            airline.AddFlight(new Flight("SSS", "DDD", "AAA", "1234", new DateTime(1999, 2, 3)));

            // Act
            bool actual = airline.AddFlightSectionToFlight(new FlightSection(SeatClass.ECONOMY, 5, 5), "1234");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Equals_ComparingTwoAirlines_ShouldPassTest()
        {
            // Arragne
            Airline airline1 = new Airline("ASD");
            airline1.AddFlight(new Flight("ASSD1", "ASD", "FDS", "123456", new DateTime(1992, 3, 2)));
            airline1.AddFlight(new Flight("ASSD2", "ASD", "FDS", "123454", new DateTime(1992, 3, 2)));
            airline1.AddFlight(new Flight("ASSD3", "ASD", "FDS", "123453", new DateTime(1992, 3, 2)));

            Airline airline2 = new Airline("ASD");
            airline2.AddFlight(new Flight("ASSD1", "ASD", "FDS", "123456", new DateTime(1992, 3, 2)));
            airline2.AddFlight(new Flight("ASSD2", "ASD", "FDS", "123454", new DateTime(1992, 3, 2)));
            airline2.AddFlight(new Flight("ASSD3", "ASD", "FDS", "123453", new DateTime(1992, 3, 2)));

            bool expected = true;

            // Act
            bool actual = airline1.Equals(airline2);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
