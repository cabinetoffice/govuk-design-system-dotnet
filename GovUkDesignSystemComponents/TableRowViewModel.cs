using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;
using System;
using System.Collections.Generic;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class TableCellViewModel : IHtmlText
    {
        /// <summary>
        ///     If html is set, this is not required. Text for cells in table rows. If html is provided, the text argument will be ignored.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///      If text is set, this is not required. HTML for cells in table rows. If html is provided, the text argument will be ignore.
        ///     <br/>Required. 
        /// </summary>
        public Func<object, object> Html { get; set; }

        /// <summary>
        ///     Specify format of a cell. Currently we only use "numeric".
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        ///     Classes to add to the table row cell. 
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     Specify how many columns a cell extends.
        /// </summary>
        public int Colspan { get; set; } = -1;

        /// <summary>
        ///     Specify how many rows a cell extends.
        /// </summary>
        public int Rowspan { get; set; } = -1;

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the table cell.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }
    }
    public class TableRowViewModel
    {
        public List<TableCellViewModel> Row { get; set; }
    }
}
