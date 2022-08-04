using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;

namespace GovUkDesignSystem.Attributes.ValidationAttributes
{
    public class GovUkValidationRegularExpressionAttribute: ValidationAttribute
    {
        
        public string Pattern { get; set;  }

        public GovUkValidationRegularExpressionAttribute(string pattern, string errorMessage)
        {
            Pattern = pattern;
            ErrorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var matches = Matches(Pattern, value as string);

            return matches ? ValidationResult.Success : new ValidationResult(ErrorMessage);
        }

        private bool Matches(string regexString, string value)
        {
            var regex = new Regex(regexString);
            // Automatically pass if value is null or empty. RequiredAttribute should be used to assert a value is not empty.
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            // We are looking for an exact match, not just a search hit. This matches what
            // the RegularExpressionValidator control does
            Match match = regex.Match(value);
            return match.Success && match.Index == 0 && match.Length == value.Length;
        }
    }
}