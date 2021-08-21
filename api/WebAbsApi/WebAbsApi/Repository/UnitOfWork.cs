using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAbsApi.Data;
using WebAbsApi.IRepository;

namespace WebAbsApi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        private IGenericRepository<Airport> _airports;
        private IGenericRepository<Airline> _airlines;
        private IGenericRepository<Flight> _flights;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IGenericRepository<Airport> Airports => _airports ??= new GenericRepository<Airport>(_context);

        public IGenericRepository<Airline> Airlines => _airlines ??= new GenericRepository<Airline>(_context);

        public IGenericRepository<Flight> Flights => _flights ??= new GenericRepository<Flight>(_context);

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Disposal()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
