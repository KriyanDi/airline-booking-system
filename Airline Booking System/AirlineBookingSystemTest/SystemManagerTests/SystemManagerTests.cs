using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineBookingSystem;
using Xunit;

namespace AirlineBookingSystemTest.SystemManagerTests
{
    public class SystemManagerTests
    {
        #region CreateAirportMethodTests
        [Fact]
        public void CreateAirport_WhenObjectIsCreatedItContainsZeroAirports_ShouldPassTest()
        {
            // Arrange
            SystemManager manager = new SystemManager();
            int expected = 0;

            // Act
            int actual = manager.Airports.Count;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateAirport_AddingValidNewAirportToEmptyAirportList_ShouldPassTest()
        {
            // Arrange
            SystemManager manager = new SystemManager();
            Airport expected = new Airport("QWE");

            // Act
            manager.CreateAirport("QWE");
            Airport actual = manager.Airports[0];

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateAirport_AddingValidAirportToAlreadyContainingSomeAirportsAirportsList_ShouldPassTest()
        {
            // Arrange
            SystemManager manager = new SystemManager();
            manager.CreateAirport("QWE");
            manager.CreateAirport("ASD");
            manager.CreateAirport("YUI");
            Airport expected = new Airport("SSS");

            // Act
            manager.CreateAirport("SSS");
            Airport actual = manager.Airports[3];

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateAirport_AddingInvalidNewAirportThatHasLongerThanThreeLettersName_ShoudlThrowExceptionTest()
        {
            // Arrange
            SystemManager manager = new SystemManager();
            ArgumentException expected = new ArgumentException("Airport name should be 3 letters long.");

            // Act
            ArgumentException actual = null;
            try
            {
                manager.CreateAirport("ASD23");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void CreateAirport_AddingInvalidNewAirportThatHasShorterThanThreeLettersName_ShoudlThrowExceptionTest()
        {
            // Arrange
            SystemManager manager = new SystemManager();
            ArgumentException expected = new ArgumentException("Airport name should be 3 letters long.");

            // Act
            ArgumentException actual = null;
            try
            {
                manager.CreateAirport("AS");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void CreateAirport_AddingInvalidNewAirportThatIsEmptyStringName_ShoudlThrowExceptionTest()
        {
            // Arrange
            SystemManager manager = new SystemManager();
            ArgumentException expected = new ArgumentException("Airport name should be 3 letters long.");

            // Act
            ArgumentException actual = null;
            try
            {
                manager.CreateAirport("");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void CreateAirport_AddingInvalidNewAirportThatIsNullString_ShoudlThrowExceptionTest()
        {
            // Arrange
            SystemManager manager = new SystemManager();
            ArgumentNullException expected = new ArgumentNullException("Airport name can not be null.");
            string airportName = null;
            // Act
            ArgumentNullException actual = null;
            try
            {
                manager.CreateAirport(airportName);
            }
            catch (ArgumentNullException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void CreateAirport_AddingInvalidNewAirportThatHasThreeSymbolsButNotOnlyLettersName_ShoudlThrowExceptionTest()
        {
            // Arrange
            SystemManager manager = new SystemManager();
            ArgumentException expected = new ArgumentException("Airport name should contain only capital letters.");

            // Act
            ArgumentException actual = null;
            try
            {
                manager.CreateAirport("e@2");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void CreateAirport_AddingAlreadyExistingAirport_ShouldThrowExceptionTest()
        {
            // Arrange
            SystemManager manager = new SystemManager();
            manager.CreateAirport("QWE");
            manager.CreateAirport("ASD");
            manager.CreateAirport("YUI");
            ArgumentException expected = new ArgumentException("Airport YUI already exists!");

            // Act
            ArgumentException actual = null;
            try
            {
                manager.CreateAirport("YUI");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(actual.Message, actual.Message);
        }
        #endregion

        #region CreateAirlineMethodTests
        [Fact]
        public void CreateAirline_WhenObjectIsCreatedItContainsZeroAirlines_ShouldPassTest()
        {
            // Arrange
            SystemManager manager = new SystemManager();
            int expected = 0;

            // Act
            int actual = manager.Airlines.Count;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateAirline_AddingValidAirlineToEmptyListOfAirlines_ShouldPassTest()
        {
            // Arrange
            SystemManager manager = new SystemManager();
            Airline expected = new Airline("DEL2");

            // Act
            manager.CreateAirline("DEL2");
            Airline actual = manager.Airlines[0];

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateAirline_AddingValidAirlineToNonEmptyListOfAirlines_ShouldPassTest()
        {
            // Arrange
            SystemManager manager = new SystemManager();
            Airline expected = new Airline("DEL5");

            // Act
            manager.CreateAirline("DEL2");
            manager.CreateAirline("DEL3");
            manager.CreateAirline("DEL4");
            manager.CreateAirline("DEL5");
            Airline actual = manager.Airlines[3];

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateAirline_AddingAirlineThatAlreadyExist_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException($"Airline QWES already exists!");
            SystemManager manager = new SystemManager();
            manager.CreateAirline("QWES");

            // Act
            ArgumentException actual = null;
            try
            {
                manager.CreateAirline("QWES");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }
        #endregion


    }
}
