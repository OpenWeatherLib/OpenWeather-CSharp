using Domain.OpenWeatherMap.Model;

namespace Adapter.OpenWeatherMap.Converter
{
    public interface IJsonToWeatherForecastConverter
    {
        WeatherForecast Convert(string response);
    }
}
