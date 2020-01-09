using System;
using System.Collections.Generic;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class ErrorSummaryViewModel
    {
        /// <summary>
        ///     HTML / Text to use for the heading of the error summary block.
        /// </summary>
        public ErrorSummaryTitle Title { get; set; }

        /// <summary>
        ///     HTML / Text to use for the description of the error summary block.
        /// </summary>
        public ErrorSummaryDescription Description { get; set; }

        /// <summary>
        ///     The list of individual errors
        /// </summary>
        public List<ErrorSummaryItemViewModel> Errors { get; set; }

        /// <summary>
        ///     Classes to add to the error-summary container.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the error-summary container.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }
    }

    public class ErrorSummaryTitle : IHtmlText
    {
        /// <summary>
        ///     HTML to use for the heading of the error summary block.
        ///     <br/>If `html` is provided, the `text` argument will be ignored.
        /// </summary>
        public Func<object, object> Html { get; set; }

        /// <summary>
        ///     Text to use for the heading of the error summary block.
        ///     <br/>If `html` is provided, the `text` argument will be ignored.
        /// </summary>
        public string Text { get; set; }
    }

    public class ErrorSummaryDescription : IHtmlText
    {
        /// <summary>
        ///     HTML to use for the description of the error summary block.
        ///     <br/>If `html` is provided, the `text` argument will be ignored.
        /// </summary>
        public Func<object, object> Html { get; set; }

        /// <summary>
        ///     Text to use for the description of the error summary block.
        ///     <br/>If `html` is provided, the `text` argument will be ignored.
        /// </summary>
        public string Text { get; set; }
    }

    public class ErrorSummaryItemViewModel : IHtmlText
    {
        /// <summary>
        ///     Href attribute for the error link item. If provided item will be an anchor.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        ///     HTML for the error link item.
        ///     <br/>If `html` is provided, the `text` argument will be ignored.
        /// </summary>
        public Func<object, object> Html { get; }

        /// <summary>
        ///     Text for the error link item.
        ///     <br/>If `html` is provided, the `text` argument will be ignored.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the error link anchor.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }
    }
}