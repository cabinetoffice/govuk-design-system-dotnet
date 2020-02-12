using System;

namespace GovUkDesignSystem.Attributes.DataBinding
{
    public class GovUkDataBindingDateErrorTextAttribute : GovUkDataBindingErrorTextAttribute
    {
        public GovUkDataBindingDateErrorTextAttribute(string errorMessageIfMissing, string nameAtStartOfSentence, string nameNotAtStartOfSentence)
        {
            if (string.IsNullOrEmpty(nameAtStartOfSentence))
            {
                throw new ArgumentNullException("nameAtStartOfSentence cannot be null or empty");
            }
            if (string.IsNullOrEmpty(nameNotAtStartOfSentence))
            {
                throw new ArgumentNullException("nameNotAtStartOfSentence cannot be null or empty");
            }
            if (string.IsNullOrEmpty(errorMessageIfMissing))
            {
                throw new ArgumentNullException("errorMessageIfMissing cannot be null or empty");
            }
            NameNotAtStartOfSentence = nameNotAtStartOfSentence;
            NameAtStartOfSentence = nameAtStartOfSentence;
            ErrorMessageIfMissing = errorMessageIfMissing;
        }
        /// <summary>
        /// The name as it would appear at the start of a sentence
        /// <br/>e.g. "[Date of birth] must include a day"
        /// </summary>
        public string NameAtStartOfSentence { get; set; }

        /// <summary>
        /// The name as it would appear when not at the start of a sentence
        /// <br/>e.g. "Enter a real [date of birth]"
        /// </summary>
        public string NameNotAtStartOfSentence { get; set; }

        /// <summary>
        /// A complete sentence of the form: ‘Enter [whatever it is]’.
        /// <br/>For example, ‘Enter your date of birth’.
        /// </summary>
        public string ErrorMessageIfMissing { get; set; }
    }
}