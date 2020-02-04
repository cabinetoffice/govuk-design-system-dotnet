using System;
using System.Reflection;
using GovUkDesignSystem.Attributes;
using GovUkDesignSystem.Attributes.ValidationAttributes;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace GovUkDesignSystem.Parsers
{
    public class TextParser
    {

        public static void ParseAndValidate(
            GovUkViewModel model,
            PropertyInfo property,
            HttpRequest httpRequest)
        {
            string parameterName = $"GovUk_Text_{property.Name}";

            StringValues parameterValues = httpRequest.Form[parameterName];

            ParserHelpers.ThrowIfMoreThanOneValue(parameterValues, property);
            ParserHelpers.SaveUnparsedValueFromRequestToModel(model, httpRequest, parameterName);

            if (ParserHelpers.IsValueRequiredAndMissingOrEmpty(property, parameterValues))
            {
                ParserHelpers.AddRequiredAndMissingErrorMessage(model, property);
                return;
            }

            if (parameterValues.Count > 0)
            {
                string parameterValue = parameterValues[0];

                if (ExceedsCharacterCount(property, parameterValue))
                {
                    AddExceedsCharacterCountErrorMessage(model, property);
                    return;
                }

                property.SetValue(model, parameterValue);
            }

            model.ValueWasSuccessfullyParsed(property);
        }

        private static void AddExceedsCharacterCountErrorMessage(GovUkViewModel model, PropertyInfo property)
        {
            var characterCountAttribute = property.GetSingleCustomAttribute<GovUkValidateCharacterCountAttribute>();
            var displayNameForErrorsAttribute = property.GetSingleCustomAttribute<GovUkDisplayNameForErrorsAttribute>();

            string errorMessage;
            if (displayNameForErrorsAttribute != null)
            {
                errorMessage = $"{displayNameForErrorsAttribute.NameAtStartOfSentence} must be {characterCountAttribute.MaxCharacters} characters or fewer";
            }
            else
            {
                errorMessage = $"{property.Name} must be {characterCountAttribute.MaxCharacters} characters or fewer";
            }

            model.AddErrorFor(property, errorMessage);
        }

        private static bool ExceedsCharacterCount(PropertyInfo property, string parameterValue)
        {
            var characterCountAttribute = property.GetSingleCustomAttribute<GovUkValidateCharacterCountAttribute>();

            bool characterCountInForce = characterCountAttribute != null;

            if (characterCountInForce)
            {
                int parameterLength = parameterValue.Length;
                int maximumLength = characterCountAttribute.MaxCharacters;

                bool exceedsCharacterCount = parameterLength > maximumLength;
                return exceedsCharacterCount;
            }
            else
            {
                return false;
            }
        }

        

        


    }
}
