using System;
using System.Collections.Generic;

namespace GovUkDesignSystem.Helpers
{
    public static class TypeHelpers
    {
        public static bool IsNullableEnum(Type type)
        {
            var underlyingType = Nullable.GetUnderlyingType(type);

            bool isNullableType = underlyingType != null;

            bool isNullableEnum = isNullableType && underlyingType.IsEnum;

            return isNullableEnum;
        }

        public static bool IsListOfEnums(Type type)
        {
            bool isGenericList = type.IsGenericType &&
                                 type.GetGenericTypeDefinition() == typeof(List<>);

            if (!isGenericList)
            {
                return false;
            }

            Type genericType = type.GetGenericArguments()[0];
            return genericType.IsEnum;
        }

        public static Type GetGenericTypeFromGenericListType(Type listType)
        {
            return listType.GetGenericArguments()[0];
        }

        public static object GetDefaultValue(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }

            return null;
        }
    }
}