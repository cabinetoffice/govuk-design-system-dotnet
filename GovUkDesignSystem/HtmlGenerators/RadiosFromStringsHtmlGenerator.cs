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
    internal static class RadiosFromStringsHtmlGenerator
    {
        internal static async Task<IHtmlContent> GenerateHtml<TModel>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, string>> propertyExpression,
            Dictionary<string, LabelViewModel> radioOptions,
            FieldsetViewModel fieldsetOptions = null,
            HintViewModel hintOptions = null,
            string classes = null,
            Dictionary<string, HintViewModel> radioHints = null,
            Dictionary<string, Conditional> conditionalOptions = null,
            string idPrefix = null)
            where TModel : class
        {
            string propertyId = idPrefix + htmlHelper.IdFor(propertyExpression);
            string propertyName = idPrefix + htmlHelper.NameFor(propertyExpression);
            htmlHelper.ViewData.ModelState.TryGetValue(propertyName, out var modelStateEntry);

            // Normally we'd want to get our values from the post data first. However with a list of radio buttons we only
            // care about valid submitted values (invalid values mean someone is messing around with PostMan or similar)
            // so we can just use the model values straight away.
            var selectedValue = ExpressionHelpers.GetPropertyValueFromModelAndExpression(htmlHelper.ViewData.Model, propertyExpression);

            List<ItemViewModel> radios = radioOptions.Select(kvp =>
                {
                    var value = kvp.Key;
                    var label = kvp.Value;
                    bool isValueCurrentlySelected = !string.IsNullOrEmpty(selectedValue) && value == selectedValue;

                    HintViewModel itemHint = null;

                    radioHints?.TryGetValue(value, out itemHint);

                    var radioItemViewModel = new RadioItemViewModel
                    {
                        Value = value,
                        Id = $"{propertyId}_{value}",
                        Checked = isValueCurrentlySelected,
                        Label = label ?? new LabelViewModel{Text = value},
                        Hint = itemHint
                    };

                    if (conditionalOptions != null && conditionalOptions.TryGetValue(value, out Conditional conditional))
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
