using GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit.Dto;
using GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap.Dto;

namespace GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap
{
    public interface IOpenWeatherMapService
    {
        WeatherCurrentDto LoadWeatherCurrent(CityDto cityDto);

        WeatherForecastDto LoadWeatherForecast(CityDto cityDto);

        UvIndexDto LoadUvIndex(CityDto cityDto);
    }
}
