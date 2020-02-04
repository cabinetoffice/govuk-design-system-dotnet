using System;
using System.ComponentModel.DataAnnotations;

namespace GovUkDesignSystem.Attributes.ValidationAttributes
{
    /// <summary>
    /// This class isn't strictly required anymore - it could be replace with RequiredAttribute.
    /// Leaving it for backwards compatibility, and because it may be useful to easily identify
    /// all attributes relevant to this library.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class GovUkValidateRequiredAttribute : RequiredAttribute
    {
        /// <summary>
        /// The error message to show to the user if they don't select an option
        /// <br/>
        /// <br/>GDS guidance for text input:
        /// <br/>
        /// <br/>If the input is empty
        /// <br/>- Say ‘Enter [whatever it is]’.
        /// <br/>- For example, ‘Enter your first name’..
        /// <br/>
        /// <br/>from <see cref="https://design-system.service.gov.uk/components/text-input/#error-messages"/>
        /// <br/>
        /// <br/>GDS guidance for radio buttons:
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
        public string ErrorMessageIfMissing
        {
            get
            {
                return ErrorMessage;
            }
            set
            {
                ErrorMessage = value;
            }
        }
    }
}
