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
            return _mapper.Map<AirportDTO>(result);
        }
        public async Task<AirportDTO> CreateAirport(CreateAirportDTO airport)
        {
            var parameters = new DynamicParameters();
            parameters.Add("airp_name", airport.Name, DbType.String, ParameterDirection.Input);
            IEnumerable<Airport> result = await ExecStoredProcedure<Airport>("AddAirport", parameters);
            return _mapper.Map<AirportDTO>(result);
        }
        public async Task<AirportDTO> UpdateAirport(Guid id, CreateAirportDTO airport)
        {
            var parameters = new DynamicParameters();
            parameters.Add("airp_id", id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("airp_new_name", airport.Name, DbType.String, ParameterDirection.Input);
            IEnumerable<Airport> result = await ExecStoredProcedure<Airport>("UpdateAirport", parameters);
            return _mapper.Map<AirportDTO>(result);
        }
        public async Task DeleteAirport(Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("airp_id", id, DbType.Guid, ParameterDirection.Input);
            IEnumerable<Airport> result = await ExecStoredProcedure<Airport>("DeleteAirprot", parameters);
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

