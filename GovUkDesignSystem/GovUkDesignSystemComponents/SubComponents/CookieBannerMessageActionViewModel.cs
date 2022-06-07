using System.Collections.Generic;

namespace GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;

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