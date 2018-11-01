using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model;

namespace GuepardoApps.OpenWeatherLib.Adapter.OpenWeatherMap.Converter
{
    public interface IJsonToCarbonMonoxideConverter
    {
        CarbonMonoxide Convert(string response);
    }
}
