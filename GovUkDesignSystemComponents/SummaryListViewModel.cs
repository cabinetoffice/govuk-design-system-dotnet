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
}
