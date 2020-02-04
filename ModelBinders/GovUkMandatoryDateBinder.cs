using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Threading.Tasks;
using GovUkDesignSystem.Attributes.DataBinding;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GovUkDesignSystem.ModelBinders
{
    /// <summary>
    /// This model binder can be used to replace the default MVC model binder for a required date property. It will add
    /// validation messages to the model state inline with the GovUk Design System guidelines.
    /// This binder must be used alongside a GovUkDataBindingDateErrorTextAttribute attribute.
    /// </summary>
    public class GovUkMandatoryDateBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var errorText = bindingContext.ModelMetadata.ValidatorMetadata.OfType<GovUkDataBindingDateErrorTextAttribute>().SingleOrDefault();
            if (errorText == null)
            {
                throw new Exception("When using the GovUkMandatoryDateBinder you must also provide a GovUkDataBindingDateErrorTextAttribute attribute and ensure that you register GovUkDataBindingErrorTextProvider in your application's Startup.ConfigureServices method.");
            }
            var modelName = bindingContext.ModelName;
            var modelNames = new[] { modelName + "-day", modelName + "-month", modelName + "-year" };
            var modelValueDictionary = new List<KeyValuePair<string, ValueProviderResult>>();

            modelNames.ToList().ForEach(m => { modelValueDictionary.Add(new KeyValuePair<string, ValueProviderResult>(m, bindingContext.ValueProvider.GetValue(m))); });

            // Ensure that a value was sent to us in the request
            if (modelValueDictionary.Any(r => r.Value == ValueProviderResult.None)) 
            {
                bindingContext.ModelState.TryAddModelError(modelName, errorText.ErrorMessageIfMissing);
                return Task.CompletedTask;
            }

            var valuesDictionary = modelValueDictionary.Select( v => new KeyValuePair<string, string>(v.Key,v.Value.FirstValue)).ToList();

            var errors = new List<KeyValuePair<string, DateErrors>>();
            valuesDictionary.ForEach(p =>
            {
                if (string.IsNullOrEmpty(p.Value))
                {
                    errors.Add(new KeyValuePair<string, DateErrors>(p.Key, DateErrors.ValueMissing));
                }
            });

            if (errors.Count == 0)
            {
                var day = Int32.Parse(valuesDictionary[0].Value);
                var month = Int32.Parse(valuesDictionary[1].Value);
                var year = Int32.Parse(valuesDictionary[2].Value);
                try
                {
                    bindingContext.ModelState.SetModelValue(modelName, new ValueProviderResult(new DateTime(year, month, day).ToString()));
                    bindingContext.Result = ModelBindingResult.Success(new DateTime(year, month, day));
                }
                catch 
                {
                    bindingContext.ModelState.TryAddModelError(modelName, $"Enter a real {errorText.NameNotAtStartOfSentence}");
                }
            }
            else if (errors.Count < modelNames.Length)
            {
                bindingContext.ModelState.TryAddModelError(modelName, $"{errorText.NameAtStartOfSentence} does not include {String.Join(" or ", errors.Select(p => p.Key))}");
            }

            return Task.CompletedTask;
        }

        private enum DateErrors
        {
            ValueMissing = 0
        }
    }
}
