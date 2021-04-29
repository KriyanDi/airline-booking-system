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
            ArgumentException expected = new ArgumentException(AirportExceptionMessages.invalidName);

            // Act
            ArgumentException actual = null;
            try
            {
                Airport airport = new Airport("AAAA");
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
            ArgumentException expected = new ArgumentException(AirportExceptionMessages.invalidName);

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
            ArgumentException expected = new ArgumentException(AirportExceptionMessages.invalidName);

            // Act
            ArgumentException actual = null;
            try
            {
                Airport airport = new Airport(nullString);
            }
            catch (ArgumentException ex)
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
            ArgumentException expected = new ArgumentException(AirportExceptionMessages.invalidName);

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
            ArgumentException expected = new ArgumentException(AirportExceptionMessages.invalidName);

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
            ArgumentException expected = new ArgumentException(AirportExceptionMessages.invalidName);

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
            ArgumentException expected = new ArgumentException(AirportExceptionMessages.invalidName);

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
        public void NamePropertySetter_LongerThanThreeLettersName_ShouldPassTest()
        {
            // Arrange
            Airport airport = new Airport("OFK");
            AirportOperation expected = AirportOperation.InvalidNameLenghtFailure;

            // Act
            AirportOperation actual = airport.ChangeName("aaasssddd");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NamePropertySetter_ShorterThanThreeLettersName_ShouldPassTest()
        {
            // Arrange
            Airport airport = new Airport("ASD");
            AirportOperation expected = AirportOperation.InvalidNameLenghtFailure;

            // Act
            AirportOperation actual = airport.ChangeName("AA");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NamePropertySetter_NullStringName_ShouldPassTest()
        {
            // Arrange
            string nullString = null;
            Airport airport = new Airport("ASD");
            AirportOperation expected = AirportOperation.InvalidNameNullFailure;

            // Act
            AirportOperation actual = airport.ChangeName(nullString);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NamePropertySetter_EmptyStringName_ShouldPassTest()
        {
            // Arrange
            Airport airport = new Airport("OFK");
            AirportOperation expected = AirportOperation.InvalidNameLenghtFailure;

            // Act
            AirportOperation actual = airport.ChangeName("");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NamePropertySetter_ThreeLetterStringWithNumbersAndLettersName_ShouldPassTest()
        {
            // Arrange
            Airport airport = new Airport("OFK");
            AirportOperation expected = AirportOperation.InvalidNameFormatFailure;

            // Act
            AirportOperation actual = airport.ChangeName("A21");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NamePropertySetter_ThreeLetterStringWithOnlyNumbersName_ShouldPassTest()
        {
            // Arrange
            Airport airport = new Airport("ASD");
            AirportOperation expected = AirportOperation.InvalidNameFormatFailure;

            // Act
            AirportOperation actual = airport.ChangeName("123");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NamePropertySetter_ThreeLetterStringWithSmallLettersName_ShouldPassTest()
        {
            // Arrange
            Airport airport = new Airport("ASD");
            AirportOperation expected = AirportOperation.InvalidNameFormatFailure;

            // Act
            AirportOperation actual = airport.ChangeName("asd");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NamePropertySetter_ThreeLetterStringWithOnlyCapitalLettersName_ShouldPassTest()
        {
            // Arrange
            Airport airport = new Airport("ASD");
            string expected = "SDS";

            // Act
            airport.ChangeName("SDS");
            string actual = airport.Name;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
