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
            Dictionary<TEnum, Dictionary<string,string>> attributeOptions = null,
            IEnumerable<TEnum> overrideRadioValues = null,
            string idPrefix = null)
            where TModel : class
            where TEnum : struct, Enum
        {
            string propertyId = idPrefix + htmlHelper.IdFor(propertyExpression);
            string propertyName = idPrefix + htmlHelper.NameFor(propertyExpression);
            htmlHelper.ViewData.ModelState.TryGetValue(propertyName, out var modelStateEntry);

            // Get the value to put in the input from the post data if possible, otherwise use the value in the model 
            TEnum? selectedValue = HtmlGenerationHelpers.GetNullableEnumValueFromModelStateOrModel(htmlHelper.ViewData.Model, propertyExpression, modelStateEntry);

            IEnumerable<TEnum> enumRadioOptions = overrideRadioValues ?? Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            List<ItemViewModel> radios = enumRadioOptions
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

                    Dictionary<string, string> attributes = null;
                    attributeOptions?.TryGetValue(enumValue, out attributes);

                    var radioItemViewModel = new RadioItemViewModel
                    {
                        Value = enumValue.ToString(),
                        Id = $"{propertyId}_{enumValue}",
                        Checked = isEnumValueCurrentlySelected,
                        Label = radioLabelViewModel,
                        Hint = itemHint,
                        Attributes = attributes
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
