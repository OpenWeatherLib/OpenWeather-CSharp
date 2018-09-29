using AutoMapper;
using Services.DataScienceToolkit.Dto;
using Services.OpenWeatherMap.Dto;
using Services.OpenWeatherMap.Enum;
using Web.Models.DataScienceToolkit;
using Web.Models.OpenWeatherMap;
using Web.Models.OpenWeatherMap.Enum;

namespace Services.OpenWeatherMap.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CityViewModel, CityDto>();

            CreateMap<CityDto, CityViewModel>();

            CreateMap<CoordinatesViewModel, CoordinatesDto>();

            CreateMap<CoordinatesDto, CoordinatesViewModel>();

            CreateMap<UvIndexDto, UvIndexViewModel>();

            CreateMap<WeatherCurrentDto, WeatherCurrentViewModel>();

            CreateMap<WeatherPartDto, WeatherPartViewModel>();

            CreateMap<MainDto, MainViewModel>();

            CreateMap<WindDto, WindViewModel>();

            CreateMap<CloudsDto, CloudsViewModel>();

            CreateMap<SysDto, SysViewModel>();

            CreateMap<WeatherConditionDtoEnum, WeatherConditionViewModelEnum>();

            CreateMap<WeatherForecastDto, WeatherForecastViewModel>();

            CreateMap<WeatherForecastPartDto, WeatherForecastPartViewModel>();

            CreateMap<RainDto, RainViewModel>();
        }
    }
}
