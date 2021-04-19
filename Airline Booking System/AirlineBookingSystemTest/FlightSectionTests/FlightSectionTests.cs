﻿using AirlineBookingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AirlineBookingSystemTest.FlightSectionTests
{
    public class FlightSectionTests
    {
        [Fact]
        public void Constructor_InvalidRowAboveOnehundred_ShouldThrowException()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Row or Col are invalid.");

            // Act
            ArgumentException actual = null;
            try
            {
                FlightSection flightSection = new FlightSection(SeatClass.FIRST, 101, 10);
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void Constructor_InvalidRowZero_ShouldThrowException()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Row or Col are invalid.");

            // Act
            ArgumentException actual = null;
            try
            {
                FlightSection flightSection = new FlightSection(SeatClass.FIRST, 0, 10);
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void Constructor_InvalidColAboveTen_ShouldThrowException()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Row or Col are invalid.");

            // Act
            ArgumentException actual = null;
            try
            {
                FlightSection flightSection = new FlightSection(SeatClass.FIRST, 10, 12);
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void Constructor_InvalidColUnderZero_ShouldThrowException()
        {
            // Arrange
            ArgumentException expected = new ArgumentException("Row or Col are invalid.");

            // Act
            ArgumentException actual = null;
            try
            {
                FlightSection flightSection = new FlightSection(SeatClass.FIRST, 10, -5);
            }
            catch (ArgumentException ex)
            {
                actual = ex;
            }

            // Assert
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void Constructor_InitializeSeats_ShouldPass()
        {
            // Arrange
            List<Seat> expected = new List<Seat>
            {
                new Seat(new (1, 'A'), false),
                new Seat(new (2, 'B'), false),
                new Seat(new (3, 'C'), false),
                new Seat(new (4, 'D'), false)
            };

            // Act
            FlightSection flightSection = new FlightSection(SeatClass.ECONOMY, 4, 4);
            List<Seat> actual = flightSection.Seats;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HasAvailableSeats_ListWithAvailableSeats_ShouldPass()
        {
            // Arrange
            bool expected = true;

            // Act
            FlightSection flightSection = new FlightSection(SeatClass.ECONOMY, 4, 4);
            bool actual = flightSection.HasAvailableSeats();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HasAvailableSeats_ListWithUnavailableSeats_ShouldPass()
        {
            // Arrange
            bool expected = false;

            // Act
            FlightSection flightSection = new FlightSection(SeatClass.ECONOMY, 4, 4);

            // Book all available seats
            for (int i = 0; i < flightSection.Seats.Count; i++)
            {
                flightSection.BookSeat();
            }
            bool actual = flightSection.HasAvailableSeats();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
