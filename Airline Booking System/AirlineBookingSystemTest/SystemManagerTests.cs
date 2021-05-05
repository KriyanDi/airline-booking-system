using AirlineBookingSystem.Additional;
using System.Collections.Generic;
using Xunit;
using System;

namespace AirlineBookingSystem.SystemManagers
{
    public class SystemManagerTests
    {
        private SystemManager sm = new SystemManager();

        #region CreateAirport Tests
        [Fact]
        public void CreateAirport_ShortName_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.InvalidAirportFormatFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);

            // Act
            OperationResult actual = sys.CreateAirport("AA");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateAirport_LongName_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.InvalidAirportFormatFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);

            // Act
            OperationResult actual = sys.CreateAirport("AA");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateAirport_NullName_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.InvalidAirportFormatFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            string strNull = null;

            // Act
            OperationResult actual = sys.CreateAirport(strNull);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateAirport_ContainNumbers_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.InvalidAirportFormatFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);

            // Act
            OperationResult actual = sys.CreateAirport("A32");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateAirport_Valid_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.Succeded;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);

            // Act
            OperationResult actual = sys.CreateAirport("ASD");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateAirport_ExistingAirport_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.AirportNameExistFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirport("ASD");

            // Act
            OperationResult actual = sys.CreateAirport("ASD");

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region CreateAirline Tests
        [Fact]
        public void CreateAirline_ShortName_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.InvalidAirlineFormatFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);

            // Act
            OperationResult actual = sys.CreateAirline("");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateAirline_LongName_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.InvalidAirlineFormatFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);

            // Act
            OperationResult actual = sys.CreateAirline("AAABBB");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateAirline_NullName_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.InvalidAirlineFormatFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            string strNull = null;

            // Act
            OperationResult actual = sys.CreateAirline(strNull);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateAirline_Valid_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.Succeded;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);

            // Act
            OperationResult actual = sys.CreateAirline("A342");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateAirline_ContainsOtherSymbols_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.InvalidAirlineFormatFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);

            // Act
            OperationResult actual = sys.CreateAirline("A$42");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateAirline_ExistingAirline_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.InvalidNameAirlineExistFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirline("ASD");

            // Act
            OperationResult actual = sys.CreateAirline("ASD");

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region CreateFlight Tests
        [Fact]
        public void CreateFlight_UnexistingAirline_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.UnexistingAirlineFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);

            // Act
            OperationResult actual = sys.CreateFlight("ASD", "BBB", "AAA", 1, 1, 1, "1");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateFlight_UnexistingOriginatingAirport_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.UnexistingAirportFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirline("ASD");

            // Act
            OperationResult actual = sys.CreateFlight("ASD", "AWW", "WWA", 1998, 1, 1, "1");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateFlight_UnexistingDestinationAirport_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.UnexistingAirportFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirline("ASD");
            sys.CreateAirport("AWW");

            // Act
            OperationResult actual = sys.CreateFlight("ASD", "AWW", "WAA", 1, 1, 1, "1");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateFlight_ExistingFlightNumber_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.InvalidFlightNumberExistsFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirline("ASD");
            sys.CreateAirline("FDS");
            sys.CreateAirport("AWW");
            sys.CreateAirport("WAA");
            sys.CreateFlight("ASD", "AWW", "WAA", 2000, 1, 1, "1234");

            // Act
            OperationResult actual = sys.CreateFlight("FDS", "AWW", "WAA", 1, 1, 1, "1234");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateFlight_Valid_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.Succeded;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirline("ASD");
            sys.CreateAirport("AWW");
            sys.CreateAirport("WAA");

            // Act
            OperationResult actual = sys.CreateFlight("ASD", "AWW", "WAA", 2001, 1, 1, "1");

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region CreateSection Tests
        [Fact]
        public void CreateSection_InvalidRows_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.SectionParametersFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirline("ASD");
            sys.CreateAirport("AWW");
            sys.CreateAirport("WAA");
            sys.CreateFlight("ASD", "AWW", "WAA", 2001, 1, 1, "1234");

            // Act
            OperationResult actual = sys.CreateSection("ASD", "1234", 101, 1, SeatClass.FIRST);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateSection_InvalidCols_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.SectionParametersFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirline("ASD");
            sys.CreateAirport("AWW");
            sys.CreateAirport("WAA");
            sys.CreateFlight("ASD", "AWW", "WAA", 2001, 1, 1, "1234");

            // Act
            OperationResult actual = sys.CreateSection("ASD", "1234", 10, 15, SeatClass.FIRST);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateSection_UnexistingAirline_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.UnexistingAirlineFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirline("ASD");
            sys.CreateAirport("AWW");
            sys.CreateAirport("WAA");
            sys.CreateFlight("ASD", "AWW", "WAA", 2001, 1, 1, "1234");

            // Act
            OperationResult actual = sys.CreateSection("ASD1", "1234", 10, 5, SeatClass.FIRST);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateSection_UnexistingFlight_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.UnexistingFlightFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirline("ASD");
            sys.CreateAirline("DDD");
            sys.CreateAirport("AWW");
            sys.CreateAirport("WAA");
            sys.CreateFlight("DDD", "AWW", "WAA", 2001, 1, 1, "1234");

            // Act
            OperationResult actual = sys.CreateSection("ASD", "1234", 10, 5, SeatClass.FIRST);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateSection_ExistingFlightSection_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.ExsistingSectionFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirline("ASD");
            sys.CreateAirport("AWW");
            sys.CreateAirport("WAA");
            sys.CreateFlight("ASD", "AWW", "WAA", 2001, 1, 1, "1234");
            sys.CreateSection("ASD", "1234", 10, 5, SeatClass.FIRST);

            // Act
            OperationResult actual = sys.CreateSection("ASD", "1234", 10, 5, SeatClass.FIRST);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateSection_Valid_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.Succeded;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirline("ASD");
            sys.CreateAirport("AWW");
            sys.CreateAirport("WAA");
            sys.CreateFlight("ASD", "AWW", "WAA", 2001, 1, 1, "1234");
            sys.CreateSection("ASD", "1234", 10, 5, SeatClass.FIRST);

            // Act
            OperationResult actual = sys.CreateSection("ASD", "1234", 10, 5, SeatClass.BUSINESS);

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region FindAvailableFlights Tests
        [Fact]
        public void FindAvailableFlights_UnexistingOriginatingAirport_ShouldPassTest()
        {
            // Arrange
            List<Flight> expected = new List<Flight>();
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirport("ASD");

            // Act
            List<Flight> actual = sys.FindAvailableFlights("AAA", "ASD");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindAvailableFlights_UnexistingDestinationAirport_ShouldPassTest()
        {
            // Arrange
            List<Flight> expected = new List<Flight>();
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirport("ASD");

            // Act
            List<Flight> actual = sys.FindAvailableFlights("ASD", "DDD");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindAvailableFlights_ExistingAirportsNoFlights_ShouldPassTest()
        {
            // Arrange
            List<Flight> expected = new List<Flight>();
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirport("ASD");
            sys.CreateAirport("DDD");

            // Act
            List<Flight> actual = sys.FindAvailableFlights("ASD", "DDD");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindAvailableFlights_ExistingAirportsNoAvailableFlights_ShouldPassTest()
        {
            // Arrange
            List<Flight> expected = new List<Flight>();
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirport("ASD");
            sys.CreateAirport("DDD");
            sys.CreateFlight("AAA", "ASD", "DDD", 1998, 2, 2, "1234");
            sys.CreateSection("AAA", "1234", 1, 1, SeatClass.FIRST);
            sys.BookSeat("AAA", "1234", SeatClass.FIRST, 1, 'A');

            // Act
            List<Flight> actual = sys.FindAvailableFlights("ASD", "DDD");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindAvailableFlights_ExistingAirportsAvailableFlights_ShouldPassTest()
        {
            // Arrange
            List<Flight> expected = new List<Flight>();
            expected.Add(new Flight("AAA", "ASD", "DDD", "1234", new DateTime(1998, 2, 2)));

            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirline("AAA");
            sys.CreateAirport("ASD");
            sys.CreateAirport("DDD");
            sys.CreateFlight("AAA", "ASD", "DDD", 1998, 2, 2, "1234");
            sys.CreateSection("AAA", "1234", 1, 1, SeatClass.FIRST);

            // Act
            List<Flight> actual = sys.FindAvailableFlights("ASD", "DDD");

            // Assert
            Assert.True(expected.Count == actual.Count);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.True(expected[i].AirlineName == actual[i].AirlineName &&
                    expected[i].OriginatingAirport == actual[i].OriginatingAirport &&
                    expected[i].DestinationAirport == actual[i].DestinationAirport &&
                    expected[i].FlightNumber == actual[i].FlightNumber &&
                    expected[i].DepartureDate == actual[i].DepartureDate &&
                    expected[i].Id == actual[i].Id) ;
            }
        }
        #endregion

        #region BookSeat Tests
        [Fact]
        public void BookSeat_InvalidRows_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.BookingSeatFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirline("AAA");
            sys.CreateAirport("ASD");
            sys.CreateAirport("DSA");
            sys.CreateFlight("AAA", "ASD", "DSA", 1998, 2, 2, "1234");
            sys.CreateSection("AAA", "1234", 12, 2, SeatClass.BUSINESS);

            // Act
            OperationResult actual = sys.BookSeat("AAA", "1234", SeatClass.BUSINESS, 1000, 'A');

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BookSeat_InvalidCols_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.BookingSeatFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirline("AAA");
            sys.CreateAirport("ASD");
            sys.CreateAirport("DSA");
            sys.CreateFlight("AAA", "ASD", "DSA", 1998, 2, 2, "1234");
            sys.CreateSection("AAA", "1234", 12, 2, SeatClass.BUSINESS);

            // Act
            OperationResult actual = sys.BookSeat("AAA", "1234", SeatClass.BUSINESS, 10, 'K');

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BookSeat_UnexistingAirline_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.UnexistingAirlineFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);

            // Act
            OperationResult actual = sys.BookSeat("AAA", "1234", SeatClass.BUSINESS, 10, 'D');

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BookSeat_UnexistingFlight_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.UnexistingFlightFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirline("AAA");

            // Act
            OperationResult actual = sys.BookSeat("AAA", "1234", SeatClass.BUSINESS, 10, 'D');

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BookSeat_UnexistingFlightForAirline_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.UnexistingFlightFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirline("AAA");
            sys.CreateAirline("BBB");
            sys.CreateAirport("ASD");
            sys.CreateAirport("DFG");
            sys.CreateFlight("AAA", "ASD", "DFG", 1998, 2, 3, "1234");

            // Act
            OperationResult actual = sys.BookSeat("BBB", "1234", SeatClass.BUSINESS, 10, 'D');

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BookSeat_UnexistingFlightSection_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.UnexsistingSeatClassFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirline("AAA");
            sys.CreateAirport("ASD");
            sys.CreateAirport("DFG");
            sys.CreateFlight("AAA", "ASD", "DFG", 1998, 2, 3, "1234");

            // Act
            OperationResult actual = sys.BookSeat("AAA", "1234", SeatClass.BUSINESS, 10, 'D');

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BookSeat_Valid_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.Succeded;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirline("AAA");
            sys.CreateAirport("ASD");
            sys.CreateAirport("DFG");
            sys.CreateFlight("AAA", "ASD", "DFG", 1998, 2, 3, "1234");
            sys.CreateSection("AAA", "1234", 1, 2, SeatClass.FIRST);

            // Act
            OperationResult actual = sys.BookSeat("AAA", "1234", SeatClass.FIRST, 1, 'A');

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BookSeat_BookBookedSeat_ShouldPassTest()
        {
            // Arrange
            OperationResult expected = OperationResult.BookingSeatFailure;
            SystemManagerValidationDecorator sys = new SystemManagerValidationDecorator(sm);
            sys.CreateAirline("AAA");
            sys.CreateAirport("ASD");
            sys.CreateAirport("DFG");
            sys.CreateFlight("AAA", "ASD", "DFG", 1998, 2, 3, "1234");
            sys.CreateSection("AAA", "1234", 1, 2, SeatClass.FIRST);
            sys.BookSeat("AAA", "1234", SeatClass.FIRST, 1, 'A');

            // Act
            OperationResult actual = sys.BookSeat("AAA", "1234", SeatClass.FIRST, 1, 'A');

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion
    }
}
