using System;
using System.ComponentModel.DataAnnotations;


namespace Seldat.Amuta.Entities.Validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class RequiredPhone : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string phoneNumber = (string)validationContext.ObjectType.GetProperty("PhoneNumber").GetValue(validationContext.ObjectInstance, null);

            string cellPhoneNumber = (string)validationContext.ObjectType.GetProperty("CellphoneNumber").GetValue(validationContext.ObjectInstance, null);

            //check at least one has a value
            if (string.IsNullOrEmpty(phoneNumber) && string.IsNullOrEmpty(cellPhoneNumber))
                return new ValidationResult("At least one of PhoneNumber/CellPhoneNumber fields is required");

            return ValidationResult.Success;
        }
    }
}
