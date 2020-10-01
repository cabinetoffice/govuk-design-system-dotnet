using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Get the value to put in the input from the post data if possible, otherwise use the value in the model
        /// </summary>
        public static TEnum? GetNullableEnumValueFromModelStateOrModel<TModel, TEnum>(
            TModel model,
            Expression<Func<TModel, TEnum?>> propertyLambdaExpression,
            ModelStateEntry modelStateEntry)
            where TModel : class
            where TEnum : struct, Enum
        {
            if (modelStateEntry != null && modelStateEntry.RawValue != null)
            {
                return (TEnum)Enum.Parse(typeof(TEnum), modelStateEntry.RawValue.ToString());
            }
            else
            {
                return ExpressionHelpers.GetPropertyValueFromModelAndExpression(model, propertyLambdaExpression);
            }
        }

        /// <summary>
        /// Get the value to put in the input from the post data if possible, otherwise use the value in the model
        /// </summary>
        public static List<TEnum> GetListOfEnumValuesFromModelStateOrModel<TModel, TEnum>(
            TModel model,
            Expression<Func<TModel, List<TEnum>>> propertyLambdaExpression,
            ModelStateEntry modelStateEntry)
            where TModel : class
            where TEnum : struct, Enum
        {
            if (modelStateEntry != null && modelStateEntry.RawValue != null)
            {
                if (modelStateEntry.RawValue is string[])
                {
                    return ((string[])modelStateEntry.RawValue).Select(e => (TEnum)Enum.Parse(typeof(TEnum), e.ToString())).ToList();
                }
                else if (modelStateEntry.RawValue is string)
                {
                    return new List<TEnum> { (TEnum)Enum.Parse(typeof(TEnum), modelStateEntry.RawValue.ToString()) };
                }
            }

            return ExpressionHelpers.GetPropertyValueFromModelAndExpression(model, propertyLambdaExpression);
        }

        /// <summary>
        /// Get the value to put in the input from the post data if possible, otherwise use the value in the model
        /// </summary>
        public static List<string> GetListOfStringValuesFromModelStateOrModel<TModel>(
            TModel model,
            Expression<Func<TModel, List<string>>> propertyLambdaExpression,
            ModelStateEntry modelStateEntry)
            where TModel : class
        {
            if (modelStateEntry != null && modelStateEntry.RawValue != null)
            {
                if (modelStateEntry.RawValue is string[])
                {
                    return ((string[])modelStateEntry.RawValue).ToList();
                }
                else if (modelStateEntry.RawValue is string)
                {
                    return new List<string> { modelStateEntry.RawValue.ToString() };
                }
            }

            return ExpressionHelpers.GetPropertyValueFromModelAndExpression(model, propertyLambdaExpression);
        }

        /// <summary>
        /// Get the value to put in the input from the post data if possible, otherwise use the value in the model
        /// </summary>
        public static bool GetBoolValueFromModelStateOrModel<TModel>(
            TModel model,
            Expression<Func<TModel, bool>> propertyLambdaExpression,
            ModelStateEntry modelStateEntry)
            where TModel : class
        {
            if (modelStateEntry != null && modelStateEntry.RawValue != null)
            {
                if (modelStateEntry.RawValue is string)
                {
                    return bool.Parse(modelStateEntry.RawValue.ToString());
                }
                if (modelStateEntry.RawValue is string[])
                {
                    // We have a hidden field which will always return a false value. If the checkbox is checked
                    // we will also get a true value.
                    return ((string[])modelStateEntry.RawValue).Any(r => r == "true");
                }
            }

            return ExpressionHelpers.GetPropertyValueFromModelAndExpression(model, propertyLambdaExpression);
        }
    }
}
