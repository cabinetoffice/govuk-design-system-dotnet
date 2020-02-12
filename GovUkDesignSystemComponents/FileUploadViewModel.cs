using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class FileUploadViewModel
    {
        /// <summary>
        /// Required. The id of the input
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Required. The name of the input, which is submitted with the form data.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Optional initial value of the input
        /// </summary>
        public IFormFile Value { get; set; }

        /// <summary>
        /// One or more element IDs to add to the aria-describedby attribute, used to provide additional descriptive information for screenreader users.
        /// </summary>
        public string DescribedBy { get; set; }

        /// <summary>
        /// Required. Options for the Label component (e.g. text).
        /// </summary>
        public LabelViewModel Label { get; set; }

        /// <summary>
        /// Options for the hint component.
        /// </summary>
        public HintViewModel Hint { get; set; }

        /// <summary>
        /// Options for the errorMessage component (e.g. text).
        /// </summary>
        public ErrorMessageViewModel ErrorMessage { get; set; }

        /// <summary>
        /// Options for the form-group wrapper
        /// </summary>
        public FormGroupViewModel FormGroup { get; set; }

        /// <summary>
        /// Classes to add to the file upload component.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        ///     HTML attributes (for example data attributes) to add to the file upload component.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }
    }
}
