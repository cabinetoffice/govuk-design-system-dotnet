using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GovUkDesignSystem.HtmlGenerators
{
    internal static class DateInputHtmlGenerator
    {
        public static readonly string Day = "Day";
        public static readonly string Month = "Month";
        public static readonly string Year = "Year";
        internal static IHtmlContent GenerateHtml<TModel>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, DateTime?>> propertyLambdaExpression,
            string classes,
            LabelViewModel labelOptions,
            HintViewModel hintOptions,
            FieldsetViewModel fieldsetOptions,
            FormGroupViewModel formGroupOptions,
            Dictionary<string, string> attributes
        )
            where TModel : class
        {
            string propertyId = htmlHelper.IdFor(propertyLambdaExpression);
            string propertyName = htmlHelper.NameFor(propertyLambdaExpression);
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

            inputValues.TryGetValue(Day, out var day);
            inputValues.TryGetValue(Month, out var month);
            inputValues.TryGetValue(Year, out var year);

            var items = new List<DateInputItemViewModel>() {
                new DateInputItemViewModel(){
                    Name = Day,
                    Classes = "govuk-input--width-2",
                    Value = day
                },
                new DateInputItemViewModel(){
                    Name = Month,
                    Classes = "govuk-input--width-2",
                    Value = month
                } ,
                new DateInputItemViewModel(){
                    Name = Year,
                    Classes = "govuk-input--width-4",
                    Value = year
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

            return htmlHelper.Partial("/GovUkDesignSystemComponents/DateInput.cshtml", dateInputViewModel);
        }
    }
}
