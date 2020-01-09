using System;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class BackLinkViewModel : IHtmlText
    {

        /// <summary>
        ///     The value of the link href attribute.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        ///     Should we use javascript to intercept the click and replace it with a call to window.location.back()
        /// </summary>
        public bool OverrideWithJavascript { get; set; }

        /// <summary>
        ///     Classes to add to the anchor tag.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the anchor tag.
        /// </summary>
        [Obsolete(
            "This doesn't work yet - The GenderPayGap.WebUI.Classes.TagHelpers.AnchorTagHelper doesn't currently allow arbitrary attributes")]
        public string Attributes { get; set; }

        /// <summary>
        ///     HTML to use within the back link component.
        ///     Set this using the @&lt;text&gt;&lt;/text&gt; syntax
        /// </summary>
        public Func<object, object> Html { get; set; }

        /// <summary>
        ///     Text to use within the back link component.
        ///     If the 'Html' property is specified, this option is ignored.
        /// </summary>
        public string Text { get; set; }

    }
}
