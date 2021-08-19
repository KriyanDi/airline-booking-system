using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebAbsApi.Models.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AirlineName : ValidationAttribute
    {
        public override bool IsValid(object value) => Regex.Match(value.ToString(), @"^[A-Z0-9]{1,5}$").Success;
    }
}
