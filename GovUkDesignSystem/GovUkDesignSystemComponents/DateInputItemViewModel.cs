using System.Collections.Generic;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class DateInputItemViewModel
    {
        /// <summary>
        /// 	Item-specific id. If provided, it will be used instead of the generated id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 	Required. Item-specific name attribute.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 	Required. Item-specific label text. If provided, this will be used instead of Name for item label text.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 	If provided, it will be used as the initial value of the input.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 	Attribute to identify input purpose, for instance "postal-code" or "username".
        /// </summary>
        public string Autocomplete { get; set; }

        /// <summary>
        /// 	Attribute to provide a regular expression pattern, used to match allowed character combinations for the input value.
        /// </summary>
        public string Pattern { get; set; } = "[0-9]*";

        /// <summary>
        ///     Classes to add to date input item.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        /// 	HTML attributes (for example data attributes) to add to the date input tag.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

    }
}
