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
    internal static class CheckboxesFromStringsHtmlGenerator
    {
        internal static async Task<IHtmlContent> GenerateHtml<TModel>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, List<string>>> propertyExpression,
            Dictionary<string, LabelViewModel> checkboxOptions,
            FieldsetViewModel fieldsetOptions = null,
            HintViewModel hintOptions = null,
            Dictionary<string, string> classOptions = null,
            Dictionary<string, Conditional> conditionalOptions = null,
            string idPrefix = null)
            where TModel : class
        {
            string propertyId = idPrefix + htmlHelper.IdFor(propertyExpression);
            string propertyName = idPrefix + htmlHelper.NameFor(propertyExpression);
            htmlHelper.ViewData.ModelState.TryGetValue(propertyName, out var modelStateEntry);

            // Normally we'd want to get our values from the post data first. However with a list of checkboxes we only
            // care about valid submitted values (invalid values mean someone is messing around with PostMan or similar)
            // so we can just use the model values straight away.
            var selectedValues = ExpressionHelpers.GetPropertyValueFromModelAndExpression(htmlHelper.ViewData.Model, propertyExpression);

            List<ItemViewModel> checkboxes = checkboxOptions.Select(kvp =>
                {
                    string value = kvp.Key;
                    LabelViewModel label = kvp.Value ?? new LabelViewModel { Text = value };

                    string classes = null;
                    classOptions?.TryGetValue(value, out classes);

                    var checkboxItemViewModel = new CheckboxItemViewModel
                    {
                        Value = value,
                        Id = $"{propertyName}_{value}",
                        Checked = selectedValues.Contains(value),
                        Label = label,
                        Classes = classes
                    };

                    if (conditionalOptions != null && conditionalOptions.TryGetValue(value, out Conditional conditional))
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
    }
}
