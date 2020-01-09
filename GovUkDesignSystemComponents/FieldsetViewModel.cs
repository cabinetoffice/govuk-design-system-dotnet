using System;
using System.Collections.Generic;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class FieldsetViewModel
    {

        /// <summary>
        ///     One or more element IDs to add to the aria-describedby attribute.
        ///     Used to provide additional descriptive information for screen reader users.
        /// </summary>
        public string DescribedBy { get; set; }

        /// <summary>
        ///     Options for the legend.
        /// </summary>
        public LegendViewModel Legend { get; set; }

        /// <summary>
        ///     Optional ARIA role attribute.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        ///     Classes to add to the fieldset container.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the fieldset container.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

        public Func<object, object> InnerHtml { get; set; }

    }
}
