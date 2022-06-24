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

        [Fact]
        public void ToTagAttributes_WithMultipleAttribute_ReturnsCorrectString()
        {
            // Arrange
            var underTest = new Dictionary<string, string> { { "attributeName1", "attributeValue1" }, { "attributeName2", "attributeValue2" } };

            // Act
            var result = underTest.ToTagAttributes();

            // Assert
            result.Should().Be("attributeName1=\"attributeValue1\" attributeName2=\"attributeValue2\"");
        }

        [Fact]
        public void ToTagAttributes_NameOnlyAttribute_ReturnsCorrectString()
        {
            // Arrange
            var underTest = new Dictionary<string, string> { { "attributeName", null } };

            // Act
            var result = underTest.ToTagAttributes();

            // Assert
            result.Should().Be("attributeName");
        }

        [Fact]
        public void ToTagAttributes_WithNormalAndNameOnlyAttribute_ReturnsCorrectString()
        {
            // Arrange
            var underTest = new Dictionary<string, string> { { "attributeName1", null }, { "attributeName2", "attributeValue2" } };

            // Act
            var result = underTest.ToTagAttributes();

            // Assert
            result.Should().Be("attributeName1 attributeName2=\"attributeValue2\"");
        }
    }
}
