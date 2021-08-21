using System.Collections.Generic;

namespace WebAbsApi.Data
{
    public class Airport
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Flight> OriginToFlights { get; set; }
        public ICollection<Flight> DestinationToFlights { get; set; }
    }
}
