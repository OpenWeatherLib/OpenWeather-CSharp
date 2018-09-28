using Services.DataScienceToolkit.Dto;
using Services.OpenWeatherMap.Dto;

namespace Services.OpenWeatherMap
{
    public interface IOpenWeatherMapService
    {
        WeatherCurrentDto LoadWeatherCurrent(CityDto cityDto);

        WeatherForecastDto LoadWeatherForecast(CityDto cityDto);

        UvIndexDto LoadUvIndex(CityDto cityDto);
    }
}
