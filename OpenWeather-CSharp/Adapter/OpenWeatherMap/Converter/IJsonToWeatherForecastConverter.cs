using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model;

namespace GuepardoApps.OpenWeatherLib.Adapter.OpenWeatherMap.Converter
{
    public interface IJsonToWeatherForecastConverter
    {
        WeatherForecast Convert(string response);
    }
}
