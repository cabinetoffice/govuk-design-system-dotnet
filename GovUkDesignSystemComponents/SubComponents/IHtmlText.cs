using System;

namespace GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents
{
    public interface IHtmlText
    {

        Func<object, object> Html { get; }
        string Text { get; }

    }
}
