using System;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class LegendViewModel : IHtmlText
    {

        /// <summary>
        ///     Whether the legend also acts as the heading for the page.
        /// </summary>
        public bool IsPageHeading { get; set; }

        /// <summary>
        ///     Classes to add to the legend.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     Required. If html is set, this is not required.
        ///     Text to use within the legend.
        ///     If html is provided, the text argument will be ignored.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     Required. If text is set, this is not required.
        ///     HTML to use within the legend.
        ///     If html is provided, the text argument will be ignored.
        /// </summary>
        public Func<object, object> Html { get; set; }

    }
}
