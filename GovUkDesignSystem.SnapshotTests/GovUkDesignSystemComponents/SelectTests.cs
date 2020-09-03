using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.SnapshotTests.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GovUkDesignSystem.SnapshotTests.GovUkDesignSystemComponents
{
    public class SelectTests : SnapshotTestBase
    {
        private const string ViewName = "Select";

        private static SelectViewModel DefaultSelectViewModel()
        {
            return new SelectViewModel
            {
                Id = "test-id",
                Name = "test-name",
                Classes = "test-css-class",
                DescribedBy = "test-described-by",
                Items = new List<SelectItemViewModel>
                {
                    new SelectItemViewModel
                    {
                        Value = "test-item-value",
                        Text = "Test Item Text",
                        Selected = true,
                        Disabled = false,
                        Attributes = new Dictionary<string, string> { { "item-attr-name", "item-attr-value" } }
                    }
                },
                Label = new LabelViewModel { Text = "test-label" },
                Hint = new HintViewModel { Text = "test-hint" },
                ErrorMessage = new ErrorMessageViewModel { Text = "test-error" },
                FormGroup = new FormGroupViewModel { Classes = "form-group-classes" },
                Attributes = new Dictionary<string, string> { { "attr-name", "attr-value" } }
            };
        }

        [Fact]
        public async Task Render_AllValues()
        {
            // Act & Assert
            await VerifyPartial(ViewName, DefaultSelectViewModel());
        }

        [Fact]
        public async Task Render_NoLabel()
        {
            // Arrange
            var viewModel = DefaultSelectViewModel();
            viewModel.Label = null;

            // Act & Assert
            await VerifyPartial(ViewName, viewModel);
        }

        [Fact]
        public async Task Render_NoHint()
        {
            // Arrange
            var viewModel = DefaultSelectViewModel();
            viewModel.Hint = null;

            // Act & Assert
            await VerifyPartial(ViewName, viewModel);
        }

        [Fact]
        public async Task Render_NoErrorMessage()
        {
            // Arrange
            var viewModel = DefaultSelectViewModel();
            viewModel.ErrorMessage = null;

            // Act & Assert
            await VerifyPartial(ViewName, viewModel);
        }

        [Fact]
        public async Task Render_NoFormGroup()
        {
            // Arrange
            var viewModel = DefaultSelectViewModel();
            viewModel.FormGroup = null;

            // Act & Assert
            await VerifyPartial(ViewName, viewModel);
        }

        [Fact]
        public async Task Render_NoAttributes()
        {
            // Arrange
            var viewModel = DefaultSelectViewModel();
            viewModel.Attributes = null;
            viewModel.Items[0].Attributes = null;

            // Act & Assert
            await VerifyPartial(ViewName, viewModel);
        }

        [Fact]
        public async Task Render_NoDescribedBy()
        {
            // Arrange
            var viewModel = DefaultSelectViewModel();
            viewModel.DescribedBy = null;
            viewModel.Hint = null;
            viewModel.ErrorMessage = null;

            // Act & Assert
            await VerifyPartial(ViewName, viewModel);
        }

        [Fact]
        public async Task Render_UnselectedItem()
        {
            // Arrange
            var viewModel = DefaultSelectViewModel();
            viewModel.Items[0].Selected = false;

            // Act & Assert
            await VerifyPartial(ViewName, viewModel);
        }

        [Fact]
        public async Task Render_DisabledItem()
        {
            // Arrange
            var viewModel = DefaultSelectViewModel();
            viewModel.Items[0].Selected = false;
            viewModel.Items[0].Disabled = true;

            // Act & Assert
            await VerifyPartial(ViewName, viewModel);
        }
    }
}
