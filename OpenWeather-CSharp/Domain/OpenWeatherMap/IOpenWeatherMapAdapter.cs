using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;
using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model;
using System;

namespace GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap
{
    public interface IOpenWeatherMapAdapter
    {
        CarbonMonoxide LoadCarbonMonoxide(string apiKey, City city, DateTime dateTime, int accuracy);

        NitrogenDioxide LoadNitrogenDioxide(string apiKey, City city, DateTime dateTime, int accuracy);

        Ozone LoadOzone(string apiKey, City city, DateTime dateTime, int accuracy);

        SulfurDioxide LoadSulfurDioxide(string apiKey, City city, DateTime dateTime, int accuracy);

        UvIndex LoadUvIndex(string apiKey, City city);

        WeatherCurrent LoadWeatherCurrent(string apiKey, City city);

        WeatherForecast LoadWeatherForecast(string apiKey, City city);
    }
}
