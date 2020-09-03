using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;
using System.Collections.Generic;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class SelectViewModel : IHasErrorMessage
    {
        /// <summary>
        ///     Required. The id of the select input.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Required. The name of the select input, which is submitted with the form data.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Classes to add to the select element.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     Required. Array of select item objects.
        /// </summary>
        public List<SelectItemViewModel> Items { set; get; }

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
        ///     HTML attributes (for example data attributes) to add to the select element.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }
    }
}