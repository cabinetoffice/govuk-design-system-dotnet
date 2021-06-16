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
    internal static class SelectHtmlGenerator
    {
        internal static async Task<IHtmlContent> GenerateHtml<TModel, TEnum>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TEnum?>> propertyExpression,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            ErrorMessageViewModel errorMessageOptions = null,
            FormGroupViewModel formGroupOptions = null,
            string classes = null,
            Dictionary<string, string> attributeOptions = null,
            Dictionary<TEnum, Dictionary<string, string>> itemAttributeOptions = null,
            Dictionary<TEnum, string> textOptions = null,
            Dictionary<TEnum, bool> disabledOptions = null,
            string idPrefix = null)
            where TModel : class
            where TEnum : struct, Enum
        {
            string propertyId = idPrefix + htmlHelper.IdFor(propertyExpression);
            string propertyName = idPrefix + htmlHelper.NameFor(propertyExpression);
            htmlHelper.ViewData.ModelState.TryGetValue(propertyName, out var modelStateEntry);

            // Get the value to put in the input from the post data if possible, otherwise use the value in the model 
            TEnum? selectedValue = HtmlGenerationHelpers.GetNullableEnumValueFromModelStateOrModel(htmlHelper.ViewData.Model, propertyExpression, modelStateEntry);

            List<SelectItemViewModel> selectItems = Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(enumValue =>
                {
                    bool isEnumValueCurrentlySelected = selectedValue.HasValue && enumValue.Equals(selectedValue.Value);

                    bool isEnumValueDisabled = false;
                    disabledOptions?.TryGetValue(enumValue, out isEnumValueDisabled);

                    if (textOptions == null || !textOptions.TryGetValue(enumValue, out string text))
                    {
                        text = enumValue.ToString();
                    }

                    Dictionary<string, string> attributes = null;
                    itemAttributeOptions?.TryGetValue(enumValue, out attributes);

                    var selectItemViewModel = new SelectItemViewModel
                    {
                        Value = enumValue.ToString(),
                        Text = text,
                        Selected = isEnumValueCurrentlySelected,
                        Disabled = isEnumValueDisabled,
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