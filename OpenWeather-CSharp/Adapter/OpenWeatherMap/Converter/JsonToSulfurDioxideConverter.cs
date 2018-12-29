using System;
using System.Collections.Generic;
using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;
using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model;
using Newtonsoft.Json.Linq;
using Serilog;

namespace GuepardoApps.OpenWeatherLib.Adapter.OpenWeatherMap.Converter
{
    public class JsonToSulfurDioxideConverter : IJsonToSulfurDioxideConverter
    {
        private readonly ILogger _logger;

        public JsonToSulfurDioxideConverter(ILogger logger)
        {
            _logger = logger;
        }

        public SulfurDioxide Convert(string response)
        {
            var sulfurDioxide = new SulfurDioxide();

            try
            {
                var jsonObject = JObject.Parse(response);

                sulfurDioxide.DateTime = System.Convert.ToDateTime(jsonObject["time"].ToString());

                var lat = System.Convert.ToDouble(jsonObject["location"]["latitude"].ToString());
                var lon = System.Convert.ToDouble(jsonObject["location"]["longitude"].ToString());
                sulfurDioxide.Coordinates = new Coordinates { Lat = lat, Lon = lon };

                var data = new List<SulfurDioxideData>();
                var dataListJsonObject = jsonObject["data"];
                foreach (JToken dataJsonObject in dataListJsonObject)
                {
                    var sulfurDioxideData = new SulfurDioxideData
                    {
                        Precision = System.Convert.ToDouble(dataJsonObject["precision"].ToString()),
                        Pressure = System.Convert.ToDouble(dataJsonObject["pressure"].ToString()),
                        Value = System.Convert.ToDouble(dataJsonObject["value"].ToString())
                    };
                    data.Add(sulfurDioxideData);
                }

                sulfurDioxide.Data = data;
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
            }

            return sulfurDioxide;
        }
    }
}
