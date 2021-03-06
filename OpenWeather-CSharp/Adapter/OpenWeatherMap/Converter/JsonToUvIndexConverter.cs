﻿using System;
using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;
using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model;
using Newtonsoft.Json.Linq;
using Serilog;

namespace GuepardoApps.OpenWeatherLib.Adapter.OpenWeatherMap.Converter
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
            var uvIndex = new UvIndex();

            try
            {
                var jsonObject = JObject.Parse(response);

                var lat = System.Convert.ToDouble(jsonObject["lat"].ToString());
                var lon = System.Convert.ToDouble(jsonObject["lon"].ToString());
                uvIndex.Coordinates = new Coordinates { Lat = lat, Lon = lon };

                uvIndex.DateTimeIso = jsonObject["date_iso"].ToString();
                uvIndex.DateTime = System.Convert.ToDateTime(jsonObject["date_iso"].ToString());
                uvIndex.Value = System.Convert.ToDouble(jsonObject["value"].ToString());
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
            }

            return uvIndex;
        }
    }
}
