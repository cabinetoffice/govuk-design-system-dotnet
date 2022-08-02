using System.Collections.Generic;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.SnapshotTests.Helpers;
using Xunit;

namespace GovUkDesignSystem.SnapshotTests.GovUkDesignSystemComponents
{
    public class ButtonTests : SnapshotTestBase
    {
        private ButtonViewModel DefaultLabelViewModel()
        {
            return new ButtonViewModel
            {
                Name = "test-name",
                Value = "test-value",
                Disabled = false,
                PreventDoubleClick = true,
                PreventDoubleClickTimeout = 2,
                IsStartButton = false,
                Classes = "test-css-class",
                Attributes = new Dictionary<string, string> { { "attr-name", "attr-value" } },
                Text = "test text",
                Html = o => "test html"
            };
        }

        [Fact]
        public async Task Render_AllValues()
        {
            // Act & Assert
            await VerifyPartial("Button", DefaultLabelViewModel());
        }

        [Fact]
        public async Task Render_Disabled()
        {
            // Arrange
            var viewModel = DefaultLabelViewModel();
            viewModel.Disabled = true;

            // Act & Assert
            await VerifyPartial("Button", viewModel);
        }

        [Fact]
        public async Task Render_StartButton()
        {
            // Arrange
            var viewModel = DefaultLabelViewModel();
            viewModel.IsStartButton = true;

            // Act & Assert
            await VerifyPartial("Button", viewModel);
        }

        [Fact]
        public async Task Render_AsLink()
        {
            // Arrange
            var viewModel = DefaultLabelViewModel();
            viewModel.Href = "test-href";

            // Act & Assert
            await VerifyPartial("Button", viewModel);
        }

        [Fact]
        public async Task Render_AsDisabledLink()
        {
            // Arrange
            var viewModel = DefaultLabelViewModel();
            viewModel.Href = "test-href";
            viewModel.Disabled = true;

            // Act & Assert
            await VerifyPartial("Button", viewModel);
        }

        [Fact]
        public async Task Render_AsInput()
        {
            // Arrange
            var viewModel = DefaultLabelViewModel();
            viewModel.Element = "input";

            // Act & Assert
            await VerifyPartial("Button", viewModel);
        }

        [Fact]
        public async Task Render_AsDisabledInput()
        {
            // Arrange
            var viewModel = DefaultLabelViewModel();
            viewModel.Element = "input";
            viewModel.Disabled = true;

            // Act & Assert
            await VerifyPartial("Button", viewModel);
        }
    }
}
