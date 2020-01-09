using System;

namespace GovUkDesignSystem.Attributes.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GovUkValidateCharacterCountAttribute : Attribute
    {

        public int MaxCharacters { get; set; }

    }
}
