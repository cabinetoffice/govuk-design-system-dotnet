using System;
using System.Collections.Generic;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class BreadcrumbsViewModel
    {

        public List<CrumbViewModel> Crumbs { get; set; }

        /// <summary>
        ///     Classes to add to the breadcrumbs container.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the breadcrumbs container.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

    }

    public class CrumbViewModel : IHtmlText
    {

        /// <summary>
        ///     Link for the breadcrumbs item. If not specified, breadcrumbs item is a normal list item.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        ///     HTML to use within the breadcrumbs item component.
        ///     Set this using the @&lt;text&gt;&lt;/text&gt; syntax
        /// </summary>
        public Func<object, object> Html { get; set; }

        /// <summary>
        ///     Text to use within the breadcrumbs item component.
        ///     If the 'Html' property is specified, this option is ignored.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the individual crumb.
        /// </summary>
        [Obsolete(
            "This doesn't work yet - The GenderPayGap.WebUI.Classes.TagHelpers.AnchorTagHelper doesn't currently allow arbitrary attributes")]
        public string Attributes { get; set; }

    }
}
