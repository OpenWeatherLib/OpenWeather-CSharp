using Domain.DataScienceToolkit.Model;
using Domain.OpenWeatherMap.Model;

namespace Domain.OpenWeatherMap
{
    public interface IOpenWeatherMapAdapter
    {
        UvIndex LoadUvIndex(City city);

        WeatherCurrent LoadWeatherCurrent(City city);

        WeatherForecast LoadWeatherForecast(City city);
    }
}
