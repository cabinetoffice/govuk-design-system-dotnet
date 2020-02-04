using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace GovUkDesignSystem.Attributes.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GovUkValidateCheckboxNumberOfResponsesRangeAttribute : ValidationAttribute
    {
        /// <summary>
        ///     The minimum number of checkboxes the user must select for us not to show an error
        ///     <br/>If this is omitted then there is no minimum
        /// </summary>
        public int MinimumSelected { get; set; } = int.MinValue;

        /// <summary>
        ///     The maximum number of checkboxes the user can select before we show an error
        ///     <br/>If this is omitted, then there is no maximum
        /// </summary>
        public int MaximumSelected { get; set; } = int.MaxValue;

        /// <summary>
        /// Whether a value must be supplied
        /// </summary>
        public bool IsRequired { get; set; } = false;

        /// <summary>
        /// The name to use within error messages about the number of selected options
        /// </summary>
        public string PropertyNameForErrorMessage { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var selectedValues = (IList)value;

            if (IsRequired &&
                selectedValues.Count == 0)
            {
                return new ValidationResult($"Enter {PropertyNameForErrorMessage}");
            }

            if (selectedValues.Count < MinimumSelected)
            {
                return new ValidationResult($"Select at least {MinimumSelected} options for {PropertyNameForErrorMessage}");
            }

            if (selectedValues.Count > MaximumSelected)
            {
                return new ValidationResult($"Select at most {MaximumSelected} options for {PropertyNameForErrorMessage}");
            }

            return ValidationResult.Success;
        }
    }
}
