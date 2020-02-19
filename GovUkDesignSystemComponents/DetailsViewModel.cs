using System;
using System.Collections.Generic;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class DetailsViewModel : IHtmlText
    {
        /// <summary>
        ///     HTML to use within the summary part of @&lt;details&gt; element.
        ///     Set this using the @&lt;text&gt;&lt;/text&gt; syntax
        /// </summary>
        public Func<object, object> SummaryHtml { get; set; }

        /// <summary>
        ///     Text to use within the summary part of @&lt;details&gt; element.
        ///     If the 'SummaryText' property is specified, this option is ignored.
        /// </summary>
        public string SummaryText { get; set; }

        /// <summary>
        ///     Id to add to the details element.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     If true, details element will be expanded. 
        /// </summary>
        public bool Open { get; set; }

        /// <summary>
        ///     Classes to add to the @&lt;details&gt; element.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the @&lt;details&gt; element.
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
