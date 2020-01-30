using System;
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
            Expression<Func<TModel, string>> propertyLambdaExpression,
            int? rows = null,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            FormGroupViewModel formGroupOptions = null
        )
            where TModel : GovUkViewModel
        {
            PropertyInfo property = ExpressionHelpers.GetPropertyFromExpression(propertyLambdaExpression);

            string propertyName = property.Name;

            TModel model = htmlHelper.ViewData.Model;

            string currentValue = ExtensionHelpers.GetCurrentValue(model, property, propertyLambdaExpression);


            var textAreaViewModel = new TextAreaViewModel {
                Name = $"GovUk_Text_{propertyName}",
                Id = $"GovUk_{propertyName}",
                Value = currentValue,
                Rows = rows,
                Label = labelOptions,
                Hint = hintOptions,
                FormGroup = formGroupOptions
            };

            if (model.HasErrorFor(property))
            {
                textAreaViewModel.ErrorMessage = new ErrorMessageViewModel {Text = model.GetErrorFor(property)};
            }

            return htmlHelper.Partial("/GovUkDesignSystemComponents/Textarea.cshtml", textAreaViewModel);
        }

        internal static async Task<IHtmlContent> GenerateHtmlFromModelState<TModel>(
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

            //qq:DCC Update label for property

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
                // qq:DCC Are we OK with only displaying the first error message here?
                textAreaViewModel.ErrorMessage = new ErrorMessageViewModel { Text = modelStateEntry.Errors[0].ErrorMessage };
            }

            return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Textarea.cshtml", textAreaViewModel);
        }

    }
}
