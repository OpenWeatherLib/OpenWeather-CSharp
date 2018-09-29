using Domain.OpenWeatherMap.Model;

namespace Adapter.OpenWeatherMap.Converter
{
    public interface IJsonToUvIndexConverter
    {
        UvIndex Convert(string response);
    }
}
