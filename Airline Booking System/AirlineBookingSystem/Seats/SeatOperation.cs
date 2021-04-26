using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Seats
{
    public enum SeatOperation
    {
        // Basic
        Succeded,
        Failed,

        // Rows Cols
        InvalidSeatRowsFailure,
        InvalidSeatColsFailure
    }
}
