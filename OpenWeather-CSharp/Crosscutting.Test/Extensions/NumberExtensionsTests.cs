using GuepardoApps.OpenWeatherLib.Crosscutting.Extensions;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace GuepardoApps.OpenWeatherLib.Crosscutting.Test.Extensions
{
    public class NumberExtensionsTests
    {
        public static IEnumerable<object[]> ToFixedTestData()
        {
            yield return new object[] { 5.43210, 0, "5,4" };
            yield return new object[] { 5.43210, 1, "5,4" };
            yield return new object[] { 5.43210, 2, "5,43" };
            yield return new object[] { 5.43210, 3, "5,432" };
            yield return new object[] { 5.43210, 4, "5,4321" };
            yield return new object[] { 5.43210, 5, "5,4321" };
        }

        [Theory]
        [MemberData(nameof(ToFixedTestData))]
        public void ToFixed_ShouldReturnAsExpected(double value, int accuracy, string expected)
        {
            // Arrange
            var actual = value.ToFixed(accuracy);

            // Act
            actual.Should().Be(expected);
        }
    }
}
