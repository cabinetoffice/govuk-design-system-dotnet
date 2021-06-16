using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Logging;

namespace GovUkDesignSystem.ModelBinders
{
    /// <summary>
    /// Model binder for checkboxes bound to bools that will ignore the special dummy value used in the hidden field.
    /// </summary>
    public class GovUkCheckboxBoolBinder : GovUkCheckboxBinderBase
    {
        public GovUkCheckboxBoolBinder(ILoggerFactory loggerFactory) :
            base(new SimpleTypeModelBinder(typeof(bool), loggerFactory))
        {
        }
    }
}
