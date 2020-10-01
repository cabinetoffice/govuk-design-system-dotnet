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
            ModelStateEntry modelStateEntry,
            string ignoreValue = null)
            where TModel : class
            where TEnum : struct, Enum
        {
            if (modelStateEntry != null && modelStateEntry.RawValue != null)
            {
                var stringValues = new List<string>();
                if (modelStateEntry.RawValue is string[])
                {
                    stringValues.AddRange((string[])modelStateEntry.RawValue);
                }
                else if (modelStateEntry.RawValue is string)
                {
                    stringValues.Add((string)modelStateEntry.RawValue);
                }

                return stringValues
                    .Except(new[] { ignoreValue })
                    .Select(e => (TEnum)Enum.Parse(typeof(TEnum), e.ToString()))
                    .ToList();
            }

            return ExpressionHelpers.GetPropertyValueFromModelAndExpression(model, propertyLambdaExpression);
        }

        /// <summary>
        /// Get the value to put in the input from the post data if possible, otherwise use the value in the model
        /// </summary>
        public static List<string> GetListOfStringValuesFromModelStateOrModel<TModel>(
            TModel model,
            Expression<Func<TModel, List<string>>> propertyLambdaExpression,
            ModelStateEntry modelStateEntry,
            string ignoreValue = null)
            where TModel : class
        {
            if (modelStateEntry != null && modelStateEntry.RawValue != null)
            {
                var values = new List<string>();
                if (modelStateEntry.RawValue is string[])
                {
                    values.AddRange((string[])modelStateEntry.RawValue);
                }
                else if (modelStateEntry.RawValue is string)
                {
                    values.Add((string)modelStateEntry.RawValue);
                }
                return values.Except(new[] { ignoreValue }).ToList();
            }

            return ExpressionHelpers.GetPropertyValueFromModelAndExpression(model, propertyLambdaExpression);
        }

        /// <summary>
        /// Get the value to put in the input from the post data if possible, otherwise use the value in the model
        /// </summary>
        public static bool GetCheckboxBoolValueFromModelStateOrModel<TModel>(
            TModel model,
            Expression<Func<TModel, bool>> propertyLambdaExpression,
            ModelStateEntry modelStateEntry,
            string ignoreValue)
            where TModel : class
        {
            if (modelStateEntry != null && modelStateEntry.RawValue != null)
            {
                // In theory we should either get a single entry containing the ignore value, or two
                // entries - the ignore value and a value of true.
                var values = new List<string>();
                if (modelStateEntry.RawValue is string[])
                {
                    values.AddRange((string[])modelStateEntry.RawValue);
                }
                else if (modelStateEntry.RawValue is string)
                {
                    values.Add((string)modelStateEntry.RawValue);
                }
                return bool.Parse(values
                    .Except(new[] { ignoreValue })
                    .Single());
            }

            return ExpressionHelpers.GetPropertyValueFromModelAndExpression(model, propertyLambdaExpression);
        }
    }
}
