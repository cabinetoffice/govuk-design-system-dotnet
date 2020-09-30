using System.Collections.Generic;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class CheckboxViewModel : IHasErrorMessage
    {
        /// <summary>
        ///     Specific id attribute for the item.
        ///     If omitted, then idPrefix string will be applied.
        /// </summary>
        public string Id { set; get; }

        /// <summary>
        ///     Required. Name attribute for all items.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Required. Value for the input.
        /// </summary>
        public string Value { set; get; }

        /// <summary>
        ///     Extra classes for item.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     Provide attributes and classes to each item label.
        /// </summary>
        public LabelViewModel Label { set; get; }

        /// <summary>
        ///     Provide hint to each item.
        /// </summary>
        public HintViewModel Hint { set; get; }

        /// <summary>
        ///     Content provided will be revealed when the item is checked.
        /// </summary>
        public Conditional Conditional { set; get; }

        /// <summary>
        ///     Divider text to separate items, for example the text "or".
        /// </summary>
        public string Divider { set; get; }

        /// <summary>
        ///     If true, item will be checked.
        /// </summary>
        public bool Checked { set; get; }

        /// <summary>
        ///     If true, item will be disabled.
        /// </summary>
        public bool Disabled { set; get; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the input tag.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

        public string StyleNamePrefix { get; } = "govuk-checkbox";

        // public string InputType { get; } = "checkbox";

        public ErrorMessageViewModel ErrorMessage { get; set; }
    }
}
