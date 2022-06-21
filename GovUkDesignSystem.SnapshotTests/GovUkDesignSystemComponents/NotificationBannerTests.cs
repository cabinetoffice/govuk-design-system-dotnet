using System.Collections.Generic;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;
using GovUkDesignSystem.SnapshotTests.Helpers;
using Xunit;

namespace GovUkDesignSystem.SnapshotTests.GovUkDesignSystemComponents
{
    public class CNotificationBannerTests : SnapshotTestBase
    {
        private NotificationBannerViewModel DefaultNotificationBannerViewModel()
        {
            return new NotificationBannerViewModel
            {
                Text = "Banner text",
                TitleText = "Title text",
                TitleHeadingLevel = "3",
                Type = "success",
                TitleId = "title-id",
                DisableAutoFocus = true,
                Classes = "custom-class"
            };
        }

        [Fact]
        public async Task Render_AllValues()
        {
            // Act & Assert
            await VerifyPartial("NotificationBanner", DefaultNotificationBannerViewModel());
        }
    }
}