using GuepardoApps.OpenWeatherLib.Crosscutting.Helper;
using FluentAssertions;
using System;
using Xunit;

namespace GuepardoApps.OpenWeatherLib.Crosscutting.Test.Helper
{
    public class UnixToDateTimeTests
    {
        [Fact]
        public void UnixTimeStampToDateTime_ShouldReturnExpectedDateTime_FromString()
        {
            // Arrange 
            var expectedDateTime = new DateTime(2018, 9, 13, 14, 0, 0);

            // Act
            var actual = UnixToDateTime.UnixTimeStampToDateTime("1536840000");

            // Assert
            actual.Year.Should().Be(expectedDateTime.Year);
            actual.Month.Should().Be(expectedDateTime.Month);
            actual.Day.Should().Be(expectedDateTime.Day);
            actual.DayOfYear.Should().Be(expectedDateTime.DayOfYear);
            actual.Hour.Should().Be(expectedDateTime.Hour);
            actual.Minute.Should().Be(expectedDateTime.Minute);
            actual.Second.Should().Be(expectedDateTime.Second);
        }

        [Fact]
        public void UnixTimeStampToDateTime_ShouldReturnExpectedDateTime_FromDouble()
        {
            // Arrange 
            var expectedDateTime = new DateTime(2018, 9, 13, 14, 0, 0);

            // Act
            var actual = UnixToDateTime.UnixTimeStampToDateTime(1536840000);

            // Assert
            actual.Year.Should().Be(expectedDateTime.Year);
            actual.Month.Should().Be(expectedDateTime.Month);
            actual.Day.Should().Be(expectedDateTime.Day);
            actual.DayOfYear.Should().Be(expectedDateTime.DayOfYear);
            actual.Hour.Should().Be(expectedDateTime.Hour);
            actual.Minute.Should().Be(expectedDateTime.Minute);
            actual.Second.Should().Be(expectedDateTime.Second);
        }
    }
}
