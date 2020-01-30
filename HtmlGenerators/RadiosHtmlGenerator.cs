using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using GovUkDesignSystem.Attributes;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovUkDesignSystem.HtmlGenerators
{
    internal static class RadiosHtmlGenerator
    {
        public static async Task<IHtmlContent> GenerateHtmlFromModelState<TModel, TEnum>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TEnum?>> propertyExpression,
            FieldsetViewModel fieldsetOptions = null,
            HintViewModel hintOptions = null)
            where TModel : class
            where TEnum : struct, Enum
        {
            PropertyInfo property = ExpressionHelpers.GetPropertyFromExpression(propertyExpression);
            ThrowIfPropertyTypeIsNotNullableEnum(property);

            string propertyId = htmlHelper.IdFor(propertyExpression);
            string propertyName = htmlHelper.NameFor(propertyExpression);
            htmlHelper.ViewData.ModelState.TryGetValue(propertyName, out var modelStateEntry);

            // Get the value to put in the input from the post data if possible, otherwise use the value in the model
            string selectedValue = null;
            if (modelStateEntry != null && modelStateEntry.RawValue != null)
            {
                selectedValue = modelStateEntry.RawValue as string;
            }
            else
            {
                var modelValue = ExpressionHelpers.GetPropertyValueFromModelAndExpression(htmlHelper.ViewData.Model, propertyExpression);
                if (modelValue != null)
                {
                    selectedValue = modelValue.ToString();
                }
            }

            var enumType = typeof(TEnum);
            Array allEnumValues = Enum.GetValues(enumType);

            List<ItemViewModel> radios = allEnumValues
                .OfType<object>()
                .Select(enumValue =>
                {
                    bool isEnumValueCurrentlySelected = enumValue.ToString() == selectedValue;
                    string radioLabelText = GetRadioLabelText(enumType, enumValue);

                    return new RadioItemViewModel
                    {
                        Value = enumValue.ToString(),
                        Id = $"{propertyId}_{enumValue}",
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
                Name = propertyName,
                IdPrefix = propertyId,
                Items = radios,
                Fieldset = fieldsetOptions,
                Hint = hintOptions
            };

            if (modelStateEntry != null && modelStateEntry.Errors.Count > 0)
            {
                // qq:DCC Are we OK with only displaying the first error message here?
                radiosViewModel.ErrorMessage = new ErrorMessageViewModel { Text = modelStateEntry.Errors[0].ErrorMessage };
            }

            return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/Radios.cshtml", radiosViewModel);
        }

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