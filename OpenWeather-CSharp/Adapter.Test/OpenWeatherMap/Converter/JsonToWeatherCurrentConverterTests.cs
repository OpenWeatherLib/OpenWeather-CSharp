using GuepardoApps.OpenWeatherLib.Adapter.OpenWeatherMap.Converter;
using FluentAssertions;
using NSubstitute;
using Serilog;
using Xunit;

namespace GuepardoApps.OpenWeatherLib.Adapter.Test.OpenWeatherMap.Converter
{
    public class JsonToWeatherCurrentConverterTests
    {
        private readonly ILogger _logger;

        private IJsonToWeatherCurrentConverter _sut;

        public JsonToWeatherCurrentConverterTests()
        {
            _logger = Substitute.For<ILogger>();

            _sut = new JsonToWeatherCurrentConverter(_logger);
        }

        [Fact]
        public void Convert_ShouldReturnExpectedUvIndex()
        {
            // Arrange
            var response = "{\"coord\":{\"lon\":11.08,\"lat\":49.45}," +
            "\"weather\":" +
            "[" +
            "{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03d\"}" +
            "]," +
            "\"base\":\"stations\"," +
            "\"main\":" +
            "{\"temp\":21.37,\"pressure\":1021,\"humidity\":56,\"temp_min\":20,\"temp_max\":23}," +
            "\"visibility\":10000," +
            "\"wind\":" +
            "{\"speed\":3.1,\"deg\":90}," +
            "\"clouds\":" +
            "{\"all\":40}," +
            "\"dt\":1527326400," +
            "\"sys\":" +
            "{\"type\":1,\"id\":4888,\"message\":0.0147,\"country\":\"DE\",\"sunrise\":1527304731,\"sunset\":1527361642}," +
            "\"id\":2861650," +
            "\"name\":\"Nuremberg\"," +
            "\"cod\":200}";

            // Act
            var actual = _sut.Convert(response);

            // Assert
            actual.Should().NotBeNull();
            actual.Coordinates.Lon.Should().Be(11.08);
            actual.Coordinates.Lat.Should().Be(49.45);
            actual.Weather[0].Id.Should().Be(802);
            actual.Weather[0].Main.Should().Be("Clouds");
            actual.Weather[0].Description.Should().Be("scattered clouds");
            actual.Weather[0].Icon.Should().Be("03d");
            actual.Base.Should().Be("stations");
            actual.Main.Temperature.Should().Be(21.37);
            actual.Main.Pressure.Should().Be(1021);
            actual.Main.Humidity.Should().Be(56);
            actual.Main.TemperatureMin.Should().Be(20);
            actual.Main.TemperatureMax.Should().Be(23);
            actual.Visibility.Should().Be(10000);
            actual.Wind.Speed.Should().Be(3.1);
            actual.Wind.Degree.Should().Be(90);
            actual.Clouds.All.Should().Be(40);
            actual.Sys.Type.Should().Be(1);
            actual.Sys.Id.Should().Be(4888);
            actual.Sys.Message.Should().Be(0.0147);
            actual.Sys.Country.Should().Be("DE");
            actual.Id.Should().Be(2861650);
            actual.Name.Should().Be("Nuremberg");
            actual.Cod.Should().Be(200);
        }
    }
}
