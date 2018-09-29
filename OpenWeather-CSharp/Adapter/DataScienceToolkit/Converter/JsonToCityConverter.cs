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
            try
            {
                var city = new City();

                JObject jsonObject = JObject.Parse(response);

                JToken cityNameJObject = jsonObject.GetValue("address_components")[0];
                city.Name = cityNameJObject["short_name"].ToString();

                JToken countryNameJObject = jsonObject.GetValue("address_components")[1];
                city.Country = countryNameJObject["short_name"].ToString();

                JToken geometryJObject = jsonObject["geometry"];
                JToken locationJObject = geometryJObject["location"];

                var lat = System.Convert.ToDouble(locationJObject["lat"].ToString());
                var lng = System.Convert.ToDouble(locationJObject["lng"].ToString());

                city.Coordinates = new Coordinates { Lat = lat, Lon = lng };

                return city;
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
            }

            return null;
        }
    }
}
