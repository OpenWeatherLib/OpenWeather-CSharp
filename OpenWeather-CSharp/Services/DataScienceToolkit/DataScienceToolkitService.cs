using AutoMapper;
using Domain.DataScienceToolkit;
using Services.DataScienceToolkit.Dto;
using Services.Validation;

namespace Services.DataScienceToolkit
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
