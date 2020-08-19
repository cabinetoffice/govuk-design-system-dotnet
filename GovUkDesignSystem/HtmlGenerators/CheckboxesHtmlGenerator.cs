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
            Dictionary<TEnum, string> classOptions = null,
            Dictionary<TEnum, Conditional> conditionalOptions = null,
            string idPrefix = null,
            Dictionary<TEnum, LabelViewModel> labelOptions = null)
            where TModel : class
            where TEnum : struct, Enum
        {
            string propertyId = idPrefix + htmlHelper.IdFor(propertyExpression);
            string propertyName = idPrefix + htmlHelper.NameFor(propertyExpression);
            htmlHelper.ViewData.ModelState.TryGetValue(propertyName, out var modelStateEntry);

            // Get the value to put in the input from the post data if possible, otherwise use the value in the model 
            var selectedValues = HtmlGenerationHelpers.GetListOfEnumValuesFromModelStateOrModel(htmlHelper.ViewData.Model, propertyExpression, modelStateEntry);

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

                    string classes = null;
                    classOptions?.TryGetValue(enumValue, out classes);

                    var checkboxItemViewModel = new CheckboxItemViewModel
                    {
                        Value = enumValue.ToString(),
                        Id = $"{propertyName}_{enumValue}",
                        Checked = isEnumValueInListOfCurrentlySelectedValues,
                        Label = checkboxLabelViewModel,
                        Classes = classes
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
