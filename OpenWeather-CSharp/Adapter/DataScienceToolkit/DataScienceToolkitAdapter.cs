using GuepardoApps.OpenWeatherLib.Adapter.DataScienceToolkit.Converter;
using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit;
using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;
using System.Net;

namespace GuepardoApps.OpenWeatherLib.Adapter.DataScienceToolkit
{
    public class DataScienceToolkitAdapter : IDataScienceToolkitAdapter
    {
        private const string GeoCodeForCityUrl = "http://www.datasciencetoolkit.org/maps/api/geocode/json?address={0}";

        private readonly IJsonToCityConverter _jsonToCityConverter;

        private WebClient _webClient;

        public DataScienceToolkitAdapter(IJsonToCityConverter jsonToCityConverter)
        {
            _jsonToCityConverter = jsonToCityConverter;

            _webClient = new WebClient();
        }

        public City LoadCityData(string cityName)
        {
            string url = string.Format(GeoCodeForCityUrl, cityName);
            string response = _webClient.DownloadString(url);
            return _jsonToCityConverter.Convert(response);
        }
    }
}
