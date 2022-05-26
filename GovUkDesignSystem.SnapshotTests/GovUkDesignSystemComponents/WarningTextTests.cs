using System.Collections.Generic;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.SnapshotTests.Helpers;
using Xunit;

namespace GovUkDesignSystem.SnapshotTests.GovUkDesignSystemComponents
{
    public class WarningTextTests : SnapshotTestBase
    {
        private WarningTextViewModel DefaultWarningTextViewModel()
        {
            return new WarningTextViewModel
            {
                IconFallbackText = "Warning",
                Text = "This is a warning!",
                Classes = "test-class",
                Attributes = new Dictionary<string, string>
                {
                    {"key", "value"}
                }
            };
        }

        [Fact]
        public async Task Render_AllValues()
        {
            // Act & Assert
            await VerifyPartial("WarningText", DefaultWarningTextViewModel());
        }
        
        [Fact]
        public async Task Render_Html()
        {
            // Arrange
            var viewModel = DefaultWarningTextViewModel();
            viewModel.Text = null;
            viewModel.Html = o => "html";
            
            // Act & Assert
            await VerifyPartial("WarningText", viewModel);
        }
    }
}