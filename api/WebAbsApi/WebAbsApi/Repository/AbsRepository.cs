using AutoMapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebAbsApi.Context;
using WebAbsApi.Data;
using WebAbsApi.IRepository;
using WebAbsApi.Models;

namespace WebAbsApi.Repository
{
    public class AbsRepository : IAbsRepository
    {
        private readonly DapperContext _context;
        private readonly IMapper _mapper;

        public AbsRepository(DapperContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Airport
        public async Task<IEnumerable<AirportDTO>> GetAirports()
        {
            IEnumerable<Airport> result = await ExecStoredProcedure<Airport>("GetAirports");
            return _mapper.Map<IEnumerable<AirportDTO>>(result);
        }
        public async Task<AirportDTO> GetAirport(Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("airp_id", id, DbType.Guid, ParameterDirection.Input);
            IEnumerable<Airport> result = await ExecStoredProcedure<Airport>("GetAirportById", parameters);
            return _mapper.Map<AirportDTO>(result.First());
        }
        public async Task<AirportDTO> CreateAirport(CreateAirportDTO airport)
        {
            var parameters = new DynamicParameters();
            parameters.Add("airp_name", airport.Name, DbType.String, ParameterDirection.Input);
            IEnumerable<Airport> result = await ExecStoredProcedure<Airport>("AddAirport", parameters);
            return _mapper.Map<AirportDTO>(result.First());
        }
        public async Task UpdateAirport(Guid id, CreateAirportDTO airport)
        {
            var parameters = new DynamicParameters();
            parameters.Add("airp_id", id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("new_airp_name", airport.Name, DbType.String, ParameterDirection.Input);
            await ExecStoredProcedure<Airport>("UpdateAirport", parameters);
        }
        public async Task DeleteAirport(Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("airp_id", id, DbType.Guid, ParameterDirection.Input);
            await ExecStoredProcedure<Airport>("DeleteAirport", parameters);
        }
        #endregion

        #region Airline
        public async Task<IEnumerable<AirlineDTO>> GetAirlines()
        {
            IEnumerable<Airline> result = await ExecStoredProcedure<Airline>("GetAirlines");
            return _mapper.Map<IEnumerable<AirlineDTO>>(result);
        }
        public async Task<AirlineDTO> GetAirline(Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("airl_id", id, DbType.Guid, ParameterDirection.Input);
            IEnumerable<Airline> result = await ExecStoredProcedure<Airline>("GetAirlineById", parameters);
            return _mapper.Map<AirlineDTO>(result.First());
        }
        public async Task<AirlineDTO> CreateAirline(CreateAirlineDTO airline)
        {
            var parameters = new DynamicParameters();
            parameters.Add("airl_name", airline.Name, DbType.String, ParameterDirection.Input);
            IEnumerable<Airline> result = await ExecStoredProcedure<Airline>("AddAirline", parameters);
            return _mapper.Map<AirlineDTO>(result.First());
        }
        public async Task UpdateAirline(Guid id, CreateAirlineDTO airline)
        {
            var parameters = new DynamicParameters();
            parameters.Add("airl_id", id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("new_airl_name", airline.Name, DbType.String, ParameterDirection.Input);
            await ExecStoredProcedure<Airline>("UpdateAirline", parameters);
        }
        public async Task DeleteAirline(Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("airl_id", id, DbType.Guid, ParameterDirection.Input);
            await ExecStoredProcedure<Airline>("DeleteAirline", parameters);
        }
        #endregion

        #region Flight
        public async Task<IEnumerable<FlightDTO>> GetFlights()
        {
            IEnumerable<Flight> result = await ExecStoredProcedure<Flight>("GetFlights");
            return _mapper.Map<IEnumerable<FlightDTO>>(result);
        }
        public async Task<IEnumerable<FlightsInformationDTO>> GetFlightsInformation()
        {
            IEnumerable<FlightsInformation> result = await ExecStoredProcedure<FlightsInformation>("GetFlightsInformation");
            return _mapper.Map<IEnumerable<FlightsInformationDTO>>(result);
        }
        public async Task<FlightsInformationDTO> GetFlightInformation(Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("flight_id", id, DbType.Guid, ParameterDirection.Input);
            IEnumerable<FlightsInformationDTO> result = await ExecStoredProcedure<FlightsInformationDTO>("GetFlightInformationById", parameters);
            return _mapper.Map<FlightsInformationDTO>(result.First());
        }
        public async Task<IEnumerable<FlightsInformationDTO>> GetAvailableFlights()
        {
            IEnumerable<FlightsInformationDTO> result = await ExecStoredProcedure<FlightsInformationDTO>("GetAvailableFlights");
            return _mapper.Map<IEnumerable<FlightsInformationDTO>>(result);
        }
        public async Task<IEnumerable<FlightsInformationDTO>> SearchFlights(string origin, string destination)
        {
            var parameters = new DynamicParameters();
            parameters.Add("orig", origin, DbType.String, ParameterDirection.Input);
            parameters.Add("dest", destination, DbType.String, ParameterDirection.Input);
            IEnumerable<FlightsInformation> result = await ExecStoredProcedure<FlightsInformation>("SearchFlights", parameters);
            return _mapper.Map<IEnumerable<FlightsInformationDTO>>(result);
        }
        public async Task<FlightDTO> CreateFlight(CreateFlightDTO flight)
        {
            var parameters = new DynamicParameters();
            parameters.Add("airl_id", flight.Airline_Id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("dest_id", flight.Dest_Airport_Id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("orig_id", flight.Orig_Airport_Id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("take_off", flight.Take_Off, DbType.DateTime, ParameterDirection.Input);
            IEnumerable<Flight> result = await ExecStoredProcedure<Flight>("AddFlight", parameters);
            return _mapper.Map<FlightDTO>(result.First());
        }
        public async Task UpdateFlight(Guid id, CreateFlightDTO flight)
        {
            var parameters = new DynamicParameters();
            parameters.Add("flight_id", id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("airl_id", flight.Airline_Id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("dest_id", flight.Dest_Airport_Id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("orig_id", flight.Orig_Airport_Id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("take_off", flight.Take_Off, DbType.DateTime, ParameterDirection.Input);
            await ExecStoredProcedure<Flight>("UpdateFlight", parameters);
        }
        public async Task DeleteFlight(Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("flight_id", id, DbType.Guid, ParameterDirection.Input);
            await ExecStoredProcedure<Flight>("DeleteFlight", parameters);
        }
        #endregion

        #region FlightSection
        public async Task<IEnumerable<SeatclassDTO>> GetSeatclasses()
        {
            var parameters = new DynamicParameters();
            IEnumerable<SeatclassDTO> result = await ExecStoredProcedure<SeatclassDTO>("GetSeatclasses", parameters);
            return _mapper.Map<IEnumerable<SeatclassDTO>>(result);
        }

        public async Task<FlightSectionDTO> GetFlightSection(Guid flight_id, Guid seatclass_id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("flight_id", flight_id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("seatclass_id", seatclass_id, DbType.Guid, ParameterDirection.Input);
            IEnumerable<FlightSection> result = await ExecStoredProcedure<FlightSection>("GetFlightSection", parameters);
            return _mapper.Map<FlightSectionDTO>(result.First());
        }
        public async Task<IEnumerable<SeatclassDTO>> GetNotAddedSeatclasses(Guid flight_id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("flight_id", flight_id, DbType.Guid, ParameterDirection.Input);
            IEnumerable<Seatclass> result = await ExecStoredProcedure<Seatclass>("GetNotAddedSeatclasses", parameters);
            return _mapper.Map<IEnumerable<SeatclassDTO>>(result);
        }
        public async Task<IEnumerable<SeatclassDTO>> GetAddedSeatclasses(Guid flight_id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("flight_id", flight_id, DbType.Guid, ParameterDirection.Input);
            IEnumerable<Seatclass> result = await ExecStoredProcedure<Seatclass>("GetAddedSeatclasses", parameters);
            return _mapper.Map<IEnumerable<SeatclassDTO>>(result);
        }
        public async Task<IEnumerable<SeatDTO>> GetSectionSeats(Guid flight_id, Guid seatclass_id)
        {
            var flightSection = await GetFlightSection(flight_id, seatclass_id);
            var parameters = new DynamicParameters();
            parameters.Add("fl_sc_id", flightSection.Flight_Section_Id, DbType.Guid, ParameterDirection.Input);
            IEnumerable<Seat> result = await ExecStoredProcedure<Seat>("GetFlightSectionSeats", parameters);
            return _mapper.Map<IEnumerable<SeatDTO>>(result);
        }
        public async Task<IEnumerable<SeatDTO>> GetSectionFreeSeats(Guid flight_id, Guid seatclass_id)
        {
            var flightSection = await GetFlightSection(flight_id, seatclass_id);
            var parameters = new DynamicParameters();
            parameters.Add("fl_sc_id", flightSection.Flight_Section_Id, DbType.Guid, ParameterDirection.Input);
            IEnumerable<Seat> result = await ExecStoredProcedure<Seat>("GetFlightSectionFreeSeats", parameters);
            return _mapper.Map<IEnumerable<SeatDTO>>(result);
        }
        public async Task<FlightSectionDTO> CreateFlightSection(CreateFlightSectionDTO section)
        {
            var parameters = new DynamicParameters();
            parameters.Add("flight_id", section.Flight_Id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("seatclass_id", section.Seatclass_Id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("rows", section.Rows, DbType.Int32, ParameterDirection.Input);
            parameters.Add("cols", section.Cols, DbType.Int32, ParameterDirection.Input);
            IEnumerable<FlightSection> result = await ExecStoredProcedure<FlightSection>("AddFlightSection", parameters);
            return _mapper.Map<FlightSectionDTO>(result.First());
        }
        public async Task DeleteFlightSection(Guid flight_id, Guid seatclass_id)
        {
            var flightSection = await GetFlightSection(flight_id, seatclass_id);
            var parameters = new DynamicParameters();
            parameters.Add("fl_sc_id", flightSection.Flight_Section_Id, DbType.Guid, ParameterDirection.Input);
            await ExecStoredProcedure("DeleteFlightSection", parameters);
        }
        #endregion

        #region Seat
        public async Task BookSeat(SeatControlDTO seat)
        {
            var parameters = new DynamicParameters();
            parameters.Add("seat_id", seat.Seat_Id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("row", seat.Row, DbType.Int32, ParameterDirection.Input);
            parameters.Add("col", seat.Col, DbType.String, ParameterDirection.Input);
            await ExecStoredProcedure("BookSeat", parameters);
        }
        public async Task UnbookSeat(SeatControlDTO seat)
        {
            var parameters = new DynamicParameters();
            parameters.Add("seat_id", seat.Seat_Id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("row", seat.Row, DbType.Int32, ParameterDirection.Input);
            parameters.Add("col", seat.Col, DbType.String, ParameterDirection.Input);
            await ExecStoredProcedure("UnbookSeat", parameters);
        }
        #endregion

        #region Utilities
        public async Task<IEnumerable<T>> ExecStoredProcedure<T>(string storedProcedureName, DynamicParameters parameters = null)
        {
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<T>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task ExecStoredProcedure(string storedProcedureName, DynamicParameters parameters = null)
        {
            using (var connection = _context.CreateConnection())
            {
                await connection.QueryAsync(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        #endregion
    }
}

