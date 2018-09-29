using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;
using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model;

namespace GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap
{
    public interface IOpenWeatherMapAdapter
    {
        WeatherCurrent LoadWeatherCurrent(string apiKey, City city);

        WeatherForecast LoadWeatherForecast(string apiKey, City city);

        UvIndex LoadUvIndex(string apiKey, City city);
    }
}
