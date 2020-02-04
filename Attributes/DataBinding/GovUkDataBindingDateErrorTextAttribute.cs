namespace GovUkDesignSystem.Attributes.DataBinding
{
    public class GovUkDataBindingDateErrorTextAttribute : GovUkDataBindingErrorTextAttribute
    {
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