using Adapter.OpenWeatherMap.Converter;
using FluentAssertions;
using NSubstitute;
using Serilog;
using System;
using Xunit;

namespace Adapter.Test.OpenWeatherMap.Converter
{
    public class JsonToUvIndexConverterTests
    {
        private readonly ILogger _logger;

        private IJsonToUvIndexConverter _sut;

        public JsonToUvIndexConverterTests()
        {
            _logger = Substitute.For<ILogger>();

            _sut = new JsonToUvIndexConverter(_logger);
        }

        [Fact]
        public void Convert_ShouldReturnExpectedUvIndex()
        {
            // Arrange
            var response = "{\"lat\":37.75,\"lon\":-122.37,\"date_iso\":\"2018-09-13T12:00:00Z\",\"date\":1536840000,\"value\":6.96}";

            // Act
            var actual = _sut.Convert(response);

            // Assert
            actual.Should().NotBeNull();
            actual.Coordinates.Lat.Should().Be(37.75);
            actual.Coordinates.Lon.Should().Be(-122.37);
            actual.DateTimeIso.Should().Be("13/09/2018 12:00:00");
            actual.DateTime.Should().Be(Convert.ToDateTime("13/09/2018 12:00:00"));
            actual.Value.Should().Be(6.96);
        }
    }
}
