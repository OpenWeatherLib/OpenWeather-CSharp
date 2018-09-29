using GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit.Dto;

namespace GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit
{
    public interface IDataScienceToolkitService
    {
        CityDto LoadCityData(string cityName);
    }
}
