using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;

namespace GuepardoApps.OpenWeatherLib.Adapter.DataScienceToolkit.Converter
{
    public interface IJsonToCityConverter
    {
        City Convert(string response);
    }
}
