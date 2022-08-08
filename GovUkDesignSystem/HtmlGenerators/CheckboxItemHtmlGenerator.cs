using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovUkDesignSystem.HtmlGenerators
{
    public class CheckboxItemHtmlGenerator
    {

        public static async Task<IHtmlContent> GenerateHtml<TModel>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, bool>> propertyLambdaExpression,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            Conditional conditional = null,
            bool disabled = false,
            string onChange = null)
            where TModel : class
        {
            PropertyInfo property = ExpressionHelpers.GetPropertyFromExpression(propertyLambdaExpression);
            string propertyName = property.Name;

            TModel model = htmlHelper.ViewData.Model;
            bool isChecked = ExpressionHelpers.GetPropertyValueFromModelAndExpression(model, propertyLambdaExpression);

            if (labelOptions != null)
            {
                labelOptions.For = propertyName;
            }

            var attributesDictionary = new Dictionary<string, string>();

            if (onChange != null)
            {
                attributesDictionary.Add("onChange", onChange);
            }
            
            var checkboxItemViewModel = new CheckboxItemViewModel
            {
                Id = propertyName,
                Name = propertyName,
                Value = true.ToString(),
                Label = labelOptions,
                Hint = hintOptions,
                Conditional = conditional,
                Disabled = disabled,
                Checked = isChecked,
                Attributes = attributesDictionary
            };

            return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/CheckboxItem.cshtml", checkboxItemViewModel);
        }

    }
}