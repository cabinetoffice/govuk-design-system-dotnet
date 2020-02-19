using System.Collections.Generic;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class DateInputViewModel
    {
        /// <summary>
        ///     Required. The id of the input.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     The prefix for each Item name using -
        /// </summary>
        public string NamePrefix { get; set; }

        /// <summary>
        ///     List of Items to render as date inputs.
        ///     This will only work with the custom automatic data binding if the three items are called 'day', 'month', and 'year', and if they do not have ids.
        /// </summary>
        public List<DateInputItemViewModel> Items { get; set; }

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
        ///     Object containing options for the fieldset component (e.g. legend).
        /// </summary>
        public FieldsetViewModel Fieldset { get; set; }

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
