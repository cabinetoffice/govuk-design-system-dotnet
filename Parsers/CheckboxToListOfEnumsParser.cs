using System;
using System.Reflection;
using GovUkDesignSystem.Attributes;
using GovUkDesignSystem.Attributes.ValidationAttributes;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace GovUkDesignSystem.Parsers
{
    public class CheckboxToListOfEnumsParser
    {
        internal static void ParseAndValidate(
            GovUkViewModel model,
            PropertyInfo property,
            HttpRequest httpRequest)
        {
            string propertyName = $"GovUk_Checkbox_{property.Name}";
            StringValues parameterValues = httpRequest.Form[propertyName];

            ThrowIfPropertyTypeIsNotListOfEnums(property);

            Type enumType = TypeHelpers.GetGenericTypeFromGenericListType(property.PropertyType);
            ThrowIfAnyValuesAreInvalid(parameterValues, enumType);

            SetPropertyValue(model, property, parameterValues);

            if (IsTooFewSelected(property, parameterValues) ||
                IsTooManySelected(property, parameterValues))
            {
                AddInvalidNumberOfSelectedItemsErrorMessage(model, property, parameterValues);
                return;
            }

            model.ValueWasSuccessfullyParsed(property);
        }

        private static void SetPropertyValue(GovUkViewModel model, PropertyInfo property, StringValues parameterValues)
        {
            Type enumType = TypeHelpers.GetGenericTypeFromGenericListType(property.PropertyType);

            object newListOfEnums = Activator.CreateInstance(property.PropertyType);
            MethodInfo methodInfo = newListOfEnums.GetType().GetMethod("Add");

            foreach (string parameterValue in parameterValues)
            {
                object valueAsEnum = Enum.Parse(enumType, parameterValue);
                methodInfo.Invoke(newListOfEnums, new[] {valueAsEnum});
            }

            property.SetValue(model, newListOfEnums);
        }

        private static void AddInvalidNumberOfSelectedItemsErrorMessage(
            GovUkViewModel model,
            PropertyInfo property,
            StringValues parameterValues)
        {
            var responsesRangeAttribute = property.GetSingleCustomAttribute<GovUkValidateCheckboxNumberOfResponsesRangeAttribute>();
            var displayNameForErrorsAttribute = property.GetSingleCustomAttribute<GovUkDisplayNameForErrorsAttribute>();

            string propertyNameForErrorMessage = displayNameForErrorsAttribute?.NameWithinSentence ?? property.Name;

            string errorMessage;
            if (IsTooFewSelected(property, parameterValues))
            {
                if (parameterValues.Count == 0 &&
                    responsesRangeAttribute.ErrorMessageIfNothingSelected != null)
                {
                    errorMessage = responsesRangeAttribute.ErrorMessageIfNothingSelected;
                }
                else
                {
                    errorMessage = $"Select at least {responsesRangeAttribute.MinimumSelected} " +
                                   $"options for {propertyNameForErrorMessage}";
                }
            }
            else // Implicitly, the user must have selected too many options
            {
                errorMessage = $"Select at most {responsesRangeAttribute.MaximumSelected} " +
                               $"options for {propertyNameForErrorMessage}";
            }

            model.AddErrorFor(property, errorMessage);
        }

        private static bool IsTooFewSelected(PropertyInfo property, StringValues parameterValues)
        {
            var responsesRangeAttribute =
                property.GetSingleCustomAttribute<GovUkValidateCheckboxNumberOfResponsesRangeAttribute>();

            bool isRangeEnforced = responsesRangeAttribute != null &&
                                   responsesRangeAttribute.MinimumSelected.HasValue;

            bool tooFewSelected = isRangeEnforced &&
                                  parameterValues.Count < responsesRangeAttribute.MinimumSelected.Value;

            return tooFewSelected;
        }

        private static bool IsTooManySelected(PropertyInfo property, StringValues parameterValues)
        {
            var responsesRangeAttribute =
                property.GetSingleCustomAttribute<GovUkValidateCheckboxNumberOfResponsesRangeAttribute>();

            bool isRangeEnforced = responsesRangeAttribute != null &&
                                   responsesRangeAttribute.MaximumSelected.HasValue;

            bool tooManySelected = isRangeEnforced &&
                                   parameterValues.Count > responsesRangeAttribute.MaximumSelected.Value;

            return tooManySelected;
        }

        private static void ThrowIfPropertyTypeIsNotListOfEnums(PropertyInfo property)
        {
            if (!TypeHelpers.IsListOfEnums(property.PropertyType))
            {
                throw new ArgumentException(
                    "CheckboxToListOfEnumsParser can only be used on List<Enum> properties, " +
                    $"but was actually used on property [{property.Name}] of type [{property.PropertyType.FullName}] "
                );
            }
        }

        private static void ThrowIfAnyValuesAreInvalid(StringValues parameterValues, Type enumType)
        {
            try
            {
                foreach (string parameterValue in parameterValues)
                {
                    Enum.Parse(enumType, parameterValue);
                }
            }
            catch (Exception ex)
            {
                string sentValues = string.Join(", ", parameterValues);
                string allowedValues = string.Join(",", Enum.GetNames(enumType));

                throw new ArgumentException(
                    $"User sent invalid value for Enum type [{enumType.Name}] " +
                    $"sent values [{sentValues}] allowed values are [{allowedValues}]",
                    ex
                );
            }
        }

    }
}
