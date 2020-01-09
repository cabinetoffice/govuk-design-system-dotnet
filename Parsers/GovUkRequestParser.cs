using System;
using System.Linq.Expressions;
using System.Reflection;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Http;

namespace GovUkDesignSystem.Parsers
{
    public static class GovUkRequestParser
    {
        public static void ParseAndValidateParameters<TModel, TProperty>(
            this TModel model,
            HttpRequest httpRequest,
            params Expression<Func<TModel, TProperty>>[] propertyLambdaExpressions)
            where TModel : GovUkViewModel
        {
            foreach (Expression<Func<TModel, TProperty>> propertyLambdaExpression in propertyLambdaExpressions)
            {
                ParseAndValidateParameter(model, httpRequest, propertyLambdaExpression);
            }
        }

        private static void ParseAndValidateParameter<TModel, TProperty>(
            TModel model,
            HttpRequest httpRequest,
            Expression<Func<TModel, TProperty>> propertyLambdaExpression)
            where TModel : GovUkViewModel
        {
            PropertyInfo property = ExpressionHelpers.GetPropertyFromExpression(propertyLambdaExpression);

            ThrowIfPropertyHasNonDefaultValue(model, property);

            if (TypeHelpers.IsNullableEnum(typeof(TProperty)))
            {
                RadioToNullableEnumParser.ParseAndValidate(model, property, httpRequest);
            }
            else if (TypeHelpers.IsListOfEnums(typeof(TProperty)))
            {
                CheckboxToListOfEnumsParser.ParseAndValidate(model, property, httpRequest);
            }
            else if (typeof(TProperty) == typeof(string))
            {
                TextParser.ParseAndValidate(model, property, httpRequest);
            }
            else if (typeof(TProperty) == typeof(int?))
            {
                NullableIntParser.ParseAndValidate(model, property, httpRequest);
            }
        }

        private static void ThrowIfPropertyHasNonDefaultValue(object model, PropertyInfo property)
        {
            object currentValue = property.GetValue(model);
            object defaultValueOfThisType = TypeHelpers.GetDefaultValue(property.PropertyType);

            if (currentValue != defaultValueOfThisType)
            {
                throw new Exception(
                    $"GovUkRequestParser is trying to set [{property.Name}] on object [{model.GetType()}]. " +
                    $"This property already has a value [{currentValue}], which is concerning (maybe a security problem). " +
                    $"This value should only be set in one place (either directly by an HTTP parameter, or by one of the GovUk Parsers)."
                );
            }
        }

    }
}