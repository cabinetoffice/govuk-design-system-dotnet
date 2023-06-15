using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.SnapshotTests.Helpers;
using Xunit;

namespace GovUkDesignSystem.SnapshotTests.GovUkDesignSystemComponents
{
    public class LegendTests : SnapshotTestBase
    {
        private LegendViewModel DefaultLegendViewModel()
        {
            return new LegendViewModel
            {
                Text = "text",
                Html = o => "html",
                Classes = "cssClass",
                IsPageHeading = false
            };
        }

        [Fact]
        public async Task Render_AllValues()
        {
            // Act & Assert
            await VerifyPartial("Legend", DefaultLegendViewModel());
        }

        [Fact]
        public async Task Render_NoHtml()
        {
            // Arrange
            var viewModel = DefaultLegendViewModel();
            viewModel.Html = null;

            // Act & Assert
            await VerifyPartial("Legend", viewModel);
        }

        [Fact]
        public async Task Render_AsPageHeading()
        {
            // Arrange
            var viewModel = DefaultLegendViewModel();
            viewModel.IsPageHeading = true;

            // Act & Assert
            await VerifyPartial("Legend", viewModel);
        }
    }
}
