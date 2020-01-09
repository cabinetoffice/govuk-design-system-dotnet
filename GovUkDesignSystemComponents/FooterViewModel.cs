using System;
using System.Collections.Generic;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class FooterViewModel
    {

        /// <summary>
        ///     Object containing options for the meta navigation.
        /// </summary>
        public FooterMetaNavigationViewModel MetaNavigation { get; set; }

        /// <summary>
        ///     Array of items for use in the navigation section of the footer.
        /// </summary>
        public ICollection<FooterNavigationSectionViewModel> NavigationSections { get; set; }

        /// <summary>
        ///     Classes that can be added to the inner container, useful if you want to make the footer full width.
        /// </summary>
        public string ContainerClasses { get; set; }

        /// <summary>
        ///     Classes to add to the footer component container.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the footer component container.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

    }

    public class FooterMetaNavigationViewModel : IHtmlText
    {

        /// <summary>
        ///     Title for a meta item section, which defaults to Support links
        /// </summary>
        public string VisuallyHiddenTitle { get; set; }

        /// <summary>
        ///     Collection of items for use in the meta section of the footer.
        /// </summary>
        public ICollection<FooterLinksViewModel> Links { get; set; }

        /// <summary>
        ///     HTML to add to the meta section of the footer.
        ///     This will appear below any links specified using the 'Items' property.
        ///     Set this using the @&lt;text&gt;&lt;/text&gt; syntax
        /// </summary>
        public Func<object, object> Html { get; set; }

        /// <summary>
        ///     Text to add to the meta section of the footer.
        ///     This will appear below any links specified using the 'Items' property.
        ///     If either the 'Html' specified, this option is ignored.
        /// </summary>
        public string Text { get; set; }

    }

    public class FooterNavigationSectionViewModel
    {

        /// <summary>
        ///     Title for a section
        /// </summary>
        public string SectionTitle { get; set; }

        /// <summary>
        ///     Amount of columns to display items in navigation section of the footer.
        /// </summary>
        public int? Columns { get; set; }

        /// <summary>
        ///     Collection of items to display in the list in navigation section of the footer.
        /// </summary>
        public ICollection<FooterLinksViewModel> Links { get; set; }

    }

    public class FooterLinksViewModel
    {

        /// <summary>
        ///     List item text in the meta section of the footer.
        ///     Both text and href attributes need to be present to create a link.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     List item href attribute in the meta section of the footer.
        ///     Both text and href attributes need to be present to create a link.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the anchor in the footer meta section.
        /// </summary>
        [Obsolete(
            "This doesn't work yet - The GenderPayGap.WebUI.Classes.TagHelpers.AnchorTagHelper doesn't currently allow arbitrary attributes")]
        public Dictionary<string, string> Attributes { get; set; }

    }
}
