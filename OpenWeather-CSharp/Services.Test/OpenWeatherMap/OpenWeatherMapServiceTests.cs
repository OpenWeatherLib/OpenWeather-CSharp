using AutoMapper;
using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;
using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap;
using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model;
using FluentAssertions;
using NSubstitute;
using GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit.Dto;
using GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap;
using GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap.Dto;
using GuepardoApps.OpenWeatherLib.Services.Validation;
using Xunit;

namespace GuepardoApps.OpenWeatherLib.Services.Test.OpenWeatherMap
{
    public class OpenWeatherMapServiceTests
    {
        private readonly IMapper _mapper;
        private readonly IValidationService _validationService;
        private readonly IOpenWeatherMapAdapter _openWeatherMapAdapter;

        private IOpenWeatherMapService _sut;

        public OpenWeatherMapServiceTests()
        {
            _mapper = Substitute.For<IMapper>();
            _validationService = Substitute.For<IValidationService>();
            _openWeatherMapAdapter = Substitute.For<IOpenWeatherMapAdapter>();

            _sut = new OpenWeatherMapService(_mapper, _validationService, _openWeatherMapAdapter);
        }

        [Fact]
        public void LoadWeatherCurrent_ShouldReturnWeatherCurrent()
        {
            // Arrange
            _mapper.Map<City>(Arg.Any<CityDto>()).Returns(new City());
            _openWeatherMapAdapter.LoadWeatherCurrent(Arg.Any<string>(), Arg.Any<City>()).Returns(new WeatherCurrent());
            _validationService.Validate(Arg.Any<object>()).ReturnsForAnyArgs(true);
            _mapper.Map<WeatherCurrentDto>(Arg.Any<WeatherCurrent>()).Returns(new WeatherCurrentDto());
            _sut = new OpenWeatherMapService(_mapper, _validationService, _openWeatherMapAdapter);

            // Act
            var actual = _sut.LoadWeatherCurrent(new CityDto());

            // Assert
            actual.Should().NotBeNull();
        }

        [Fact]
        public void LoadWeatherForecast_ShouldReturnWeatherCurrent()
        {
            // Arrange
            _mapper.Map<City>(Arg.Any<CityDto>()).Returns(new City());
            _openWeatherMapAdapter.LoadWeatherForecast(Arg.Any<string>(), Arg.Any<City>()).Returns(new WeatherForecast());
            _validationService.Validate(Arg.Any<object>()).ReturnsForAnyArgs(true);
            _mapper.Map<WeatherForecastDto>(Arg.Any<WeatherForecast>()).Returns(new WeatherForecastDto());
            _sut = new OpenWeatherMapService(_mapper, _validationService, _openWeatherMapAdapter);

            // Act
            var actual = _sut.LoadWeatherForecast(new CityDto());

            // Assert
            actual.Should().NotBeNull();
        }

        [Fact]
        public void LoadUvIndex_ShouldReturnWeatherCurrent()
        {
            // Arrange
            _mapper.Map<City>(Arg.Any<CityDto>()).Returns(new City());
            _openWeatherMapAdapter.LoadUvIndex(Arg.Any<string>(), Arg.Any<City>()).Returns(new UvIndex());
            _validationService.Validate(Arg.Any<object>()).ReturnsForAnyArgs(true);
            _mapper.Map<UvIndexDto>(Arg.Any<UvIndex>()).Returns(new UvIndexDto());
            _sut = new OpenWeatherMapService(_mapper, _validationService, _openWeatherMapAdapter);

            // Act
            var actual = _sut.LoadUvIndex(new CityDto());

            // Assert
            actual.Should().NotBeNull();
        }
    }
}
