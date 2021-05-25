using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirlineBookingSystem
{
    public class ValidateObject
    {
        public static bool TryValidate(object obj)
        {
            var result = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(obj, new ValidationContext(obj), result, true);
            foreach (var res in result)
            {
                Console.WriteLine(res);
            }
            return isValid;
        }
    }
}