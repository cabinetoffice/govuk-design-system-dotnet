using System;
using System.Reflection;
using GovUkDesignSystem.Attributes.ValidationAttributes;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace GovUkDesignSystem.Parsers
{
    internal static class RadioToNullableEnumParser
    {
        internal static void ParseAndValidate(
            GovUkViewModel model,
            PropertyInfo property,
            HttpRequest httpRequest)
        {
            string propertyName = $"GovUk_Radio_{property.Name}";
            StringValues parameterValues = httpRequest.Form[propertyName];

            ThrowIfPropertyTypeIsNotNullableEnum(property);
            ParserHelpers.ThrowIfMoreThanOneValue(parameterValues, property);

            if (ParserHelpers.IsValueRequiredAndMissing(property, parameterValues))
            {
                ParserHelpers.AddRequiredAndMissingErrorMessage(model, property);
                return;
            }

            if (parameterValues.Count > 0)
            {
                string parameterValueAsString = parameterValues[0];

                object parameterAsEnum = ParseParameterAsEnum(parameterValueAsString, property);

                property.SetValue(model, parameterAsEnum);
            }

            model.ValueWasSuccessfullyParsed(property);
        }

        private static void ThrowIfPropertyTypeIsNotNullableEnum(PropertyInfo property)
        {
            if (!TypeHelpers.IsNullableEnum(property.PropertyType))
            {
                throw new ArgumentException(
                    "RadioToNullableEnumParser can only be used on Nullable Enum properties, " +
                    $"but was actually used on property [{property.Name}] of type [{property.PropertyType.FullName}] "
                );
            }
        }

        private static object ParseParameterAsEnum(string parameterValueAsString, PropertyInfo property)
        {
            Type underlyingType = Nullable.GetUnderlyingType(property.PropertyType);
            object parameterAsEnum;
            try
            {
                parameterAsEnum = Enum.Parse(underlyingType, parameterValueAsString);
            }
            catch (Exception ex)
            {
                string allowedValues = string.Join(",", Enum.GetNames(underlyingType));
                throw new ArgumentException(
                    $"User sent invalid value for Enum type [{property.Name}] " +
                    $"sent value [{parameterValueAsString}] allowed values are [{allowedValues}]",
                    ex
                );
            }

            return parameterAsEnum;
        }

    }
}
