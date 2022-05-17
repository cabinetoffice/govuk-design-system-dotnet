using System.ComponentModel.DataAnnotations;

namespace GovUkDesignSystem.Attributes.ValidationAttributes
{
    public class GovUkValidateIntRangeAttribute : RangeAttribute
    {
        public GovUkValidateIntRangeAttribute(string propertyName, int minimum, int maximum) : base(minimum, maximum)
        {
            ErrorMessage = $"{propertyName} must be between {minimum} and {maximum}";
        }
    }
}