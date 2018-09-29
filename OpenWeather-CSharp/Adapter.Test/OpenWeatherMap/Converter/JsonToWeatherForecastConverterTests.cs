using GuepardoApps.OpenWeatherLib.Adapter.OpenWeatherMap.Converter;
using FluentAssertions;
using NSubstitute;
using Serilog;
using Xunit;

namespace GuepardoApps.OpenWeatherLib.Adapter.Test.OpenWeatherMap.Converter
{
    public class JsonToWeatherForecastConverterTests
    {
        private readonly ILogger _logger;

        private IJsonToWeatherForecastConverter _sut;

        public JsonToWeatherForecastConverterTests()
        {
            _logger = Substitute.For<ILogger>();

            _sut = new JsonToWeatherForecastConverter(_logger);
        }

        [Fact]
        public void Convert_ShouldReturnExpectedUvIndex()
        {
            // Arrange
            var response = "{\"cod\":\"200\",\"message\":0.0026,\"cnt\":3," +
            "\"list\":[" +
            "{\"dt\":1530219600,\"main\":{\"temp\":14.79,\"temp_min\":14.79,\"temp_max\":17.08,\"pressure\":980.7,\"sea_level\":1031.63," +
            "\"grnd_level\":980.7,\"humidity\":71,\"temp_kf\":-2.29},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\"," +
            "\"icon\":\"10n\"}],\"clouds\":{\"all\":100},\"wind\":{\"speed\":3.36,\"deg\":33.0006},\"rain\":{\"3h\":0.0775},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2018-06-28 21:00:00\"}," +
            "{\"dt\":1530230400,\"main\":{\"temp\":15.21,\"temp_min\":15.21,\"temp_max\":16.93,\"pressure\":980.15,\"sea_level\":1031.31," +
            "\"grnd_level\":980.15,\"humidity\":71,\"temp_kf\":-1.72},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\"," +
            "\"icon\":\"10n\"}],\"clouds\":{\"all\":92},\"wind\":{\"speed\":3.13,\"deg\":34.0042},\"rain\":{\"3h\":0.0575},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2018-06-29 00:00:00\"}," +
            "{\"dt\":1530241200,\"main\":{\"temp\":14.94,\"temp_min\":14.94,\"temp_max\":16.08,\"pressure\":979.77,\"sea_level\":1030.91," +
            "\"grnd_level\":979.77,\"humidity\":82,\"temp_kf\":-1.15},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\"," +
            "\"icon\":\"10n\"}],\"clouds\":{\"all\":88},\"wind\":{\"speed\":2.52,\"deg\":22.001},\"rain\":{\"3h\":0.21},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2018-06-29 03:00:00\"}]," +
            "\"city\":{\"id\":2861650,\"name\":\"Nuremberg\",\"coord\":{\"lat\":49.4539,\"lon\":11.0773},\"country\":\"DE\",\"population\":499237}}";

            // Act
            var actual = _sut.Convert(response);

            // Assert
            actual.Should().NotBeNull();
            actual.Cod.Should().Be("200");
            actual.Message.Should().Be(0.0026);
            actual.Count.Should().Be(3);
            actual.List.Count.Should().Be(3);
            actual.City.Id.Should().Be(2861650);
            actual.City.Coordinates.Lat.Should().Be(49.4539);
            actual.City.Coordinates.Lon.Should().Be(11.0773);
            actual.City.Country.Should().Be("DE");
            actual.City.Population.Should().Be(499237);
        }
    }
}
