using System;
using System.Linq;
using System.Reflection;

namespace GovUkDesignSystem.Helpers
{
    public static class ExtensionHelpers
    {
        public static TAttributeType GetSingleCustomAttribute<TAttributeType>(this MemberInfo property)
            where TAttributeType : Attribute
        {
            return property.GetCustomAttributes(typeof(TAttributeType)).SingleOrDefault() as TAttributeType;
        }
    }
}
