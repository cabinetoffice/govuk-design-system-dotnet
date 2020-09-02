using System.Collections.Generic;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class SelectItemViewModel
    {
        /// <summary>
        ///     Required. Value for the input.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        ///     Required. Text to use within the option.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     If true, item will be selected.
        /// </summary>
        public bool Selected { set; get; }

        /// <summary>
        ///     If true, item will be disabled.
        /// </summary>
        public bool Disabled { set; get; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the option tag.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }
    }
}