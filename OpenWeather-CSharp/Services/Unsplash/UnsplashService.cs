using AutoMapper;
using GuepardoApps.OpenWeatherLib.Domain.Unsplash;
using GuepardoApps.OpenWeatherLib.Domain.Unsplash.Enum;
using GuepardoApps.OpenWeatherLib.Services.Unsplash.Enum;
using GuepardoApps.OpenWeatherLib.Services.Validation;

namespace GuepardoApps.OpenWeatherLib.Services.Unsplash
{
    public class UnsplashService : IUnsplashService
    {
        private readonly IMapper _mapper;

        private readonly IValidationService _validationService;

        private readonly IUnsplashAdapter _unsplashAdapter;

        // TODO Use a config file
        private readonly string _clientId = "TODO Use a config file";

        public UnsplashService(
            IMapper mapper,
            IValidationService validationService,
            IUnsplashAdapter unsplashAdapter)
        {
            _mapper = mapper;
            _validationService = validationService;
            _unsplashAdapter = unsplashAdapter;
        }

        public string ReceiveImagePictureUrl(string cityName, UnsplashImageOrientationDtoEnum orientation)
        {
            if (string.IsNullOrWhiteSpace(cityName) || orientation == UnsplashImageOrientationDtoEnum.Null)
            {
                return string.Empty;
            }

            return _unsplashAdapter.ReceiveImagePictureUrl(_clientId, cityName, _mapper.Map<UnsplashImageOrientationEnum>(orientation));
        }
    }
}
