using AutoMapper;
using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;
using GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit.Dto;

namespace GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit.MappingProfile
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
