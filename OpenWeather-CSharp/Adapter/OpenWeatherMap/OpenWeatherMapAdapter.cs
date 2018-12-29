using GuepardoApps.OpenWeatherLib.Adapter.OpenWeatherMap.Converter;
using GuepardoApps.OpenWeatherLib.Crosscutting.Extensions;
using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;
using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap;
using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model;
using System;

namespace GuepardoApps.OpenWeatherLib.Adapter.DataScienceToolkit
{
    public class OpenWeatherMapAdapter : BaseAdapter, IOpenWeatherMapAdapter
    {
        private const string CurrentWeatherUrl = "http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&APPID={1}";
        private const string ForecastWeatherUrl = "http://api.openweathermap.org/data/2.5/forecast?q={0}&units=metric&APPID={1}";
        private const string UvIndexUrl = "http://api.openweathermap.org/data/2.5/uvi?lat={0}&lon={1}&APPID={2}";

        // e.g. https://samples.openweathermap.org/pollution/v1/co/0.0,10.0/2016-12-25T01:04:08Z.json?appid=b1b15e88fa797225412429c1c50c122a1
        private const string AirPollutionUrl = "http://api.openweathermap.org/pollution/v1/{0}/{1}/{2}.json?appid={3}";

        private const string Co = "co";
        private const string No2 = "no2";
        private const string O3 = "o3";
        private const string So2 = "so2";

        private readonly IJsonToCarbonMonoxideConverter _jsonToCarbonMonoxideConverter;
        private readonly IJsonToNitrogenDioxideConverter _jsonToNitrogenDioxideConverter;
        private readonly IJsonToOzoneConverter _jsonToOzoneConverter;
        private readonly IJsonToSulfurDioxideConverter _jsonToSulfurDioxideConverter;
        private readonly IJsonToUvIndexConverter _jsonToUvIndexConverter;
        private readonly IJsonToWeatherCurrentConverter _jsonToWeatherCurrentConverter;
        private readonly IJsonToWeatherForecastConverter _jsonToWeatherForecastConverter;

        public OpenWeatherMapAdapter(
            IJsonToCarbonMonoxideConverter jsonToCarbonMonoxideConverter,
            IJsonToNitrogenDioxideConverter jsonToNitrogenDioxideConverter,
            IJsonToOzoneConverter jsonToOzoneConverter,
            IJsonToSulfurDioxideConverter jsonToSulfurDioxideConverter,
            IJsonToUvIndexConverter jsonToUvIndexConverter,
            IJsonToWeatherCurrentConverter jsonToWeatherCurrentConverter,
            IJsonToWeatherForecastConverter jsonToWeatherForecastConverter)
        {
            _jsonToCarbonMonoxideConverter = jsonToCarbonMonoxideConverter;
            _jsonToNitrogenDioxideConverter = jsonToNitrogenDioxideConverter;
            _jsonToOzoneConverter = jsonToOzoneConverter;
            _jsonToSulfurDioxideConverter = jsonToSulfurDioxideConverter;
            _jsonToUvIndexConverter = jsonToUvIndexConverter;
            _jsonToWeatherCurrentConverter = jsonToWeatherCurrentConverter;
            _jsonToWeatherForecastConverter = jsonToWeatherForecastConverter;
        }

        public CarbonMonoxide LoadCarbonMonoxide(string apiKey, City city, DateTime? dateTime, int accuracy)
        {
            var url = string.Format(AirPollutionUrl, Co, $"{city.Coordinates.Lat.ToFixed(accuracy)},{city.Coordinates.Lon.ToFixed(accuracy)}", dateTime != null ? ((DateTime)dateTime).ToString("yyyy-MM-ddZ") : "current", apiKey);
            var response = CleanResponse(GetRequest(url));
            return _jsonToCarbonMonoxideConverter.Convert(response);
        }

        public NitrogenDioxide LoadNitrogenDioxide(string apiKey, City city, DateTime? dateTime, int accuracy)
        {
            var url = string.Format(AirPollutionUrl, No2, $"{city.Coordinates.Lat.ToFixed(accuracy)},{city.Coordinates.Lon.ToFixed(accuracy)}", dateTime != null ? ((DateTime)dateTime).ToString("yyyy-MM-ddZ") : "current", apiKey);
            var response = CleanResponse(GetRequest(url));
            return _jsonToNitrogenDioxideConverter.Convert(response);
        }

        public Ozone LoadOzone(string apiKey, City city, DateTime? dateTime, int accuracy)
        {
            var url = string.Format(AirPollutionUrl, O3, $"{city.Coordinates.Lat.ToFixed(accuracy)},{city.Coordinates.Lon.ToFixed(accuracy)}", dateTime != null ? ((DateTime)dateTime).ToString("yyyy-MM-ddZ") : "current", apiKey);
            var response = CleanResponse(GetRequest(url));
            return _jsonToOzoneConverter.Convert(response);
        }

        public SulfurDioxide LoadSulfurDioxide(string apiKey, City city, DateTime? dateTime, int accuracy)
        {
            var url = string.Format(AirPollutionUrl, So2, $"{city.Coordinates.Lat.ToFixed(accuracy)},{city.Coordinates.Lon.ToFixed(accuracy)}", dateTime != null ? ((DateTime)dateTime).ToString("yyyy-MM-ddZ") : "current", apiKey);
            var response = CleanResponse(GetRequest(url));
            return _jsonToSulfurDioxideConverter.Convert(response);
        }

        public UvIndex LoadUvIndex(string apiKey, City city)
        {
            var url = string.Format(UvIndexUrl, city.Coordinates.Lat, city.Coordinates.Lon, apiKey);
            var response = CleanResponse(GetRequest(url));
            return _jsonToUvIndexConverter.Convert(response);
        }

        public WeatherCurrent LoadWeatherCurrent(string apiKey, City city)
        {
            var url = string.Format(CurrentWeatherUrl, city.Name, apiKey);
            var response = CleanResponse(GetRequest(url));
            return _jsonToWeatherCurrentConverter.Convert(response);
        }

        public WeatherForecast LoadWeatherForecast(string apiKey, City city)
        {
            var url = string.Format(ForecastWeatherUrl, city.Name, apiKey);
            var response = CleanResponse(GetRequest(url));
            return _jsonToWeatherForecastConverter.Convert(response);
        }
    }
}
