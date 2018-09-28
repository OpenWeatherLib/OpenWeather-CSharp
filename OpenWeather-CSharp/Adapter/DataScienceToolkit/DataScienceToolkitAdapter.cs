using Domain.DataScienceToolkit;
using Domain.DataScienceToolkit.Model;
using System.Net;

namespace Adapter.DataScienceToolkit
{
    public class DataScienceToolkitAdapter : IDataScienceToolkitAdapter
    {
        private const string geoCodeForCityUrl = "http://www.datasciencetoolkit.org/maps/api/geocode/json?address={0}";

        private WebClient _webClient;

        public DataScienceToolkitAdapter()
        {
            _webClient = new WebClient();
        }

        public City LoadCityData(string cityName)
        {
            string url = string.Format(geoCodeForCityUrl, cityName);
            string response = _webClient.DownloadString(url);

            // TODO Convert

            return null;
        }
    }
}
