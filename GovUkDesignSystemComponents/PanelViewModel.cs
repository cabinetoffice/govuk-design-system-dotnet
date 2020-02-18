using System;
using System.Collections.Generic;
using GovUkDesignSystem.GovUkDesignSystemComponents.Enums;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class PanelViewModel : IHtmlText
    {
        /// <summary>
        ///     HTML to use within the summary part of @&lt;details&gt; element.
        ///     Set this using the @&lt;text&gt;&lt;/text&gt; syntax
        /// </summary>
        public Func<object, object> TitleHtml { get; set; }

        /// <summary>
        ///     Text to use within the summary part of @&lt;details&gt; element.
        ///     If the 'SummaryText' property is specified, this option is ignored.
        /// </summary>
        public string TitleText { get; set; }

        /// <summary>
        ///     Heading level, from 1 to 6. Default is 1.
        /// </summary>
        public HeadingLevel HeadingLevel { get; set; } = HeadingLevel.h1;

        /// <summary>
        ///     Classes to add to the @&lt;details&gt; element.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the panel container.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

        /// <summary>
        ///     HTML to use within the details part of @&lt;details&gt; element.
        ///     Set this using the @&lt;text&gt;&lt;/text&gt; syntax
        /// </summary>
        public Func<object, object> Html { get; set; }

        /// <summary>
        ///     Text to use within the details part of @&lt;details&gt; element.
        ///     If the 'Html' property is specified, this option is ignored.
        /// </summary>
        public string Text { get; set; }
    }
}
