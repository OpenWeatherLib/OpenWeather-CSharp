using AutoMapper;
using GuepardoApps.OpenWeatherLib.Domain.Unsplash;
using GuepardoApps.OpenWeatherLib.Domain.Unsplash.Enum;
using GuepardoApps.OpenWeatherLib.Services.Unsplash.Enum;
using Microsoft.Extensions.Configuration;
using System;

namespace GuepardoApps.OpenWeatherLib.Services.Unsplash
{
    public class UnsplashService : IUnsplashService
    {
        private readonly IMapper _mapper;

        private readonly IUnsplashAdapter _unsplashAdapter;

        private readonly IConfiguration _configuration;

        public UnsplashService(
            IMapper mapper,
            IUnsplashAdapter unsplashAdapter,
            IConfiguration configuration)
        {
            _mapper = mapper;
            _unsplashAdapter = unsplashAdapter;
            _configuration = configuration;

            if (_configuration["ApiKeys:Unsplash"] == string.Empty)
            {
                throw new ArgumentException("Invalid Unsplash api key!");
            }
        }

        public string ReceiveImagePictureUrl(string cityName, UnsplashImageOrientationDtoEnum orientation) =>
            string.IsNullOrWhiteSpace(cityName) || orientation == UnsplashImageOrientationDtoEnum.Null
                ? string.Empty
                : _unsplashAdapter.ReceiveImagePictureUrl(_configuration["ApiKeys:Unsplash"], cityName, _mapper.Map<UnsplashImageOrientationEnum>(orientation));
    }
}
