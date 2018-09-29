using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Services.DataScienceToolkit.Dto;
using Services.OpenWeatherMap;
using Services.OpenWeatherMap.Dto;
using Web.Controllers;
using Web.Models.DataScienceToolkit;
using Web.Models.OpenWeatherMap;
using Xunit;

namespace Web.Test.OpenWeatherMap
{
    public class OpenWeatherMapControllerTests
    {
        private readonly IMapper _mapper;
        private readonly IOpenWeatherMapService _openWeatherMapService;

        private OpenWeatherMapController _sut;

        public OpenWeatherMapControllerTests()
        {
            _mapper = Substitute.For<IMapper>();
            _openWeatherMapService = Substitute.For<IOpenWeatherMapService>();

            _sut = new OpenWeatherMapController(_mapper, _openWeatherMapService);
        }

        [Fact]
        public void LoadWeatherCurrent_ShouldReturnWeatherCurrent()
        {
            // Arrange
            _mapper.Map<CityDto>(Arg.Any<CityViewModel>()).Returns(new CityDto());
            _openWeatherMapService.LoadWeatherCurrent(Arg.Any<CityDto>()).Returns(new WeatherCurrentDto());
            _mapper.Map<WeatherCurrentViewModel>(Arg.Any<WeatherCurrentDto>()).Returns(new WeatherCurrentViewModel());
            _sut = new OpenWeatherMapController(_mapper, _openWeatherMapService);

            // Act
            var actual = _sut.LoadWeatherCurrent(new CityViewModel());

            // Assert
            actual.Should().NotBeNull();
            actual.Value.Should().NotBeNull();
        }

        [Fact]
        public void LoadWeatherForecast_ShouldReturnWeatherCurrent()
        {
            // Arrange
            _mapper.Map<CityDto>(Arg.Any<CityViewModel>()).Returns(new CityDto());
            _openWeatherMapService.LoadWeatherForecast(Arg.Any<CityDto>()).Returns(new WeatherForecastDto());
            _mapper.Map<WeatherForecastViewModel>(Arg.Any<WeatherForecastDto>()).Returns(new WeatherForecastViewModel());
            _sut = new OpenWeatherMapController(_mapper, _openWeatherMapService);

            // Act
            var actual = _sut.LoadWeatherForecast(new CityViewModel());

            // Assert
            actual.Should().NotBeNull();
            actual.Value.Should().NotBeNull();
        }

        [Fact]
        public void LoadUvIndex_ShouldReturnWeatherCurrent()
        {
            // Arrange
            _mapper.Map<CityDto>(Arg.Any<CityViewModel>()).Returns(new CityDto());
            _openWeatherMapService.LoadUvIndex(Arg.Any<CityDto>()).Returns(new UvIndexDto());
            _mapper.Map<UvIndexViewModel>(Arg.Any<UvIndexDto>()).Returns(new UvIndexViewModel());
            _sut = new OpenWeatherMapController(_mapper, _openWeatherMapService);

            // Act
            var actual = _sut.LoadUvIndex(new CityViewModel());

            // Assert
            actual.Should().NotBeNull();
            actual.Value.Should().NotBeNull();
        }
    }
}
