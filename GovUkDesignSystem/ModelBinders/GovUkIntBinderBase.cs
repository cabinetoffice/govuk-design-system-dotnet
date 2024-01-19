using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GovUkDesignSystem.ModelBinders
{
    /// <summary>
    /// Base functionality for int model binders
    /// </summary>
    public abstract class GovUkIntBinderBase
    {
        /// <summary>
        /// Try to bind the provided value to the model state. If errorMessageIfMissing is null then treat the property as optional
        /// </summary>
        public Task BindModelBase(ModelBindingContext bindingContext, string errorMessageIfMissing, string nameAtStartOfSentence, string mustBeNumberErrorMessage = "", string isWholeNumberErrorMessage = "")
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

            if (errorMessageIfMissing == null && !bindingContext.ModelMetadata.IsReferenceOrNullableType)
            {
                throw new ArgumentException($"This property should be nullable when {nameof(errorMessageIfMissing)} is not defined, " +
                    $"but property [{modelName}] on type [{bindingContext.ModelMetadata.ContainerType.FullName}] is not");
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var value = valueProviderResult.FirstValue;

            // Return if the value is empty
            if (string.IsNullOrEmpty(value))
            {
                // Raise an error if this property is mandatory
                if (errorMessageIfMissing != null)
                {
                    bindingContext.ModelState.TryAddModelError(modelName, errorMessageIfMissing);
                }
                else
                {
                    bindingContext.Result = ModelBindingResult.Success(null);
                }
                return Task.CompletedTask;
            }

            // Ensure that the value is a number
            if (!double.TryParse(value, out _))
            {
                if (string.IsNullOrEmpty(mustBeNumberErrorMessage))
                {
                    bindingContext.ModelState.TryAddModelError(modelName, $"{nameAtStartOfSentence} must be a number");
                }
                else
                {
                    bindingContext.ModelState.TryAddModelError(modelName, mustBeNumberErrorMessage);
                }
                return Task.CompletedTask;
            }

            //Ensure that the value is an integer
            if (!int.TryParse(value, out var intValue))
            {
                if (string.IsNullOrEmpty(isWholeNumberErrorMessage))
                {
                    bindingContext.ModelState.TryAddModelError(modelName, $"{nameAtStartOfSentence} must be a whole number");
                }
                else
                {
                    bindingContext.ModelState.TryAddModelError(modelName, isWholeNumberErrorMessage);
                }

                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(intValue);
            return Task.CompletedTask;
        }
    }
}
