using System;

namespace GovUkDesignSystem.Attributes.DataBinding
{
    public class GovUkDataBindingDateErrorTextAttribute : GovUkDataBindingErrorTextAttribute
    {
        public GovUkDataBindingDateErrorTextAttribute(string errorMessageIfMissing, string nameAtStartOfSentence, string nameWithinSentence)
        {
            if (string.IsNullOrEmpty(nameAtStartOfSentence))
            {
                throw new ArgumentNullException("nameAtStartOfSentence cannot be null or empty");
            }
            if (string.IsNullOrEmpty(nameWithinSentence))
            {
                throw new ArgumentNullException("nameWithinSentence cannot be null or empty");
            }
            NameWithinSentence = nameWithinSentence;
            NameAtStartOfSentence = nameAtStartOfSentence;
        }
        /// <summary>
        /// The name as it would appear at the start of a sentence
        /// <br/>e.g. "[Date of birth] must include a day"
        /// </summary>
        public string NameAtStartOfSentence { get; private set; }

        /// <summary>
        /// The name as it would appear when not at the start of a sentence
        /// <br/>e.g. "Enter a real [date of birth]"
        /// </summary>
        public string NameWithinSentence { get; private set; }
    }
}