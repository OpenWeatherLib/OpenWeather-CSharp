using AutoMapper;
using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;
using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Enum;
using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap.Model;
using GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit.Dto;
using GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap.Dto;
using GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap.Enum;

namespace GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CityDto, City>();

            CreateMap<City, CityDto>();

            CreateMap<CoordinatesDto, Coordinates>();

            CreateMap<Coordinates, CoordinatesDto>();

            CreateMap<UvIndex, UvIndexDto>();

            CreateMap<WeatherCurrent, WeatherCurrentDto>();

            CreateMap<WeatherPart, WeatherPartDto>();

            CreateMap<Main, MainDto>();

            CreateMap<Wind, WindDto>();

            CreateMap<Clouds, CloudsDto>();

            CreateMap<Sys, SysDto>();

            CreateMap<WeatherConditionEnum, WeatherConditionDtoEnum>();

            CreateMap<WeatherForecast, WeatherForecastDto>();

            CreateMap<WeatherForecastPart, WeatherForecastPartDto>();

            CreateMap<Rain, RainDto>();
        }
    }
}
