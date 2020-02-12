using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;
using System;
using System.Collections.Generic;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class AccordionViewModel
    {
        public string Id { get; set; }
        
        public int HeadingLevel { get; set; }

        public List<AccordionSectionViewModel> Sections { get; set; }

        /// <summary>
        ///     Classes to add to the accordion container.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the accordion component.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }
    }
    public class AccordionSectionViewModel
    {
        public bool Expanded { get; set; }
        public int HeadingLevel { get; set; } = 2;
        public AccordionSectionItemViewModel Heading { get; set; }
        public AccordionSectionItemViewModel Summary { get; set; }
        public AccordionSectionItemViewModel Content { get; set; }
    }

    public class AccordionSectionItemViewModel : IHtmlText
    {
        /// <summary>
        ///     HTML to use for the section item.
        ///     Set this using the @&lt;text&gt;&lt;/text&gt; syntax
        /// </summary>
        public Func<object, object> Html { get; set; }

        /// <summary>
        ///     Text to use for the section item.
        ///     If the 'Html' property is specified, this option is ignored.
        /// </summary>
        public string Text { get; set; }
    }
}
