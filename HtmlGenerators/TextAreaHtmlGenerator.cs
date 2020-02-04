using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovUkDesignSystem.HtmlGenerators
{
    internal static class TextAreaHtmlGenerator
    {
        internal static IHtmlContent GenerateHtml<TModel>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, string>> propertyExpression,
            int? rows = null,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            FormGroupViewModel formGroupOptions = null
        )
            where TModel : class
        {
            string propertyId = htmlHelper.IdFor(propertyExpression);
            string propertyName = htmlHelper.NameFor(propertyExpression);
            htmlHelper.ViewData.ModelState.TryGetValue(propertyName, out var modelStateEntry);

            // Get the value to put in the input from the post data if possible, otherwise use the value in the model
            string inputValue = null;
            if (modelStateEntry != null && modelStateEntry.RawValue != null)
            {
                inputValue = modelStateEntry.RawValue as string;
            }
            else
            {
                var modelValue = ExpressionHelpers.GetPropertyValueFromModelAndExpression(htmlHelper.ViewData.Model, propertyExpression);
                if (modelValue != null)
                {
                    inputValue = modelValue.ToString();
                }
            }

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

            if (modelStateEntry != null && modelStateEntry.Errors.Count > 0)
            {
                textAreaViewModel.ErrorMessage = new ErrorMessageViewModel { Text = string.Join(", ", modelStateEntry.Errors.Select(e => e.ErrorMessage)) };
            }

            return htmlHelper.Partial("/GovUkDesignSystemComponents/Textarea.cshtml", textAreaViewModel);
        }
    }
}
