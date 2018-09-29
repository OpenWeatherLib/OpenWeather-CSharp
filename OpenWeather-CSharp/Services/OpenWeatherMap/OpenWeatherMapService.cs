using AutoMapper;
using Domain.DataScienceToolkit.Model;
using Domain.OpenWeatherMap;
using Services.DataScienceToolkit.Dto;
using Services.OpenWeatherMap.Dto;
using Services.Validation;

namespace Services.OpenWeatherMap
{
    public class OpenWeatherMapService : IOpenWeatherMapService
    {
        private readonly IMapper _mapper;

        private readonly IValidationService _validationService;

        private readonly IOpenWeatherMapAdapter _openWeatherMapAdapter;

        // TODO
        private readonly string _apiKey = "TODO_READ_OUT_CONFIG";

        public OpenWeatherMapService(
            IMapper mapper,
            IValidationService validationService,
            IOpenWeatherMapAdapter openWeatherMapAdapter)
        {
            _mapper = mapper;
            _validationService = validationService;
            _openWeatherMapAdapter = openWeatherMapAdapter;
        }

        public WeatherCurrentDto LoadWeatherCurrent(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);

            if (!_validationService.Validate(city))
            {
                return null;
            }

            var weatherCurrent = _openWeatherMapAdapter.LoadWeatherCurrent(_apiKey, city);

            return _mapper.Map<WeatherCurrentDto>(weatherCurrent);
        }

        public WeatherForecastDto LoadWeatherForecast(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);

            if (!_validationService.Validate(city))
            {
                return null;
            }

            var weatherForecast = _openWeatherMapAdapter.LoadWeatherForecast(_apiKey, city);

            return _mapper.Map<WeatherForecastDto>(weatherForecast);
        }

        public UvIndexDto LoadUvIndex(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);

            if (!_validationService.Validate(city))
            {
                return null;
            }

            var uvIndex = _openWeatherMapAdapter.LoadUvIndex(_apiKey, city);

            return _mapper.Map<UvIndexDto>(uvIndex);
        }
    }
}
