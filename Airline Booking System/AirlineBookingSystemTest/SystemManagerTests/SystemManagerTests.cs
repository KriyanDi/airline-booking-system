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

        #region CreateFlightMethodTests
        [Fact]
        public void CreateFlight_CreatingFlightWithUnexistingAirline_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Airline does not exist!");
            SystemManager systemManager = new SystemManager();

            // Act
            ArgumentException actual = null;
            try
            {
            systemManager.CreateFlight("ASD", "SSS", "TTT", 1982, 2, 3, "1234");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void CreateFlight_CreatingFlightWithUnexistingOriginatingAirport_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Originating Airport does not exist!");
            SystemManager systemManager = new SystemManager();
            systemManager.CreateAirline("ASD");

            // Act
            ArgumentException actual = null;
            try
            {
                systemManager.CreateFlight("ASD", "SSS", "TTT", 1982, 2, 3, "1234");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void CreateFlight_CreatingFlightWithUnexistingDestinationAirport_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Destination Airport does not exist!");
            SystemManager systemManager = new SystemManager();
            systemManager.CreateAirline("ASD");
            systemManager.CreateAirport("SSS");

            // Act
            ArgumentException actual = null;
            try
            {
                systemManager.CreateFlight("ASD", "SSS", "TTT", 1982, 2, 3, "1234");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void CreateFlight_CreatingValidFlight_ShouldPassTest()
        {
            // Arrange
            Flight expected = new Flight("ASD", "SSS", "TTT", "1234", new DateTime(1982, 2, 3));
            expected.ChangeFlightInformationId("ASD00001");
            SystemManager systemManager = new SystemManager();
            
            systemManager.CreateAirline("ASD");
            
            systemManager.CreateAirport("SSS");
            systemManager.CreateAirport("TTT");

            // Act
            systemManager.CreateFlight("ASD", "SSS", "TTT", 1982, 2, 3, "1234");
            Flight actual = systemManager.Airlines[0].Flights[0];


            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region CreateSectionMethodTests
        [Fact]
        public void CreateSection_CreateSectionForUnexistingAirline_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Airline does not exist!");
            SystemManager systemManager = new SystemManager();

            // Act
            ArgumentException actual = null;
            try
            {
                systemManager.CreateSection("QWE", "1234", 4, 5, SeatClass.ECONOMY);
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void CreateSection_CreateSectionForUnexistingFlight_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Airline QWE does not contain such flight!");
            SystemManager systemManager = new SystemManager();
            systemManager.CreateAirline("QWE");

            // Act
            ArgumentException actual = null;
            try
            {
                systemManager.CreateSection("QWE", "1234", 4, 5, SeatClass.ECONOMY);
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void CreateSection_CreateValidFlightSection_ShouldPassTest()
        {
            // Arrange
            SystemManager systemManager = new SystemManager();
            systemManager.CreateAirline("QWE");
            systemManager.CreateAirport("WER");
            systemManager.CreateAirport("REW");
            systemManager.CreateFlight("QWE", "WER", "REW", 1872, 2, 2, "1234");

            FlightSection expected = new FlightSection(SeatClass.ECONOMY, 4, 5);

            // Act
            systemManager.CreateSection("QWE", "1234", 4, 5, SeatClass.ECONOMY);
            FlightSection actual = systemManager.Airlines[0].Flights[0].FlightSections[0];
            
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region FindAvailableFlightsMethodTests
        [Fact]
        public void FindAvailableFlights_ForUnexistingOriginatingAirport_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Airport DES does not exist!");
            SystemManager system = new SystemManager();

            // Act
            ArgumentException actual = null;
            try
            {
                system.FindAvailableFlights("DES", "SED");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void FindAvailableFlights_ForUnexistingDestinationAirport_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Airport SED does not exist!");
            SystemManager system = new SystemManager();
            system.CreateAirport("DES");

            // Act
            ArgumentException actual = null;
            try
            {
                system.FindAvailableFlights("DES", "SED");
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void FindAvailableFlights_IfThereAreNoAvailableFLightsForExistingsAirportsReturnsEmptyList_ShouldPassTest()
        {
            // Arrange
            SystemManager system = new SystemManager();
            system.CreateAirport("DES");
            system.CreateAirport("SED");

            List<Flight> expected = new List<Flight>();

            // Act
            List<Flight> actual = system.FindAvailableFlights("DES", "SED");

            // Assert
            Assert.Equal(expected.Count, actual.Count);
        }

        [Fact]
        public void FindAvailableFlights_IfThereAreAvailableFLightsReturnsList_ShouldPassTest()
        {
            // Arrange
            bool expected = true;
            SystemManager system = new SystemManager();
            system.CreateAirport("DES");
            system.CreateAirport("SED");

            system.CreateAirline("DE32");
            system.CreateAirline("DE33");
            system.CreateAirline("DE34");

            system.CreateFlight("DE32", "DES", "SED", 1982, 2, 2, "123");
            system.CreateSection("DE32", "123", 5, 5, SeatClass.BUSINESS);
            
            system.CreateFlight("DE32", "DES", "SED", 1982, 2, 2, "1234");
            system.CreateSection("DE32", "1234", 5, 5, SeatClass.BUSINESS);
            
            system.CreateFlight("DE33", "DES", "SED", 1982, 2, 2, "1235");
            system.CreateSection("DE33", "1235", 5, 5, SeatClass.BUSINESS);
            
            system.CreateFlight("DE34", "DES", "SED", 1982, 2, 2, "1236");
            system.CreateSection("DE34", "1236", 5, 5, SeatClass.BUSINESS);

            List<Flight> flightList1 = new List<Flight>();
            flightList1.Add(new Flight("DE32", "DES", "SED", "123", new DateTime(1982, 2, 2)));
            flightList1[0].ChangeFlightInformationId("DE3200001");
            flightList1.Add(new Flight("DE32", "DES", "SED", "1234", new DateTime(1982, 2, 2)));
            flightList1[1].ChangeFlightInformationId("DE3200002");
            flightList1.Add(new Flight("DE33", "DES", "SED", "1235", new DateTime(1982, 2, 2)));
            flightList1[2].ChangeFlightInformationId("DE3300001");
            flightList1.Add(new Flight("DE34", "DES", "SED", "1236", new DateTime(1982, 2, 2)));
            flightList1[3].ChangeFlightInformationId("DE3400001");

            // Act
            List<Flight> flightList2 = system.FindAvailableFlights("DES", "SED");

            bool actual = true;
            for (int i = 0; i < flightList1.Count; i++)
            {
                if(!flightList1[i].Equals((flightList2[i])))
                {
                    actual = false;
                    break;
                }
            }

            // Assert
            Assert.Equal(expected, actual);
            Assert.Equal(flightList1.Count, flightList2.Count);
        }
        #endregion

        #region BookSeatMethodTests
        [Fact]
        public void BookSeat_BookASeatToUnexistingAirline_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Airline does not exist!");
            SystemManager system = new SystemManager();

            // Act
            ArgumentException actual = null;
            try
            {
                system.BookSeat("ASD", "1234", SeatClass.BUSINESS, 5, 'A');
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void BookSeat_BookASeatToUnexistingFlight_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Flight does not exist!");
            SystemManager system = new SystemManager();

            system.CreateAirport("AAA");
            system.CreateAirport("BBB");

            system.CreateAirline("ASD");

            system.CreateFlight("ASD", "AAA", "BBB", 1972, 3, 2, "1543");
            system.CreateFlight("ASD", "AAA", "BBB", 1972, 3, 2, "1523");
            system.CreateFlight("ASD", "AAA", "BBB", 1972, 3, 2, "13");

            // Act
            ArgumentException actual = null;
            try
            {
                system.BookSeat("ASD", "1234", SeatClass.BUSINESS, 5, 'A');
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void BookSeat_BookASeatToUnexistingSection_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException($"Flight does not contain section with seat class {SeatClass.BUSINESS}!");
            SystemManager system = new SystemManager();

            system.CreateAirport("AAA");
            system.CreateAirport("BBB");

            system.CreateAirline("ASD");

            system.CreateFlight("ASD", "AAA", "BBB", 1972, 3, 2, "1543");

            system.CreateSection("ASD", "1543", 5, 4, SeatClass.ECONOMY);
            system.CreateSection("ASD", "1543", 5, 4, SeatClass.FIRST);

            // Act
            ArgumentException actual = null;
            try
            {
                system.BookSeat("ASD", "1543", SeatClass.BUSINESS, 5, 'A');
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void BookSeat_BookASeatThatIsBooked_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Could not book seat on Row: 5 Col: A!");
            SystemManager system = new SystemManager();

            system.CreateAirport("AAA");
            system.CreateAirport("BBB");

            system.CreateAirline("ASD");

            system.CreateFlight("ASD", "AAA", "BBB", 1992, 4, 5, "1543");

            system.CreateSection("ASD", "1543", 5, 4, SeatClass.BUSINESS);

            system.BookSeat("ASD", "1543", SeatClass.BUSINESS, 5, 'A');
            
            // Act
            ArgumentException actual = null;
            try
            {
                system.BookSeat("ASD", "1543", SeatClass.BUSINESS, 5, 'A');
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void BookSeat_BookASeatThatIsUnexisting_ShouldThrowExceptionTest()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Could not book seat on Row: 5 Col: A!");
            SystemManager system = new SystemManager();

            system.CreateAirport("AAA");
            system.CreateAirport("BBB");

            system.CreateAirline("ASD");

            system.CreateFlight("ASD", "AAA", "BBB", 1972, 5, 5, "1543");

            system.CreateSection("ASD", "1543", 15, 5, SeatClass.BUSINESS);

            // Act
            ArgumentException actual = null;
            try
            {
                system.BookSeat("ASD", "1543", SeatClass.BUSINESS, 5, 'A');
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void BookSeat_BookAValidAvailableSeat_ShouldPassTest()
        {
            // Arrange
            bool expected = true;
            SystemManager system = new SystemManager();

            system.CreateAirport("AAA");
            system.CreateAirport("BBB");

            system.CreateAirline("ASD");

            system.CreateFlight("ASD", "AAA", "BBB", 1972, 6, 4, "1543");

            system.CreateSection("ASD", "1543", 16, 4, SeatClass.BUSINESS);

            // Act
            system.BookSeat("ASD", "1543", SeatClass.BUSINESS, 5, 'A');
            bool actual = system
                .GetReferenceAirlines()[0]
                .ReferenceFlights[0]
                .ReferenceFlightSections[0]
                .Seats[4].IsBooked;

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion
    }
}
