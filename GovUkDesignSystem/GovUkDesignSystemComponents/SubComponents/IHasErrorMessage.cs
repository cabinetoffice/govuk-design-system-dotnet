using System;
using System.Collections.Generic;
using System.Text;

namespace GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents
{
    internal interface IHasErrorMessage
    {
        ErrorMessageViewModel ErrorMessage { set; get; }
    }
}
