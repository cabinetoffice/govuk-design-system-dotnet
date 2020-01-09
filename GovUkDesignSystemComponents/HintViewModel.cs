using System;
using System.Collections.Generic;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class HintViewModel : IHtmlText
    {

        /// <summary>
        ///     Optional id attribute to add to the hint span tag.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Classes to add to the hint span tag.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the  hint span tag.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

        /// <summary>
        ///     Required. If `html` is set, this is not required.
        ///     Text to use within the hint.
        ///     If `html` is provided, the `text` argument will be ignored.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     Required. If `html` is set, this is not required.
        ///     Text to use within the hint.
        ///     If `html` is provided, the `text` argument will be ignored.
        /// </summary>
        public Func<object, object> Html { get; set; }

    }
}
