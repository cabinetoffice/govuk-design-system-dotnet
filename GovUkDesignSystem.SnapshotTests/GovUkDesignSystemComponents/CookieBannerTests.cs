using System.Collections.Generic;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;
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
                AriaLabel = "Cookies on unnamed service",
                Classes = "banner-classes",
                Messages = new List<CookieBannerMessageViewModel>
                {
                    new CookieBannerMessageViewModel
                    {
                        Actions = new List<CookieBannerMessageActionViewModel>
                        {
                            new CookieBannerMessageActionViewModel
                            {
                                Classes = "action-classes",
                                Href = "#",
                                Text = "Button text",
                                Type = "button"
                            }
                        },
                        Classes = "message-classes",
                        HeadingText = "Heading text",
                        Role = "Banner",
                        Text = "Message text"
                    }
                }
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