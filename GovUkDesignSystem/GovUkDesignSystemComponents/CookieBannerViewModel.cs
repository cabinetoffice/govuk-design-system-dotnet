using System.Collections.Generic;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;

namespace GovUkDesignSystem.GovUkDesignSystemComponents;

public class CookieBannerViewModel
{
    /// <summary>
    /// 	The text for the aria-label which labels the cookie banner region.
    ///     This region applies to all messages that the cookie banner includes.
    ///     For example, the cookie message and the confirmation message. Defaults to 'Cookie banner'.
    /// </summary>
    public string AriaLabel { get; set; }
    
    /// <summary>
    ///     Defaults to false. If you set this option to true, the whole cookie banner is hidden,
    ///     including all messages within the banner. You can use hidden for client-side implementations where the
    ///     cookie banner HTML is present, but hidden until the cookie banner is shown using JavaScript.
    /// </summary>
    public bool Hidden { get; set; }
    
    /// <summary>
    ///     The additional classes that you want to add to the cookie banner.
    /// </summary>
    public string Classes { get; set; }
    
    /// <summary>
    ///     The additional attributes that you want to add to the cookie banner. For example, data attributes.
    /// </summary>
    public Dictionary<string, string> Attributes { get; set; }
    
    /// <summary>
    /// 	<b>Required</b>. The different messages you can pass into the cookie banner.
    ///     For example, the cookie message and the confirmation message.
    /// </summary>
    public List<CookieBannerMessageViewModel> Messages { get; set; }
}