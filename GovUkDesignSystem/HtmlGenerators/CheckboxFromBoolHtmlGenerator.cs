using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GovUkDesignSystem.HtmlGenerators
{
    internal class CheckboxFromBoolHtmlGenerator
    {
        internal static async Task<IHtmlContent> GenerateHtml<TModel>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, bool>> propertyExpression,
            LabelViewModel label,
            FieldsetViewModel fieldsetOptions = null,
            HintViewModel hintOptions = null,
            string classOption = null,
            Conditional conditionalOption = null,
            string idPrefix = null)
            where TModel : class
        {
            string propertyId = idPrefix + htmlHelper.IdFor(propertyExpression);
            string propertyName = idPrefix + htmlHelper.NameFor(propertyExpression);
            htmlHelper.ViewData.ModelState.TryGetValue(propertyName, out var modelStateEntry);

            // Get the value to put in the input from the post data if possible, otherwise use the value in the model 
            var boolValue =
                HtmlGenerationHelpers.GetBoolValueFromModelStateOrModel(htmlHelper.ViewData.Model,
                    propertyExpression, modelStateEntry);

            string classes = classOption;
            var checkboxItemViewModel = new CheckboxItemViewModel
            {
                Value = "true",
                Id = $"{propertyId}",
                Checked = boolValue,
                Label = label,
                Classes = classes
            };

            if (conditionalOption != null)
            {
                checkboxItemViewModel.Conditional = conditionalOption;
            }
            ItemViewModel checkBox = checkboxItemViewModel;

            var checkboxesViewModel = new CheckboxesViewModel
            {
                Name = propertyName,
                IdPrefix = propertyId,
                Items = new List<ItemViewModel>{ checkBox },
                Fieldset = fieldsetOptions,
                Hint = hintOptions
            };

            HtmlGenerationHelpers.SetErrorMessages(checkboxesViewModel, modelStateEntry);

            return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Checkboxes.cshtml", checkboxesViewModel);
        }
    }
}