using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAbsApi.Data
{
    public class FlightDTO
    { 
        public Guid Flight_Id { get; set; }
        public Guid Airline_Id { get; set; }
        public Guid Orig_Airport_Id { get; set; }
        public Guid Dest_Airport_Id { get; set; }
        public string Flight_Number { get; set; }
        public DateTime Take_Off { get; set; }
    }

    public class FlightsInformationDTO
    {
        public Guid Flight_Id { get; set; }
        public string Flight_Number { get; set; }
        public string Airline { get; set; }
        public string Orig { get; set; }
        public string Dest { get; set; }
        public DateTime Take_Off { get; set; }
        public string Seatclass { get; set; }
        public int? Booked_Seats { get; set; }
        public int? Free_Seats { get; set; }
    }

    public class CreateFlightDTO
    {
        public Guid Airline_Id { get; set; }
        public Guid Orig_Airport_Id { get; set; }
        public Guid Dest_Airport_Id { get; set; }
        public DateTime Take_Off { get; set; }
    }
}
