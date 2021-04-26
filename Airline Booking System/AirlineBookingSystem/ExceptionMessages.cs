using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem
{
    public class AirportExceptionMessages
    {
        public static string invalidName = "Invalid Airport Name!";
    }

    public class AirlineExceptionMessages
    {
        public static string invalidName = "Invalid Airline Name!";
    }

    public class FlightExceptionMessages
    {
        public static string invalidMatchingOriginatingDestinationAirports = "Matching Originating And Destination Airport!";
    }
    public class SeatExceptionMessages
    {
        public static string invalidSeatsRows = "Invalid Seats Rows!";
        public static string invalidSeatsCols = "Invalid Seats Cols!";
    }

    public class SystemManagerExceptionMessages
    {
        public static string invalidFlightSectionSeatClass = "Flight does not contain section with such seat class";
    }
}
