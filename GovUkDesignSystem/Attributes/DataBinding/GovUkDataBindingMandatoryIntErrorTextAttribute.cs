using System;


namespace GovUkDesignSystem.Attributes.DataBinding
{
    public class GovUkDataBindingMandatoryIntErrorTextAttribute : GovUkDataBindingErrorTextAttribute
    {
        public GovUkDataBindingMandatoryIntErrorTextAttribute(string errorMessageIfMissing, string nameAtStartOfSentence = "", Type resourceType = null, string resourceName = "", string isWholeNumberErrorMessage = "", string mustBeNumberErrorMessage = "")
        {
            if(string.IsNullOrEmpty(nameAtStartOfSentence) && (string.IsNullOrEmpty(isWholeNumberErrorMessage) || string.IsNullOrEmpty(mustBeNumberErrorMessage)))
            {
                throw new ArgumentNullException("nameAtStartOfSentence cannot be null or empty unless all error messages are overidden");
            }

            if (resourceType == null ^ string.IsNullOrEmpty(resourceName))
            {
                throw new ArgumentNullException("resourceName or resourceType cannot be null or empty while the other is not null or empty");
            }
            
            if(string.IsNullOrEmpty(errorMessageIfMissing))
            {
                throw new ArgumentNullException("errorMessageIfMissing cannot be null or empty");
            }
            
            NameAtStartOfSentence = nameAtStartOfSentence;
            ErrorMessageIfMissing = errorMessageIfMissing;
            MustBeNumberErrorMessage = mustBeNumberErrorMessage;
            IsWholeNumberErrorMessage = isWholeNumberErrorMessage;
            ResourceType = resourceType;
            ResourceName = resourceName;
        }

        /// <summary>
        /// An override for the error message that is displayed if the value entered is not a whole number.
        /// A complete sentence of the form: ‘[Whatever it is] must be a whole number’
        /// <br/>e.g. "Median age must be a whole number"
        /// </summary>
        private string _isWholeNumberErrorMessage;
        public string IsWholeNumberErrorMessage
        {
            get => GetResourceValue(_isWholeNumberErrorMessage);
            private set => _isWholeNumberErrorMessage = value;
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

        /// <summary>
        /// A complete sentence of the form: ‘Enter [whatever it is]’.
        /// <br/>For example, ‘Enter your first name’.
        /// </summary>
        private string _errorMessageIfMissing;
        public string ErrorMessageIfMissing
        {
            get => GetResourceValue(_errorMessageIfMissing);
            private set => _errorMessageIfMissing = value;
        }
    }
}