using Domain.OpenWeatherMap.Model;

namespace Adapter.OpenWeatherMap.Converter
{
    public interface IJsonToWeatherCurrentConverter
    {
        WeatherCurrent Convert(string response);
    }
}
