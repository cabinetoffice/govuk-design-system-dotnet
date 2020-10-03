using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Logging;

namespace GovUkDesignSystem.ModelBinders
{
    /// <summary>
    /// Model binder for checkboxes bound to strings that will ignore the special dummy value used in the hidden field.
    /// </summary>
    public class GovUkCheckboxStringBinder : GovUkCheckboxBinderBase
    {
        public GovUkCheckboxStringBinder(ILoggerFactory loggerFactory) :
            base(new SimpleTypeModelBinder(typeof(string), loggerFactory))
        {
        }
    }
}
