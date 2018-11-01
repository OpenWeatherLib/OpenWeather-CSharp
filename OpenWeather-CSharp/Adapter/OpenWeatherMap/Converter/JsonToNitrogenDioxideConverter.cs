using System;
using System.Collections.Generic;
using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;
using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model;
using Newtonsoft.Json.Linq;
using Serilog;

namespace GuepardoApps.OpenWeatherLib.Adapter.OpenWeatherMap.Converter
{
    public class JsonToNitrogenDioxideConverter : IJsonToNitrogenDioxideConverter
    {
        private readonly ILogger _logger;

        public JsonToNitrogenDioxideConverter(ILogger logger)
        {
            _logger = logger;
        }

        public NitrogenDioxide Convert(string response)
        {
            try
            {
                var nitrogenDioxide = new NitrogenDioxide();

                JObject jsonObject = JObject.Parse(response);

                var lat = System.Convert.ToDouble(jsonObject["latitude"].ToString());
                var lon = System.Convert.ToDouble(jsonObject["longitude"].ToString());
                nitrogenDioxide.Coordinates = new Coordinates { Lat = lat, Lon = lon };

                nitrogenDioxide.DateTime = System.Convert.ToDateTime(jsonObject["dateTime"].ToString());

                var data = new List<NitrogenDioxideData>();
                JToken dataListJsonObject = jsonObject.GetValue("data");
                foreach (JToken dataJsonObject in dataListJsonObject)
                {
                    JToken no2JsonObject = dataJsonObject["no2"];
                    var no2 = new NitrogenDioxideDataHolder
                    {
                        Precision = System.Convert.ToDouble(no2JsonObject["precision"].ToString()),
                        Value = System.Convert.ToDouble(no2JsonObject["value"].ToString())
                    };

                    JToken no2StratJsonObject = dataJsonObject["no2_strat"];
                    var no2Strat = new NitrogenDioxideDataHolder
                    {
                        Precision = System.Convert.ToDouble(no2StratJsonObject["precision"].ToString()),
                        Value = System.Convert.ToDouble(no2StratJsonObject["value"].ToString())
                    };

                    JToken no2TropJsonObject = dataJsonObject["no2_trop"];
                    var no2Trop = new NitrogenDioxideDataHolder
                    {
                        Precision = System.Convert.ToDouble(no2TropJsonObject["precision"].ToString()),
                        Value = System.Convert.ToDouble(no2TropJsonObject["value"].ToString())
                    };

                    var nitrogenDioxideData = new NitrogenDioxideData
                    {
                        No2 = no2,
                        No2Strat = no2Strat,
                        No2Trop = no2Trop
                    };

                    data.Add(nitrogenDioxideData);
                }
                nitrogenDioxide.Data = data;

                return nitrogenDioxide;
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
            }

            return null;
        }
    }
}
