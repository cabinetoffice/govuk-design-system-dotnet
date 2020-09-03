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

            // Get the value to put in the input from the post data if possible, otherwise use the value in the model 
            var selectedValue = HtmlGenerationHelpers.GetStringValueFromModelStateOrModel(modelStateEntry, htmlHelper.ViewData.Model, propertyExpression);

            List<ItemViewModel> radios = radioOptions.Select(kvp =>
                {
                    string value = kvp.Key;
                    LabelViewModel label = kvp.Value ?? new LabelViewModel { Text = value };

                    HintViewModel itemHint = null;

                    radioHints?.TryGetValue(value, out itemHint);

                    var radioItemViewModel = new RadioItemViewModel
                    {
                        Value = value,
                        Id = $"{propertyId}_{value}",
                        Checked = value == selectedValue,
                        Label = label,
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
