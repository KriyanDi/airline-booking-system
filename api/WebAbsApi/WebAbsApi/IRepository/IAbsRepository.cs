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
        public Task<IEnumerable<AirportDTO>> GetAirports();
        public Task<AirportDTO> GetAirport(Guid id);
        public Task<AirportDTO> CreateAirport(CreateAirportDTO airport);
        public Task<AirportDTO> UpdateAirport(Guid id, CreateAirportDTO airport);
        public Task DeleteAirport(Guid id);
    }
}
