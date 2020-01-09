using System;
using System.Collections.Generic;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class LabelViewModel : IHtmlText
    {

        /// <summary>
        ///     Required. The value of the for attribute, the id of the input the label is associated with.
        /// </summary>
        public string For { get; set; }

        /// <summary>
        ///     Whether the label also acts as the heading for the page.
        /// </summary>
        public bool IsPageHeading { get; set; }

        /// <summary>
        ///     Classes to add to the label tag.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the label tag.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

        /// <summary>
        ///     Required. If `html` is set, this is not required.
        ///     Text to use within the label.
        ///     If `html` is provided, the `text` argument will be ignored.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     Required. If `text` is set, this is not required.
        ///     HTML to use within the label.
        ///     If `html` is provided, the `text` argument will be ignored.
        /// </summary>
        public Func<object, object> Html { get; set; }

    }
}
