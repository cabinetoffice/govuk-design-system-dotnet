using System;

namespace GovUkDesignSystem.Attributes.DataBinding
{
    public class GovUkDataBindingOptionalDecimalErrorTextAttribute : GovUkDataBindingErrorTextAttribute
    {
        public GovUkDataBindingOptionalDecimalErrorTextAttribute(string nameAtStartOfSentence)
        {
            if (string.IsNullOrEmpty(nameAtStartOfSentence))
            {
                throw new ArgumentNullException("nameAtStartOfSentence cannot be null or empty");
            }
            NameAtStartOfSentence = nameAtStartOfSentence;
        }

        /// <summary>
        /// The name as it would appear at the start of a sentence
        /// <br/>e.g. "[Full name] must be 2 characters or more"
        /// <br/>e.g. "[Median age] must be a number"
        /// </summary>
        public string NameAtStartOfSentence { get; private set; }
    }
}