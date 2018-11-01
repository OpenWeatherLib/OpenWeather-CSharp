using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model;

namespace GuepardoApps.OpenWeatherLib.Adapter.OpenWeatherMap.Converter
{
    public interface IJsonToNitrogenDioxideConverter
    {
        NitrogenDioxide Convert(string response);
    }
}
