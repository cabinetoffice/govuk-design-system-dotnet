using System;

namespace GovUkDesignSystem.Attributes.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GovUkValidateCheckboxNumberOfResponsesRangeAttribute : Attribute
    {
        /// <summary>
        ///     The minimum number of checkboxes the user must select for us not to show an error
        ///     <br/>If this is omitted, or has the value null, then there is no minimum
        /// </summary>
        public int? MinimumSelected { get; set; }

        /// <summary>
        ///     The maximum number of checkboxes the user can select before we show an error
        ///     <br/>If this is omitted, or has the value null, then there is no maximum
        /// </summary>
        public int? MaximumSelected { get; set; }

        /// <summary>
        /// The error message to show to the user if they don't select an option
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

    }
}
