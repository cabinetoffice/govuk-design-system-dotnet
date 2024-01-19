using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Threading.Tasks;
using GovUkDesignSystem.Attributes.DataBinding;
using System;

namespace GovUkDesignSystem.ModelBinders
{
    /// <summary>
    /// This model binder can be used to replace the default MVC model binder for an optional int property. It will add
    /// validation messages to the model state inline with the GovUk Design System guidelines.
    /// This binder must be used alongside a GovUkDataBindingOptionalIntErrorTextAttribute attribute.
    /// </summary>
    public class GovUkOptionalIntBinder : GovUkIntBinderBase, IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var errorTextAttribute = bindingContext.ModelMetadata.ValidatorMetadata.OfType<GovUkDataBindingOptionalIntErrorTextAttribute>().SingleOrDefault();
            if (errorTextAttribute == null)
            {
                throw new Exception("When using the GovUkOptionalIntBinder you must also provide a GovUkDataBindingOptionalIntErrorTextAttribute attribute and ensure that you register GovUkDataBindingErrorTextProvider in your application's Startup.ConfigureServices method.");
            }
            
            return BindModelBase(bindingContext, null, errorTextAttribute.NameAtStartOfSentence, errorTextAttribute.MustBeNumberErrorMessage, errorTextAttribute.IsWholeNumberErrorMessage);
        }
    }
}
