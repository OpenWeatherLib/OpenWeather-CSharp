using AutoMapper;
using FluentAssertions;
using NSubstitute;
using GuepardoApps.OpenWeatherLib.Services.Unsplash;
using GuepardoApps.OpenWeatherLib.Services.Unsplash.Enum;
using GuepardoApps.OpenWeatherLib.Web.Controllers;
using GuepardoApps.OpenWeatherLib.Web.Models.Unsplash.Enum;
using Xunit;

namespace GuepardoApps.OpenWeatherLib.Web.Test.Unsplash
{
    public class UnsplashControllerTests
    {
        private readonly IMapper _mapper;
        private readonly IUnsplashService _unsplashService;

        private UnsplashController _sut;

        public UnsplashControllerTests()
        {
            _mapper = Substitute.For<IMapper>();
            _unsplashService = Substitute.For<IUnsplashService>();

            _sut = new UnsplashController(_mapper, _unsplashService);
        }

        [Fact]
        public void ReceiveImagePictureUrl_ShouldReturnUrl()
        {
            // Arrange
            _mapper.Map<UnsplashImageOrientationDtoEnum>(Arg.Any<UnsplashImageOrientationViewModelEnum>()).Returns(UnsplashImageOrientationDtoEnum.Landscape);
            _unsplashService.ReceiveImagePictureUrl(Arg.Any<string>(), Arg.Any<UnsplashImageOrientationDtoEnum>()).Returns("https://www.test.org");
            _sut = new UnsplashController(_mapper, _unsplashService);

            // Act
            var actual = _sut.ReceiveImagePictureUrl("Nuremberg", 3);

            // Assert
            actual.Should().NotBeNull();
            actual.Value.Should().NotBeNull();
            actual.Value.Should().Be("https://www.test.org");
        }
    }
}
