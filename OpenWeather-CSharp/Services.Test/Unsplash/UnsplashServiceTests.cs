using AutoMapper;
using GuepardoApps.OpenWeatherLib.Domain.Unsplash;
using GuepardoApps.OpenWeatherLib.Domain.Unsplash.Enum;
using FluentAssertions;
using NSubstitute;
using GuepardoApps.OpenWeatherLib.Services.Unsplash;
using GuepardoApps.OpenWeatherLib.Services.Unsplash.Enum;
using GuepardoApps.OpenWeatherLib.Services.Validation;
using Xunit;

namespace GuepardoApps.OpenWeatherLib.Services.Test.Unsplash
{
    public class UnsplashServiceTests
    {
        private readonly IMapper _mapper;
        private readonly IValidationService _validationService;
        private readonly IUnsplashAdapter _unsplashAdapter;

        private IUnsplashService _sut;

        public UnsplashServiceTests()
        {
            _mapper = Substitute.For<IMapper>();
            _validationService = Substitute.For<IValidationService>();
            _unsplashAdapter = Substitute.For<IUnsplashAdapter>();

            _sut = new UnsplashService(_mapper, _validationService, _unsplashAdapter);
        }

        [Fact]
        public void ReceiveImagePictureUrl_ShouldReturnEmptyString_IfNoNameProvided()
        {
            // Act
            var actual = _sut.ReceiveImagePictureUrl(null, UnsplashImageOrientationDtoEnum.Landscape);

            // Assert
            actual.Should().Be(string.Empty);
        }

        [Fact]
        public void ReceiveImagePictureUrl_ShouldReturnUrl()
        {
            // Arrange
            _unsplashAdapter.ReceiveImagePictureUrl(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<UnsplashImageOrientationEnum>()).Returns("URL");
            _sut = new UnsplashService(_mapper, _validationService, _unsplashAdapter);

            // Act
            var actual = _sut.ReceiveImagePictureUrl("Nuremberg", UnsplashImageOrientationDtoEnum.Landscape);

            // Assert
            actual.Should().NotBeNull();
            actual.Should().Be("URL");
        }
    }
}
