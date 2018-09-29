using GuepardoApps.OpenWeatherLib.Adapter.Unsplash.Converter;
using FluentAssertions;
using NSubstitute;
using Serilog;
using Xunit;

namespace GuepardoApps.OpenWeatherLib.Adapter.Test.Unsplash.Converter
{
    public class JsonToUrlConverterTests
    {
        private readonly ILogger _logger;

        private IJsonToUrlConverter _sut;

        public JsonToUrlConverterTests()
        {
            _logger = Substitute.For<ILogger>();

            _sut = new JsonToUrlConverter(_logger);
        }

        [Fact]
        public void Convert_ShouldReturnExpectedUrl()
        {
            // Arrange
            var response = "{\"results\":[{\"urls\":{\"small\":\"https://www.test.org\"}}]}";

            // Act
            var actual = _sut.Convert(response);

            // Assert
            actual.Should().Be("https://www.test.org");
        }
    }
}
