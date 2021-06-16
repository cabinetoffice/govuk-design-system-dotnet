using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Logging;
using System;

namespace GovUkDesignSystem.ModelBinders
{
    public class GovUkCheckboxEnumSetBinder<T> : CollectionModelBinder<T> where T : Enum
    {
        public GovUkCheckboxEnumSetBinder(ILoggerFactory loggerFactory) :
            base(new GovUkCheckboxEnumBinder<T>(loggerFactory), loggerFactory)
        { }
    }
}
