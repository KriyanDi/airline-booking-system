using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AirlineBookingSystem;

namespace AirlineBookingSystemTest.FlightTests
{
    public class FlightTests
    {
        private FlightInformation info = new FlightInformation("AAAA", "QWE", "RTY", "123456789", new DateTime(2021, 5, 3), String.Empty);
        private FlightSection section1 = new FlightSection(SeatClass.BUSINESS, 45, 6);
        private FlightSection section2 = new FlightSection(SeatClass.ECONOMY, 45, 6);
        private FlightSection section3 = new FlightSection(SeatClass.FIRST, 45, 6);

        [Fact]
        public void Constructor_MakingObjectNoFlightSections_ShouldPassTest()
        {
            // Arrange 
            FlightInformation expected = new FlightInformation(info);

            // Act
            Flight actual = new Flight(info.AirlineName, info.OriginatingAirport, info.DestinationAirport, info.FlightNumber, info.DepartureDate);

            // Assert
            Assert.Equal(expected.AirlineName, actual.Information.AirlineName);
            Assert.Equal(expected.OriginatingAirport, actual.Information.OriginatingAirport);
            Assert.Equal(expected.DestinationAirport, actual.Information.DestinationAirport);
            Assert.Equal(expected.DepartureDate, actual.Information.DepartureDate);
            Assert.Equal(expected.Id, actual.Information.Id);
            Assert.NotNull(actual.FlightSections);
        }

        [Fact]
        public void Constuctor_MakingObjectWithTheSameAirportForOrginiateAndDestination_ShouldThrowException()
        {
            // Arrange
            ArgumentException expected = new ArgumentException(FlightExceptionMessages.invalidMatchingOriginatingDestinationAirports);

            // Act
            ArgumentException actual = null;
            try
            {
                Flight flight = new Flight(info.AirlineName, info.OriginatingAirport, info.OriginatingAirport, info.FlightNumber, info.DepartureDate);
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void CopyConstructor_MakingObject_ShouldPass()
        {
            // Arrange
            Flight flight = new Flight(info.AirlineName, info.OriginatingAirport, info.DestinationAirport, info.FlightNumber, info.DepartureDate);
            flight.AddFlightSection(section1);
            flight.AddFlightSection(section2);
            flight.AddFlightSection(section3);

            // Act
            Flight flightCopy = new Flight(flight);

            bool HasSameSequentialElements = true;
            for (int i = 0; i < flightCopy.FlightSections.Count; i++)
            {
                if (flight.FlightSections[i] != flightCopy.FlightSections[i])
                {
                    HasSameSequentialElements = false;
                    break;
                }
            }

            // Assert
            Assert.Equal(flight.Information.AirlineName, flightCopy.Information.AirlineName);
            Assert.Equal(flight.Information.OriginatingAirport, flightCopy.Information.OriginatingAirport);
            Assert.Equal(flight.Information.DestinationAirport, flightCopy.Information.DestinationAirport);
            Assert.Equal(flight.Information.DepartureDate, flightCopy.Information.DepartureDate);
            Assert.Equal(flight.Information.Id, flightCopy.Information.Id);
            Assert.Equal(flight.FlightSections.Count, flightCopy.FlightSections.Count);
            Assert.True(HasSameSequentialElements);
        }

        [Fact]
        public void AddFlightSection_AddingTwoDifferentFlightSections_ShouldPassTest()
        {
            // Arrange 

            // Act
            Flight actual = new Flight(info.AirlineName, info.OriginatingAirport, info.DestinationAirport, info.FlightNumber, info.DepartureDate);
            actual.AddFlightSection(section1);
            actual.AddFlightSection(section2);

            // Assert
            Assert.NotNull(actual.FlightSections);
            Assert.Equal(2, actual.FlightSections.Count);
        }

        [Fact]
        public void AddFlightSection_AddingTwoExactFlightSections_ShouldPassTest()
        {
            // Arrange 
            FlightOperation expected = FlightOperation.InvalidSectionAlreadyExistsFailure;
            Flight flight = new Flight(info.AirlineName, info.OriginatingAirport, info.DestinationAirport, info.FlightNumber, info.DepartureDate);
            flight.AddFlightSection(section1);

            // Act
            FlightOperation actual = flight.AddFlightSection(section1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
