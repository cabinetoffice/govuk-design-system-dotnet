using System;

namespace GovUkDesignSystem.Attributes.DataBinding
{
    /// <summary>
    /// Abstract base class for all attributes that hold data binding error text
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public abstract class GovUkDataBindingErrorTextAttribute : Attribute
    {
    }
}
