using System;

namespace GovUkDesignSystem.Attributes.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GovUkValidateRequiredAttribute : Attribute
    {
        /// <summary>
        /// The error message to show to the user if they don't select an option
        /// <br/>
        /// <br/>GDS guidance:
        /// <br/>
        /// <br/>If nothing is selected and the options are ‘yes’ and ‘no’
        /// <br/>- Say "Select yes if [whatever it is is true]".
        /// <br/>- For example, "Select yes if Sarah normally lives with you".
        /// <br/>
        /// <br/>If nothing is selected and the question has options in it
        /// <br/>- Say "Select if [whatever it is]".
        /// <br/>- For example, "Select if you are employed or self-employed".
        /// <br/>
        /// <br/>If nothing is selected and the question does not have options in it
        /// <br/>- Say "Select [whatever it is]".
        /// <br/>- For example, "Select the day of the week you pay your rent".
        /// <br/>
        /// <br/>from <see cref="https://design-system.service.gov.uk/components/radios/#error-messages"/>
        /// </summary>
        public string ErrorMessageIfMissing { get; set; }
    }
}
