using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Logging;

namespace GovUkDesignSystem.ModelBinders
{
    public class GovUkCheckboxStringSetBinder : CollectionModelBinder<string>
    {
        public GovUkCheckboxStringSetBinder(ILoggerFactory loggerFactory) :
            base(new GovUkCheckboxStringBinder(loggerFactory), loggerFactory)
        { }
    }
}
