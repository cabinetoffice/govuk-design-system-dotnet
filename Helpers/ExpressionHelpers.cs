using System;
using System.Linq.Expressions;
using System.Reflection;

namespace GovUkDesignSystem.Helpers
{
    internal static class ExpressionHelpers
    {
        //qq:DCC Can probably remove this once other changes are complete
        internal static PropertyInfo GetPropertyFromExpression<TModel, TProperty>(
            Expression<Func<TModel, TProperty>> propertyLambdaExpression)
            where TModel : class
        {
            MemberExpression memberExpression = propertyLambdaExpression.Body as MemberExpression;
            return memberExpression.Member as PropertyInfo;
        }

        public static TProperty GetPropertyValueFromModelAndExpression<TModel, TProperty>(
            TModel model,
            Expression<Func<TModel, TProperty>> propertyLambdaExpression)
            where TModel : class
        {
            Func<TModel, TProperty> compiledExpression = propertyLambdaExpression.Compile();
            TProperty currentPropertyValue = compiledExpression(model);
            return currentPropertyValue;
        }
    }
}