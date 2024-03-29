﻿using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.GovUkDesignSystemComponents.Enums;
using GovUkDesignSystem.SnapshotTests.Helpers;
using Xunit;

namespace GovUkDesignSystem.SnapshotTests.GovUkDesignSystemComponents
{
    public class NotificationBannerTests : SnapshotTestBase
    {
        private NotificationBannerViewModel DefaultNotificationBannerViewModel()
        {
            return new NotificationBannerViewModel
            {
                Text = "Banner text",
                TitleText = "Title text",
                TitleHeadingLevel = HeadingLevel.h3,
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
        
        [Fact]
        public async Task Render_WithHtml()
        {
            // Arrange
            var viewModel = DefaultNotificationBannerViewModel();
            viewModel.Text = null;
            viewModel.Html = o => "html text";
            viewModel.TitleText = null;
            viewModel.TitleHtml = o => "html title";
            viewModel.Role = "region";
            
            // Act & Assert
            await VerifyPartial("NotificationBanner", viewModel);
        }
    }
}