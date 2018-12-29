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
using System;
using Microsoft.Extensions.Configuration;

namespace GuepardoApps.OpenWeatherLib.Services.Test.OpenWeatherMap
{
    public class OpenWeatherMapServiceTests
    {
        private readonly IMapper _mapper;
        private readonly IValidationService _validationService;
        private readonly IOpenWeatherMapAdapter _openWeatherMapAdapter;
        private readonly IConfiguration _configuration;

        private IOpenWeatherMapService _sut;

        public OpenWeatherMapServiceTests()
        {
            _mapper = Substitute.For<IMapper>();
            _validationService = Substitute.For<IValidationService>();
            _openWeatherMapAdapter = Substitute.For<IOpenWeatherMapAdapter>();
            _configuration = Substitute.For<IConfiguration>();

            _configuration["ApiKeys:OpenWeatherMap"].Returns("ApiKey");

            _sut = new OpenWeatherMapService(_mapper, _validationService, _openWeatherMapAdapter, _configuration);
        }

        [Fact]
        public void LoadCarbonMonoxide_ShouldReturnWeatherCurrent()
        {
            // Arrange
            _mapper.Map<City>(Arg.Any<CityDto>()).Returns(new City());
            _openWeatherMapAdapter.LoadCarbonMonoxide(Arg.Any<string>(), Arg.Any<City>(), Arg.Any<DateTime>(), Arg.Any<int>()).Returns(new CarbonMonoxide());
            _validationService.Validate(Arg.Any<object>()).ReturnsForAnyArgs(true);
            _mapper.Map<CarbonMonoxideDto>(Arg.Any<CarbonMonoxide>()).Returns(new CarbonMonoxideDto());
            _sut = new OpenWeatherMapService(_mapper, _validationService, _openWeatherMapAdapter, _configuration);

            // Act
            var actual = _sut.LoadCarbonMonoxide(new CityDto(), DateTime.Now, 1);

            // Assert
            actual.Should().NotBeNull();
        }

        [Fact]
        public void LoadNitrogenDioxide_ShouldReturnWeatherCurrent()
        {
            // Arrange
            _mapper.Map<City>(Arg.Any<CityDto>()).Returns(new City());
            _openWeatherMapAdapter.LoadNitrogenDioxide(Arg.Any<string>(), Arg.Any<City>(), Arg.Any<DateTime>(), Arg.Any<int>()).Returns(new NitrogenDioxide());
            _validationService.Validate(Arg.Any<object>()).ReturnsForAnyArgs(true);
            _mapper.Map<NitrogenDioxideDto>(Arg.Any<NitrogenDioxide>()).Returns(new NitrogenDioxideDto());
            _sut = new OpenWeatherMapService(_mapper, _validationService, _openWeatherMapAdapter, _configuration);

            // Act
            var actual = _sut.LoadNitrogenDioxide(new CityDto(), DateTime.Now, 1);

            // Assert
            actual.Should().NotBeNull();
        }

        [Fact]
        public void LoadOzone_ShouldReturnWeatherCurrent()
        {
            // Arrange
            _mapper.Map<City>(Arg.Any<CityDto>()).Returns(new City());
            _openWeatherMapAdapter.LoadOzone(Arg.Any<string>(), Arg.Any<City>(), Arg.Any<DateTime>(), Arg.Any<int>()).Returns(new Ozone());
            _validationService.Validate(Arg.Any<object>()).ReturnsForAnyArgs(true);
            _mapper.Map<OzoneDto>(Arg.Any<Ozone>()).Returns(new OzoneDto());
            _sut = new OpenWeatherMapService(_mapper, _validationService, _openWeatherMapAdapter, _configuration);

            // Act
            var actual = _sut.LoadOzone(new CityDto(), DateTime.Now, 1);

            // Assert
            actual.Should().NotBeNull();
        }

        [Fact]
        public void LoadSulfurDioxide_ShouldReturnWeatherCurrent()
        {
            // Arrange
            _mapper.Map<City>(Arg.Any<CityDto>()).Returns(new City());
            _openWeatherMapAdapter.LoadSulfurDioxide(Arg.Any<string>(), Arg.Any<City>(), Arg.Any<DateTime>(), Arg.Any<int>()).Returns(new SulfurDioxide());
            _validationService.Validate(Arg.Any<object>()).ReturnsForAnyArgs(true);
            _mapper.Map<SulfurDioxideDto>(Arg.Any<SulfurDioxide>()).Returns(new SulfurDioxideDto());
            _sut = new OpenWeatherMapService(_mapper, _validationService, _openWeatherMapAdapter, _configuration);

            // Act
            var actual = _sut.LoadSulfurDioxide(new CityDto(), DateTime.Now, 1);

            // Assert
            actual.Should().NotBeNull();
        }

        [Fact]
        public void LoadWeatherCurrent_ShouldReturnWeatherCurrent()
        {
            // Arrange
            _mapper.Map<City>(Arg.Any<CityDto>()).Returns(new City());
            _openWeatherMapAdapter.LoadWeatherCurrent(Arg.Any<string>(), Arg.Any<City>()).Returns(new WeatherCurrent());
            _validationService.Validate(Arg.Any<object>()).ReturnsForAnyArgs(true);
            _mapper.Map<WeatherCurrentDto>(Arg.Any<WeatherCurrent>()).Returns(new WeatherCurrentDto());
            _sut = new OpenWeatherMapService(_mapper, _validationService, _openWeatherMapAdapter, _configuration);

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
            _sut = new OpenWeatherMapService(_mapper, _validationService, _openWeatherMapAdapter, _configuration);

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
            _sut = new OpenWeatherMapService(_mapper, _validationService, _openWeatherMapAdapter, _configuration);

            // Act
            var actual = _sut.LoadUvIndex(new CityDto());

            // Assert
            actual.Should().NotBeNull();
        }
    }
}
