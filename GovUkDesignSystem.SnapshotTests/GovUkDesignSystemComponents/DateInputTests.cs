using System.Collections.Generic;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.SnapshotTests.Helpers;
using Xunit;

namespace GovUkDesignSystem.SnapshotTests.GovUkDesignSystemComponents
{
    public class DateInputTests : SnapshotTestBase
    {
        private DateInputViewModel DefaultItemSetViewModel()
        {
            return new DateInputViewModel
                   {
                       Id = "test-id",
                       NamePrefix = "test-name-prefix",
                       Items = new List<DateInputItemViewModel>
                               {
                                   new DateInputItemViewModel
                                   {
                                       Name = "test-item-name",
                                       Value = "test item value"
                                   }
                               },
                       Hint = new HintViewModel { Text = "test-hint" },
                       ErrorMessage = new ErrorMessageViewModel { Text = "test-error" },
                       FormGroup = new FormGroupViewModel { Classes = "form-group-classes" },
                       Fieldset = new FieldsetViewModel
                                  {
                                      InnerHtml = (o) => "test fieldset HTML",
                                      DescribedBy = "test-fieldset-described-by",
                                      Legend = new LegendViewModel { Text = "test legend" }
                                  },
                       Classes = "test-css-class",
                       Attributes = new Dictionary<string, string> { { "attr-name", "attr-value" } }
                   };
        }

        [Fact]
        public async Task Render_AllValues()
        {
            // Act & Assert
            await VerifyPartial("DateInput", DefaultItemSetViewModel());
        }

        [Fact]
        public async Task Render_NoNamePrefix()
        {
            // Arrange
            var viewModel = DefaultItemSetViewModel();
            viewModel.NamePrefix = null;

            // Act & Assert
            await VerifyPartial("DateInput", viewModel);
        }

        [Fact]
        public async Task Render_NoHint()
        {
            // Arrange
            var viewModel = DefaultItemSetViewModel();
            viewModel.Hint = null;

            // Act & Assert
            await VerifyPartial("DateInput", viewModel);
        }

        [Fact]
        public async Task Render_NoErrorMessage()
        {
            // Arrange
            var viewModel = DefaultItemSetViewModel();
            viewModel.ErrorMessage = null;

            // Act & Assert
            await VerifyPartial("DateInput", viewModel);
        }

        [Fact]
        public async Task Render_NoFormGroup()
        {
            // Arrange
            var viewModel = DefaultItemSetViewModel();
            viewModel.FormGroup = null;

            // Act & Assert
            await VerifyPartial("DateInput", viewModel);
        }

        [Fact]
        public async Task Render_NoFieldSet()
        {
            // Arrange
            var viewModel = DefaultItemSetViewModel();
            viewModel.Fieldset = null;

            // Act & Assert
            await VerifyPartial("DateInput", viewModel);
        }
    }
}
