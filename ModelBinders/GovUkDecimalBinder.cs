using GovUkDesignSystem.Attributes.DataBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GovUkDesignSystem.ModelBinders
{
    /// <summary>
    /// This model binder can be used to replace the default MVC model binder for a decimal property. It will add
    /// validation messages to the model state inline with the GovUk Design System guidelines.
    /// This binder must be used alongside a GovUkDataBindingDecimalErrorTextAttribute attribute.
    /// </summary>
    public class GovUkDecimalBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var errorTextAttribute = bindingContext.ModelMetadata.ValidatorMetadata.OfType<GovUkDataBindingDecimalErrorTextAttribute>().SingleOrDefault();
            if (errorTextAttribute == null)
            {
                throw new Exception("When using the GovUkDecimalBinder you must also provide a GovUkDataBindingDecimalErrorTextAttribute attribute and ensure that you register GovUkDataBindingErrorTextProvider in your application's Startup.ConfigureServices method.");
            }

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
                return Task.CompletedTask;
            }

            // Ensure that the value is a number
            if (!double.TryParse(value, out _))
            {
                bindingContext.ModelState.TryAddModelError(modelName, $"{errorTextAttribute.NameAtStartOfSentence} must be a number");
                return Task.CompletedTask;
            }

            //Ensure that the value is a decimal
            if (!decimal.TryParse(value, out var decimalValue))
            {
                bindingContext.ModelState.TryAddModelError(modelName, $"{errorTextAttribute.NameAtStartOfSentence} must be a whole number or decimal");
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(decimalValue);
            return Task.CompletedTask;
        }
    }
}
