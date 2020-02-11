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
        internal static async Task<IHtmlContent> GenerateHtml<TModel, TProperty>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> propertyLambdaExpression,
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
            htmlHelper.ViewData.ModelState.TryGetValue(propertyName, out var modelStateEntry);
            // Get the value to put in the input from the post data if possible, otherwise use the value in the model

            var inputDate = new List<string>();
            if (modelStateEntry != null && modelStateEntry.RawValue != null && modelStateEntry.RawValue.ToString().Contains("/"))
            {
                inputDate = GetDayMonthYearFromDateTimeString(modelStateEntry.RawValue.ToString());
            }
            else
            {
                var modelValue = ExpressionHelpers.GetPropertyValueFromModelAndExpression(htmlHelper.ViewData.Model, propertyLambdaExpression);
                if (modelValue != null)
                {
                    inputDate = GetDayMonthYearFromDateTimeString(modelValue.ToString());
                }
            }

            if (labelOptions != null)
            {
                labelOptions.For = propertyId;
            }

            if (items == null)
            {
                items = new List<DateInputItemViewModel>() {
                    new DateInputItemViewModel(){
                        Name = "day",
                        Classes = "govuk-input--width-2",
                        Value = inputDate.Count == 3 ? inputDate[0] : ""
                    },
                    new DateInputItemViewModel(){
                        Name = "month",
                        Classes = "govuk-input--width-2",
                        Value = inputDate.Count == 3 ? inputDate[1] : ""
                    } ,
                    new DateInputItemViewModel(){
                        Name = "year",
                        Classes = "govuk-input--width-4",
                        Value = inputDate.Count == 3 ? inputDate[2] : ""
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

            return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/DateInput.cshtml", dateInputViewModel);
        }

        private static List<string> GetDayMonthYearFromDateTimeString(string dateString)
        {
            var firstSlashIndex = dateString.IndexOf("/");
            var secondSlashIndex = dateString.IndexOf("/", firstSlashIndex + 2);
            var day = dateString.Substring(0, firstSlashIndex);
            var month = dateString.Substring(firstSlashIndex + 1, secondSlashIndex - firstSlashIndex - 1);
            var year = dateString.Substring(secondSlashIndex + 1, dateString.IndexOf(" ") - secondSlashIndex - 1);
            return new List<string> { day, month, year };
        }
    }
}
