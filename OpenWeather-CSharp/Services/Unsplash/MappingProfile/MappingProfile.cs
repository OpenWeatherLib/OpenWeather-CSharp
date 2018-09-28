using AutoMapper;
using Domain.Unsplash.Enum;
using Services.Unsplash.Enum;

namespace Services.Unsplash.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UnsplashImageOrientationDtoEnum, UnsplashImageOrientationEnum>();
        }
    }
}
