using System;
using System.Collections.Generic;
using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;
using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model;
using Newtonsoft.Json.Linq;
using Serilog;

namespace GuepardoApps.OpenWeatherLib.Adapter.OpenWeatherMap.Converter
{
    public class JsonToCarbonMonoxideConverter : IJsonToCarbonMonoxideConverter
    {
        private readonly ILogger _logger;

        public JsonToCarbonMonoxideConverter(ILogger logger)
        {
            _logger = logger;
        }

        public CarbonMonoxide Convert(string response)
        {
            try
            {
                var carbonMonoxide = new CarbonMonoxide();

                JObject jsonObject = JObject.Parse(response);

                var lat = System.Convert.ToDouble(jsonObject["latitude"].ToString());
                var lon = System.Convert.ToDouble(jsonObject["longitude"].ToString());
                carbonMonoxide.Coordinates = new Coordinates { Lat = lat, Lon = lon };

                carbonMonoxide.DateTime = System.Convert.ToDateTime(jsonObject["dateTime"].ToString());

                var data = new List<CarbonMonoxideData>();
                JToken dataListJsonObject = jsonObject.GetValue("data");
                foreach (JToken dataJsonObject in dataListJsonObject)
                {
                    var carbonMonoxideData = new CarbonMonoxideData
                    {
                        Precision = System.Convert.ToDouble(dataJsonObject["precision"].ToString()),
                        Pressure = System.Convert.ToDouble(dataJsonObject["pressure"].ToString()),
                        Value = System.Convert.ToDouble(dataJsonObject["value"].ToString())
                    };
                    data.Add(carbonMonoxideData);
                }
                carbonMonoxide.Data = data;

                return carbonMonoxide;
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
            }

            return null;
        }
    }
}
