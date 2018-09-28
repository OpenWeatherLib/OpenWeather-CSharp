using AutoMapper;
using Domain.DataScienceToolkit.Model;
using Services.DataScienceToolkit.Dto;

namespace Services.DataScienceToolkit.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDto>();

            CreateMap<Coordinates, CoordinatesDto>();
        }
    }
}
