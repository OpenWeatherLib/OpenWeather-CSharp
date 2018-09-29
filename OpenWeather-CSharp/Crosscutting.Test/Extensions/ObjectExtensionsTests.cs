using GuepardoApps.OpenWeatherLib.Crosscutting.Extensions;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace GuepardoApps.OpenWeatherLib.Crosscutting.Test.Extensions
{
    public class ObjectExtensionsTests
    {
        public static IEnumerable<object[]> IsEmptyTestData()
        {
            yield return new object[] { "NotEmptyString", false };
            yield return new object[] { string.Empty, true };
            yield return new object[] { new { x = 1, y = "A", z = true }, false };
            yield return new object[] { null, true };
        }

        [Theory]
        [MemberData(nameof(IsEmptyTestData))]
        public void IsEmpty_ShouldReturnAsExpected(object value, bool expected)
        {
            // Arrange
            var actual = value.IsEmpty();

            // Act
            actual.Should().Be(expected);
        }
    }
}
