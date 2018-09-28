using AutoMapper;
using Domain.DataScienceToolkit.Model;
using Services.DataScienceToolkit.Dto;

namespace Services.OpenWeatherMap.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CityDto, City>();

            CreateMap<CoordinatesDto, Coordinates>();
        }
    }
}
