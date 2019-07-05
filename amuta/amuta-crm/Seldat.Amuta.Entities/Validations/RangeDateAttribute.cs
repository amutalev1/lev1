using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Seldat.Amuta.Entities.Validations
{

    class RangeDateAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int minAge = int.Parse(ConfigurationManager.AppSettings.Get("StudentMinAge"));
            int maxAge = int.Parse(ConfigurationManager.AppSettings.Get("StudentMaxAge"));
            DateTime maximumDate = DateTime.Today.AddYears(-minAge);
            DateTime minimumDate = DateTime.Today.AddYears(-maxAge);
            string validationMessage;
            if (value != null && (DateTime)value <= maximumDate && (DateTime)value >= minimumDate)
            {
                return ValidationResult.Success;
            }
            validationMessage = $"{validationContext.MemberName} must be between {minimumDate.ToShortDateString()} and {maximumDate.ToShortDateString()}";
            
            return new ValidationResult(validationMessage, new[] {validationContext.MemberName});
        }
    }

}
