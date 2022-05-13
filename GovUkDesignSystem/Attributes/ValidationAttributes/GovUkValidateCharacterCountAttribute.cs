using System;
using System.ComponentModel.DataAnnotations;

namespace GovUkDesignSystem.Attributes.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GovUkValidateCharacterCountAttribute : ValidationAttribute
    {
        public int MaxCharacters { get; set; }

        /// <summary>
        /// Whether a value must be supplied
        /// </summary>
        public bool IsRequired { get; set; } = false;

        /// <summary>
        /// The name as it would appear at the start of a sentence
        /// <br/>e.g. "[Full name] must be 2 characters or more"
        /// <br/>e.g. "[Median age] must be a number"
        /// </summary>
        public string NameAtStartOfSentence { get; set; }

        /// <summary>
        /// The name as it would appear within / at the end of a sentence
        /// <br/>e.g. "Enter [your full name]"
        /// <br/>or "Enter [the median age]"
        /// </summary>
        public string NameWithinSentence { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(NameAtStartOfSentence))
            {
                throw new ArgumentNullException("NameAtStartOfSentence cannot be null or empty");
            }
            if (string.IsNullOrEmpty(NameWithinSentence))
            {
                throw new ArgumentNullException("NameWithinSentence cannot be null or empty");
            }

            var stringValue = (string)value;

            if (IsRequired &&
                string.IsNullOrEmpty(stringValue))
            {
                return new ValidationResult($"Enter {NameWithinSentence}");
            }

            if (stringValue != null &&
                stringValue.Length > MaxCharacters)
            {
                return new ValidationResult($"{NameAtStartOfSentence} must be {MaxCharacters} characters or fewer");
            }

            return ValidationResult.Success;
        }
    }
}
