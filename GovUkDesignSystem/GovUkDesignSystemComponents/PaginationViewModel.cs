using System.Collections.Generic;

namespace GovUkDesignSystem.GovUkDesignSystemComponents;

public class PaginationViewModel
{
    /// <summary>
    /// The array of link objects.
    /// </summary>
    public List<PaginationItemViewModel> Items { get; set; }

    /// <summary>
    /// A link to the previous page, if there is a previous page.
    /// </summary>
    public PaginationLinkViewModel Previous { get; set; }
    
    /// <summary>
    /// A link to the next page, if there is a next page.
    /// </summary>
    public PaginationLinkViewModel Next { get; set; }
    
    /// <summary>
    /// The label for the navigation landmark that wraps the pagination. Defaults to 'results'.
    /// </summary>
    public string LandmarkLabel { get; set; }
    
    /// <summary>
    /// The classes you want to add to the pagination nav parent.
    /// </summary>
    public string Classes { get; set; }
    
    /// <summary>
    /// The HTML attributes (for example, data attributes) you want to add to the pagination nav parent.
    /// </summary>
    public Dictionary<string, string> Attributes { get; set; }
}

public class PaginationItemViewModel
{
    /// <summary>
    /// The pagination item text - usually a page number.
    /// </summary>
    public string Number { get; set; }
    
    /// <summary>
    /// The visually hidden label (for the pagination item) which will be applied to an aria-label and announced
    /// by screen readers on the pagination item link. Should include page number.
    /// </summary>
    public string VisuallyHiddenText { get; set; }
    
    /// <summary>
    /// <b>Required</b>. The link's URL.
    /// </summary>
    public string Href { get; set; }
    
    /// <summary>
    /// Set to true to indicate the current page the user is on.
    /// </summary>
    public bool Current { get; set; }
    
    /// <summary>
    /// Use this option if you want to specify an ellipsis at a given point between numbers.
    /// If you set this option as true, any other options for the item are ignored.
    /// </summary>
    public bool Ellipsis { get; set; }
    
    /// <summary>
    /// The HTML attributes (for example, data attributes) you want to add to the anchor.
    /// </summary>
    public Dictionary<string, string> Attributes { get; set; }
}

public class PaginationLinkViewModel
{
    /// <summary>
    /// The link text to the previous or next page. Defaults to 'Previous page' or 'Next page', where 'page' is visually hidden.
    /// </summary>
    public string Text { get; set; }
    
    /// <summary>
    /// The optional label that goes underneath the link to the previous or next page,
    /// providing further context for the user about where the link goes.
    /// </summary>
    public string LabelText { get; set; }
    
    /// <summary>
    /// <b>Required</b>. The previous or next page's URL.
    /// </summary>
    public string Href { get; set; }
    
    /// <summary>
    /// The HTML attributes (for example, data attributes) you want to add to the anchor.
    /// </summary>
    public Dictionary<string, string> Attributes { get; set; }
}