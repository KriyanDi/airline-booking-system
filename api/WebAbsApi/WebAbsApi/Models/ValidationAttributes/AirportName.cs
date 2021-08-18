using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebAbsApi.Models.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    sealed public class AirportName : ValidationAttribute
    {
        public override bool IsValid(object value) => Regex.Match(value.ToString(), @"^[A-Z]{3}$").Success;
    }
}