using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAbsApi.Data
{
    public class SeatControlDTO
    {
        public Guid Seat_Id { get; set; }
        public int Row { get; set; }
        public string Col { get; set; }
    }

    public class SeatDTO : SeatControlDTO
    {
        public bool Booked { get; set; }
    }

    public class SeatclassDTO
    {
        public Guid Seatclass_Id { get; set; }
        public string Type { get; set; }
    }

    public class CreateFlightSectionDTO
    {
        public Guid Flight_Id { get; set; }
        public Guid Seatclass_Id { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }
    }

    public class FlightSectionDTO : CreateFlightSectionDTO
    {
        public Guid Flight_Section_Id { get; set; }
    }
}
