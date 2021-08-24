using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebAbsApi.Models.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    sealed public class SeatRow : ValidationAttribute
    {
        public override bool IsValid(object value) => Regex.Match(value.ToString(), @"^[1-9][0-9]?$|^100$").Success;
    }
}