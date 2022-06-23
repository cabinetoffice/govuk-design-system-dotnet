using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.GovUkDesignSystemComponents.Enums;
using GovUkDesignSystem.SnapshotTests.Helpers;
using Xunit;

namespace GovUkDesignSystem.SnapshotTests.GovUkDesignSystemComponents
{
    public class PanelTests : SnapshotTestBase
    {
        private PanelViewModel DefaultPanelViewModel()
        {
            return new PanelViewModel
            {
                TitleText = "Title text",
                HeadingLevel = HeadingLevel.h1,
                Classes = "panel-class",
                Text = "Panel text"
            };
        }

        [Fact]
        public async Task Render_AllValues()
        {
            // Act & Assert
            await VerifyPartial("Panel", DefaultPanelViewModel());
        }
        
        [Fact]
        public async Task Render_Html()
        {
            // Arrange
            var viewModel = DefaultPanelViewModel();
            viewModel.Text = null;
            viewModel.Html = o => "Html body";
            viewModel.TitleText = null;
            viewModel.TitleHtml = o => "Html title";
            
            // Act & Assert
            await VerifyPartial("Panel", viewModel);
        }
    }
}