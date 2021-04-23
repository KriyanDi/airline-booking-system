using AirlineBookingSystem;
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
            ArgumentNullException expected = new ArgumentNullException("Airline name can not be null.");

            // Act
            ArgumentNullException actual = null;
            try
            {
                Airline airline = new Airline(nullString);
            }
            catch (ArgumentNullException ex)
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
            ArgumentException expected = new ArgumentException("Airline name should be between 1 and 5 symbols long.");

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
            ArgumentException expected = new ArgumentException("Airline name should contain only capital letters and numbers.");

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
            ArgumentException expected = new ArgumentException("Airline name should contain only capital letters and numbers.");

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
            ArgumentException expected = new ArgumentException("Airline name should be between 1 and 5 symbols long.");

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
            expected.AddFlight(new Flight("TEST1", "AAA", "BBB", "1234", new DateTime(1987, 3, 3)));
            expected.AddFlight(new Flight("TEST2", "AAA", "BBB", "1235", new DateTime(1987, 3, 3)));

            // Act
            Airline actual = new Airline(expected);

            // Assert
            Assert.Equal(expected.Name, actual.Name);
        }

        [Fact]
        public void NameProperty_NullName_ShouldThrowExceptionTest()
        {
            // Arrange
            string nullString = null;
            Airline airline = new Airline("AS123");
            ArgumentNullException expected = new ArgumentNullException("Airline name can not be null.");

            // Act
            ArgumentNullException actual = null;
            try
            {
                airline.Name = nullString;
            }
            catch (ArgumentNullException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void NameProperty_EmptyName_ShouldThrowExceptionTest()
        {
            // Arrange
            Airline airline = new Airline("AS234");
            ArgumentException expected = new ArgumentException("Airline name should be between 1 and 5 symbols long.");

            // Act
            ArgumentException actual = null;
            try
            {
                airline.Name = "";
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void NameProperty_LessThanSixLetterNameWithOtherSymbols_ShouldThrowExceptionTest()
        {
            // Arrange
            Airline airline = new Airline("AS123");
            ArgumentException expected = new ArgumentException("Airline name should contain only capital letters and numbers.");

            // Act
            ArgumentException actual = null;
            try
            {
                airline.Name = "AA_@";
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void NameProperty_LessThanSixLetterNameWithNumbersAndSmallLetters_ShouldThrowExceptionTest()
        {
            // Arrange
            Airline airline = new Airline("123AS");
            ArgumentException expected = new ArgumentException("Airline name should contain only capital letters and numbers.");

            // Act
            ArgumentException actual = null;
            try
            {
                airline.Name = "123sd";
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void NameProperty_MoreThanSixLetterName_ShouldThrowExceptionTest()
        {
            // Arrange
            Airline airline = new Airline("SAAS");
            ArgumentException expected = new ArgumentException("Airline name should be between 1 and 5 symbols long.");

            // Act
            ArgumentException actual = null;
            try
            {
                airline.Name = "123asdss";
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void AddFlight_AddingThreeFlights_ShouldPassTest()
        {
            // Arrange
            Flight flight1 = new Flight("ASD", "QWE", "RTY", "143222", new DateTime(1992, 3, 3));
            Flight flight2 = new Flight("ASD", "QWE", "RTY", "123221", new DateTime(1992, 3, 3));
            Flight flight3 = new Flight("ASD", "QWE", "RTY", "143220", new DateTime(1992, 3, 3));

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
        public void AddFlight_AddingTwoDifferentFlightButWithSameFlightNumber_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("This Flight matches by flight number with other flight!");
            Airline airline = new Airline("TEST");
            airline.AddFlight(new Flight("QWE", "WER", "ERT", "13243", new DateTime(3002, 3, 2)));

            // Act
            ArgumentException actual = null;
            try
            {
                 airline.AddFlight(new Flight("QWE", "RRR", "TTT", "13243", new DateTime(3000, 3, 2)));
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
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
