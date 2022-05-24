namespace GovUkDesignSystem.GovUkDesignSystemComponents;

public class CookieBannerViewModel
{
    public BannerState BannerState { get; set; } 
    public CookieType CookieType { get; set; }
    public bool UseAntiForgeryToken { get; set; } = true;
    public string ButtonClickAction { get; set; }
    public string ViewCookiesLink { get; set; }
    public string ReturnUrl { get; set; }
}

public enum BannerState
{
    ShowBanner,
    ShowAccepted,
    ShowRejected,
    Hide
}

public enum CookieType
{
    Analytics,
    Additional
}