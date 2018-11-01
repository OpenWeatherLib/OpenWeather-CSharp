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
            CreateMap<CarbonMonoxide, CarbonMonoxideDto>();

            CreateMap<CarbonMonoxideData, CarbonMonoxideDataDto>();

            CreateMap<CityDto, City>();

            CreateMap<City, CityDto>();

            CreateMap<Clouds, CloudsDto>();

            CreateMap<CoordinatesDto, Coordinates>();

            CreateMap<Coordinates, CoordinatesDto>();

            CreateMap<Main, MainDto>();

            CreateMap<NitrogenDioxide, NitrogenDioxideDto>();

            CreateMap<NitrogenDioxideData, NitrogenDioxideDataDto>();

            CreateMap<NitrogenDioxideDataHolder, NitrogenDioxideDataHolderDto>();

            CreateMap<Ozone, OzoneDto>();

            CreateMap<Rain, RainDto>();

            CreateMap<SulfurDioxide, SulfurDioxideDto>();

            CreateMap<SulfurDioxideData, SulfurDioxideDataDto>();

            CreateMap<Sys, SysDto>();

            CreateMap<UvIndex, UvIndexDto>();

            CreateMap<WeatherConditionEnum, WeatherConditionDtoEnum>();

            CreateMap<WeatherCurrent, WeatherCurrentDto>();

            CreateMap<WeatherForecast, WeatherForecastDto>();

            CreateMap<WeatherForecastPart, WeatherForecastPartDto>();

            CreateMap<WeatherPart, WeatherPartDto>();

            CreateMap<Wind, WindDto>();
        }
    }
}
