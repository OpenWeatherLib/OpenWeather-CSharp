using GuepardoApps.OpenWeatherLib.Adapter.DataScienceToolkit.Converter;
using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit;
using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;

namespace GuepardoApps.OpenWeatherLib.Adapter.DataScienceToolkit
{
    public class DataScienceToolkitAdapter : BaseAdapter, IDataScienceToolkitAdapter
    {
        private const string GeoCodeForCityUrl = "http://www.datasciencetoolkit.org/maps/api/geocode/json?address={0}";

        private readonly IJsonToCityConverter _jsonToCityConverter;

        public DataScienceToolkitAdapter(IJsonToCityConverter jsonToCityConverter)
        {
            _jsonToCityConverter = jsonToCityConverter;
        }

        public City LoadCityData(string cityName) =>
            _jsonToCityConverter.Convert(CleanResponse(GetRequest(string.Format(GeoCodeForCityUrl, cityName))));
    }
}
