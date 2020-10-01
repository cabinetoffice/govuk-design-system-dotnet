using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GovUkDesignSystem.Attributes;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovUkDesignSystem.HtmlGenerators
{
    internal class CheckboxesFromBoolsHtmlGenerator
    {
        internal static async Task<IHtmlContent> GenerateHtml<TModel>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, bool>> propertyExpression,
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


            // Get the value to put in the input from the post data if possible, otherwise use the value in the model 
            var boolValue =
                HtmlGenerationHelpers.GetListOfBoolValuesFromModelStateOrModel(htmlHelper.ViewData.Model,
                    propertyExpression, modelStateEntry);
            
#region ForOneItem
            //string classes = classOptions;
            // classOptions?.TryGetValue(value, out classes);
            //var checkboxItemViewModel = new CheckboxItemViewModel
            //{
            //    Value = boolValue.ToString(),
            //    Id = $"{propertyName}_{boolValue}",
            //    Checked = boolValue,
            //    Label = checkboxOption,
            //    Classes = classes
            //};

            //if (conditionalOption != null )
            //{
            //    checkboxItemViewModel.Conditional = conditionalOption;
            //}
            //ItemViewModel checkBox = checkboxItemViewModel;
#endregion
            List<ItemViewModel> checkboxes = checkboxOptions.Select(kvp =>
                {
                    string value = kvp.Key;
                    LabelViewModel label = kvp.Value ?? new LabelViewModel { Text = value };

                    string classes = null;
                    classOptions?.TryGetValue(value, out classes);

                    var checkboxItemViewModel = new CheckboxItemViewModel
                    {
                        Value = "true",
                        Id = $"{propertyName}_{value}",
                        Checked = bool.Parse(value),
                        Label = label,
                        Classes = classes
                    };

                    if (conditionalOptions != null &&
                        conditionalOptions.TryGetValue(value, out Conditional conditional))
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