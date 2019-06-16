using AutoMapper;
using GuepardoApps.OpenWeatherLib.Domain.Unsplash;
using GuepardoApps.OpenWeatherLib.Domain.Unsplash.Enum;
using FluentAssertions;
using NSubstitute;
using GuepardoApps.OpenWeatherLib.Services.Unsplash;
using GuepardoApps.OpenWeatherLib.Services.Unsplash.Enum;
using Xunit;
using Microsoft.Extensions.Configuration;

namespace GuepardoApps.OpenWeatherLib.Services.Test.Unsplash
{
    public class UnsplashServiceTests
    {
        private readonly IMapper _mapper;
        private readonly IUnsplashAdapter _unsplashAdapter;
        private readonly IConfiguration _configuration;

        private IUnsplashService _sut;

        public UnsplashServiceTests()
        {
            _mapper = Substitute.For<IMapper>();
            _unsplashAdapter = Substitute.For<IUnsplashAdapter>();
            _configuration = Substitute.For<IConfiguration>();

            _configuration["ApiKeys:Unsplash"].Returns("ApiKey");

            _sut = new UnsplashService(_mapper, _unsplashAdapter, _configuration);
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
            _sut = new UnsplashService(_mapper, _unsplashAdapter, _configuration);

            // Act
            var actual = _sut.ReceiveImagePictureUrl("Nuremberg", UnsplashImageOrientationDtoEnum.Landscape);

            // Assert
            actual.Should().NotBeNull();
            actual.Should().Be("URL");
        }
    }
}
