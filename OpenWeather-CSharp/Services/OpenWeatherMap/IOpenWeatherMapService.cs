using GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit.Dto;
using GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap.Dto;
using System;

namespace GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap
{
    public interface IOpenWeatherMapService
    {
        CarbonMonoxideDto LoadCarbonMonoxide(CityDto cityDto, DateTime? dateTime, int accuracy);

        NitrogenDioxideDto LoadNitrogenDioxide(CityDto cityDto, DateTime? dateTime, int accuracy);

        OzoneDto LoadOzone(CityDto cityDto, DateTime? dateTime, int accuracy);

        SulfurDioxideDto LoadSulfurDioxide(CityDto cityDto, DateTime? dateTime, int accuracy);

        WeatherCurrentDto LoadWeatherCurrent(CityDto cityDto);

        WeatherForecastDto LoadWeatherForecast(CityDto cityDto);

        UvIndexDto LoadUvIndex(CityDto cityDto);
    }
}
