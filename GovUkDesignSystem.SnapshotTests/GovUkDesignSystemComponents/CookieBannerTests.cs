using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.SnapshotTests.Helpers;
using Xunit;

namespace GovUkDesignSystem.SnapshotTests.GovUkDesignSystemComponents
{
    public class CookieBannerTests : SnapshotTestBase
    {
        private CookieBannerViewModel DefaultCookieBannerViewModel()
        {
            // TODO
            return new CookieBannerViewModel
            {};
        }

        [Fact]
        public async Task Render_AllValues()
        {
            // Act & Assert
            await VerifyPartial("CookieBanner", DefaultCookieBannerViewModel());
        }
    }
}