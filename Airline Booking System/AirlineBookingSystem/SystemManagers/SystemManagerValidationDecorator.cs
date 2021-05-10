using AirlineBookingSystem.Additional;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirlineBookingSystem.SystemManagers
{
    public class SystemManagerValidationDecorator : ISystemManageableExtend
    {
        private ISystemManageable _systemManager;

        public SystemManagerValidationDecorator(ISystemManageable systemManager) => _systemManager = systemManager;

        public OperationResult CreateAirport(string airportName) => Validation(new Airport(airportName), _systemManager.CreateAirport, OperationResult.InvalidAirportFormatFailure);
        public OperationResult CreateAirline(string airlineName) => Validation(new Airline(airlineName), _systemManager.CreateAirline, OperationResult.InvalidAirlineFormatFailure);
        public OperationResult CreateFlight(string airlineName, string fromAirport, string toAirport, int year, int month, int day, string id) => Validation(new Flight(airlineName, fromAirport, toAirport, id, new DateTime(year, month, day)), _systemManager.CreateFlight, OperationResult.InvalidFlightDetailsFailure);
        public OperationResult CreateSection(string airlineName, string flightId, int rows, int cols, SeatClass seatClass)
        {
            FlightSection section = new FlightSection(seatClass, rows, cols);

            var validationResult = new List<ValidationResult>();
            if (Validator.TryValidateObject(section, new ValidationContext(section), validationResult, true))
            {
                return _systemManager.CreateSection(airlineName, flightId, section);
            }
            else
            {
                validationResult.ForEach(el => Console.WriteLine(el));
                return OperationResult.SectionParametersFailure;
            }
        }
        public List<Flight> FindAvailableFlights(string originatingAirport, string destionationAirport) => _systemManager.FindAvailableFlights(originatingAirport, destionationAirport);
        public OperationResult BookSeat(string airlineName, string flightNumber, SeatClass seatClass, int rows, char cols) => _systemManager.BookSeat(airlineName, flightNumber, seatClass, rows, cols);
        public void DisplaySystemDetails() => _systemManager.DisplaySystemDetails();

        private OperationResult Validation<T>(T obj, Func<T, OperationResult> function, OperationResult errorCode)
        {
            var validationResult = new List<ValidationResult>();
            if (Validator.TryValidateObject(obj, new ValidationContext(obj), validationResult, true))
            {
                return function.Invoke(obj);
            }
            else
            {
                validationResult.ForEach(el => Console.WriteLine(el));
                return errorCode;
            }
        }

        #region Not Implemented
        public OperationResult CreateAirport(Airport airport) => throw new NotImplementedException();
        public OperationResult CreateAirline(Airline airline) => throw new NotImplementedException();
        public OperationResult CreateFlight(Flight flight) => throw new NotImplementedException();
        public OperationResult CreateSection(string airlineName, string flightId, FlightSection section) => throw new NotImplementedException();
        #endregion
    }
}
