using System;
using System.ComponentModel.DataAnnotations;

namespace GovUkDesignSystem.Attributes.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GovUkValidateRequiredIfAttribute: GovUkValidateRequiredAttribute
    {
        public string IsRequiredPropertyName;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var isRequiredPropertyInfo = validationContext.ObjectInstance.GetType().GetProperty(IsRequiredPropertyName);
            
            if (isRequiredPropertyInfo is null)
            {
                throw new ArgumentException(
                    "'isRequiredPropertyName' must be a boolean property in the model the attribute is included in");
            }
            
            var isRequired = (bool)isRequiredPropertyInfo.GetValue(validationContext.ObjectInstance, null)!;
            
            if (isRequired && value is null)
            {
                return new ValidationResult(ErrorMessageIfMissing);
            }
            return ValidationResult.Success;
        }
    }
}