using System.ComponentModel.DataAnnotations;

namespace GovUkDesignSystem.Attributes.ValidationAttributes
{
    public class GovUkValidateDecimalRangeAttribute : RangeAttribute
    {
        // Attributes do not allow decimals as parameters, but allow for their string representation
        public GovUkValidateDecimalRangeAttribute(string propertyName, double minimum, double maximum, string customErrorMessage = null)
            : base(typeof(decimal), minimum.ToString(), maximum.ToString())
        {
            ErrorMessage = customErrorMessage ?? $"{propertyName} must be between {minimum} and {maximum}";
        }
    }
}