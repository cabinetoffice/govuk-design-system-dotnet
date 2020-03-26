using GovUkDesignSystem.Attributes;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GovUkDesignSystem.HtmlGenerators
{
    internal static class RadiosHtmlGenerator
    {
        internal static async Task<IHtmlContent> GenerateHtml<TModel, TEnum>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TEnum?>> propertyExpression,
            FieldsetViewModel fieldsetOptions = null,
            HintViewModel hintOptions = null,
            string classes = null,
            Dictionary<TEnum, HintViewModel> radioHints = null,
            Dictionary<TEnum, Conditional> conditionalOptions = null,
            Dictionary<TEnum, LabelViewModel> labelOptions = null,
            string idPrefix = null)
            where TModel : class
            where TEnum : struct, Enum
        {
            string propertyId = idPrefix + htmlHelper.IdFor(propertyExpression);
            string propertyName = idPrefix + htmlHelper.NameFor(propertyExpression);
            htmlHelper.ViewData.ModelState.TryGetValue(propertyName, out var modelStateEntry);

            // Normally we'd want to get our values from the post data first. However with a list of radio buttons we only
            // care about valid submitted values (invalid values mean someone is messing around with PostMan or similar)
            // so we can just use the model values straight away.
            TEnum? selectedValue = ExpressionHelpers.GetPropertyValueFromModelAndExpression(htmlHelper.ViewData.Model, propertyExpression);

            List<ItemViewModel> radios = Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(enumValue =>
                {
                    bool isEnumValueCurrentlySelected = selectedValue.HasValue && enumValue.Equals(selectedValue.Value);
                    if (labelOptions == null || !labelOptions.TryGetValue(enumValue, out LabelViewModel radioLabelViewModel))
                    {
                        radioLabelViewModel = new LabelViewModel
                        {
                            Text = GovUkRadioCheckboxLabelTextAttribute.GetLabelText(enumValue)
                        };
                    }
                    HintViewModel itemHint = null;

                    radioHints?.TryGetValue(enumValue, out itemHint);

                    var radioItemViewModel = new RadioItemViewModel
                    {
                        Value = enumValue.ToString(),
                        Id = $"{propertyId}_{enumValue}",
                        Checked = isEnumValueCurrentlySelected,
                        Label = radioLabelViewModel,
                        Hint = itemHint
                    };

                    if (conditionalOptions != null && conditionalOptions.TryGetValue(enumValue, out Conditional conditional))
                    {
                        radioItemViewModel.Conditional = conditional;
                    }

                    return radioItemViewModel;
                })
                .Cast<ItemViewModel>()
                .ToList();

            var radiosViewModel = new RadiosViewModel
            {
                Name = propertyName,
                Classes = classes,
                IdPrefix = propertyId,
                Items = radios,
                Fieldset = fieldsetOptions,
                Hint = hintOptions
            };

            HtmlGenerationHelpers.SetErrorMessages(radiosViewModel, modelStateEntry);

            return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Radios.cshtml", radiosViewModel);
        }
    }
}
