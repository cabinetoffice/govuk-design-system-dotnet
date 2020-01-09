using System;
using System.Collections.Generic;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class HeaderViewModel
    {

        /// <summary>
        ///     The url of the homepage. Defaults to /
        /// </summary>
        public string HomepageUrl { get; set; }

        /// <summary>
        ///     The public path for the assets folder. If not provided it defaults to /assets/images
        /// </summary>
        public string AssetsPath { get; set; }

        /// <summary>
        ///     Product name, used when the product name follows on directly from ‘GOV.UK’.
        ///     For example, GOV.UK Pay or GOV.UK Design System.
        ///     In most circumstances, you should use serviceName.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        ///     The name of your service, included in the header.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        ///     Url for the service name anchor.
        /// </summary>
        public string ServiceUrl { get; set; }

        /// <summary>
        ///     A collection of navigation item objects.
        /// </summary>
        public ICollection<HeaderNavigationViewModel> Navigation { get; set; }

        /// <summary>
        ///     Classes for the navigation section of the header.
        /// </summary>
        public string NavigationClasses { get; set; }

        /// <summary>
        ///     Classes for the container, useful if you want to make the header fixed width.
        /// </summary>
        public string ContainerClasses { get; set; }

        /// <summary>
        ///     Classes to add to the header container.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the header container.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

    }

    public class HeaderNavigationViewModel
    {

        /// <summary>
        ///     Text of the navigation item.
        ///     Both `href` and `text` attributes for navigation items need to be provided to create an item.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     Url of the navigation item anchor.
        ///     Both `href` and `text` attributes for navigation items need to be provided to create an item.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        ///     Flag to mark the navigation item as active or not.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        ///     Classes to add to the header link &lt;li&gt; element.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the navigation item anchor.
        /// </summary>
        [Obsolete(
            "This doesn't work yet - The GenderPayGap.WebUI.Classes.TagHelpers.AnchorTagHelper doesn't currently allow arbitrary attributes")]
        public Dictionary<string, string> Attributes { get; set; }

    }
}
