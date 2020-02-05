using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Threading.Tasks;
using GovUkDesignSystem.Attributes.DataBinding;
using System;

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
        public Task BindModelBase(ModelBindingContext bindingContext, string errorMessageIfMissing, string nameAtStartOfSentence)
        {
            var modelName = bindingContext.ModelName;

            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            // Check whether a value was sent to us in the request at all
            if (valueProviderResult == ValueProviderResult.None)
            {
                // Raise an error if this property is mandatory
                if (errorMessageIfMissing != null)
                {
                    bindingContext.ModelState.TryAddModelError(modelName, errorMessageIfMissing);
                }
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
                // Raise an error if this property is mandatory
                if (errorMessageIfMissing != null)
                {
                    bindingContext.ModelState.TryAddModelError(modelName, errorMessageIfMissing);
                }
                return Task.CompletedTask;
            }

            // Ensure that the value is a number
            if (!double.TryParse(value, out _))
            {
                bindingContext.ModelState.TryAddModelError(modelName, $"{nameAtStartOfSentence} must be a number");
                return Task.CompletedTask;
            }

            //Ensure that the value is an integer
            if (!int.TryParse(value, out var intValue))
            {
                bindingContext.ModelState.TryAddModelError(modelName, $"{nameAtStartOfSentence} must be a whole number");
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(intValue);
            return Task.CompletedTask;
        }
    }
}
