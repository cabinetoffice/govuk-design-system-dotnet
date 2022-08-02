using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovUkDesignSystem.HtmlGenerators
{
    internal static class TextInputHtmlGenerator
    {
        internal static async Task<IHtmlContent> GenerateHtml<TModel, TProperty>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> propertyExpression,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            FormGroupViewModel formGroupOptions = null,
            string classes = null,
            TextInputAppendixViewModel textInputAppendix = null,
            string autocomplete = null,
            string placeholder = null,
            string type = null,
            bool spellcheck = false,
            string pattern = null,
            string idPrefix = null
        )
            where TModel : class
        {
            string propertyId = idPrefix + htmlHelper.IdFor(propertyExpression);
            string propertyName = idPrefix + htmlHelper.NameFor(propertyExpression);
            htmlHelper.ViewData.ModelState.TryGetValue(propertyName, out var modelStateEntry);

            // Get the value to put in the input from the post data if possible, otherwise use the value in the model
            string inputValue = HtmlGenerationHelpers.GetStringValueFromModelStateOrModel(modelStateEntry, htmlHelper.ViewData.Model, propertyExpression);

            if (labelOptions != null)
            {
                labelOptions.For = propertyId;
            }

            var textInputViewModel = new TextInputViewModel
            {
                Id = propertyId,
                Name = propertyName,
                Type = type,
                Label = labelOptions,
                Hint = hintOptions,
                FormGroup = formGroupOptions,
                Classes = classes,
                TextInputAppendix = textInputAppendix,
                Autocomplete = autocomplete,
                Placeholder = placeholder,
                Spellcheck = spellcheck,
                Value = inputValue,
                Pattern = pattern
            };

            HtmlGenerationHelpers.SetErrorMessages(textInputViewModel, modelStateEntry);

            return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/TextInput.cshtml", textInputViewModel);
        }
    }
}
