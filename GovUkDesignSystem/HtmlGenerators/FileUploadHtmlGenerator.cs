using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GovUkDesignSystem.HtmlGenerators
{
    internal static class FileUploadHtmlGenerator
    {
        internal static async Task<IHtmlContent> GenerateHtml<TModel, TProperty>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> propertyExpression,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            FormGroupViewModel formGroupOptions = null,
            string classes = null,
            string idPrefix = null)
            where TModel : class
        {
            string propertyId = idPrefix + htmlHelper.IdFor(propertyExpression);
            string propertyName = idPrefix + htmlHelper.NameFor(propertyExpression);
            htmlHelper.ViewData.ModelState.TryGetValue(propertyName, out var modelStateEntry);

            if (labelOptions != null)
            {
                labelOptions.For = propertyId;
            }

            var fileUploadViewModel = new FileUploadViewModel()
            {
                Id = propertyId,
                Name = propertyName,
                Label = labelOptions,
                Hint = hintOptions,
                FormGroup = formGroupOptions,
                Classes = classes,
            };

            HtmlGenerationHelpers.SetErrorMessages(fileUploadViewModel, modelStateEntry);

            return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/FileUpload.cshtml", fileUploadViewModel);
        }
    }
}
