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
            return _mapper.Map<IEnumerable<AirportDTO>>(result).ToList();
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
            parameters.Add("airp_new_name", airport.Name, DbType.String, ParameterDirection.Input);
            IEnumerable<Airport> result = await ExecStoredProcedure<Airport>("UpdateAirport", parameters);
        }
        public async Task DeleteAirport(Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("airp_id", id, DbType.Guid, ParameterDirection.Input);
            IEnumerable<Airport> result = await ExecStoredProcedure<Airport>("DeleteAirprot", parameters);
        }
        #endregion

        #region Airline
        public async Task<IEnumerable<AirlineDTO>> GetAirlines()
        {
            IEnumerable<Airline> result = await ExecStoredProcedure<Airline>("GetAirlines");
            return _mapper.Map<IEnumerable<AirlineDTO>>(result).ToList();
        }
        public async Task<AirlineDTO> GetAirline(Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("airl_id", id, DbType.Guid, ParameterDirection.Input);
            IEnumerable<Airline> result = await ExecStoredProcedure<Airline>("GetAirlineById", parameters);
            return _mapper.Map<AirlineDTO>(result);
        }
        public async Task<AirlineDTO> CreateAirline(CreateAirlineDTO airline)
        {
            var parameters = new DynamicParameters();
            parameters.Add("airl_name", airline.Name, DbType.String, ParameterDirection.Input);
            IEnumerable<Airport> result = await ExecStoredProcedure<Airport>("AddAirline", parameters);
            return _mapper.Map<AirlineDTO>(result);
        }
        public async Task<AirlineDTO> UpdateAirline(Guid id, CreateAirlineDTO airline)
        {
            var parameters = new DynamicParameters();
            parameters.Add("airl_id", id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("airl_new_name", airline.Name, DbType.String, ParameterDirection.Input);
            IEnumerable<Airline> result = await ExecStoredProcedure<Airline>("UpdateAirline", parameters);
            return _mapper.Map<AirlineDTO>(result);
        }
        public async Task DeleteAirline(Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("airl_id", id, DbType.Guid, ParameterDirection.Input);
            IEnumerable<Airline> result = await ExecStoredProcedure<Airline>("DeleteAirline", parameters);
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
        #endregion
    }
}

