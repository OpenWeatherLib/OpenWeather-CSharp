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
    public class JsonToWeatherForecastConverter : IJsonToWeatherForecastConverter
    {
        private readonly ILogger _logger;

        public JsonToWeatherForecastConverter(ILogger logger)
        {
            _logger = logger;
        }

        public WeatherForecast Convert(string response)
        {
            try
            {
                var weatherForecast = new WeatherForecast();

                JObject jsonObject = JObject.Parse(response);

                weatherForecast.Cod = jsonObject["cod"].ToString();
                weatherForecast.Message = System.Convert.ToDouble(jsonObject["message"].ToString());
                weatherForecast.Count = System.Convert.ToUInt32(jsonObject["cnt"].ToString());

                var city = new City();
                JToken cityJsonObject = jsonObject.GetValue("city");
                city.Id = System.Convert.ToUInt32(cityJsonObject["id"].ToString());
                city.Name = cityJsonObject["name"].ToString();
                city.Country = cityJsonObject["country"].ToString();
                city.Population = System.Convert.ToUInt32(cityJsonObject["population"].ToString());

                JToken coordinationJsonObject = cityJsonObject["coord"];
                var lat = System.Convert.ToDouble(coordinationJsonObject["lat"].ToString());
                var lon = System.Convert.ToDouble(coordinationJsonObject["lon"].ToString());
                city.Coordinates = new Coordinates { Lat = lat, Lon = lon };

                weatherForecast.City = city;

                var weatherForecastList = new List<WeatherForecastPart>();
                JToken weatherForecastListJsonObject = jsonObject.GetValue("list");
                foreach (JToken weatherForecastJsonObject in weatherForecastListJsonObject)
                {
                    var weatherForecastPart = new WeatherForecastPart();

                    weatherForecastPart.DateTime = UnixToDateTime.UnixTimeStampToDateTime(System.Convert.ToDouble(weatherForecastJsonObject["dt"].ToString()));

                    var main = new Main();
                    JToken mainJsonObject = weatherForecastJsonObject["main"];
                    main.Temperature = System.Convert.ToDouble(mainJsonObject["temp"].ToString());
                    main.TemperatureMin = System.Convert.ToDouble(mainJsonObject["temp_min"].ToString());
                    main.TemperatureMax = System.Convert.ToDouble(mainJsonObject["temp_max"].ToString());
                    main.Pressure = System.Convert.ToDouble(mainJsonObject["pressure"].ToString());
                    main.PressureSeaLevel = System.Convert.ToDouble(mainJsonObject["sea_level"].ToString());
                    main.PressureGroundLevel = System.Convert.ToDouble(mainJsonObject["grnd_level"].ToString());
                    main.Humidity = System.Convert.ToDouble(mainJsonObject["humidity"].ToString());
                    main.TemperatureKf = System.Convert.ToDouble(mainJsonObject["temp_kf"].ToString());
                    weatherForecastPart.Main = main;

                    var weatherPart = new WeatherPart();
                    JToken weatherPartJsonObject = weatherForecastJsonObject["weather"][0];
                    weatherPart.Id = System.Convert.ToUInt16(weatherPartJsonObject["id"].ToString());
                    weatherPart.Main = weatherPartJsonObject["main"].ToString();
                    weatherPart.Description = weatherPartJsonObject["description"].ToString();
                    weatherPart.Icon = weatherPartJsonObject["icon"].ToString();
                    weatherForecastPart.Weather = new List<WeatherPart> { weatherPart };

                    var clouds = new Clouds();
                    JToken cloudsJsonObject = weatherForecastJsonObject["clouds"];
                    clouds.All = System.Convert.ToUInt16(cloudsJsonObject["all"].ToString());
                    weatherForecastPart.Clouds = clouds;

                    var wind = new Wind();
                    JToken windJsonObject = weatherForecastJsonObject["wind"];
                    wind.Speed = System.Convert.ToDouble(windJsonObject["speed"].ToString());
                    wind.Degree = System.Convert.ToDouble(windJsonObject["deg"].ToString());
                    weatherForecastPart.Wind = wind;

                    var rain = new Rain();
                    // TODO casting of "3h" causes error...
                    // JToken rainJsonObject = weatherForecastJsonObject["rain"];
                    // rain.ThreeHourTrend = System.Convert.ToUInt16(rainJsonObject["3h"].ToString());
                    weatherForecastPart.Rain = rain;

                    weatherForecastPart.DateTimeTxt = weatherForecastJsonObject["dt_txt"].ToString();

                    weatherForecastPart.WeatherCondition = WeatherConditionEnum.GetByDescription(weatherPart.Main);

                    weatherForecastList.Add(weatherForecastPart);
                }
                weatherForecast.List = weatherForecastList;

                return weatherForecast;
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
            }

            return null;
        }
    }
}
