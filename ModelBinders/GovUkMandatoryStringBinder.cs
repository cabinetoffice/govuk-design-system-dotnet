using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Threading.Tasks;
using System;
using GovUkDesignSystem.Attributes.DataBinding;

namespace GovUkDesignSystem.ModelBinders
{
    /// <summary>
    /// This model binder can be used to replace the default MVC model binder for a required string property. It will add
    /// validation messages to the model state inline with the GovUk Design System guidelines.
    /// This binder must be used alongside a GovUkDataBindingStringErrorTextAttribute attribute.
    /// </summary>
    public class GovUkMandatoryStringBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var errorText = bindingContext.ModelMetadata.ValidatorMetadata.OfType<GovUkDataBindingStringErrorTextAttribute>().SingleOrDefault();
            if (errorText == null)
            {
                throw new Exception("When using the GovUkMandatoryStringBinder you must also provide a GovUkDataBindingStringErrorTextAttribute attribute and ensure that you register GovUkDataBindingErrorTextProvider in your application's Startup.ConfigureServices method.");
            }

            var modelName = bindingContext.ModelName;

            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            // Ensure that a value was sent to us in the request
            if (valueProviderResult == ValueProviderResult.None)
            {
                bindingContext.ModelState.TryAddModelError(modelName, errorText.ErrorMessageIfMissing);
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

            // Ensure that the value we have isn't empty
            if (string.IsNullOrEmpty(value))
            {
                bindingContext.ModelState.TryAddModelError(modelName, errorText.ErrorMessageIfMissing);
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(value);
            return Task.CompletedTask;
        }
    }
}
