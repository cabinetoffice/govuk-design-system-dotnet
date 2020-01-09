using System;
using System.Linq.Expressions;
using System.Reflection;

namespace GovUkDesignSystem.Helpers
{
    internal static class ExpressionHelpers
    {
        internal static PropertyInfo GetPropertyFromExpression<TModel, TProperty>(
            Expression<Func<TModel, TProperty>> propertyLambdaExpression)
            where TModel : GovUkViewModel
        {
            MemberExpression memberExpression = propertyLambdaExpression.Body as MemberExpression;
            return memberExpression.Member as PropertyInfo;
        }

        public static TProperty GetPropertyValueFromModelAndExpression<TModel, TProperty>(
            TModel model,
            Expression<Func<TModel, TProperty>> propertyLambdaExpression)
        {
            Func<TModel, TProperty> compiledExpression = propertyLambdaExpression.Compile();
            TProperty currentPropertyValue = compiledExpression(model);
            return currentPropertyValue;
        }
    }
}