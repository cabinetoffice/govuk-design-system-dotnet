using GovUkDesignSystem.Attributes.DataBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GovUkDesignSystem.ModelBinders
{
    /// <summary>
    /// This model binder can be used to replace the default MVC model binder for a required decimal property.
    /// It will add  validation messages to the model state inline with the GovUk Design System guidelines.
    /// This binder must be used alongside a GovUkDataBindingMandatoryDecimalErrorTextAttribute attribute.
    /// </summary>
    public class GovUkMandatoryDecimalBinder : GovUkDecimalBinderBase, IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var errorTextAttribute = bindingContext.ModelMetadata.ValidatorMetadata.OfType<GovUkDataBindingMandatoryDecimalErrorTextAttribute>().SingleOrDefault();
            if (errorTextAttribute == null)
            {
                throw new Exception("When using the GovUkMandatoryDecimalBinder you must also provide a GovUkDataBindingMandatoryDecimalErrorTextAttribute attribute and ensure that you register GovUkDataBindingErrorTextProvider in your application's Startup.ConfigureServices method.");
            }

            return BindModelBase(bindingContext, errorTextAttribute.ErrorMessageIfMissing, errorTextAttribute.NameAtStartOfSentence, errorTextAttribute.MustBeNumberErrorMessage);
        }

    }
}