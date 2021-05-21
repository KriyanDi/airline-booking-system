using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AirlineBookingSystem.Additional
{
    sealed public class AirportName : ValidationAttribute
    {
        public AirportName() => ErrorMessage = "Error: Airport name should be exact three capital letters long.";
        public override bool IsValid(object value) => (value is string str && Regex.IsMatch(str, @"^[A-Z]{3}$"));
    }


    sealed public class AirlineName : ValidationAttribute
    {
        public AirlineName() => ErrorMessage = "Error: Airline name should be with more than zero and less than six alphanumeric capital symbols long.";
        public override bool IsValid(object value) => (value is string str && Regex.IsMatch(str, @"^[A-Z0-9]{1,5}$"));
    }


    sealed public class FlightNumber : ValidationAttribute
    {
        public FlightNumber() => ErrorMessage = "Error: Flight number should contain only numerics.";
        public override bool IsValid(object value) => (value is string str && Regex.IsMatch(str, @"^[0-9]+$"));
    }


    sealed public class SeatSection : ValidationAttribute
    {
        public SeatSection() => ErrorMessage = "Error: Seat row should be number between 1 - 100 and seat column should be between 1 - 10";
        public override bool IsValid(object value)
        {
            // Try-catch is used instead of "value is (int,char)" because C# 7.3 does not support this
            try
            {
                return 1 <= ((Seat[,])value).GetLength(0) && ((Seat[,])value).GetLength(0) <= 100 &&
                     1 <= ((Seat[,])value).GetLength(1) && ((Seat[,])value).GetLength(1) <= 10;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
