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
        public List<TabsListItemViewModel> TabsList { get; set; }
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
        
        public TabsListItemSectionViewModel Section { get; set; }
    }

    // Section (panel)
    public class TabsListItemSectionViewModel : IHtmlText
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public Func<object, object> Html { get; set; }

        /// <summary>
        ///     HTML attributes(for example data attributes) to add to the tab section (panel).
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }
    }
}
