using System;
using System.Collections.Generic;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;

namespace GovUkDesignSystem.GovUkDesignSystemComponents;

public class NotificationBannerViewModel: IHtmlText
{
    
    /// <summary>
    /// <b>Required.</b> The text that displays in the notification banner. You can use any string with this option.
    /// If you set html, this option is not required and is ignored.
    /// </summary>
    public string Text { get; set; }
    
    /// <summary>
    /// <b>Required.</b> The HTML to use within the notification banner. You can use any HTML with this option.
    /// If you set html, text is not required and is ignored.
    /// </summary>
    public Func<object, object> Html { get; set; }
    
    /// <summary>
    /// The title text that displays in the notification banner. You can use any string with this option.
    /// Use this option to set text that does not contain HTML.
    /// The available default values are 'Important', 'Success', and null:
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// if you do not set type, titleText defaults to 'Important'
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// if you set type to success, titleText defaults to 'Success'
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// if you set titleHtml, this option is ignored
    /// </description>
    /// </item>
    /// </list>
    /// </summary>
    public string TitleText { get; set; }
    
    /// <summary>
    /// The title HTML to use within the notification banner. You can use any HTML with this option.
    /// Use this option to set text that contains HTML. If you set titleHtml, the titleText option is ignored.
    /// </summary>
    public Func<object, object> TitleHtml { get; set; }
    
    /// <summary>
    /// Sets heading level for the title only. You can only use values between 1 and 6 with this option.
    /// The default is 2.
    /// </summary>
    public string TitleHeadingLevel { get; set; }
    
    /// <summary>
    /// The type of notification to render. You can use only the "success" or null values with this option.
    /// If you set type to "success", the notification banner sets role to alert.
    /// JavaScript then moves the keyboard focus to the notification banner when the page loads.
    /// If you do not set type, the notification banner sets role to region.
    /// </summary>
    public string Type { get; set; }
    
    /// <summary>
    /// Overrides the value of the role attribute for the notification banner.
    /// Defaults to region. If you set type to success, role defaults to alert.
    /// </summary>
    public string Role { get; set; }
    
    /// <summary>
    /// The id for the banner title, and the aria-labelledby attribute in the banner.
    /// Defaults to govuk-notification-banner-title.
    /// </summary>
    public string TitleId { get; set; }
    
    /// <summary>
    /// If you set type to success, or role to alert, JavaScript moves the keyboard focus to the notification banner
    /// when the page loads. To disable this behaviour, set disableAutoFocus to true.
    /// </summary>
    public bool DisableAutoFocus { get; set; }
    
    /// <summary>
    /// The classes that you want to add to the notification banner.
    /// </summary>
    public string Classes { get; set; }
    
    /// <summary>
    /// The HTML attributes that you want to add to the notification banner, for example, data attributes.
    /// </summary>
    public Dictionary<string, string> Attributes { get; set; }
}