using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using GovUkDesignSystem.Attributes;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovUkDesignSystem.HtmlGenerators
{
    internal static class RadiosHtmlGenerator
    {
        public static IHtmlContent GenerateHtml<TModel, TEnum>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TEnum?>> propertyExpression,
            FieldsetViewModel fieldsetOptions = null,
            HintViewModel hintOptions = null)
            where TModel : class
            where TEnum : struct, Enum
        {
            string propertyId = htmlHelper.IdFor(propertyExpression);
            string propertyName = htmlHelper.NameFor(propertyExpression);
            htmlHelper.ViewData.ModelState.TryGetValue(propertyName, out var modelStateEntry);

            // Normally we'd want to get our values from the post data first. However with a list of radio buttons we only
            // care about valid submitted values (invalid values mean someone is messing around with PostMan or similar)
            // so we can just use the model values straight away.
            string selectedValue = null;
            var modelValue = ExpressionHelpers.GetPropertyValueFromModelAndExpression(htmlHelper.ViewData.Model, propertyExpression);
            if (modelValue != null)
            {
                selectedValue = modelValue.ToString();
            }

            List<ItemViewModel> radios = Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(enumValue =>
                {
                    bool isEnumValueCurrentlySelected = enumValue.ToString() == selectedValue;
                    string radioLabelText = GovUkRadioCheckboxLabelTextAttribute.GetLabelText(enumValue);

                    return new RadioItemViewModel
                    {
                        Value = enumValue.ToString(),
                        Id = $"{propertyId}_{enumValue}",
                        Checked = isEnumValueCurrentlySelected,
                        Label = new LabelViewModel
                        {
                            Text = radioLabelText
                        }
                    };
                })
                .Cast<ItemViewModel>()
                .ToList();

            var radiosViewModel = new RadiosViewModel
            {
                Name = propertyName,
                IdPrefix = propertyId,
                Items = radios,
                Fieldset = fieldsetOptions,
                Hint = hintOptions
            };

            if (modelStateEntry != null && modelStateEntry.Errors.Count > 0)
            {
                radiosViewModel.ErrorMessage = new ErrorMessageViewModel { Text = string.Join(", ", modelStateEntry.Errors.Select(e => e.ErrorMessage)) };
            }

            return htmlHelper.Partial("/GovUkDesignSystemComponents/Radios.cshtml", radiosViewModel);
        }
    }
}