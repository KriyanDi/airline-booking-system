using AirlineBookingSystem.Additional;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.SystemManagers
{
    public class SystemManagerValidationDecorator : ISystemManageable
    {
        private ISystemManageable _systemManager;

        public SystemManagerValidationDecorator(ISystemManageable systemManager) => _systemManager = systemManager;

        public OperationResult CreateAirport(string airportName)
        {
            Airport airport = new Airport(airportName);

            var validationResult = new List<ValidationResult>();
            if (Validator.TryValidateObject(airport, new ValidationContext(airport), validationResult, true))
            {
                return _systemManager.CreateAirport(airportName);
            }
            else
            {
                validationResult.ForEach(el => Console.WriteLine(el));
                return OperationResult.InvalidAirportFormatFailure;
            }
        }
        public OperationResult CreateAirline(string airlineName)
        {
            Airline airline = new Airline(airlineName);

            var validationResult = new List<ValidationResult>();
            if (Validator.TryValidateObject(airline, new ValidationContext(airline), validationResult,true))
            {
                return _systemManager.CreateAirline(airlineName);
            }
            else
            {
                validationResult.ForEach(el => Console.WriteLine(el));
                return OperationResult.InvalidAirlineFormatFailure;
            }
        }
        public OperationResult CreateFlight(string airlineName, string fromAirport, string toAirport, int year, int month, int day, string id)
        {
            Flight flight = new Flight(airlineName, fromAirport, toAirport, id, new DateTime(year, month, day));

            var validationResult = new List<ValidationResult>();
            if (Validator.TryValidateObject(flight, new ValidationContext(flight), validationResult, true))
            {
                return _systemManager.CreateFlight(airlineName, fromAirport, toAirport, year, month, day, id);
            }
            else
            {
                validationResult.ForEach(el => Console.WriteLine(el));
                return OperationResult.InvalidFlightDetailsFailure;
            }
        }
        public OperationResult CreateSection(string airlineName, string flightId, int rows, int cols, SeatClass seatClass)
        {
            FlightSection section = new FlightSection(seatClass, rows, cols);

            var validationResult = new List<ValidationResult>();
            if (Validator.TryValidateObject(section, new ValidationContext(section), validationResult, true))
            {
                return _systemManager.CreateSection(airlineName, flightId, rows, cols, seatClass);
            }
            else
            {
                validationResult.ForEach(el => Console.WriteLine(el.ErrorMessage));
                return OperationResult.SectionParametersFailure;
            }
        }
        public List<Flight> FindAvailableFlights(string originatingAirport, string destionationAirport)
        {
            return _systemManager.FindAvailableFlights(originatingAirport, destionationAirport);
        }
        public OperationResult BookSeat(string airlineName, string flightNumber, SeatClass seatClass, int rows, char cols)
        {
            return _systemManager.BookSeat(airlineName, flightNumber, seatClass, rows, cols);
        }
        public void DisplaySystemDetails()
        {
            _systemManager.DisplaySystemDetails();
        }
    }
}
