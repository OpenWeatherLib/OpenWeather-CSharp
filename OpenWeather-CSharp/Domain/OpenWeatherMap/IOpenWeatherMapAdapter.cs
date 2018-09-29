using Domain.DataScienceToolkit.Model;
using Domain.OpenWeatherMap.Model;

namespace Domain.OpenWeatherMap
{
    public interface IOpenWeatherMapAdapter
    {
        WeatherCurrent LoadWeatherCurrent(string apiKey, City city);

        WeatherForecast LoadWeatherForecast(string apiKey, City city);

        UvIndex LoadUvIndex(string apiKey, City city);
    }
}
