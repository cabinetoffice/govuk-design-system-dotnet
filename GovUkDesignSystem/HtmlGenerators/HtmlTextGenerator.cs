using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovUkDesignSystem.HtmlGenerators;

internal static class HtmlTextGenerator
{
    internal static async Task<IHtmlContent> GenerateHtml<TModel, TProperty>(
        IHtmlHelper<TModel> htmlHelper, 
        Expression<Func<TModel, TProperty>> propertyLambdaExpression, 
        string appendix = null)
        where TModel : class
    {
        PropertyInfo property = ExpressionHelpers.GetPropertyFromExpression(propertyLambdaExpression);
        TModel model = htmlHelper.ViewData.Model;
        var displayFormatAttribute = property.GetSingleCustomAttribute<DisplayFormatAttribute>();
        TProperty propertyValue = ExpressionHelpers.GetPropertyValueFromModelAndExpression(model, propertyLambdaExpression);
            
        string formattedPropertyValue = displayFormatAttribute?.DataFormatString != null
            ? string.Format(displayFormatAttribute.DataFormatString, propertyValue)
            : propertyValue.ToString();

        string text = appendix != null ? $"{formattedPropertyValue}{appendix}" : formattedPropertyValue;

        var htmlText = new HtmlText(null, text);

        return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/SubComponents/HtmlText.cshtml", htmlText);
    }
}