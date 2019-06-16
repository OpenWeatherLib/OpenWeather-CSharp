using AutoMapper;
using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit;
using GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit.Dto;

namespace GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit
{
    public class DataScienceToolkitService : IDataScienceToolkitService
    {
        private readonly IMapper _mapper;

        private readonly IDataScienceToolkitAdapter _dataScienceToolkitAdapter;

        public DataScienceToolkitService(
            IMapper mapper,
            IDataScienceToolkitAdapter dataScienceToolkitAdapter)
        {
            _mapper = mapper;
            _dataScienceToolkitAdapter = dataScienceToolkitAdapter;
        }

        public CityDto LoadCityData(string cityName) =>
            string.IsNullOrWhiteSpace(cityName)
                ? null
                : _mapper.Map<CityDto>(_dataScienceToolkitAdapter.LoadCityData(cityName));
    }
}
