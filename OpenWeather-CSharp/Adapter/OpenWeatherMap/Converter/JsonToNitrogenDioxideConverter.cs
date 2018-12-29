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
            var nitrogenDioxide = new NitrogenDioxide();

            try
            {
                var jsonObject = JObject.Parse(response);

                nitrogenDioxide.DateTime = System.Convert.ToDateTime(jsonObject["time"].ToString());

                var lat = System.Convert.ToDouble(jsonObject["location"]["latitude"].ToString());
                var lon = System.Convert.ToDouble(jsonObject["location"]["longitude"].ToString());
                nitrogenDioxide.Coordinates = new Coordinates { Lat = lat, Lon = lon };

                var dataJsonObject = jsonObject["data"];

                var no2JsonObject = dataJsonObject["no2"];
                var no2 = new NitrogenDioxideDataHolder
                {
                    Precision = System.Convert.ToDouble(no2JsonObject["precision"].ToString()),
                    Value = System.Convert.ToDouble(no2JsonObject["value"].ToString())
                };

                var no2StratJsonObject = dataJsonObject["no2_strat"];
                var no2Strat = new NitrogenDioxideDataHolder
                {
                    Precision = System.Convert.ToDouble(no2StratJsonObject["precision"].ToString()),
                    Value = System.Convert.ToDouble(no2StratJsonObject["value"].ToString())
                };

                var no2TropJsonObject = dataJsonObject["no2_trop"];
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

                nitrogenDioxide.Data = new List<NitrogenDioxideData> { nitrogenDioxideData };
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
            }

            return nitrogenDioxide;
        }
    }
}
