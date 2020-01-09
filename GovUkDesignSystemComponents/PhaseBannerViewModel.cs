using System;
using System.Collections.Generic;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class PhaseBannerViewModel : IHtmlText
    {

        /// <summary>
        ///     The phase.
        ///     Typically "alpha" or "beta".
        /// </summary>
        public string Phase { get; set; }

        /// <summary>
        ///     Classes to add to the phase banner container.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the phase banner container.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

        /// <summary>
        ///     HTML to use within the phase banner.
        ///     Set this using the @&lt;text&gt;&lt;/text&gt; syntax
        /// </summary>
        public Func<object, object> Html { get; set; }

        /// <summary>
        ///     Text to use within the phase banner.
        ///     If  the 'Html' is specified, this option is ignored.
        /// </summary>
        public string Text { get; set; }

    }
}
