using GovUkDesignSystem.GovUkDesignSystemComponents;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace GovUkDesignSystem.ModelBinders
{
    /// <summary>
    /// Model binder base class for checkboxes that will ignore the special dummy value used in the hidden field.
    /// </summary>
    public abstract class GovUkCheckboxBinderBase : IModelBinder
    {
        private readonly IModelBinder ElementBinder;

        public GovUkCheckboxBinderBase(IModelBinder elementBinder)
        {
            ElementBinder = elementBinder;
        }

        /// <summary>
        /// Just go far enough to check the value we've been given, then delegate to a built-in binder.
        /// </summary>
        /// <param name="bindingContext"></param>
        /// <returns></returns>
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult == ValueProviderResult.None)
            {
                // no entry
                return Task.CompletedTask;
            }

            // If this is the dummy value then skip it
            if (valueProviderResult.FirstValue == CheckboxesViewModel.HIDDEN_CHECKBOX_DUMMY_VALUE)
            {
                return Task.CompletedTask;
            }

            // Non-dummy value so do the actual binding
            return ElementBinder.BindModelAsync(bindingContext);
        }
    }
}
