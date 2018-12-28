using System;
using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;
using Newtonsoft.Json.Linq;
using Serilog;

namespace GuepardoApps.OpenWeatherLib.Adapter.DataScienceToolkit.Converter
{
    public class JsonToCityConverter : IJsonToCityConverter
    {
        private readonly ILogger _logger;

        public JsonToCityConverter(ILogger logger)
        {
            _logger = logger;
        }

        public City Convert(string response)
        {
            var name = string.Empty;
            var country = string.Empty;
            var lat = 0.0;
            var lng = 0.0;

            try
            {
                var jsonObject = JObject.Parse(response)["results"][0];

                var cityNameJObject = jsonObject["address_components"][0];
                name = cityNameJObject["short_name"].ToString();

                var countryNameJObject = jsonObject["address_components"][1];
                country = countryNameJObject["short_name"].ToString();

                var locationJObject = jsonObject["geometry"]["location"];
                lat = System.Convert.ToDouble(locationJObject["lat"].ToString());
                lng = System.Convert.ToDouble(locationJObject["lng"].ToString());
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
            }

            return new City
            {
                Id = 0,
                Name = name,
                Country = country,
                Population = 0,
                Coordinates = new Coordinates
                {
                    Lat = lat,
                    Lon = lng
                }
            };
        }
    }
}
