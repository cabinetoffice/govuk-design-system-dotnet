using System;
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

public class CookieBannerMessageViewModel : IHtmlText
{
    /// <summary>
    ///     The heading text that displays in the message. You can use any string with this option.
    ///     If you set headingHtml, headingText is ignored.
    /// </summary>
    public string HeadingText { get; set; }
    
    /// <summary>
    ///     The heading HTML to use within the message. You can use any string with this option.
    ///     If you set headingHtml, headingText is ignored. If you are not passing HTML, use headingText.
    /// </summary>
    public string HeadingHtml { get; set; }
    
    /// <summary>
    /// 	<b>Required</b>. The text for the main content within the message. You can use any string with this option.
    ///     If you set html, text is not required and is ignored.
    /// </summary>
    public string Text { get; set; }
    
    /// <summary>
    ///     <b>Required</b>. The HTML for the main content within the message. You can use any string with this option.
    ///     If you set html, text is not required and is ignored. If you are not passing HTML, use text.
    /// </summary>
    public Func<object, object> Html { get; set; }
    
    /// <summary>
    ///     The buttons and links that you want to display in the message. Actions defaults to button unless you set href,
    ///     which renders the action as a link. See actions.
    /// </summary>
    public List<CookieBannerMessageActionViewModel> Actions { get; set; }
    
    /// <summary>
    /// 	Defaults to false. If you set it to true, the message is hidden. You can use hidden for client-side
    ///     implementations where the confirmation message HTML is present, but hidden on the page.
    /// </summary>
    public bool Hidden { get; set; }
    
    /// <summary>
    /// 	Set role to `alert` on confirmation messages to allow assistive tech to automatically read the message.
    ///     You will also need to move focus to the confirmation message using JavaScript you have written yourself.
    /// </summary>
    public string Role { get; set; }
    
    /// <summary>
    /// 	The additional classes that you want to add to the message.
    /// </summary>
    public string Classes { get; set; }
    
    /// <summary>
    /// 	The additional attributes that you want to add to the message. For example, data attributes.
    /// </summary>
    public Dictionary<string, string> Attributes { get; set; }
}

public class CookieBannerMessageActionViewModel {
    /// <summary>
    /// 	<b>Required</b>. The button or link text.
    /// </summary>
    public string Text { get; set; }
    
    /// <summary>
    ///     The type of button. You can set `button` or `submit`. Set button and href to render a link styled as a button.
    ///     If you set href, it overrides submit.
    /// </summary>
    public string Type { get; set; }
    
    /// <summary>
    ///     The href for a link. Set button and href to render a link styled as a button.
    /// </summary>
    public string Href { get; set; }
    
    /// <summary>
    ///     The name attribute for the button. Does not apply if you set href, which makes a link.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    ///     The value attribute for the button. Does not apply if you set href, which makes a link.
    /// </summary>
    public string Value { get; set; }
    
    /// <summary>
    ///     The additional classes that you want to add to the button or link.
    /// </summary>
    public string Classes { get; set; }
    
    /// <summary>
    /// 	The additional attributes that you want to add to the button or link. For example, data attributes.
    /// </summary>
    public Dictionary<string, string> Attributes { get; set; }
}