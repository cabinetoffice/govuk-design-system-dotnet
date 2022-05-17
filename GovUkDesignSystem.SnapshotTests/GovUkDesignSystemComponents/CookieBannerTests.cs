using System.Collections.Generic;
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
            return new CookieBannerViewModel
            {
                BannerState = BannerState.ShowBanner,
                CookieType = CookieType.Analytics,
                ButtonClickAction = "link_after_accept_or_reject",
                ViewCookiesLink = "link_to_view_cookies",
                ReturnUrl = "original_url"
            };
        }

        [Fact]
        public async Task Render_AllValues()
        {
            // Act & Assert
            await VerifyPartial("CookieBanner", DefaultCookieBannerViewModel());
        }
    }
}