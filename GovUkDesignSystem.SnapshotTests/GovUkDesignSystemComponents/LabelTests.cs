using System.Collections.Generic;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.SnapshotTests.Helpers;
using Xunit;

namespace GovUkDesignSystem.SnapshotTests.GovUkDesignSystemComponents
{
    public class LabelTests : SnapshotTestBase
    {
        private LabelViewModel DefaultLabelViewModel()
        {
            return new LabelViewModel
            {
                Text = "text",
                Html = o => "html",
                Attributes = new Dictionary<string, string> {{"attr-name", "attr-value"}},
                Classes = "cssClass",
                For = "for",
                IsPageHeading = false
            };
        }

        [Fact]
        public async Task Render_AllValues()
        {
            // Act & Assert
            await VerifyPartial("Label", DefaultLabelViewModel());
        }

        [Fact]
        public async Task Render_NoHtml()
        {
            // Arrange
            var viewModel = DefaultLabelViewModel();
            viewModel.Html = null;

            // Act & Assert
            await VerifyPartial("Label", viewModel);
        }

        [Fact]
        public async Task Render_AsPageHeading()
        {
            // Arrange
            var viewModel = DefaultLabelViewModel();
            viewModel.IsPageHeading = true;

            // Act & Assert
            await VerifyPartial("Label", viewModel);
        }
    }
}
