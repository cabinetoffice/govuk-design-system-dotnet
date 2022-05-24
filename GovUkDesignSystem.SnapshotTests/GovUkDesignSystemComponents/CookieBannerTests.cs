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
                UseAntiForgeryToken = false,
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
        
        [Fact]
        public async Task Render_AdditionalCookies()
        {
            // Arrange
            var viewModel = DefaultCookieBannerViewModel();
            viewModel.CookieType = CookieType.Additional;
            
            // Act & Assert
            await VerifyPartial("CookieBanner", viewModel);
        }
        
        [Fact]
        public async Task Render_AcceptedBanner()
        {
            // Arrange
            var viewModel = DefaultCookieBannerViewModel();
            viewModel.BannerState = BannerState.ShowAccepted;
            
            // Act & Assert
            await VerifyPartial("CookieBanner", viewModel);
        }
        
        [Fact]
        public async Task Render_RejectedBanner()
        {
            // Arrange
            var viewModel = DefaultCookieBannerViewModel();
            viewModel.BannerState = BannerState.ShowRejected;
            
            // Act & Assert
            await VerifyPartial("CookieBanner", viewModel);
        }
        
        [Fact]
        public async Task Render_HiddenBanner()
        {
            // Arrange
            var viewModel = DefaultCookieBannerViewModel();
            viewModel.BannerState = BannerState.Hide;
            
            // Act & Assert
            await VerifyPartial("CookieBanner", viewModel);
        }
    }
}