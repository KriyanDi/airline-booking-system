﻿using Microsoft.EntityFrameworkCore;
using WebAbsApi.Configurations.Entities;

namespace WebAbsApi.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AirportConfiguration());
            builder.ApplyConfiguration(new AirlineConfiguration());
            builder.ApplyConfiguration(new FlightConfiguration());
            builder.ApplyConfiguration(new FlightSectionConfiguration());
            builder.ApplyConfiguration(new SeatConfiguration());
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightSection> FlightSections { get; set; }
        public DbSet<Seat> Seats { get; set; }
    }
}
