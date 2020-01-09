using System;
using System.Collections.Generic;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class ButtonViewModel : IHtmlText
    {

        /// <summary>
        ///     Whether to use an input, button or a element to create the button.
        ///     <br/>In most cases you will not need to set this as it will be configured automatically if you use href or html.
        /// </summary>
        public string Element { get; set; }

        /// <summary>
        ///     Name for the input or button.
        ///     <br/>This has no effect on a elements.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Type of input or button – button, submit or reset.
        ///     <br/>Defaults to submit. This has no effect on a elements.
        /// </summary>
        public string Type { get; set; } = "submit";

        /// <summary>
        ///     Required. Value for the button tag.
        ///     <br/>This has no effect on a or input elements.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        ///     Whether the button should be disabled.
        ///     <br/>For button and input elements, disabled and aria-disabled attributes will be set automatically.
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        ///     The URL that the button should link to.
        ///     <br/>If this is set, element will be automatically set to a if it has not already been defined.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        ///     Prevent accidental double clicks on submit buttons from submitting forms multiple times
        /// </summary>
        public bool PreventDoubleClick { get; set; }

        /// <summary>
        ///     Use for the main call to action on your service's start page.
        /// </summary>
        public bool IsStartButton { get; set; }

        /// <summary>
        ///     Classes to add to the label tag.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the label tag.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

        /// <summary>
        ///     Required. If html is set, this is not required. Text for the button or link.
        ///     If html is provided, the text argument will be ignored and element will be automatically set to button unless href
        ///     is also set,
        ///     or it has already been defined. This argument has no effect if element is set to input.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     Required. If text is set, this is not required. HTML for the button or link.
        ///     If html is provided, the text argument will be ignored and element will be automatically set to button unless href
        ///     is also set,
        ///     or it has already been defined. This argument has no effect if element is set to input.
        /// </summary>
        public Func<object, object> Html { get; set; }

    }
}
