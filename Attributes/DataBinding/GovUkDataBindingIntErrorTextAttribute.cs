using System;

namespace GovUkDesignSystem.Attributes.DataBinding
{
    public class GovUkDataBindingIntErrorTextAttribute : GovUkDataBindingErrorTextAttribute
    {
        /// <summary>
        /// The name as it would appear at the start of a sentence
        /// <br/>e.g. "[Full name] must be 2 characters or more"
        /// <br/>e.g. "[Median age] must be a number"
        /// </summary>
        public string NameAtStartOfSentence { get; set; }

        /// <summary>
        /// A complete sentence of the form: ‘Enter [whatever it is]’.
        /// <br/>For example, ‘Enter your first name’.
        /// </summary>
        public string ErrorMessageIfMissing { get; set; }
    }
}