using System;
using System.Collections.Generic;
using FluentAssertions;
using GovUkDesignSystem.Helpers;
using Xunit;

namespace GovUkDesignSystem.UnitTests
{
    public class ExtensionHelperTests
    {
        [Fact]
        public void ToTagAttributes_OnNullDictionary_ReturnsEmptyString()
        {
            // Arrange
            Dictionary<string, string> underTest = null;

            // Act
            var result = underTest.ToTagAttributes();

            // Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public void ToTagAttributes_OnSingleAttribute_ReturnsCorrectString()
        {
            // Arrange
            var underTest = new Dictionary<string, string> { { "attributeName", "attributeValue" } };

            // Act
            var result = underTest.ToTagAttributes();

            // Assert
            result.Should().Be("attributeName=\"attributeValue\"");
        }
    }
}
