﻿using System;
using System.Threading.Tasks;
using WebAbsApi.IRepository;

namespace WebAbsApi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly DatabaseContext _context;

        //private IGenericRepository<Airport> _airports;
        //private IGenericRepository<Airline> _airlines;
        //private IGenericRepository<Flight> _flights;
        //private IGenericRepository<FlightSection> _flightSections;
        //private IGenericRepository<Seat> _seats;
        //private IGenericRepository<Ticket> _tickets;

        //public UnitOfWork(DatabaseContext context)
        //{
        //    _context = context;
        //}

        //public IGenericRepository<Airport> Airports => _airports ??= new GenericRepository<Airport>(_context);

        //public IGenericRepository<Airline> Airlines => _airlines ??= new GenericRepository<Airline>(_context);

        //public IGenericRepository<Flight> Flights => _flights ??= new GenericRepository<Flight>(_context);

        //public IGenericRepository<FlightSection> FlightSections => _flightSections ??= new GenericRepository<FlightSection>(_context);

        //public IGenericRepository<Seat> Seats => _seats ??= new GenericRepository<Seat>(_context);

        //public IGenericRepository<Ticket> Tickets => _tickets ??= new GenericRepository<Ticket>(_context);


        //public async Task Save()
        //{
        //    await _context.SaveChangesAsync();
        //}

        //public void Disposal()
        //{
        //    _context.Dispose();
        //    GC.SuppressFinalize(this);
        //}
    }
}
