using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAbsApi.Data;
using WebAbsApi.Models;

namespace WebAbsApi.IRepository
{
    public interface IAbsRepository
    {
        #region Airport
        public Task<IEnumerable<AirportDTO>> GetAirports();
        public Task<AirportDTO> GetAirport(Guid id);
        public Task<AirportDTO> CreateAirport(CreateAirportDTO airport);
        public Task UpdateAirport(Guid id, CreateAirportDTO airport);
        public Task DeleteAirport(Guid id);
        #endregion

        #region Airline
        public Task<IEnumerable<AirlineDTO>> GetAirlines();
        public Task<AirlineDTO> GetAirline(Guid id);
        public Task<AirlineDTO> CreateAirline(CreateAirlineDTO airline);
        public Task UpdateAirline(Guid id, CreateAirlineDTO airline);
        public Task DeleteAirline(Guid id);
        #endregion

        #region Flight
        public Task<IEnumerable<FlightDTO>> GetFlights();
        public Task<IEnumerable<FlightsInformationDTO>> GetFlightsInformation();
        public Task<FlightsInformationDTO> GetFlightInformation(Guid id);
        public Task<IEnumerable<FlightsInformationDTO>> GetAvailableFlights();
        public Task<IEnumerable<FlightsInformationDTO>> SearchFlights(string origin, string destination);
        public Task<FlightDTO> CreateFlight(CreateFlightDTO flight);
        public Task UpdateFlight(Guid id, CreateFlightDTO flight);
        public Task DeleteFlight(Guid id);
        #endregion

        #region FlightSection
        public Task<FlightSectionDTO> GetFlightSection(Guid flight_id, Guid seatclass_id);
        public Task<IEnumerable<SeatclassDTO>> GetNotAddedSeatclasses(Guid flight_id);
        public Task<IEnumerable<SeatclassDTO>> GetAddedSeatclasses(Guid flight_id);
        public Task<IEnumerable<SeatDTO>> GetSectionSeats(Guid flight_id, Guid seatclass_id);
        public Task<IEnumerable<SeatDTO>> GetSectionFreeSeats(Guid flight_id, Guid seatclass_id);
        public Task<FlightSectionDTO> CreateFlightSection(CreateFlightSectionDTO section);
        public Task DeleteFlightSection(Guid flight_id, Guid seatclass_id);
        #endregion

        #region Seat
        public Task BookSeat(SeatControlDTO seat);
        public Task UnbookSeat(SeatControlDTO seat);
        #endregion
    }
}
