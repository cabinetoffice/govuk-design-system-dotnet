using System.Collections.Generic;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public abstract class ItemSetViewModel
    {

        /// <summary>
        ///     Object containing options for the fieldset component (e.g. legend).
        /// </summary>
        public FieldsetViewModel Fieldset { get; set; }

        /// <summary>
        ///     Object containing options for the hint component (e.g. text).
        /// </summary>
        public HintViewModel Hint { get; set; }

        /// <summary>
        ///     Object containing options for the error message component (e.g. text).
        /// </summary>
        public ErrorMessageViewModel ErrorMessage { set; get; }

        /// <summary>
        ///     Object containing options for the form-group wrapper.
        /// </summary>
        public FormGroupViewModel FormGroup { set; get; }

        /// <summary>
        ///     String to prefix id for each checkbox item if no id is specified on each item.
        ///     If idPrefix is not passed, fallback to using the name attribute instead.
        /// </summary>
        public string IdPrefix { set; get; }

        /// <summary>
        ///     Required. Name attribute for each radio item.
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        ///     Classes to add to the radio container.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the radio input tag.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

        /// <summary>
        ///     Required. Array of radio items objects.
        /// </summary>
        public List<ItemViewModel> Items { set; get; }

        public abstract string StyleNamePrefix { get; }
        public abstract string ItemDesignFileName { get; }

    }
}
