using System;

namespace GovUkDesignSystem.Attributes.DataBinding
{
    public class GovUkDataBindingMandatoryIntErrorTextAttribute : GovUkDataBindingErrorTextAttribute
    {
        public GovUkDataBindingMandatoryIntErrorTextAttribute(string errorMessageIfMissing, string nameAtStartOfSentence)
        {
            if(string.IsNullOrEmpty(nameAtStartOfSentence))
            {
                throw new ArgumentNullException("nameAtStartOfSentence cannot be null or empty");
            }
            if(string.IsNullOrEmpty(errorMessageIfMissing))
            {
                throw new ArgumentNullException("errorMessageIfMissing cannot be null or empty");
            }
            NameAtStartOfSentence = nameAtStartOfSentence;
            ErrorMessageIfMissing = errorMessageIfMissing;
        }

        /// <summary>
        /// The name as it would appear at the start of a sentence
        /// <br/>e.g. "[Full name] must be 2 characters or more"
        /// <br/>e.g. "[Median age] must be a number"
        /// </summary>
        public string NameAtStartOfSentence { get; private set; }

        /// <summary>
        /// A complete sentence of the form: ‘Enter [whatever it is]’.
        /// <br/>For example, ‘Enter your first name’.
        /// </summary>
        public string ErrorMessageIfMissing { get; private set; }
    }
}