using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Threading.Tasks;
using GovUkDesignSystem.Attributes.DataBinding;
using System;

namespace GovUkDesignSystem.ModelBinders
{
    /// <summary>
    /// This model binder can be used to replace the default MVC model binder for an optional decimal property.
    /// It will add validation messages to the model state inline with the GovUk Design System guidelines.
    /// This binder must be used alongside a GovUkDataBindingOptionalDecimalErrorTextAttribute attribute.
    /// </summary>
    public class GovUkOptionalDecimalBinder : GovUkDecimalBinderBase, IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var errorTextAttribute = bindingContext.ModelMetadata.ValidatorMetadata.OfType<GovUkDataBindingOptionalDecimalErrorTextAttribute>().SingleOrDefault();
            if (errorTextAttribute == null)
            {
                throw new Exception("When using the GovUkOptionalDecimalBinder you must also provide a GovUkDataBindingOptionalDecimalErrorTextAttribute attribute and ensure that you register GovUkDataBindingErrorTextProvider in your application's Startup.ConfigureServices method.");
            }

            return BindModelBase(bindingContext, null, errorTextAttribute.NameAtStartOfSentence, errorTextAttribute.MustBeNumberErrorMessage);
        }
    }
}
