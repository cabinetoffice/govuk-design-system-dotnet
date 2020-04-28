using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;
using System;
using System.Collections.Generic;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class SummaryListViewModel
    {
        /// <summary>
        ///     Required. List of row item objects.
        /// </summary>
        public List<SummaryListRowViewModel> Rows { set; get; }

        /// <summary>
        ///     Classes to add to the container.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the container.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }
    }

    public class SummaryListRowViewModel
    {
        /// <summary>
        ///     Classes to add to the row div.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     Add row key. 
        /// </summary>
        public SummaryListRowKey Key { get; set; }

        /// <summary>
        ///     Add row value. 
        /// </summary>
        public SummaryListRowValue Value { get; set; }

        /// <summary>
        ///     Add row action. 
        /// </summary>
        public SummaryListRowActionViewModel Actions { get; set; }

        public bool ShowActions { get; set; }
    }

    public class SummaryListRowKey : IHtmlText
    {
        /// <summary>
        ///     HTML to use within the row key.
        ///     <br/>Required. 
        /// </summary>
        public Func<object, object> Html { get; set; }

        /// <summary>
        ///     Text to use within the row key.
        ///     <br/>If `html` is provided, the `text` argument will be ignored.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     Classes to add to the row div.
        /// </summary>
        public string Classes { get; set; }
    }

    public class SummaryListRowValue : IHtmlText
    {
        /// <summary>
        ///     HTML to use within the row value.
        ///     Set this using the @&lt;text&gt;&lt;/text&gt; syntax
        /// </summary>
        public Func<object, object> Html { get; set; }

        /// <summary>
        ///     Text to use within the row value.
        ///     <br/>If `html` is provided, the `text` argument will be ignored.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     Classes to add to the value wrapper.
        /// </summary>
        public string Classes { get; set; }
    }
    public class SummaryListRowActionViewModel
    {
        /// <summary>
        ///     Classes to add to the actions wrapper.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     List of action item objects. 
        /// </summary>
        public List<SummaryListRowActionItemViewModel> Items { get; set; }
    }
    public class SummaryListRowActionItemViewModel : IHtmlText
    {
        /// <summary>
        ///    The value of the link href attribute for an action item.
        ///     <br/>Required. 
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        ///      HTML to use within the each action item.
        ///     Set this using the @&lt;text&gt;&lt;/text&gt; syntax
        /// </summary>
        public Func<object, object> Html { get; set; }

        /// <summary>
        ///     Text to use within each action item.
        ///     <br/>If `html` is provided, the `text` argument will be ignored.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///    Actions rely on context from the surrounding content so may require additional accessible text, text supplied to this option is appended to the end, use html for more complicated scenarios.
        /// </summary>
        public string VisuallyHiddenText { get; set; }

        /// <summary>
        ///     Classes to add to the action item.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the action item.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }
    }
}
