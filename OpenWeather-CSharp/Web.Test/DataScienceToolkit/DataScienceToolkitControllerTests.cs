using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Services.DataScienceToolkit;
using Services.DataScienceToolkit.Dto;
using Web.Controllers;
using Web.Models.DataScienceToolkit;
using Xunit;

namespace Web.Test.DataScienceToolkit
{
    public class DataScienceToolkitControllerTests
    {
        private readonly IMapper _mapper;
        private readonly IDataScienceToolkitService _dataScienceToolkitService;

        private DataScienceToolkitController _sut;

        public DataScienceToolkitControllerTests()
        {
            _mapper = Substitute.For<IMapper>();
            _dataScienceToolkitService = Substitute.For<IDataScienceToolkitService>();

            _sut = new DataScienceToolkitController(_mapper, _dataScienceToolkitService);
        }

        [Fact]
        public void LoadCityData_ShouldReturnCity()
        {
            // Arrange
            _mapper.Map<CityViewModel>(Arg.Any<CityDto>()).Returns(new CityViewModel { Name = "Nuremberg", Coordinates = new CoordinatesViewModel { Lat = 35.3f, Lon = 45.0f } });
            _dataScienceToolkitService.LoadCityData(Arg.Any<string>()).Returns(new CityDto { Name = "Nuremberg", Coordinates = new CoordinatesDto { Lat = 35.3f, Lon = 45.0f } });
            _sut = new DataScienceToolkitController(_mapper, _dataScienceToolkitService);

            // Act
            var actual = _sut.LoadCityData("Nuremberg");

            // Assert
            actual.Should().NotBeNull();
            actual.Value.Should().NotBeNull();
            actual.Value.Name.Should().Be("Nuremberg");
            actual.Value.Coordinates.Lat.Should().Be(35.3f);
            actual.Value.Coordinates.Lon.Should().Be(45.0f);
        }
    }
}
