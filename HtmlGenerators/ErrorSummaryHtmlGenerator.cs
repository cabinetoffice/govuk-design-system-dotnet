using System.Collections.Generic;
using System.Linq;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovUkDesignSystem.HtmlGenerators
{
    public static class ErrorSummaryHtmlGenerator
    {
        public static IHtmlContent GenerateHtml<TModel>(
            IHtmlHelper<TModel> htmlHelper,
            string[] orderOfPropertyNamesInTheView)
            where TModel : GovUkViewModel
        {
            TModel model = htmlHelper.ViewData.Model;

            if (!model.HasAnyErrors())
            {
                return null;
            }

            Dictionary<string, string> errors = model.GetAllErrors();

            var orderedPropertyNames = GetErroredPropertyNamesInSpecifiedOrder(errors, orderOfPropertyNamesInTheView);

            var errorSummaryItems = orderedPropertyNames
                .Select(propertyName =>
                    new ErrorSummaryItemViewModel
                    {
                        Href = $"#GovUk_{propertyName}-error",
                        Text = errors[propertyName]
                    })
                .ToList();

            var errorSummaryViewModel = new ErrorSummaryViewModel
            {
                Title = new ErrorSummaryTitle
                {
                    Text = "There is a problem"
                },
                Errors = errorSummaryItems
            };

            return htmlHelper.Partial("/GovUkDesignSystemComponents/ErrorSummary.cshtml", errorSummaryViewModel);
        }

        private static List<string> GetErroredPropertyNamesInSpecifiedOrder(
            Dictionary<string, string> errors,
            string[] orderOfPropertyNamesInTheView)
        {
            List<string> erroredPropertyNames = errors.Keys.ToList();

            List<string> erroredPropertyNamesWithSpecifiedOrder =
                orderOfPropertyNamesInTheView.Where(p => erroredPropertyNames.Contains(p)).ToList();

            List<string> erroredPropertyNamesWithoutSpecifiedOrder =
                erroredPropertyNames.Except(erroredPropertyNamesWithSpecifiedOrder).ToList();

            List<string> orderedPropertyNames =
                erroredPropertyNamesWithSpecifiedOrder.Concat(erroredPropertyNamesWithoutSpecifiedOrder).ToList();

            return orderedPropertyNames;
        }
    }
}