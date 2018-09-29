using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;

namespace GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit
{
    public interface IDataScienceToolkitAdapter
    {
        City LoadCityData(string cityName);
    }
}
