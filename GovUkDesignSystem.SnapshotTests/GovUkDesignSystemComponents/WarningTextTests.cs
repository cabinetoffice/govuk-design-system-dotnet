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
                Text = "This is a warning!"
            };
        }

        [Fact]
        public async Task Render_AllValues()
        {
            // Act & Assert
            await VerifyPartial("WarningText", DefaultWarningTextViewModel());
        }
    }
}