using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace GovUkDesignSystem.Helpers
{
    /// <summary>
    /// This code could also go in a base class for the HtmlGenerator classes
    /// </summary>
    internal class HtmlGenerationHelpers
    {
        /// <summary>
        /// Get the value to put in the input from the post data if possible, otherwise use the value in the model
        /// </summary>
        public static string GetStringValueFromModelStateOrModel<TModel, TProperty>(
            ModelStateEntry modelStateEntry,
            TModel model,
            Expression<Func<TModel, TProperty>> propertyExpression)
            where TModel : class
        {
            string inputValue = null;
            if (modelStateEntry != null && modelStateEntry.RawValue != null)
            {
                inputValue = modelStateEntry.RawValue as string;
            }
            else
            {
                var modelValue = ExpressionHelpers.GetPropertyValueFromModelAndExpression(model, propertyExpression);
                if (modelValue != null)
                {
                    inputValue = modelValue.ToString();
                }
            }

            return inputValue;
        }

        /// <summary>
        /// If modelStateEntry contains any errors add them to target
        /// </summary>
        public static void SetErrorMessages(IHasErrorMessage target, ModelStateEntry modelStateEntry)
        {
            if (modelStateEntry != null && modelStateEntry.Errors.Count > 0)
            {
                target.ErrorMessage = new ErrorMessageViewModel { Text = string.Join(", ", modelStateEntry.Errors.Select(e => e.ErrorMessage)) };
            }
        }
    }
}
