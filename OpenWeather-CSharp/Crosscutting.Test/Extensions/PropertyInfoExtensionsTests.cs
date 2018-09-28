using Crosscutting.Attributes;
using Crosscutting.Extensions;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace Crosscutting.Test.Extensions
{
    public class PropertyInfoExtensionsTests
    {
        [Fact]
        public void GetSingleAttribute_ShouldReturnExpectedAttribute()
        {
            // Arrange
            var testClass = new GetSingleAttributeTestClass
            {
                Test = ""
            };
            var requiredProperties = testClass.GetType().GetProperties().FirstOrDefault();

            // Act
            var actual = requiredProperties.GetSingleAttribute<RequiredAttribute>();

            // Assert
            actual.Should().NotBeNull();
        }

        private class GetSingleAttributeTestClass
        {
            [Required(typeof(string))]
            public string Test { get; set; }
        }
    }
}
