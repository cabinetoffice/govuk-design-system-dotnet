using System;

namespace GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents
{
    public class HtmlText : IHtmlText
    {
        public Func<object, object> Html { get; set; }

        public string Text { get; set; }

        public HtmlText(Func<object, object> html, string text)
        {
            Html = html;
            Text = text;
        }
    }
}
