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
    internal static class SelectFromStringsHtmlGenerator
    {
        internal static async Task<IHtmlContent> GenerateHtml<TModel>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, string>> propertyExpression,
            Dictionary<string, string> selectOptions,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            ErrorMessageViewModel errorMessageOptions = null,
            FormGroupViewModel formGroupOptions = null,
            string classes = null,
            Dictionary<string, string> attributeOptions = null,
            Dictionary<string, Dictionary<string, string>> itemAttributeOptions = null,
            Dictionary<string, bool> disabledOptions = null,
            string idPrefix = null)
            where TModel : class
        {
            string propertyId = idPrefix + htmlHelper.IdFor(propertyExpression);
            string propertyName = idPrefix + htmlHelper.NameFor(propertyExpression);
            htmlHelper.ViewData.ModelState.TryGetValue(propertyName, out var modelStateEntry);

            // Get the value to put in the input from the post data if possible, otherwise use the value in the model 
            var selectedValue = HtmlGenerationHelpers.GetStringValueFromModelStateOrModel(modelStateEntry, htmlHelper.ViewData.Model, propertyExpression);

            List<SelectItemViewModel> selectItems = selectOptions.Select(kvp =>
                {
                    string value = kvp.Key;
                    string text = kvp.Value ?? value;

                    bool isValueDisabled = false;
                    disabledOptions?.TryGetValue(value, out isValueDisabled);

                    Dictionary<string, string> attributes = null;
                    itemAttributeOptions?.TryGetValue(value, out attributes);

                    var selectItemViewModel = new SelectItemViewModel
                    {
                        Value = value,
                        Text = text,
                        Selected = value == selectedValue,
                        Disabled = isValueDisabled,
                        Attributes = attributes
                    };

                    return selectItemViewModel;
                })
                .ToList();

            var selectViewModel = new SelectViewModel
            {
                Id = propertyId,
                Name = propertyName,
                Classes = classes,
                Items = selectItems,
                Label = labelOptions,
                Hint = hintOptions,
                ErrorMessage = errorMessageOptions,
                FormGroup = formGroupOptions,
                Attributes = attributeOptions
            };

            HtmlGenerationHelpers.SetErrorMessages(selectViewModel, modelStateEntry);

            return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Select.cshtml", selectViewModel);
        }
    }
}
