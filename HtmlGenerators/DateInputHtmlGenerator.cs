using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovUkDesignSystem.HtmlGenerators
{
    internal static class DateInputHtmlGenerator
    {
        internal static IHtmlContent GenerateHtml<TModel>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, DateTime?>> propertyLambdaExpression,
            string classes,
            LabelViewModel labelOptions,
            HintViewModel hintOptions,
            FieldsetViewModel fieldsetOptions,
            FormGroupViewModel formGroupOptions,
            Dictionary<string, string> attributes,
            List<DateInputItemViewModel> items
        )
            where TModel : class
        {
            string propertyId = htmlHelper.IdFor(propertyLambdaExpression);
            string propertyName = htmlHelper.NameFor(propertyLambdaExpression);
            var modelSuffixes = new[] { "day", "month", "year" };
            var areModelValues = true;
            htmlHelper.ViewData.ModelState.TryGetValue(propertyName, out var modelStateEntry);
            var modelStateValues = modelSuffixes.ToDictionary(m => m, m =>
            {
                if (!htmlHelper.ViewData.ModelState.TryGetValue(propertyName + "-" + m, out var modelStateSubEntry))
                    areModelValues = false;
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
                    inputValues.Add("day", modelValue.Value.Day.ToString());
                    inputValues.Add("month", modelValue.Value.Month.ToString());
                    inputValues.Add("year", modelValue.Value.Year.ToString());
                }
            }

            if (labelOptions != null)
            {
                labelOptions.For = propertyId;
            }

            if (items == null)
            {
                inputValues.TryGetValue("day", out var day);
                inputValues.TryGetValue("month", out var month);
                inputValues.TryGetValue("year", out var year);

                items = new List<DateInputItemViewModel>() {
                    new DateInputItemViewModel(){
                        Name = "day",
                        Classes = "govuk-input--width-2",
                        Value = day
                    },
                    new DateInputItemViewModel(){
                        Name = "month",
                        Classes = "govuk-input--width-2",
                        Value = month
                    } ,
                    new DateInputItemViewModel(){
                        Name = "year",
                        Classes = "govuk-input--width-4",
                        Value = year
                    }
                };
            }

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

            if (modelStateEntry != null && modelStateEntry.Errors.Count > 0)
            {
                // qq:DCC Are we OK with only displaying the first error message here?
                dateInputViewModel.ErrorMessage = new ErrorMessageViewModel { Text = modelStateEntry.Errors[0].ErrorMessage };
            }

            return htmlHelper.Partial("/GovUkDesignSystemComponents/DateInput.cshtml", dateInputViewModel);
        }
    }
}
