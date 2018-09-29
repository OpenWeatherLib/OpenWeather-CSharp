using AutoMapper;
using Domain.DataScienceToolkit;
using Domain.DataScienceToolkit.Model;
using FluentAssertions;
using NSubstitute;
using Services.DataScienceToolkit;
using Services.DataScienceToolkit.Dto;
using Services.Validation;
using Xunit;

namespace Services.Test.DataScienceToolkit
{
    public class DataScienceToolkitServiceTests
    {
        private readonly IMapper _mapper;
        private readonly IValidationService _validationService;
        private readonly IDataScienceToolkitAdapter _dataScienceToolkitAdapter;

        private IDataScienceToolkitService _sut;

        public DataScienceToolkitServiceTests()
        {
            _mapper = Substitute.For<IMapper>();
            _validationService = Substitute.For<IValidationService>();
            _dataScienceToolkitAdapter = Substitute.For<IDataScienceToolkitAdapter>();

            _sut = new DataScienceToolkitService(_mapper, _validationService, _dataScienceToolkitAdapter);
        }

        [Fact]
        public void LoadCityData_ShouldReturnNull_IfNoNameProvided()
        {
            // Act
            var actual = _sut.LoadCityData(null);

            // Assert
            actual.Should().BeNull();
        }

        [Fact]
        public void LoadCityData_ShouldReturnCity()
        {
            // Arrange
            _mapper.Map<CityDto>(Arg.Any<City>()).Returns(new CityDto { Name = "Nuremberg", Coordinates = new CoordinatesDto { Lat = 35.3f, Lon = 45.0f } });
            _dataScienceToolkitAdapter.LoadCityData(Arg.Any<string>()).Returns(new City { Name = "Nuremberg", Coordinates = new Coordinates { Lat = 35.3f, Lon = 45.0f } });
            _sut = new DataScienceToolkitService(_mapper, _validationService, _dataScienceToolkitAdapter);

            // Act
            var actual = _sut.LoadCityData("Nuremberg");

            // Assert
            actual.Should().NotBeNull();
            actual.Name.Should().Be("Nuremberg");
            actual.Coordinates.Lat.Should().Be(35.3f);
            actual.Coordinates.Lon.Should().Be(45.0f);
        }
    }
}
