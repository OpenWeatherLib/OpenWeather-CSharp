using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model;

namespace GuepardoApps.OpenWeatherLib.Adapter.OpenWeatherMap.Converter
{
    public interface IJsonToSulfurDioxideConverter
    {
        SulfurDioxide Convert(string response);
    }
}
