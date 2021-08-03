using AirportsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportsApi
{
    public class AirportsDbContext : DbContext
    {
        public AirportsDbContext(DbContextOptions<AirportsDbContext> options) : base(options) { }

        public DbSet<Airport> Airports { get; set; }
    }
}
