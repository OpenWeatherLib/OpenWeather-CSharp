using AutoMapper;
using Domain.Unsplash;
using Domain.Unsplash.Enum;
using Services.Unsplash.Enum;
using Services.Validation;

namespace Services.Unsplash
{
    public class UnsplashService : IUnsplashService
    {
        private readonly IMapper _mapper;

        private readonly IValidationService _validationService;

        private readonly IUnsplashAdapter _unsplashAdapter;

        // TODO
        private readonly string _clientId = "TODO_READ_OUT_CONFIG";

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
