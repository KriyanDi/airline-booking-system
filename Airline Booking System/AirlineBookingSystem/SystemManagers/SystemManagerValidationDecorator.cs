using AirlineBookingSystem.Additional;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.SystemManagers
{
    class SystemManagerValidationDecorator : ISystemManageable
    {
        private ISystemManageable _systemManager;

        public SystemManagerValidationDecorator(ISystemManageable systemManager)
        {
            _systemManager = systemManager;
        }
        
        public SystemManagerOperation CreateAirport([AirportName] string airportName)
        {
            var validationResult = new List<ValidationResult>();
            if (Validator.TryValidateObject(airportName, new ValidationContext(airportName), validationResult))
            {
                return _systemManager.CreateAirport(airportName);
            }
            else
            {
                validationResult.ForEach(el => Console.WriteLine(el));
                return SystemManagerOperation.InvalidAirportFormatFailure;
            }
        }
        public SystemManagerOperation CreateAirline([AirlineName] string airlineName)
        {
            var validationResult = new List<ValidationResult>();
            if (Validator.TryValidateObject(airlineName, new ValidationContext(airlineName), validationResult))
            {
                return _systemManager.CreateAirline(airlineName);
            }
            else
            {
                validationResult.ForEach(el => Console.WriteLine(el));
                return SystemManagerOperation.InvalidAirlineFormatFailure;
            }
        }
        public SystemManagerOperation CreateFlight(string airlineName, string fromAirport, string toAirport, int year, int month, int day, [FlightNumber] string id)
        {
            var validationResult = new List<ValidationResult>();
            if (Validator.TryValidateObject(id, new ValidationContext(id), validationResult))
            {
                return _systemManager.CreateFlight(airlineName, fromAirport, toAirport, year, month, day, id);
            }
            else
            {
                validationResult.ForEach(el => Console.WriteLine(el));
                return SystemManagerOperation.InvalidFlightNumberFormatFailure;
            }
        }
        public SystemManagerOperation CreateSection(string airlineName, string flightId, int rows, int cols, SeatClass seatClass)
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
                return SystemManagerOperation.SectionParametersFailure;
            }
        }
        public List<Flight> FindAvailableFlights(string originatingAirport, string destionationAirport)
        {
            return _systemManager.FindAvailableFlights(originatingAirport, destionationAirport);
        }
        public SystemManagerOperation BookSeat(string airlineName, string flightNumber, SeatClass seatClass, int rows, char cols)
        {
            return _systemManager.BookSeat(airlineName, flightNumber, seatClass, rows, cols);
        }
        public void DisplaySystemDetails()
        {
            _systemManager.DisplaySystemDetails();
        }
    }
}
