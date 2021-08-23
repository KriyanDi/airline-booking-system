using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebAbsApi.Models.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    sealed public class SeatClass : ValidationAttribute
    {
        public override bool IsValid(object value) => Regex.Match(value.ToString(), @"^ECONOMY|BUSINESS|FIRST$").Success;
    }
}