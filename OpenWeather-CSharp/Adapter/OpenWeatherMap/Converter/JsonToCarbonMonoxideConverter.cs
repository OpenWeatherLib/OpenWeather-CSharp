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
            var carbonMonoxide = new CarbonMonoxide();

            try
            {
                var jsonObject = JObject.Parse(response);

                carbonMonoxide.DateTime = System.Convert.ToDateTime(jsonObject["time"].ToString());

                var lat = System.Convert.ToDouble(jsonObject["location"]["latitude"].ToString());
                var lon = System.Convert.ToDouble(jsonObject["location"]["longitude"].ToString());
                carbonMonoxide.Coordinates = new Coordinates { Lat = lat, Lon = lon };
                
                var data = new List<CarbonMonoxideData>();
                var dataListJsonObject = jsonObject["data"];
                foreach (var dataJsonObject in dataListJsonObject)
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
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
            }

            return carbonMonoxide;
        }
    }
}
