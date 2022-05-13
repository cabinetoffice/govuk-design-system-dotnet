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
    internal static class DateInputHtmlGenerator
    {
        public static readonly string Day = "Day";
        public static readonly string Month = "Month";
        public static readonly string Year = "Year";

        internal static async Task<IHtmlContent> GenerateHtml<TModel>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, DateTime?>> propertyLambdaExpression,
            string classes,
            LabelViewModel labelOptions,
            HintViewModel hintOptions,
            FieldsetViewModel fieldsetOptions,
            FormGroupViewModel formGroupOptions,
            Dictionary<string, string> attributes,
            bool disabled,
            string idPrefix = null
        )
            where TModel : class
        {
            string propertyId = idPrefix + htmlHelper.IdFor(propertyLambdaExpression);
            string propertyName = idPrefix + htmlHelper.NameFor(propertyLambdaExpression);
            var modelSuffixes = new[] { Day, Month, Year };
            var areModelValues = true;
            htmlHelper.ViewData.ModelState.TryGetValue(propertyName, out var modelStateEntry);
            var modelStateValues = modelSuffixes.ToDictionary(m => m, m =>
            {
                if (!htmlHelper.ViewData.ModelState.TryGetValue(propertyName + "-" + m, out var modelStateSubEntry))
                {
                    areModelValues = false;
                }

                return modelStateSubEntry;
            });

            // Get the value to put in the input from the post data if possible, otherwise use the value in the model
            var inputValues = new Dictionary<string, string>();
            if (areModelValues)
            {
                inputValues = modelStateValues.ToDictionary(valuePair => valuePair.Key,
                    valuePair => valuePair.Value.RawValue.ToString());
            }
            else
            {
                var modelValue = ExpressionHelpers.GetPropertyValueFromModelAndExpression(htmlHelper.ViewData.Model, propertyLambdaExpression);
                if (modelValue != null)
                {
                    inputValues.Add(Day, modelValue.Value.Day.ToString());
                    inputValues.Add(Month, modelValue.Value.Month.ToString());
                    inputValues.Add(Year, modelValue.Value.Year.ToString());
                }
            }

            if (labelOptions != null)
            {
                labelOptions.For = propertyId;
            }

            var disabledAttributes = disabled ? new Dictionary<string, string> {{"disabled", null}} : null;

            inputValues.TryGetValue(Day, out var day);
            inputValues.TryGetValue(Month, out var month);
            inputValues.TryGetValue(Year, out var year);

            var items = new List<DateInputItemViewModel>() {
                new DateInputItemViewModel(){
                    Name = Day,
                    Classes = "govuk-input--width-2",
                    Value = day,
                    Attributes = disabledAttributes
                },
                new DateInputItemViewModel(){
                    Name = Month,
                    Classes = "govuk-input--width-2",
                    Value = month,
                    Attributes = disabledAttributes
                } ,
                new DateInputItemViewModel(){
                    Name = Year,
                    Classes = "govuk-input--width-4",
                    Value = year,
                    Attributes = disabledAttributes
                }
            };

            var dateInputViewModel = new DateInputViewModel
            {
                Id = propertyId,
                NamePrefix = propertyName,
                Hint = hintOptions,
                FormGroup = formGroupOptions,
                Fieldset = fieldsetOptions,
                Classes = classes,
                Attributes = attributes,
                Items = items
            };

            HtmlGenerationHelpers.SetErrorMessages(dateInputViewModel, modelStateEntry);

            return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/DateInput.cshtml", dateInputViewModel);
        }
    }
}
