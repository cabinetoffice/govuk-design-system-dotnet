using GovUkDesignSystem.Attributes;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace GovUkDesignSystem.HtmlGenerators
{
    internal static class CheckboxesHtmlGenerator
    {
        internal static async Task<IHtmlContent> GenerateHtml<TModel, TEnum>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, List<TEnum>>> propertyExpression,
            FieldsetViewModel fieldsetOptions = null,
            HintViewModel hintOptions = null,
            Dictionary<TEnum, Conditional> conditionalOptions = null,
            string idPrefix = null,
            Dictionary<TEnum, LabelViewModel> labelOptions = null)
            where TModel : class
            where TEnum : Enum
        {
            string propertyId = idPrefix + htmlHelper.IdFor(propertyExpression);
            string propertyName = idPrefix + htmlHelper.NameFor(propertyExpression);
            htmlHelper.ViewData.ModelState.TryGetValue(propertyName, out var modelStateEntry);

            // Normally we'd want to get our values from the post data first. However with a list of checkboxes we only
            // care about valid submitted values (invalid values mean someone is messing around with PostMan or similar)
            // so we can just use the model values straight away.
            var selectedValues = ExpressionHelpers.GetPropertyValueFromModelAndExpression(htmlHelper.ViewData.Model, propertyExpression);

            List<ItemViewModel> checkboxes = Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(enumValue =>
                {
                    var isEnumValueInListOfCurrentlySelectedValues = selectedValues.Contains(enumValue);
                    if (labelOptions == null || !labelOptions.TryGetValue(enumValue, out LabelViewModel checkboxLabelViewModel))
                    {
                        checkboxLabelViewModel = new LabelViewModel
                        {
                            Text = GovUkRadioCheckboxLabelTextAttribute.GetLabelText(enumValue)
                        };
                    }
                    var checkboxItemViewModel = new CheckboxItemViewModel
                    {
                        Value = enumValue.ToString(),
                        Id = $"{propertyName}_{enumValue}",
                        Checked = isEnumValueInListOfCurrentlySelectedValues,
                        Label = checkboxLabelViewModel
                    };

                    if (conditionalOptions != null && conditionalOptions.TryGetValue(enumValue, out Conditional conditional))
                    {
                        checkboxItemViewModel.Conditional = conditional;
                    }

                    return checkboxItemViewModel;
                })
                .Cast<ItemViewModel>()
                .ToList();

            var checkboxesViewModel = new CheckboxesViewModel
            {
                Name = propertyName,
                IdPrefix = propertyId,
                Items = checkboxes,
                Fieldset = fieldsetOptions,
                Hint = hintOptions
            };

            HtmlGenerationHelpers.SetErrorMessages(checkboxesViewModel, modelStateEntry);

            return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Checkboxes.cshtml", checkboxesViewModel);
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
