using GuepardoApps.OpenWeatherLib.Adapter.Unsplash.Converter;
using GuepardoApps.OpenWeatherLib.Domain.Unsplash;
using GuepardoApps.OpenWeatherLib.Domain.Unsplash.Enum;

namespace GuepardoApps.OpenWeatherLib.Adapter.Unsplash
{
    public class UnsplashAdapter : BaseAdapter, IUnsplashAdapter
    {
        private const string ImageApiUrl = "https://api.unsplash.com/search/photos?client_id={0}&orientation={1}&query={2}";

        private readonly IJsonToUrlConverter _jsonToUrlConverter;

        public UnsplashAdapter(IJsonToUrlConverter jsonToUrlConverter)
        {
            _jsonToUrlConverter = jsonToUrlConverter;
        }

        public string ReceiveImagePictureUrl(string clientId, string cityName, UnsplashImageOrientationEnum orientation)
        {
            var url = string.Format(ImageApiUrl, clientId, orientation.Description, cityName);
            var response = CleanResponse(GetRequest(url));
            return _jsonToUrlConverter.Convert(response);
        }
    }
}
