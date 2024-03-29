﻿using System;
using System.Linq;
using System.Reflection;

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
        
        /// <summary>
        /// Returns the Text property of any GovUkRadioCheckboxLabelTextAttribute on the enum value
        /// If no attribute exists returns enumValue.ToString()
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetLabelText(Enum enumValue)
        {
            var attribute = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .Single()
                .GetCustomAttribute<GovUkRadioCheckboxLabelTextAttribute>();

            return attribute == null ? enumValue.ToString() : attribute.Text;
        }

    }
}
