using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Airports
{
    public enum AirportOperation
    {
        // Basic
        Succeded,
        Failed,

        // Airport Name
        InvalidNameLenghtFailure,
        InvalidNameNullFailure,
        InvalidNameFormatFailure
    }
}
