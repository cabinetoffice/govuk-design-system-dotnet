using System;

namespace GovUkDesignSystem.Attributes.DataBinding
{
    public class GovUkDataBindingOptionalDecimalErrorTextAttribute : GovUkDataBindingErrorTextAttribute
    {
        public GovUkDataBindingOptionalDecimalErrorTextAttribute(string nameAtStartOfSentence = "", Type resourceType = null, string resourceName = "", string mustBeNumberErrorMessage = "")
        {
            if (resourceType == null ^ string.IsNullOrEmpty(resourceName))
            {
                throw new ArgumentNullException("resourceName or resourceType cannot be null or empty while the other is not null or empty");
            }
            
            if (string.IsNullOrEmpty(nameAtStartOfSentence))
            {
                throw new ArgumentNullException("nameAtStartOfSentence cannot be null or empty");
            }
            NameAtStartOfSentence = nameAtStartOfSentence;
            MustBeNumberErrorMessage = mustBeNumberErrorMessage;
            ResourceType = resourceType;
            ResourceName = resourceName;
        }
                
        /// <summary>
        /// An override for the error message that is displayed if the value entered is not a number.
        /// A complete sentence of the form: ‘[Whatever it is] must be a number’
        /// <br/>e.g. "Median age must be a number"
        /// </summary>
        private string _mustBeNumberErrorMessage;
        public string MustBeNumberErrorMessage
        {
            get => GetResourceValue(_mustBeNumberErrorMessage);
            private set => _mustBeNumberErrorMessage = value;
        }
        
        /// <summary>
        /// The name as it would appear at the start of a sentence
        /// <br/>e.g. "[Full name] must be 2 characters or more"
        /// <br/>e.g. "[Median age] must be a number"
        /// </summary>
        public string NameAtStartOfSentence { get; private set; }
    }
}