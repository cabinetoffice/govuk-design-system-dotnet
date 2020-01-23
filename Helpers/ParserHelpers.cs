﻿using System;
using System.Reflection;
using GovUkDesignSystem.Attributes;
using GovUkDesignSystem.Attributes.ValidationAttributes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace GovUkDesignSystem.Helpers
{
    public static class ParserHelpers
    {

        public static void ThrowIfMoreThanOneValue(StringValues parameterValues, PropertyInfo property)
        {
            if (parameterValues.Count > 1)
            {
                throw new ArgumentException(
                    $"This property should only be able to send 1 value at a time, " +
                    $"but we just received [{parameterValues.Count}] values [{parameterValues}] " +
                    $"for property [{property.Name}] on type [{property.DeclaringType.FullName}]"
                );
            }
        }

        public static void SaveUnparsedValueFromRequestToModel(GovUkViewModel model, HttpRequest httpRequest, string parameterName)
        {
            StringValues unparsedValuesFromRequestForThisProperty = httpRequest.Form[parameterName];

            model.AddUnparsedValues(parameterName, unparsedValuesFromRequestForThisProperty);
        }


        public static bool IsValueRequiredAndMissing(PropertyInfo property, StringValues parameterValues)
        {
            var requiredAttribute = property.GetSingleCustomAttribute<GovUkValidateRequiredAttribute>();

            bool valueIsRequired = requiredAttribute != null;
            bool valueIsMissing = parameterValues.Count == 0;

            return (valueIsRequired && valueIsMissing);
        }

        public static bool IsValueRequiredAndMissingOrEmpty(PropertyInfo property, StringValues parameterValues)
        {
            var requiredAttribute = property.GetSingleCustomAttribute<GovUkValidateRequiredAttribute>();

            bool valueIsRequired = requiredAttribute != null;
            bool valueIsMissing = parameterValues.Count == 0 || string.IsNullOrWhiteSpace(parameterValues[0]);

            return (valueIsRequired && valueIsMissing);
        }

        public static void AddRequiredAndMissingErrorMessage(GovUkViewModel model, PropertyInfo property)
        {
            var requiredAttribute = property.GetSingleCustomAttribute<GovUkValidateRequiredAttribute>();
            var displayNameForErrorsAttribute = property.GetSingleCustomAttribute<GovUkDisplayNameForErrorsAttribute>();

            string errorMessage;
            if (requiredAttribute.ErrorMessageIfMissing != null)
            {
                errorMessage = requiredAttribute.ErrorMessageIfMissing;
            }
            else if (displayNameForErrorsAttribute != null)
            {
                errorMessage = $"Select {displayNameForErrorsAttribute.NameWithinSentence}";
            }
            else
            {
                errorMessage = $"Select {property.Name}";
            }

            model.AddErrorFor(property, errorMessage);
        }

        public static void AddErrorMessageBasedOnPropertyDisplayName(
            GovUkViewModel model,
            PropertyInfo property,
            Func<string, string> getErrorMessageBasedOnPropertyDisplayName)
        {
            var displayNameForErrorsAttribute = property.GetSingleCustomAttribute<GovUkDisplayNameForErrorsAttribute>();

            string errorMessage;
            if (displayNameForErrorsAttribute != null)
            {
                errorMessage = getErrorMessageBasedOnPropertyDisplayName(displayNameForErrorsAttribute.NameWithinSentence);
            }
            else
            {
                errorMessage = getErrorMessageBasedOnPropertyDisplayName(property.Name);
            }

            model.AddErrorFor(property, errorMessage);
        }

        public static void AddErrorInNested(object model, PropertyInfo property, string error, int nestLevel = 0)
        {
            Type t = model.GetType();
            PropertyInfo[] modelProperties = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo modelProperty in modelProperties)
            {
                if (!modelProperty.PropertyType.FullName.StartsWith("System"))
                {
                    object nestedObject = modelProperty.GetValue(model, null);

                    if (nestedObject == null)
                    {
                        nestedObject = modelProperty.PropertyType.GetConstructor(new Type[] { }).Invoke(new object[] { });
                    }

                    AddErrorInNested(nestedObject, property, error, nestLevel + 1);
                    modelProperty.SetValue(model, nestedObject, null);
                    break;
                }
                else if (modelProperty.Name == property.Name)
                {
                    if (nestLevel > 0)
                    {
                        ((GovUkViewModel)model).AddErrorFor(property, error);
                        nestLevel = -1;
                    }
                    break;
                }
            }
        }
    }
}
