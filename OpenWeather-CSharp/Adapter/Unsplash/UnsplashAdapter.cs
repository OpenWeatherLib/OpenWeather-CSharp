using Adapter.Unsplash.Converter;
using Domain.Unsplash;
using Domain.Unsplash.Enum;
using System.Net;

namespace Adapter.Unsplash
{
    public class UnsplashAdapter : IUnsplashAdapter
    {
        private string imageApiUrl = "https://api.unsplash.com/search/photos?client_id={0}&orientation={1}&query={2}";

        private readonly IJsonToUrlConverter _jsonToUrlConverter;

        private readonly WebClient _webClient;

        public UnsplashAdapter(IJsonToUrlConverter jsonToUrlConverter)
        {
            _jsonToUrlConverter = jsonToUrlConverter;

            _webClient = new WebClient();
        }

        public string ReceiveImagePictureUrl(string clientId, string cityName, UnsplashImageOrientationEnum orientation)
        {
            string url = string.Format(imageApiUrl, clientId, cityName, orientation.Description);
            string response = _webClient.DownloadString(url);
            return _jsonToUrlConverter.Convert(response);
        }
    }
}
