using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;
using System;
using System.Collections.Generic;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class TabsViewModel
    {
        /// <summary>
        ///     This is used for the main component and to compose id attribute for each item.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     String to prefix id for each tab item if no id is specified on each item
        /// </summary>
        public string IdPrefix { get; set; }

        /// <summary>
        ///     Title for the tabs table of contents
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Classes to add to the tabs component.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the Tabs component.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

        /// <summary>
        ///     List of tab items
        /// </summary>
        public List<TabsListItemViewModel> Items { get; set; }
    }

    // Tab
    public class TabsListItemViewModel
    {
        /// <summary>
        ///     Required.Specific id attribute for the tab item.If omitted, then idPrefix string will be applied.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Required.The text label of a tab item.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        ///     HTML attributes(for example data attributes) to add to the tab.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }
        
        public TabsListItemSectionViewModel Panel { get; set; }
    }

    // Section (panel)
    public class TabsListItemSectionViewModel : IHtmlText
    {
        /// <summary>
        /// Required. If html is set, this is not required. Text to use within each tab panel. If html is provided, the text argument will be ignored.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Required. If text is set, this is not required. HTML to use within the each tab panel. If html is provided, the text argument will be ignored.
        /// </summary>
        public Func<object, object> Html { get; set; }

        /// <summary>
        ///     HTML attributes(for example data attributes) to add to the tab section (panel).
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }
    }
}
