using System;
using System.Collections.Generic;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class TextInputViewModel
    {

        /// <summary>
        ///     Required. The id of the input.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Required. The name of the input, which is submitted with the form data.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Type of input control to render. Defaults to "text".
        /// </summary>
        public string Type { get; set; } = "text";

        /// <summary>
        ///     Optional value for input mode.
        /// </summary>
        public string InputMode { get; set; }

        /// <summary>
        ///     Optional initial value of the input.
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
        ///     Attribute to provide a regular expression pattern, used to match allowed character combinations for the input
        ///     value.
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        ///     Classes to add to the textarea.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the textarea.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

        public TextInputAppendixViewModel TextInputAppendix { get; set; }

    }

    public class TextInputAppendixViewModel : IHtmlText
    {

        /// <summary>
        ///     HTML to use after the input element.
        ///     Set this using the @&lt;text&gt;&lt;/text&gt; syntax
        /// </summary>
        public Func<object, object> Html { get; set; }

        /// <summary>
        ///     Text to use after the input element.
        ///     If either the 'Html' specified, this option is ignored.
        /// </summary>
        public string Text { get; set; }

    }
}
