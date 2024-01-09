using System;
using System.Reflection;
using System.Resources;
using System.Globalization;

namespace GovUkDesignSystem.Attributes.DataBinding
{
    /// <summary>
    /// Abstract base class for all attributes that hold data binding error text
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public abstract class GovUkDataBindingErrorTextAttribute : Attribute
    {
        private ResourceManager _resourceManager = null;
        protected Type ResourceType { get; set; }
        
        protected string ResourceName { get; set; }

        protected string GetResourceValue(string resourceKey)
        {
            if (ResourceType != null && Assembly.GetAssembly(ResourceType) != null)
            {
                _resourceManager ??= new ResourceManager(ResourceName, Assembly.GetAssembly(ResourceType));
            }
            
            return _resourceManager.GetString(resourceKey, CultureInfo.CurrentCulture) ?? resourceKey;
        }
    }
}
