using AirlineBookingSystem.Airline;
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
    }
}
