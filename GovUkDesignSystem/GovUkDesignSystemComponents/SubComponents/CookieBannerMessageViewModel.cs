using System;
using System.Collections.Generic;

namespace GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;

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
    public Func<object, object> HeadingHtml { get; set; }
    
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