using System;
using System.Collections.Generic;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class TagViewModel : IHtmlText
    {

        /// <summary>
        ///     Classes to add to the tag.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the tag.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

        /// <summary>
        ///     HTML to use within the tag component.
        ///     Set this using the @&lt;text&gt;&lt;/text&gt; syntax
        /// </summary>
        public Func<object, object> Html { get; set; }

        /// <summary>
        ///     Text to use within the tag component.
        ///     If either the 'Html' specified, this option is ignored.
        /// </summary>
        public string Text { get; set; }

    }
}
