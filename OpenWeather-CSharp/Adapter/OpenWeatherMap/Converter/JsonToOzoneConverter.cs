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
            try
            {
                var ozone = new Ozone();

                JObject jsonObject = JObject.Parse(response);

                var lat = System.Convert.ToDouble(jsonObject["latitude"].ToString());
                var lon = System.Convert.ToDouble(jsonObject["longitude"].ToString());
                ozone.Coordinates = new Coordinates { Lat = lat, Lon = lon };

                ozone.DateTime = System.Convert.ToDateTime(jsonObject["dateTime"].ToString());
                ozone.Data = System.Convert.ToDouble(jsonObject["data"]);

                return ozone;
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
            }

            return null;
        }
    }
}
