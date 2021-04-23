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
            ArgumentException expected = new ArgumentException(AirportExceptionMessages.invalidName);

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
            ArgumentException expected = new ArgumentException(AirportExceptionMessages.invalidName);

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
            ArgumentException expected = new ArgumentException(AirportExceptionMessages.invalidName);

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
            ArgumentException expected = new ArgumentException(AirportExceptionMessages.invalidName);
            string airportName = null;
            // Act
            ArgumentException actual = null;
            try
            {
                manager.CreateAirport(airportName);
            }
            catch (ArgumentException ex)
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
            ArgumentException expected = new ArgumentException(AirportExceptionMessages.invalidName);

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
        public void CreateAirport_AddingAlreadyExistingAirport_ShouldPassTest()
        {
            // Arrange
            SystemManager manager = new SystemManager();
            manager.CreateAirport("QWE");
            manager.CreateAirport("ASD");
            manager.CreateAirport("YUI");
            SystemManagerOperation expected = SystemManagerOperation.InvalidNameAirportExistFailure;

            // Act
            SystemManagerOperation actual = manager.CreateAirport("YUI");

            // Assert
            Assert.Equal(expected, actual);
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
        public void CreateAirline_AddingAirlineThatAlreadyExist_ShouldPassTest()
        {
            // Arrange
            SystemManagerOperation expected = SystemManagerOperation.InvalidNameAirlineExistFailure;
            SystemManager manager = new SystemManager();
            manager.CreateAirline("QWES");

            // Act
            SystemManagerOperation actual = manager.CreateAirline("QWES");

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region CreateFlightMethodTests
        [Fact]
        public void CreateFlight_CreatingFlightWithUnexistingAirline_ShouldPassTest()
        {
            // Arrange
            SystemManagerOperation expected = SystemManagerOperation.UnexistingAirlineFailure;
            SystemManager systemManager = new SystemManager();

            // Act
            SystemManagerOperation actual = systemManager.CreateFlight("ASD", "SSS", "TTT", 1982, 2, 3, "1234");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateFlight_CreatingFlightWithUnexistingOriginatingAirport_ShouldPassTest()
        {
            // Arrange
            SystemManagerOperation expected = SystemManagerOperation.UnexistingAirportFailure;
            SystemManager systemManager = new SystemManager();
            systemManager.CreateAirline("ASD");

            // Act
            SystemManagerOperation actual = systemManager.CreateFlight("ASD", "SSS", "TTT", 1982, 2, 3, "1234");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateFlight_CreatingFlightWithUnexistingDestinationAirport_ShouldPassTest()
        {
            // Arrange
            SystemManagerOperation expected = SystemManagerOperation.UnexistingAirportFailure;
            SystemManager systemManager = new SystemManager();
            systemManager.CreateAirline("ASD");
            systemManager.CreateAirport("SSS");

            // Act
            SystemManagerOperation actual = systemManager.CreateFlight("ASD", "SSS", "TTT", 1982, 2, 3, "1234");

            // Assert
            Assert.Equal(expected, actual);
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
        public void CreateSection_CreateSectionForUnexistingAirline_ShouldPassTest()
        {
            // Arrange
            SystemManagerOperation expected = SystemManagerOperation.UnexistingAirlineFailure;
            SystemManager systemManager = new SystemManager();

            // Act
            SystemManagerOperation actual = systemManager.CreateSection("QWE", "1234", 4, 5, SeatClass.ECONOMY);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateSection_CreateSectionForUnexistingFlight_ShouldPassTest()
        {
            // Arrange
            SystemManagerOperation expected = SystemManagerOperation.UnexistingFlightFailure;
            SystemManager systemManager = new SystemManager();
            systemManager.CreateAirline("QWE");

            // Act
            SystemManagerOperation actual = systemManager.CreateSection("QWE", "1234", 4, 5, SeatClass.ECONOMY);
            
            // Assert
            Assert.Equal(expected, actual);
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
        public void FindAvailableFlights_ForUnexistingOriginatingAirport_ShouldPassTest()
        {
            // Arrange
            List<Flight> expected = new List<Flight>();
            SystemManager system = new SystemManager();

            // Act
            List<Flight> actual = system.FindAvailableFlights("DES", "SED");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindAvailableFlights_ForUnexistingDestinationAirport_ShouldPassTest()
        {
            // Arrange
            List<Flight> expected = new List<Flight>();
            SystemManager system = new SystemManager();
            system.CreateAirport("DES");

            // Act
            List<Flight> actual = system.FindAvailableFlights("DES", "SED");


            // Assert
            Assert.Equal(expected, actual);
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
                if (!flightList1[i].Equals((flightList2[i])))
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
        public void BookSeat_BookASeatToUnexistingAirline_ShouldPassTest()
        {
            // Arrange
            SystemManagerOperation expected = SystemManagerOperation.UnexistingAirlineFailure;
            SystemManager system = new SystemManager();

            // Act
            SystemManagerOperation actual = system.BookSeat("ASD", "1234", SeatClass.BUSINESS, 5, 'A');

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BookSeat_BookASeatToUnexistingFlight_ShouldPassTest()
        {
            // Arrange
            SystemManagerOperation expected = SystemManagerOperation.UnexistingFlightFailure;
            SystemManager system = new SystemManager();

            system.CreateAirport("AAA");
            system.CreateAirport("BBB");

            system.CreateAirline("ASD");

            system.CreateFlight("ASD", "AAA", "BBB", 1972, 3, 2, "1543");
            system.CreateFlight("ASD", "AAA", "BBB", 1972, 3, 2, "1523");
            system.CreateFlight("ASD", "AAA", "BBB", 1972, 3, 2, "13");

            // Act
            SystemManagerOperation actual = system.BookSeat("ASD", "1234", SeatClass.BUSINESS, 5, 'A');

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BookSeat_BookASeatToUnexistingSection_ShouldPassTest()
        {
            // Arrange
            SystemManagerOperation expected = SystemManagerOperation.UnexsistingSeatClassFailure;
            SystemManager system = new SystemManager();

            system.CreateAirport("AAA");
            system.CreateAirport("BBB");

            system.CreateAirline("ASD");

            system.CreateFlight("ASD", "AAA", "BBB", 1972, 3, 2, "1543");

            system.CreateSection("ASD", "1543", 5, 4, SeatClass.ECONOMY);
            system.CreateSection("ASD", "1543", 5, 4, SeatClass.FIRST);

            // Act
            SystemManagerOperation actual = system.BookSeat("ASD", "1543", SeatClass.BUSINESS, 5, 'A');

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BookSeat_BookASeatThatIsBooked_ShouldPassTest()
        {
            // Arrange
            SystemManagerOperation expected = SystemManagerOperation.BookingSeatFailure;
            SystemManager system = new SystemManager();

            system.CreateAirport("AAA");
            system.CreateAirport("BBB");

            system.CreateAirline("ASD");

            system.CreateFlight("ASD", "AAA", "BBB", 1992, 4, 5, "1543");

            system.CreateSection("ASD", "1543", 5, 4, SeatClass.BUSINESS);

            system.BookSeat("ASD", "1543", SeatClass.BUSINESS, 5, 'A');

            // Act
            SystemManagerOperation actual = system.BookSeat("ASD", "1543", SeatClass.BUSINESS, 5, 'A');

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BookSeat_BookASeatThatIsUnexisting_ShouldPassTest()
        {
            // Arrange
            SystemManagerOperation expected = SystemManagerOperation.BookingSeatFailure;
            SystemManager system = new SystemManager();

            system.CreateAirport("AAA");
            system.CreateAirport("BBB");

            system.CreateAirline("ASD");

            system.CreateFlight("ASD", "AAA", "BBB", 1972, 5, 5, "1543");

            system.CreateSection("ASD", "1543", 3, 2, SeatClass.BUSINESS);

            // Act
            SystemManagerOperation actual = system.BookSeat("ASD", "1543", SeatClass.BUSINESS, 5, 'B');

            // Assert
            Assert.Equal(expected, actual);
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

            system.CreateSection("ASD", "1543", 4, 4, SeatClass.BUSINESS);

            // Act
            system.BookSeat("ASD", "1543", SeatClass.BUSINESS, 2, 'B');
            bool actual = system
                .AirlinesReference[0]
                .FlightsReference[0]
                .FlightSectionsReference[0]
                .Seats[5].IsBooked;

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region FinalTests
        [Fact]
        public void FinalTests_ShouldPassTest()
        {
            SystemManager res = new SystemManager();

            //Create airports
            res.CreateAirport("DEN");
            res.CreateAirport("DFW");
            res.CreateAirport("LON");
            res.CreateAirport("JPN");

            try
            {
                res.CreateAirport("DE"); //invalid
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            res.CreateAirport("DEH");

            try
            {
                res.CreateAirport("DEN"); //invalid
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            res.CreateAirport("NCE");

            try
            {
                res.CreateAirport("TRIord9"); //invalid
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                res.CreateAirport("DEN"); //invalid
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Create airlines
            res.CreateAirline("DELTA");
            res.CreateAirline("AMER");
            res.CreateAirline("JET");

            try
            {
                res.CreateAirline("DELTA"); //invalid
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            res.CreateAirline("SWEST");

            try
            {
                res.CreateAirline("AMER"); //invalid
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            res.CreateAirline("FRONT");

            try
            {
                res.CreateAirline("FRONTIER"); //invalid
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Create flights
            res.CreateFlight("DELTA", "DEN", "LON", 2009, 10, 10, "123");
            res.CreateFlight("DELTA", "DEN", "DEH", 2009, 8, 8, "567");

            try
            {
                res.CreateFlight("DELTA", "DEN", "NCE", 2010, 9, 8, "567"); //invalid
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            res.CreateFlight("JET", "LON", "DEN", 2009, 5, 7, "123");
            res.CreateFlight("AMER", "DEN", "LON", 2010, 10, 1, "123");
            res.CreateFlight("JET", "DEN", "LON", 2010, 6, 10, "786");
            res.CreateFlight("JET", "DEN", "LON", 2009, 1, 12, "909");

            //Create sections
            res.CreateSection("JET", "123", 2, 2, SeatClass.ECONOMY);

            try
            {
                res.CreateSection("JET", "123", 1, 3, SeatClass.ECONOMY); //invalid
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            res.CreateSection("JET", "123", 2, 3, SeatClass.FIRST);
            res.CreateSection("DELTA", "123", 1, 1, SeatClass.BUSINESS);
            res.CreateSection("DELTA", "123", 1, 2, SeatClass.ECONOMY);

            try
            {
                res.CreateSection("SWSERTT", "123", 5, 5, SeatClass.ECONOMY); //invalid
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            res.DisplaySystemDetails();

            res.FindAvailableFlights("DEN", "LON");

            res.BookSeat("DELTA", "123", SeatClass.BUSINESS, 1, 'A');
            res.BookSeat("DELTA", "123", SeatClass.ECONOMY, 1, 'A');

            try
            {
                res.BookSeat("DELTA", "123", SeatClass.ECONOMY, 1, 'B');
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                res.BookSeat("DELTA", "123", SeatClass.BUSINESS, 1, 'A'); //already booked
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            res.DisplaySystemDetails();
            res.FindAvailableFlights("DEN", "LON");
        }
        #endregion
    }
}
