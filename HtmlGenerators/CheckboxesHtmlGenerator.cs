using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using GovUkDesignSystem.Attributes;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovUkDesignSystem.HtmlGenerators
{
    internal static class CheckboxesHtmlGenerator
    {
        public static IHtmlContent GenerateHtml<TModel, TEnum>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, List<TEnum>>> propertyLambdaExpression,
            FieldsetViewModel fieldsetOptions = null,
            HintViewModel hintOptions = null,
            Dictionary<TEnum, Func<object, object>> conditionalOptions = null)
            where TModel : GovUkViewModel
            where TEnum : Enum
        {
            PropertyInfo property = ExpressionHelpers.GetPropertyFromExpression(propertyLambdaExpression);
            ThrowIfPropertyTypeIsNotListOfEnums<TEnum>(property);
            string propertyName = property.Name;

            TModel model = htmlHelper.ViewData.Model;
            List<TEnum> currentlySelectedValues =
                ExpressionHelpers.GetPropertyValueFromModelAndExpression(model, propertyLambdaExpression);

            List<TEnum> allEnumValues =
                Enum.GetValues(typeof(TEnum))
                    .Cast<TEnum>()
                    .ToList();

            List<ItemViewModel> checkboxes = allEnumValues
                .Select(enumValue =>
                {
                    var isEnumValueInListOfCurrentlySelectedValues =
                        currentlySelectedValues != null && currentlySelectedValues.Contains(enumValue);

                    string checkboxLabelText = GovUkRadioCheckboxLabelTextAttribute.GetLabelText(enumValue);

                    var checkboxItemViewModel = new CheckboxItemViewModel
                    {
                        Value = enumValue.ToString(),
                        Id = $"GovUk_Checkbox_{propertyName}_{enumValue}",
                        Checked = isEnumValueInListOfCurrentlySelectedValues,
                        Label = new LabelViewModel
                        {
                            Text = checkboxLabelText
                        }
                    };

                    if (conditionalOptions != null && conditionalOptions.TryGetValue(enumValue, out Func<object, object> conditionalHtml))
                    {
                        checkboxItemViewModel.Conditional = new Conditional { Html = conditionalHtml };

                    }

                    return checkboxItemViewModel;
                })
                .Cast<ItemViewModel>()
                .ToList();

            var checkboxesViewModel = new CheckboxesViewModel
            {
                Name = $"GovUk_Checkbox_{propertyName}",
                IdPrefix = $"GovUk_{propertyName}",
                Items = checkboxes,
                Fieldset = fieldsetOptions,
                Hint = hintOptions
            };
            if (model.HasErrorFor(property))
            {
                checkboxesViewModel.ErrorMessage = new ErrorMessageViewModel
                {
                    Text = model.GetErrorFor(property)
                };
            }

            return htmlHelper.Partial("/GovUkDesignSystemComponents/Checkboxes.cshtml", checkboxesViewModel);
        }

        private static void ThrowIfPropertyTypeIsNotListOfEnums<TPropertyListItem>(PropertyInfo property)
        {
            if (!typeof(TPropertyListItem).IsEnum)
            {
                throw new ArgumentException(
                    "GovUkCheckboxesFor can only be used on List<Enum> properties, " +
                    $"but was actually used on property [{property.Name}] which is a List of type [{property.PropertyType.FullName}] "
                );
            }
        }
    }
}
