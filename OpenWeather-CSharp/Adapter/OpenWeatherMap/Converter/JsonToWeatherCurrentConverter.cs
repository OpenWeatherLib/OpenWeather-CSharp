using System;
using System.Collections.Generic;
using GuepardoApps.OpenWeatherLib.Crosscutting.Helper;
using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;
using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Enum;
using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model;
using Newtonsoft.Json.Linq;
using Serilog;

namespace GuepardoApps.OpenWeatherLib.Adapter.OpenWeatherMap.Converter
{
    public class JsonToWeatherCurrentConverter : IJsonToWeatherCurrentConverter
    {
        private readonly ILogger _logger;

        public JsonToWeatherCurrentConverter(ILogger logger)
        {
            _logger = logger;
        }

        public WeatherCurrent Convert(string response)
        {
            try
            {
                var weatherCurrent = new WeatherCurrent();

                JObject jsonObject = JObject.Parse(response);

                JToken coordinationJsonObject = jsonObject.GetValue("coord");
                var lat = System.Convert.ToDouble(coordinationJsonObject["lat"].ToString());
                var lon = System.Convert.ToDouble(coordinationJsonObject["lon"].ToString());
                weatherCurrent.Coordinates = new Coordinates { Lat = lat, Lon = lon };

                var weatherPart = new WeatherPart();
                JToken weatherPartJsonObject = jsonObject.GetValue("weather")[0];
                weatherPart.Id = System.Convert.ToUInt16(weatherPartJsonObject["id"].ToString());
                weatherPart.Main = weatherPartJsonObject["main"].ToString();
                weatherPart.Description = weatherPartJsonObject["description"].ToString();
                weatherPart.Icon = weatherPartJsonObject["icon"].ToString();
                weatherCurrent.Weather = new List<WeatherPart> { weatherPart };

                weatherCurrent.Base = jsonObject["base"].ToString();

                var main = new Main();
                JToken mainJsonObject = jsonObject.GetValue("main");
                main.Temperature = System.Convert.ToDouble(mainJsonObject["temp"].ToString());
                main.Pressure = System.Convert.ToDouble(mainJsonObject["pressure"].ToString());
                main.Humidity = System.Convert.ToDouble(mainJsonObject["humidity"].ToString());
                main.TemperatureMin = System.Convert.ToDouble(mainJsonObject["temp_min"].ToString());
                main.TemperatureMax = System.Convert.ToDouble(mainJsonObject["temp_max"].ToString());
                weatherCurrent.Main = main;

                weatherCurrent.Visibility = System.Convert.ToUInt16(jsonObject["visibility"].ToString());

                var wind = new Wind();
                JToken windJsonObject = jsonObject.GetValue("wind");
                wind.Speed = System.Convert.ToDouble(windJsonObject["speed"].ToString());
                wind.Degree = System.Convert.ToDouble(windJsonObject["deg"].ToString());
                weatherCurrent.Wind = wind;

                var clouds = new Clouds();
                JToken cloudsJsonObject = jsonObject.GetValue("clouds");
                clouds.All = System.Convert.ToUInt16(cloudsJsonObject["all"].ToString());
                weatherCurrent.Clouds = clouds;

                weatherCurrent.Datetime = UnixToDateTime.UnixTimeStampToDateTime(jsonObject["dt"].ToString());

                var sys = new Sys();
                JToken sysJsonObject = jsonObject.GetValue("sys");
                sys.Id = System.Convert.ToUInt16(sysJsonObject["id"].ToString());
                sys.Type = System.Convert.ToInt16(sysJsonObject["type"].ToString());
                sys.Message = System.Convert.ToDouble(sysJsonObject["message"].ToString());
                sys.Country = sysJsonObject["country"].ToString();
                sys.Sunrise = UnixToDateTime.UnixTimeStampToDateTime(sysJsonObject["sunrise"].ToString());
                sys.Sunset = UnixToDateTime.UnixTimeStampToDateTime(sysJsonObject["sunset"].ToString());
                weatherCurrent.Sys = sys;

                weatherCurrent.Id = System.Convert.ToUInt32(jsonObject["id"].ToString());
                weatherCurrent.Name = jsonObject["name"].ToString();
                weatherCurrent.Cod = System.Convert.ToInt16(jsonObject["cod"].ToString());

                weatherCurrent.WeatherCondition = WeatherConditionEnum.GetByDescription(weatherPart.Main);

                return weatherCurrent;
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
            }

            return null;
        }
    }
}
