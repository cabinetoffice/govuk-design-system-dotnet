using System.Collections.Generic;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.SnapshotTests.Helpers;
using Xunit;

namespace GovUkDesignSystem.SnapshotTests.GovUkDesignSystemComponents
{
    /// <summary>
    /// As ItemViewModel is abstract we use CheckboxItemViewModel in these tests.
    /// </summary>
    public class ItemTests : SnapshotTestBase
    {
        private CheckboxItemViewModel DefaultItemViewModel()
        {
            return new CheckboxItemViewModel
            {
                Id = "test-id",
                Name = "test-name",
                Value = "test value",
                Classes = "test-css-class",
                Label = new LabelViewModel { Text = "test-label" },
                Hint = new HintViewModel { Text = "test-hint" },
                Conditional = new Conditional { Text = "test-conditional-text" },
                Divider = "test-divider",
                Checked = false,
                Disabled = false,
                Attributes = new Dictionary<string, string> { { "attr-name", "attr-value" } }
            };
        }

        [Fact]
        public async Task Render_AllValues()
        {
            // Act & Assert
            await VerifyPartial("Item", DefaultItemViewModel());
        }

        [Fact]
        public async Task Render_NoLabel()
        {
            // Arrange
            var viewModel = DefaultItemViewModel();
            viewModel.Label = null;

            // Act & Assert
            await VerifyPartial("Item", viewModel);
        }

        [Fact]
        public async Task Render_NoHint()
        {
            // Arrange
            var viewModel = DefaultItemViewModel();
            viewModel.Hint = null;

            // Act & Assert
            await VerifyPartial("Item", viewModel);
        }

        [Fact]
        public async Task Render_NoConditional()
        {
            // Arrange
            var viewModel = DefaultItemViewModel();
            viewModel.Conditional = null;

            // Act & Assert
            await VerifyPartial("Item", viewModel);
        }

        [Fact]
        public async Task Render_Checked()
        {
            // Arrange
            var viewModel = DefaultItemViewModel();
            viewModel.Checked = true;

            // Act & Assert
            await VerifyPartial("Item", viewModel);
        }

        [Fact]
        public async Task Render_Disabled()
        {
            // Arrange
            var viewModel = DefaultItemViewModel();
            viewModel.Disabled = true;

            // Act & Assert
            await VerifyPartial("Item", viewModel);
        }
    }
}
