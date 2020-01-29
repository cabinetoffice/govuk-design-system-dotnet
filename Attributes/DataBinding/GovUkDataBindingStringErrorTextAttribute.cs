using System;

namespace GovUkDesignSystem.Attributes.DataBinding
{
    public class GovUkDataBindingStringErrorTextAttribute : GovUkDataBindingErrorTextAttribute
    {
        /// <summary>
        /// A complete sentence of the form: ‘Enter [whatever it is]’.
        /// <br/>For example, ‘Enter your first name’.
        /// </summary>
        public string ErrorMessageIfMissing { get; set; }
    }
}