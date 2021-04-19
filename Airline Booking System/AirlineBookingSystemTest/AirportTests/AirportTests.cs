using AirlineBookingSystem;
using System;
using Xunit;

namespace AirlineBookingSystemTest
{
    public class AirportTests
    {
        [Fact]
        public void Constructor_LongerThanThreeLettersName_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Airport name should be 3 letters long.");

            // Act
            ArgumentException actual = null;
            try
            {
                Airport airport = new Airport("aaasssddd");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void Constructor_ShorterThanThreeLettersName_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Airport name should be 3 letters long.");

            // Act
            ArgumentException actual = null;
            try
            {
                Airport airport = new Airport("aa");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void Constructor_NullStringName_ShouldThrowExceptionTest()
        {
            // Arrange
            string nullString = null;
            ArgumentNullException expected = new ArgumentNullException("Airport name can not be null.");

            // Act
            ArgumentNullException actual = null;
            try
            {
                Airport airport = new Airport(nullString);
            }
            catch (ArgumentNullException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void Constructor_EmptyStringName_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Airport name should be 3 letters long.");

            // Act
            ArgumentException actual = null;
            try
            {
                Airport airport = new Airport("");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void Constructor_ThreeLetterStringWithNumbersAndLettersName_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Airport name should contain only capital letters.");

            // Act
            ArgumentException actual = null;
            try
            {
                Airport airport = new Airport("A21");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void Constructor_ThreeLetterStringWithOnlyNumbersName_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Airport name should contain only capital letters.");

            // Act
            ArgumentException actual = null;
            try
            {
                Airport airport = new Airport("221");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void Constructor_ThreeLetterStringWithSmallLettersName_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Airport name should contain only capital letters.");

            // Act
            ArgumentException actual = null;
            try
            {
                Airport airport = new Airport("aof");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void Constructor_ThreeLetterStringWithOnlyCapitalLettersName_ShouldPassTest()
        {
            // Arrange
            Airport airport = new Airport("ASD");
            string expected = "ASD";

            // Act
            string actual = airport.Name;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CopyConstructor_InstanceOfAirportClass_ShouldPassTest()
        {
            // Arrange
            Airport expected = new Airport("ASD");

            // Act
            Airport actual = new Airport(expected);

            // Assert
            Assert.NotSame(expected, actual);
            Assert.Equal(expected.Name, actual.Name);
        }

        [Fact]
        public void NamePropertySetter_LongerThanThreeLettersName_ShouldThrowExceptionTest()
        {
            // Arrange
            Airport airport = new Airport("OFK");
            ArgumentException expected = new ArgumentException("Airport name should be 3 letters long.");

            // Act
            ArgumentException actual = null;
            try
            {
                airport.Name = "aaasssddd";
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void NamePropertySetter_ShorterThanThreeLettersName_ShouldThrowExceptionTest()
        {
            // Arrange
            Airport airport = new Airport("ASD");
            ArgumentException expected = new ArgumentException("Airport name should be 3 letters long.");

            // Act
            ArgumentException actual = null;
            try
            {
                airport.Name = "aa";
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void NamePropertySetter_NullStringName_ShouldThrowExceptionTest()
        {
            // Arrange
            string nullString = null;
            Airport airport = new Airport("ASD");
            ArgumentNullException expected = new ArgumentNullException("Airport name can not be null.");

            // Act
            ArgumentNullException actual = null;
            try
            {
                airport.Name = nullString;
            }
            catch (ArgumentNullException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void NamePropertySetter_EmptyStringName_ShouldThrowExceptionTest()
        {
            // Arrange
            Airport airport = new Airport("OFK");
            ArgumentException expected = new ArgumentException("Airport name should be 3 letters long.");

            // Act
            ArgumentException actual = null;
            try
            {
                airport.Name = "";
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void NamePropertySetter_ThreeLetterStringWithNumbersAndLettersName_ShouldThrowExceptionTest()
        {
            // Arrange
            Airport airport = new Airport("OFK");
            ArgumentException expected = new ArgumentException("Airport name should contain only capital letters.");

            // Act
            ArgumentException actual = null;
            try
            {
                airport.Name = "A21";
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void NamePropertySetter_ThreeLetterStringWithOnlyNumbersName_ShouldThrowExceptionTest()
        {
            // Arrange
            Airport airport = new Airport("ASD");
            ArgumentException expected = new ArgumentException("Airport name should contain only capital letters.");

            // Act
            ArgumentException actual = null;
            try
            {
                airport.Name = "123";
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void NamePropertySetter_ThreeLetterStringWithSmallLettersName_ShouldThrowExceptionTest()
        {
            // Arrange
            Airport airport = new Airport("ASD");
            ArgumentException expected = new ArgumentException("Airport name should contain only capital letters.");

            // Act
            ArgumentException actual = null;
            try
            {
                airport.Name = "aso";
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void NamePropertySetter_ThreeLetterStringWithOnlyCapitalLettersName_ShouldPassTest()
        {
            // Arrange
            Airport airport = new Airport("ASD");
            string expected = "SDS";

            // Act
            airport.Name = "SDS";
            string actual = airport.Name;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
