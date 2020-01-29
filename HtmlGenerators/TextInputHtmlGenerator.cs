using System;
using System.Linq.Expressions;
using System.Reflection;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GovUkDesignSystem.HtmlGenerators
{
    internal static class TextInputHtmlGenerator
    {

        internal static IHtmlContent GenerateHtml<TModel, TProperty>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> propertyLambdaExpression,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            FormGroupViewModel formGroupOptions = null,
            string classes = null,
            TextInputAppendixViewModel textInputAppendix = null
        )
            where TModel : GovUkViewModel
        {
            PropertyInfo property = ExpressionHelpers.GetPropertyFromExpression(propertyLambdaExpression);

            string propertyName = property.Name;

            TModel model = htmlHelper.ViewData.Model;

            string id = $"GovUk_{propertyName}";
            string currentValue = ExtensionHelpers.GetCurrentValue(model, property, propertyLambdaExpression);

            if (labelOptions != null)
            {
                labelOptions.For = id;
            }

            var textInputViewModel = new TextInputViewModel {
                Name = $"GovUk_Text_{propertyName}",
                Id = id,
                Value = currentValue,
                Label = labelOptions,
                Hint = hintOptions,
                FormGroup = formGroupOptions,
                Classes = classes,
                TextInputAppendix = textInputAppendix
            };

            if (model.HasErrorFor(property))
            {
                textInputViewModel.ErrorMessage = new ErrorMessageViewModel {Text = model.GetErrorFor(property)};
            }

            return htmlHelper.Partial("/GovUkDesignSystemComponents/TextInput.cshtml", textInputViewModel);
        }

        internal static IHtmlContent GenerateHtmlDcc<TModel, TProperty>(//qq:DCC
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> propertyLambdaExpression,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            FormGroupViewModel formGroupOptions = null,
            string classes = null,
            TextInputAppendixViewModel textInputAppendix = null
        )
            where TModel : class
        {
            string propertyId = htmlHelper.IdFor(propertyLambdaExpression);
            string propertyName = htmlHelper.NameFor(propertyLambdaExpression);

            // Get the value to put in the input from the post data if possible, otherwise use the value in the model
            string inputValue;
            if (htmlHelper.ViewContext.ViewData.ModelState.TryGetValue(propertyName, out var entry) && entry.RawValue != null)
            {
                inputValue = entry.RawValue as string;
            }
            else
            {
                TModel model = htmlHelper.ViewData.Model;
                inputValue = ExpressionHelpers.GetPropertyValueFromModelAndExpression(model, propertyLambdaExpression).ToString();
            }

            // qq:DCC Give the label template the property name instead?
            //if (labelOptions != null)
            //{
            //    labelOptions.For = id;
            //}

            var textInputViewModel = new TextInputViewModel
            {
                Id = propertyId,
                Name = propertyName,
                Label = labelOptions,
                Hint = hintOptions,
                FormGroup = formGroupOptions,
                Classes = classes,
                TextInputAppendix = textInputAppendix,
                Value = inputValue
            };

            //qq:DCC check ModelState instead
            //if (model.HasErrorFor(property))
            //{
            //    textInputViewModel.ErrorMessage = new ErrorMessageViewModel { Text = model.GetErrorFor(property) };
            //}

            return htmlHelper.Partial("/GovUkDesignSystemComponents/TextInputDcc.cshtml", textInputViewModel);
        }
    }
}
