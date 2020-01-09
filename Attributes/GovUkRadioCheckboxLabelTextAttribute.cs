using System;
using System.Reflection;
using GovUkDesignSystem.Helpers;

namespace GovUkDesignSystem.Attributes
{
    /// <summary>
    ///     Label text for Radio buttons and Checkboxes
    ///     <br/> Note: this attribute should only be applied to Enum values
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class GovUkRadioCheckboxLabelTextAttribute : Attribute
    {
        public string Text { get; set; }

        public static string GetValueForEnum(
            Type enumType,
            object enumValue)
        {
            MemberInfo memberInfo = enumType.GetMember(enumValue.ToString())[0];

            var govUkRadioCheckboxLabelTextAttribute = memberInfo.GetSingleCustomAttribute<GovUkRadioCheckboxLabelTextAttribute>();

            return govUkRadioCheckboxLabelTextAttribute?.Text;
        }
    }
}
