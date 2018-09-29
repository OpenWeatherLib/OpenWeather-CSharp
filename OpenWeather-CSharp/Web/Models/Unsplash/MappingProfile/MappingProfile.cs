using AutoMapper;
using Services.Unsplash.Enum;
using Web.Models.Unsplash.Enum;

namespace Web.Models.Unsplash.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UnsplashImageOrientationViewModelEnum, UnsplashImageOrientationDtoEnum>();
        }
    }
}
