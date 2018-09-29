using AutoMapper;
using GuepardoApps.OpenWeatherLib.Domain.Unsplash.Enum;
using GuepardoApps.OpenWeatherLib.Services.Unsplash.Enum;

namespace GuepardoApps.OpenWeatherLib.Services.Unsplash.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UnsplashImageOrientationDtoEnum, UnsplashImageOrientationEnum>();
        }
    }
}
