using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using GovUkDesignSystem.Helpers;
using Microsoft.Extensions.Primitives;

namespace GovUkDesignSystem
{
    public abstract class GovUkViewModel
    {
        private readonly Dictionary<string, string> errors = new Dictionary<string, string>();
        private readonly Dictionary<string, StringValues> unparsedValues = new Dictionary<string, StringValues>();
        private readonly HashSet<string> propertiesWithSuccessfullyParsedValues = new HashSet<string>();

        internal void ValueWasSuccessfullyParsed(PropertyInfo property)
        {
            propertiesWithSuccessfullyParsedValues.Add(property.Name);
        }

        internal bool HasSuccessfullyParsedValue(PropertyInfo property)
        {
            return propertiesWithSuccessfullyParsedValues.Contains(property.Name);
        }

        internal void AddUnparsedValues(string parameterName, StringValues values)
        {
            unparsedValues.Add(parameterName, values);
        }

        internal bool HasUnparsedValues(string parameterName)
        {
            return unparsedValues.ContainsKey(parameterName);
        }

        internal StringValues GetUnparsedValues(string parameterName)
        {
            if (unparsedValues.ContainsKey(parameterName))
            {
                return unparsedValues[parameterName];
            }
            else
            {
                return StringValues.Empty;
            }
        }

        public void AddErrorFor<TModel, TProperty>(
            Expression<Func<TModel, TProperty>> propertyLambdaExpression, string errorMessage)
            where TModel : GovUkViewModel
        {
            var property = ExpressionHelpers.GetPropertyFromExpression(propertyLambdaExpression);
            AddErrorFor(property, errorMessage);
        }

        internal void AddErrorFor(PropertyInfo property, string errorMessage)
        {
            errors.Add(property.Name, errorMessage);
        }

        public bool HasErrorFor<TModel, TProperty>(
            Expression<Func<TModel, TProperty>> propertyLambdaExpression)
            where TModel : GovUkViewModel
        {
            var property = ExpressionHelpers.GetPropertyFromExpression(propertyLambdaExpression);
            return HasErrorFor(property);
        }

        internal bool HasErrorFor(PropertyInfo property)
        {
            return errors.ContainsKey(property.Name);
        }

        public bool HasAnyErrors()
        {
            return errors.Count > 0;
        }

        internal Dictionary<string, string> GetAllErrors()
        {
            return errors;
        }

        public string GetErrorFor<TModel, TProperty>(
            Expression<Func<TModel, TProperty>> propertyLambdaExpression)
            where TModel : GovUkViewModel
        {
            var property = ExpressionHelpers.GetPropertyFromExpression(propertyLambdaExpression);
            return GetErrorFor(property);
        }

        internal string GetErrorFor(PropertyInfo property)
        {
            return errors.ContainsKey(property.Name) ? errors[property.Name] : null;
        }

    }
}