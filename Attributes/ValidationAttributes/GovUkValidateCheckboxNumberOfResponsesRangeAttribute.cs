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
        /// The error message to show to the user if they don't select an option.
        /// Leave null if the value is not required
        /// <br/>
        /// <br/>GDS guidance:
        /// <br/>
        /// <br/>If nothing is selected and the question has options in it
        /// <br/>- Say "Select if [whatever it is]".
        /// <br/>- For example, "Select if you are British, Irish or a citizen of a different country".
        /// <br/>
        /// <br/>If nothing is selected and the question does not have options in it
        /// <br/>- Say "Select [whatever it is]".
        /// <br/>- For example, "Select your nationality or nationalities".
        /// <br/>
        /// <br/>from <see cref="https://design-system.service.gov.uk/components/checkboxes/#error-messages"/>
        /// </summary>
        public string ErrorMessageIfNothingSelected { get; set; }

        /// <summary>
        /// The name to use within error messages about the number of selected options
        /// </summary>
        public string PropertyNameForErrorMessage { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var selectedValues = (IList)value;

            if (!string.IsNullOrEmpty(ErrorMessageIfNothingSelected) &&
                selectedValues.Count == 0)
            {
                return new ValidationResult(ErrorMessageIfNothingSelected);
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
