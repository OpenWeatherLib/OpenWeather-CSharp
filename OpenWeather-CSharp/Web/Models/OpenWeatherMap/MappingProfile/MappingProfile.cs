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
            CreateMap<CarbonMonoxideDto, CarbonMonoxideViewModel>();

            CreateMap<CarbonMonoxideDataDto, CarbonMonoxideDataViewModel>();

            CreateMap<CityViewModel, CityDto>();

            CreateMap<CityDto, CityViewModel>();

            CreateMap<CloudsDto, CloudsViewModel>();

            CreateMap<CoordinatesViewModel, CoordinatesDto>();

            CreateMap<CoordinatesDto, CoordinatesViewModel>();

            CreateMap<MainDto, MainViewModel>();

            CreateMap<NitrogenDioxideDto, NitrogenDioxideViewModel>();

            CreateMap<NitrogenDioxideDataDto, NitrogenDioxideDataViewModel>();

            CreateMap<NitrogenDioxideDataHolderDto, NitrogenDioxideDataHolderViewModel>();

            CreateMap<OzoneDto, OzoneViewModel>();

            CreateMap<RainDto, RainViewModel>();

            CreateMap<SulfurDioxideDto, SulfurDioxideViewModel>();

            CreateMap<SulfurDioxideDataDto, SulfurDioxideDataViewModel>();

            CreateMap<SysDto, SysViewModel>();

            CreateMap<UvIndexDto, UvIndexViewModel>();

            CreateMap<WeatherConditionDtoEnum, WeatherConditionViewModelEnum>();

            CreateMap<WeatherCurrentDto, WeatherCurrentViewModel>();

            CreateMap<WeatherForecastDto, WeatherForecastViewModel>();

            CreateMap<WeatherForecastPartDto, WeatherForecastPartViewModel>();

            CreateMap<WeatherPartDto, WeatherPartViewModel>();

            CreateMap<WindDto, WindViewModel>();
        }
    }
}
