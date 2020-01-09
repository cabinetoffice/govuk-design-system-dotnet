using System.Collections.Generic;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class TextAreaViewModel
    {

        /// <summary>
        ///     Required. The id of the textarea.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Required. The name of the textarea, which is submitted with the form data.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Optional number of textarea rows (default is 5 rows).
        /// </summary>
        public int? Rows { get; set; } = 5;

        /// <summary>
        ///     Optional initial value of the textarea.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        ///     One or more element IDs to add to the aria-describedby attribute,
        ///     used to provide additional descriptive information for screenreader users.
        /// </summary>
        public string DescribedBy { get; set; }

        /// <summary>
        ///     Required. Options for the label component.
        /// </summary>
        public LabelViewModel Label { get; set; }

        /// <summary>
        ///     Options for the hint component.
        /// </summary>
        public HintViewModel Hint { get; set; }

        /// <summary>
        ///     Options for the errorMessage component (e.g. text).
        /// </summary>
        public ErrorMessageViewModel ErrorMessage { get; set; }

        /// <summary>
        ///     Options for the form-group wrapper.
        /// </summary>
        public FormGroupViewModel FormGroup { get; set; }

        /// <summary>
        ///     Attribute to identify input purpose, for instance "postal-code" or "username".
        /// </summary>
        public string Autocomplete { get; set; }

        /// <summary>
        ///     Classes to add to the textarea.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the textarea.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

    }
}
