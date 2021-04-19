using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.ExtensionClasses
{
    public static class CharExtension
    {
        public static bool IsLetterBetweenAAndJ(this char str)
        {
            return ('A' <= str) && (str <= 'J');
        }
    }
}
