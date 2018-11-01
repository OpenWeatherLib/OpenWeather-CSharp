using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model;

namespace GuepardoApps.OpenWeatherLib.Adapter.OpenWeatherMap.Converter
{
    public interface IJsonToOzoneConverter
    {
        Ozone Convert(string response);
    }
}
