using System;
using System.Collections.Generic;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;

namespace GovUkDesignSystem.GovUkDesignSystemComponents;

public class WarningTextViewModel: IHtmlText
{
    
    /// <summary>
    ///     Required. If `html` is set, this is not required.
    ///     Text to use within the warning text component.
    ///     If `html` is provided, the `text` argument will be ignored.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    ///     Required. If `text` is set, this is not required.
    ///     HTML to use within the warning text component.
    ///     If `html` is provided, the `text` argument will be ignored.
    /// </summary>
    public Func<object, object> Html { get; set; }
    
    /// <summary>
    ///     Required. The fallback text for the icon.
    /// </summary>
    public string IconFallbackText { get; set; }
    
    /// <summary>
    ///     Classes to add to the warning text.
    /// </summary>
    public string Classes { get; set; }
    
    /// <summary>
    ///     HTML attributes (for example data attributes) to add to the warning text.
    /// </summary>
    public Dictionary<string, string> Attributes { get; set; }
}