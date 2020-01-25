using GovUkDesignSystem.Attributes;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System.Linq;

namespace GovUkDesignSystem.ModelBinders
{
    /// <summary>
    /// This class ensures that any attributes required by the GovUk custom model binders are available in the binding
    /// context's ValidatorMetadata property.
    /// </summary>
    public class GovUkValidationMetadataProvider : IValidationMetadataProvider
    {
        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
            foreach (var attribute in context.Attributes.OfType<GovUkDisplayNameForErrorsAttribute>())
            {
                context.ValidationMetadata.ValidatorMetadata.Add(attribute);
            }
        }
    }
}
