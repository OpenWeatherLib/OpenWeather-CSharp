using AutoMapper;
using GuepardoApps.OpenWeatherLib.Domain.Unsplash;
using GuepardoApps.OpenWeatherLib.Domain.Unsplash.Enum;
using GuepardoApps.OpenWeatherLib.Services.Unsplash.Enum;
using GuepardoApps.OpenWeatherLib.Services.Validation;
using Microsoft.Extensions.Configuration;
using System;

namespace GuepardoApps.OpenWeatherLib.Services.Unsplash
{
    public class UnsplashService : IUnsplashService
    {
        private readonly IMapper _mapper;

        private readonly IValidationService _validationService;

        private readonly IUnsplashAdapter _unsplashAdapter;

        private readonly IConfiguration _configuration;

        public UnsplashService(
            IMapper mapper,
            IValidationService validationService,
            IUnsplashAdapter unsplashAdapter,
            IConfiguration configuration)
        {
            _mapper = mapper;
            _validationService = validationService;
            _unsplashAdapter = unsplashAdapter;
            _configuration = configuration;

            if (_configuration["ApiKeys:Unsplash"] == string.Empty)
            {
                throw new ArgumentException("Invalid Unsplash api key!");
            }
        }

        public string ReceiveImagePictureUrl(string cityName, UnsplashImageOrientationDtoEnum orientation)
        {
            if (string.IsNullOrWhiteSpace(cityName) || orientation == UnsplashImageOrientationDtoEnum.Null)
            {
                return string.Empty;
            }

            return _unsplashAdapter.ReceiveImagePictureUrl(_configuration["ApiKeys:Unsplash"], cityName, _mapper.Map<UnsplashImageOrientationEnum>(orientation));
        }
    }
}
