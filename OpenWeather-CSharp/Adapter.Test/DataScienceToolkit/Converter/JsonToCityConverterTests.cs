using Adapter.DataScienceToolkit.Converter;
using FluentAssertions;
using NSubstitute;
using Serilog;
using Xunit;

namespace Adapter.Test.DataScienceToolkit.Converter
{
    public class JsonToCityConverterTests
    {
        private readonly ILogger _logger;

        private IJsonToCityConverter _sut;

        public JsonToCityConverterTests()
        {
            _logger = Substitute.For<ILogger>();

            _sut = new JsonToCityConverter(_logger);
        }

        [Fact]
        public void Convert_ShouldReturnExpectedCity()
        {
            // Arrange
            var response = "{\"address_components\":[{\"short_name\":\"Nuremberg\"},{\"short_name\":\"Germany\"}],\"geometry\":{\"location\":{\"lat\":23.45,\"lng\":65.43}}}";

            // Act
            var actual = _sut.Convert(response);

            // Assert
            actual.Should().NotBeNull();
            actual.Name.Should().Be("Nuremberg");
            actual.Country.Should().Be("Germany");
            actual.Coordinates.Lat.Should().Be(23.45);
            actual.Coordinates.Lon.Should().Be(65.43);
        }
    }
}
