using System;
using System.Collections.Generic;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class TableGovUkViewModel
    {

        /// <summary>
        ///     Required. List of table rows and cells.
        /// </summary>
        public List<TableRowViewModel> Rows { set; get; }

        /// <summary>
        ///     List of table head cells.
        /// </summary>
        public List<TableCellViewModel> Head { set; get; }

        /// <summary>
        ///     Caption text.
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        ///     Classes for caption text size. Classes should correspond to the available typography heading classes.
        /// </summary>
        public string CaptionClasses { get; set; }

        /// <summary>
        ///     	If set to true, first cell in table row will be a TH instead of a TD.
        /// </summary>
        public bool FirstCellIsHeader { get; set; }

        /// <summary>
        ///     Classes to add to the table container.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the container..
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }
    }
}
