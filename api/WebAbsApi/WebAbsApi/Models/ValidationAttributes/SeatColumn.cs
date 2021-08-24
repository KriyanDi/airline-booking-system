using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebAbsApi.Models.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    sealed public class SeatColumn : ValidationAttribute
    {
        public override bool IsValid(object value) => Regex.Match(value.ToString(), @"^[A-J]{1}$").Success;
    }
}
