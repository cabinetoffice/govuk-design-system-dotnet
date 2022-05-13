using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Logging;
using System;

namespace GovUkDesignSystem.ModelBinders
{
    /// <summary>
    /// Model binder for checkboxes bound to enums that will ignore the special dummy value used in the hidden field.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GovUkCheckboxEnumBinder<T> : GovUkCheckboxBinderBase where T : Enum
    {
        public GovUkCheckboxEnumBinder(ILoggerFactory loggerFactory) :
            // First param is _suppressBindingUndefinedValueToEnumType. If this is false the binder won't check that the value is actually in the enum.
            base(new EnumTypeModelBinder(true, typeof(T), loggerFactory))
        {
        }
    }
}
