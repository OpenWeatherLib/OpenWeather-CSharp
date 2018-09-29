using AutoMapper;
using Domain.DataScienceToolkit.Model;
using Domain.OpenWeatherMap.Enum;
using Domain.OpenWeatherMap.Model;
using Services.DataScienceToolkit.Dto;
using Services.OpenWeatherMap.Dto;
using Services.OpenWeatherMap.Enum;

namespace Services.OpenWeatherMap.MappingProfile
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
