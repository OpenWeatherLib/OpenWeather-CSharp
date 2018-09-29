using System;
using Domain.DataScienceToolkit.Model;
using Domain.OpenWeatherMap.Model;
using Newtonsoft.Json.Linq;
using Serilog;

namespace Adapter.OpenWeatherMap.Converter
{
    public class JsonToUvIndexConverter : IJsonToUvIndexConverter
    {
        private readonly ILogger _logger;

        public JsonToUvIndexConverter(ILogger logger)
        {
            _logger = logger;
        }

        public UvIndex Convert(string response)
        {
            try
            {
                var uvIndex = new UvIndex();

                JObject jsonObject = JObject.Parse(response);

                var lat = System.Convert.ToDouble(jsonObject["lat"].ToString());
                var lon = System.Convert.ToDouble(jsonObject["lon"].ToString());
                uvIndex.Coordinates = new Coordinates { Lat = lat, Lon = lon };

                uvIndex.DateTimeIso = jsonObject["date_iso"].ToString();
                uvIndex.DateTime = System.Convert.ToDateTime(jsonObject["date_iso"].ToString());
                uvIndex.Value = System.Convert.ToDouble(jsonObject["value"].ToString());

                return uvIndex;
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
            }

            return null;
        }
    }
}
