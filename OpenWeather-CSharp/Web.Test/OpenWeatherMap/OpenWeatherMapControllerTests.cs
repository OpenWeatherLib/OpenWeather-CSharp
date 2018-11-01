using AutoMapper;
using FluentAssertions;
using NSubstitute;
using GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit.Dto;
using GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap;
using GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap.Dto;
using GuepardoApps.OpenWeatherLib.Web.Controllers;
using GuepardoApps.OpenWeatherLib.Web.Models.DataScienceToolkit;
using GuepardoApps.OpenWeatherLib.Web.Models.OpenWeatherMap;
using Xunit;
using System;

namespace GuepardoApps.OpenWeatherLib.Web.Test.OpenWeatherMap
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
        public void LoadCarbonMonoxide_ShouldReturnWeatherCurrent()
        {
            // Arrange
            _mapper.Map<CityDto>(Arg.Any<CityViewModel>()).Returns(new CityDto());
            _openWeatherMapService.LoadCarbonMonoxide(Arg.Any<CityDto>(), Arg.Any<DateTime>(), Arg.Any<int>()).Returns(new CarbonMonoxideDto());
            _mapper.Map<CarbonMonoxideViewModel>(Arg.Any<CarbonMonoxideDto>()).Returns(new CarbonMonoxideViewModel());
            _sut = new OpenWeatherMapController(_mapper, _openWeatherMapService);

            // Act
            var actual = _sut.LoadCarbonMonoxide(new AirPollutionRequestViewModel
            {
                City = new CityViewModel(),
                DateTime = DateTime.Now,
                Accuracy = 1
            });

            // Assert
            actual.Should().NotBeNull();
            actual.Value.Should().NotBeNull();
        }

        [Fact]
        public void LoadNitrogenDioxide_ShouldReturnWeatherCurrent()
        {
            // Arrange
            _mapper.Map<CityDto>(Arg.Any<CityViewModel>()).Returns(new CityDto());
            _openWeatherMapService.LoadNitrogenDioxide(Arg.Any<CityDto>(), Arg.Any<DateTime>(), Arg.Any<int>()).Returns(new NitrogenDioxideDto());
            _mapper.Map<NitrogenDioxideViewModel>(Arg.Any<NitrogenDioxideDto>()).Returns(new NitrogenDioxideViewModel());
            _sut = new OpenWeatherMapController(_mapper, _openWeatherMapService);

            // Act
            var actual = _sut.LoadNitrogenDioxide(new AirPollutionRequestViewModel
            {
                City = new CityViewModel(),
                DateTime = DateTime.Now,
                Accuracy = 1
            });

            // Assert
            actual.Should().NotBeNull();
            actual.Value.Should().NotBeNull();
        }

        [Fact]
        public void LoadOzone_ShouldReturnWeatherCurrent()
        {
            // Arrange
            _mapper.Map<CityDto>(Arg.Any<CityViewModel>()).Returns(new CityDto());
            _openWeatherMapService.LoadOzone(Arg.Any<CityDto>(), Arg.Any<DateTime>(), Arg.Any<int>()).Returns(new OzoneDto());
            _mapper.Map<OzoneViewModel>(Arg.Any<OzoneDto>()).Returns(new OzoneViewModel());
            _sut = new OpenWeatherMapController(_mapper, _openWeatherMapService);

            // Act
            var actual = _sut.LoadOzone(new AirPollutionRequestViewModel
            {
                City = new CityViewModel(),
                DateTime = DateTime.Now,
                Accuracy = 1
            });

            // Assert
            actual.Should().NotBeNull();
            actual.Value.Should().NotBeNull();
        }

        [Fact]
        public void LoadSulfurDioxide_ShouldReturnWeatherCurrent()
        {
            // Arrange
            _mapper.Map<CityDto>(Arg.Any<CityViewModel>()).Returns(new CityDto());
            _openWeatherMapService.LoadSulfurDioxide(Arg.Any<CityDto>(), Arg.Any<DateTime>(), Arg.Any<int>()).Returns(new SulfurDioxideDto());
            _mapper.Map<SulfurDioxideViewModel>(Arg.Any<SulfurDioxideDto>()).Returns(new SulfurDioxideViewModel());
            _sut = new OpenWeatherMapController(_mapper, _openWeatherMapService);

            // Act
            var actual = _sut.LoadSulfurDioxide(new AirPollutionRequestViewModel
            {
                City = new CityViewModel(),
                DateTime = DateTime.Now,
                Accuracy = 1
            });

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
    }
}
