using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GovUkDesignSystem.ModelBinders
{
    /// <summary>
    /// Base functionality for decimal model binders
    /// </summary>
    public abstract class GovUkDecimalBinderBase
    {
        /// <summary>
        /// Try to bind the provided value to the model state. If errorMessageIfMissing is null then treat the property as optional
        /// </summary>
        public Task BindModelBase(ModelBindingContext bindingContext, string errorMessageIfMissing, string nameAtStartOfSentence)
        {
            var modelName = bindingContext.ModelName;

            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            // Check whether a value was sent to us in the request at all
            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            if (valueProviderResult.Length > 1)
            {
                throw new ArgumentException(
                    $"This property should only be able to send 1 value at a time, " +
                    $"but we just received [{valueProviderResult.Length}] values [{String.Join(", ", valueProviderResult.ToArray())}] " +
                    $"for property [{modelName}] on type [{bindingContext.ModelMetadata.ContainerType.FullName}]"
                );
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var value = valueProviderResult.FirstValue;

            // Return if the value is empty
            if (string.IsNullOrEmpty(value))
            {
                // Raise an error if this property is mandatory or if property type is non-nullable
                if (errorMessageIfMissing != null || !bindingContext.ModelMetadata.IsReferenceOrNullableType)
                {
                    bindingContext.ModelState.TryAddModelError(modelName, errorMessageIfMissing ?? $"{nameAtStartOfSentence} cannot be null or empty");
                }
                else
                {
                    bindingContext.Result = ModelBindingResult.Success(null);
                }
                return Task.CompletedTask;
            }

            // Ensure that the value is a number
            if (!decimal.TryParse(value, out var decimalValue))
            {
                bindingContext.ModelState.TryAddModelError(modelName, $"{nameAtStartOfSentence} must be a number");
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(decimalValue);
            return Task.CompletedTask;
        }
    }
}
