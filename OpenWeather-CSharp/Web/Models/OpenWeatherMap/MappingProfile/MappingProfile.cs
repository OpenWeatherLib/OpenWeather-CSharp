using AutoMapper;
using GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit.Dto;
using GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap.Dto;
using GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap.Enum;
using GuepardoApps.OpenWeatherLib.Web.Models.DataScienceToolkit;
using GuepardoApps.OpenWeatherLib.Web.Models.OpenWeatherMap;
using GuepardoApps.OpenWeatherLib.Web.Models.OpenWeatherMap.Enum;

namespace GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap.MappingProfile
{
    /// <summary>
    /// MappingProfile
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// MappingProfile
        /// </summary>
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
