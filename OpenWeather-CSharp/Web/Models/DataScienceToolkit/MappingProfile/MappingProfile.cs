using AutoMapper;
using Services.DataScienceToolkit.Dto;

namespace Web.Models.DataScienceToolkit.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CityDto, CityViewModel>();

            CreateMap<CoordinatesDto, CoordinatesViewModel>();
        }
    }
}
