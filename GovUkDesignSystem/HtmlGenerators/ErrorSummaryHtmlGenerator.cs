using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovUkDesignSystem.HtmlGenerators
{
    public static class ErrorSummaryHtmlGenerator
    {
        internal static async Task<IHtmlContent> GenerateHtml(
            this IHtmlHelper htmlHelper,
            ModelStateDictionary modelState,
            string[] orderOfPropertyNamesInTheView, string errorSummaryTitle,
            string idPrefix = null)
        {
            if (modelState.IsValid)
            {
                return null;
            }

            // IndexOf returns -1 for items not in the property ordering list so we
            // reverse the list and order by descending index.
            var reversedPropertyOrder = orderOfPropertyNamesInTheView.Reverse().ToList();
            var propertiesWithErrorsInOrder = modelState
                .Where(mse => mse.Value.Errors.Count > 0)
                .OrderByDescending(mse => reversedPropertyOrder.IndexOf(mse.Key));
            
            var errorSummaryItems = propertiesWithErrorsInOrder
                .SelectMany(mse => mse.Value.Errors.Select(error => new Tuple<string, string>(mse.Key, error.ErrorMessage)))
                .Select(tuple => new ErrorSummaryItemViewModel { Href = $"#{tuple.Item1}-error", Text = tuple.Item2 })
                .ToList();

            var errorSummaryViewModel = new ErrorSummaryViewModel
            {
                Title = new ErrorSummaryTitle
                {
                    Text = errorSummaryTitle
                },
                Errors = errorSummaryItems
            };

            return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/ErrorSummary.cshtml", errorSummaryViewModel);
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
