using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using GovUkDesignSystem.Attributes;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovUkDesignSystem.HtmlGenerators
{
    internal static class RadiosHtmlGenerator
    {
        public static IHtmlContent GenerateHtml<TModel, TProperty>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> propertyLambdaExpression,
            FieldsetViewModel fieldsetOptions = null,
            HintViewModel hintOptions = null)
            where TModel : GovUkViewModel
        {
            PropertyInfo property = ExpressionHelpers.GetPropertyFromExpression(propertyLambdaExpression);
            ThrowIfPropertyTypeIsNotNullableEnum(property);
            string propertyName = property.Name;

            TModel model = htmlHelper.ViewData.Model;
            TProperty currentlySelectedValue =
                ExpressionHelpers.GetPropertyValueFromModelAndExpression(model, propertyLambdaExpression);

            Type enumType = Nullable.GetUnderlyingType(typeof(TProperty));
            Array allEnumValues = Enum.GetValues(enumType);


            List<ItemViewModel> radios = allEnumValues
                .OfType<object>()
                .Select(enumValue =>
                {
                    bool isEnumValueCurrentlySelected = enumValue.ToString() == currentlySelectedValue.ToString();
                    string radioLabelText = GetRadioLabelText(enumType, enumValue);

                    return new RadioItemViewModel
                    {
                        Value = enumValue.ToString(),
                        Id = $"GovUk_Radio_{propertyName}_{enumValue}",
                        Checked = isEnumValueCurrentlySelected,
                        Label = new LabelViewModel
                        {
                            Text = radioLabelText
                        }
                    };
                })
                .Cast<ItemViewModel>()
                .ToList();

            var radiosViewModel = new RadiosViewModel
            {
                Name = $"GovUk_Radio_{propertyName}",
                IdPrefix = $"GovUk_{propertyName}",
                Items = radios,
                Fieldset = fieldsetOptions,
                Hint = hintOptions
            };
            if (model.HasErrorFor(property))
            {
                radiosViewModel.ErrorMessage = new ErrorMessageViewModel
                {
                    Text = model.GetErrorFor(property)
                };
            }

            return htmlHelper.Partial("/GovUkDesignSystemComponents/Radios.cshtml", radiosViewModel);
        }

        private static void ThrowIfPropertyTypeIsNotNullableEnum(PropertyInfo property)
        {
            if (!TypeHelpers.IsNullableEnum(property.PropertyType))
            {
                throw new ArgumentException(
                    "GovUkRadiosFor can only be used on Nullable Enum properties, " +
                    $"but was actually used on property [{property.Name}] of type [{property.PropertyType.FullName}] "
                );
            }
        }

        private static string GetRadioLabelText(Type enumType, object enumValue)
        {
            string textFromAttribute = GovUkRadioCheckboxLabelTextAttribute.GetValueForEnum(enumType, enumValue);

            string radioLabel = textFromAttribute ?? enumValue.ToString();

            return radioLabel;
        }

    }
}