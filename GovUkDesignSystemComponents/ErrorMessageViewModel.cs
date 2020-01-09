using System;
using System.Collections.Generic;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class ErrorMessageViewModel : IHtmlText
    {

        /// <summary>
        ///     Id attribute to add to the error message span tag.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     A visually hidden prefix used before the error message. Defaults to "Error".
        /// </summary>
        public string VisuallyHiddenText { get; set; }

        /// <summary>
        ///     Classes to add to the legend.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the error message span tag.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

        /// <summary>
        ///     Required. If html is set, this is not required.
        ///     Text to use within the error message.
        ///     If html is provided, the text argument will be ignored.
        /// </summary>
        public string Text { get; set; } = "Error";

        /// <summary>
        ///     Required. If text is set, this is not required.
        ///     HTML to use within the error message.
        ///     If html is provided, the text argument will be ignored.
        /// </summary>
        public Func<object, object> Html { get; set; }

    }
}
