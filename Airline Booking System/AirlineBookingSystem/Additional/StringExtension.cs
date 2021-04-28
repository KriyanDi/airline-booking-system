using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AirlineBookingSystem
{
    public static class StringExtension
    {
        public static bool HasOnlyCapitalLetters(this String str)
        {
            return Regex.IsMatch(str, @"^[A-Z]+$");
        }
        public static bool HasOnlyCapitalLettersAndNumbers(this String str)
        {
            return Regex.IsMatch(str, @"^[A-Z0-9]+$");
        }
        public static bool HasLengthThree(this String str)
        {
            return str.Length == 3;
        }
        public static bool HasLengthMoreThanOneAndLessThanSix(this String str)
        {
            return (0 < str.Length) && (str.Length < 6);
        }
        public static bool HasOnlyNumbers(this String str)
        {
            return Regex.IsMatch(str, @"^[0-9]+$");
        }
    }
}
