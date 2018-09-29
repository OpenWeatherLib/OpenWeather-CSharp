using AutoMapper;
using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit;
using GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit.Dto;
using GuepardoApps.OpenWeatherLib.Services.Validation;

namespace GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit
{
    public class DataScienceToolkitService : IDataScienceToolkitService
    {
        private readonly IMapper _mapper;

        private readonly IValidationService _validationService;

        private readonly IDataScienceToolkitAdapter _dataScienceToolkitAdapter;

        public DataScienceToolkitService(
            IMapper mapper,
            IValidationService validationService,
            IDataScienceToolkitAdapter dataScienceToolkitAdapter)
        {
            _mapper = mapper;
            _validationService = validationService;
            _dataScienceToolkitAdapter = dataScienceToolkitAdapter;
        }

        public CityDto LoadCityData(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
            {
                return null;
            }

            var city = _dataScienceToolkitAdapter.LoadCityData(cityName);

            return _mapper.Map<CityDto>(city);
        }
    }
}
