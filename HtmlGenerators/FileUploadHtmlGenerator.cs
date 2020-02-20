using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;

namespace GovUkDesignSystem.HtmlGenerators
{
    internal static class FileUploadHtmlGenerator
    {
        internal static IHtmlContent GenerateHtml<TModel, TProperty>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> propertyExpression,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            FormGroupViewModel formGroupOptions = null,
            string classes = null
        )
            where TModel : class
        {
            string propertyId = htmlHelper.IdFor(propertyExpression);
            string propertyName = htmlHelper.NameFor(propertyExpression);
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

            return htmlHelper.Partial("/GovUkDesignSystemComponents/FileUpload.cshtml", fileUploadViewModel);
        }
    }
}
