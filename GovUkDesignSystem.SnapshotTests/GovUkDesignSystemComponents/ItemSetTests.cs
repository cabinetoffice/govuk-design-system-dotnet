using System.Collections.Generic;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.SnapshotTests.Helpers;
using Xunit;

namespace GovUkDesignSystem.SnapshotTests.GovUkDesignSystemComponents
{
    /// <summary>
    /// As ItemSetViewModel is abstract we use CheckboxesViewModel in these tests.
    /// </summary>
    public class ItemSetTests : SnapshotTestBase
    {
        private CheckboxesViewModel DefaultItemSetViewModel()
        {
            return new CheckboxesViewModel
                   {
                       Fieldset = new FieldsetViewModel
                                  {
                                      InnerHtml = (o) => "test fieldset HTML",
                                      DescribedBy = "test-fieldset-described-by",
                                      Legend = new LegendViewModel { Text = "test legend" }
                                  },
                       Hint = new HintViewModel { Text = "test-hint" },
                       ErrorMessage = new ErrorMessageViewModel { Text = "test-error" },
                       FormGroup = new FormGroupViewModel { Classes = "form-group-classes" },
                       IdPrefix = "test-id-prefix",
                       Name = "test-name",
                       Classes = "test-css-class",
                       Attributes = new Dictionary<string, string> { { "attr-name", "attr-value" } },
                       Items = new List<ItemViewModel>
                               {
                                   new CheckboxItemViewModel
                                   {
                                       Value = "test item value"
                                   }
                               }
                   };
        }

        [Fact]
        public async Task Render_AllValues()
        {
            // Act & Assert
            await VerifyPartial("ItemSet", DefaultItemSetViewModel());
        }

        [Fact]
        public async Task Render_NoFieldSet()
        {
            // Arrange
            var viewModel = DefaultItemSetViewModel();
            viewModel.Fieldset = null;

            // Act & Assert
            await VerifyPartial("ItemSet", viewModel);
        }

        [Fact]
        public async Task Render_NoHint()
        {
            // Arrange
            var viewModel = DefaultItemSetViewModel();
            viewModel.Hint = null;

            // Act & Assert
            await VerifyPartial("ItemSet", viewModel);
        }

        [Fact]
        public async Task Render_NoErrorMessage()
        {
            // Arrange
            var viewModel = DefaultItemSetViewModel();
            viewModel.ErrorMessage = null;

            // Act & Assert
            await VerifyPartial("ItemSet", viewModel);
        }

        [Fact]
        public async Task Render_ConditionalItem()
        {
            // Arrange
            var viewModel = DefaultItemSetViewModel();
            viewModel.Items[0].Conditional = new Conditional { Text = "test item conditional text" };

            // Act & Assert
            await VerifyPartial("ItemSet", viewModel);
        }

        [Fact]
        public async Task Render_NoDescribedBy()
        {
            // Arrange
            var viewModel = DefaultItemSetViewModel();
            viewModel.Fieldset.DescribedBy = null;
            viewModel.Hint = null;
            viewModel.ErrorMessage = null;

            // Act & Assert
            await VerifyPartial("ItemSet", viewModel);
        }
    }
}
