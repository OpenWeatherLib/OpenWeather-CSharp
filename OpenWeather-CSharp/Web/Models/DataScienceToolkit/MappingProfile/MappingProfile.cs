using AutoMapper;
using GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit.Dto;

namespace GuepardoApps.OpenWeatherLib.Web.Models.DataScienceToolkit.MappingProfile
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
            CreateMap<CityDto, CityViewModel>();

            CreateMap<CoordinatesDto, CoordinatesViewModel>();
        }
    }
}
