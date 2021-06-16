using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovUkDesignSystem.HtmlGenerators
{
    internal static class TextAreaHtmlGenerator
    {
        internal static async Task<IHtmlContent> GenerateHtml<TModel>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, string>> propertyExpression,
            int? rows = null,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            FormGroupViewModel formGroupOptions = null,
            string idPrefix = null
        )
            where TModel : class
        {
            string propertyId = idPrefix + htmlHelper.IdFor(propertyExpression);
            string propertyName = idPrefix + htmlHelper.NameFor(propertyExpression);
            htmlHelper.ViewData.ModelState.TryGetValue(propertyName, out var modelStateEntry);

            // Get the value to put in the input from the post data if possible, otherwise use the value in the model
            string inputValue = HtmlGenerationHelpers.GetStringValueFromModelStateOrModel(modelStateEntry, htmlHelper.ViewData.Model, propertyExpression);

            if (labelOptions != null)
            {
                labelOptions.For = propertyId;
            }

            var textAreaViewModel = new TextAreaViewModel
            {
                Name = propertyName,
                Id = propertyId,
                Value = inputValue,
                Rows = rows,
                Label = labelOptions,
                Hint = hintOptions,
                FormGroup = formGroupOptions
            };

            HtmlGenerationHelpers.SetErrorMessages(textAreaViewModel, modelStateEntry);

            return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Textarea.cshtml", textAreaViewModel);
        }
    }
}
