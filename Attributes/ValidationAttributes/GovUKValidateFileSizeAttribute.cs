using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace GovUkDesignSystem.Attributes.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class GovUkValidateFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;
        private readonly string _maxFileSizeErrorMessage;

        public GovUkValidateFileSizeAttribute(int maxFileSize, string maxFileSizeErrorMessage)
        {
            _maxFileSize = maxFileSize;
            _maxFileSizeErrorMessage = maxFileSizeErrorMessage;
        }

        protected override ValidationResult IsValid( object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file == null)
            {
                return ValidationResult.Success;
            }

            if (file.Length <= _maxFileSize)
            {
                return new ValidationResult($"The selected file must be smaller than {_maxFileSizeErrorMessage}");
            }

            return ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(_maxFileSize.ToString());
        }
    }
}
