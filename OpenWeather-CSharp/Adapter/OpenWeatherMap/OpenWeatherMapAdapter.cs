using Adapter.OpenWeatherMap.Converter;
using Domain.DataScienceToolkit.Model;
using Domain.OpenWeatherMap;
using Domain.OpenWeatherMap.Model;
using System.Net;

namespace Adapter.DataScienceToolkit
{
    public class OpenWeatherMapAdapter : IOpenWeatherMapAdapter
    {
        private const string CurrentWeatherUrl = "http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&APPID={1}";
        private const string ForecastWeatherUrl = "http://api.openweathermap.org/data/2.5/forecast?q={0}&units=metric&APPID={1}";
        private const string UvIndexUrl = "http://api.openweathermap.org/data/2.5/uvi?lat={0}&lon={1}&APPID={2}";

        private readonly IJsonToWeatherCurrentConverter _jsonToWeatherCurrentConverter;
        private readonly IJsonToWeatherForecastConverter _jsonToWeatherForecastConverter;
        private readonly IJsonToUvIndexConverter _jsonToUvIndexConverter;

        private WebClient _webClient;

        public OpenWeatherMapAdapter(
            IJsonToWeatherCurrentConverter jsonToWeatherCurrentConverter,
            IJsonToWeatherForecastConverter jsonToWeatherForecastConverter,
            IJsonToUvIndexConverter jsonToUvIndexConverter)
        {
            _jsonToWeatherCurrentConverter = jsonToWeatherCurrentConverter;
            _jsonToWeatherForecastConverter = jsonToWeatherForecastConverter;
            _jsonToUvIndexConverter = jsonToUvIndexConverter;

            _webClient = new WebClient();
        }

        public WeatherCurrent LoadWeatherCurrent(string apiKey, City city)
        {
            string url = string.Format(CurrentWeatherUrl, city.Name, apiKey);
            string response = _webClient.DownloadString(url);
            return _jsonToWeatherCurrentConverter.Convert(response);
        }

        public WeatherForecast LoadWeatherForecast(string apiKey, City city)
        {
            string url = string.Format(ForecastWeatherUrl, city.Name, apiKey);
            string response = _webClient.DownloadString(url);
            return _jsonToWeatherForecastConverter.Convert(response);
        }

        public UvIndex LoadUvIndex(string apiKey, City city)
        {
            string url = string.Format(UvIndexUrl, city.Coordinates.Lat, city.Coordinates.Lon, apiKey);
            string response = _webClient.DownloadString(url);
            return _jsonToUvIndexConverter.Convert(response);
        }
    }
}
