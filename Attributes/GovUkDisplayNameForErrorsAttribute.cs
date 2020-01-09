using System;

namespace GovUkDesignSystem.Attributes
{
    public class GovUkDisplayNameForErrorsAttribute : Attribute
    {
        /// <summary>
        /// The name as it would appear at the start of a sentence
        /// <br/>e.g. "[Full name] must be 2 characters or more"
        /// <br/>e.g. "[Median age] must be a number"
        /// </summary>
        public string NameAtStartOfSentence { get; set; }

        /// <summary>
        /// The name as it would appear within / at the end of a sentence
        /// <br/>e.g. "Enter [your full name]"
        /// <br/>or "Enter [the median age]"
        /// </summary>
        public string NameWithinSentence { get; set; }

    }
}