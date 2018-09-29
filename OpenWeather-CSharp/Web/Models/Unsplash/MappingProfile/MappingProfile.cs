using AutoMapper;
using GuepardoApps.OpenWeatherLib.Services.Unsplash.Enum;
using GuepardoApps.OpenWeatherLib.Web.Models.Unsplash.Enum;

namespace GuepardoApps.OpenWeatherLib.Web.Models.Unsplash.MappingProfile
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
            CreateMap<UnsplashImageOrientationViewModelEnum, UnsplashImageOrientationDtoEnum>();
        }
    }
}
