using System;
using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;
using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model;
using Newtonsoft.Json.Linq;
using Serilog;

namespace GuepardoApps.OpenWeatherLib.Adapter.OpenWeatherMap.Converter
{
    public class JsonToOzoneConverter : IJsonToOzoneConverter
    {
        private readonly ILogger _logger;

        public JsonToOzoneConverter(ILogger logger)
        {
            _logger = logger;
        }

        public Ozone Convert(string response)
        {
            var ozone = new Ozone();

            try
            {
                var jsonObject = JObject.Parse(response);

                ozone.DateTime = System.Convert.ToDateTime(jsonObject["time"].ToString());

                var lat = System.Convert.ToDouble(jsonObject["location"]["latitude"].ToString());
                var lon = System.Convert.ToDouble(jsonObject["location"]["longitude"].ToString());
                ozone.Coordinates = new Coordinates { Lat = lat, Lon = lon };

                ozone.Data = System.Convert.ToDouble(jsonObject["data"]);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
            }

            return ozone;
        }
    }
}
