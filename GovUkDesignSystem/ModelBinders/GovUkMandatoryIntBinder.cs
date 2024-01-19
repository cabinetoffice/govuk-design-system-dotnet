using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Threading.Tasks;
using GovUkDesignSystem.Attributes.DataBinding;
using System;

namespace GovUkDesignSystem.ModelBinders
{
    /// <summary>
    /// This model binder can be used to replace the default MVC model binder for a required int property. It will add
    /// validation messages to the model state inline with the GovUk Design System guidelines.
    /// This binder must be used alongside a GovUkDataBindingMandatoryIntErrorTextAttribute attribute.
    /// </summary>
    public class GovUkMandatoryIntBinder : GovUkIntBinderBase, IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var errorTextAttribute = bindingContext.ModelMetadata.ValidatorMetadata.OfType<GovUkDataBindingMandatoryIntErrorTextAttribute>().SingleOrDefault();
            if (errorTextAttribute == null)
            {
                throw new Exception("When using the GovUkMandatoryIntBinder you must also provide a GovUkDataBindingMandatoryIntErrorTextAttribute attribute and ensure that you register GovUkDataBindingErrorTextProvider in your application's Startup.ConfigureServices method.");
            }

            return BindModelBase(bindingContext, errorTextAttribute.ErrorMessageIfMissing, errorTextAttribute.NameAtStartOfSentence, errorTextAttribute.MustBeNumberErrorMessage, errorTextAttribute.IsWholeNumberErrorMessage);
        }
    }
}
