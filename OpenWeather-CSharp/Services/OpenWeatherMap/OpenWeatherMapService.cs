using System;
using AutoMapper;
using GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model;
using GuepardoApps.OpenWeatherLib.Domain.OpenWeatherMap;
using GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit.Dto;
using GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap.Dto;
using GuepardoApps.OpenWeatherLib.Services.Validation;

namespace GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap
{
    public class OpenWeatherMapService : IOpenWeatherMapService
    {
        private readonly IMapper _mapper;

        private readonly IValidationService _validationService;

        private readonly IOpenWeatherMapAdapter _openWeatherMapAdapter;

        // TODO Use a config file
        private readonly string _apiKey = "TODO Use a config file";

        public OpenWeatherMapService(
            IMapper mapper,
            IValidationService validationService,
            IOpenWeatherMapAdapter openWeatherMapAdapter)
        {
            _mapper = mapper;
            _validationService = validationService;
            _openWeatherMapAdapter = openWeatherMapAdapter;
        }

        public CarbonMonoxideDto LoadCarbonMonoxide(CityDto cityDto, DateTime dateTime, int accuracy)
        {
            var city = _mapper.Map<City>(cityDto);

            if (!_validationService.Validate(city))
            {
                return null;
            }

            var carbonMonoxide = _openWeatherMapAdapter.LoadCarbonMonoxide(_apiKey, city, dateTime, accuracy);

            return _mapper.Map<CarbonMonoxideDto>(carbonMonoxide);
        }

        public NitrogenDioxideDto LoadNitrogenDioxide(CityDto cityDto, DateTime dateTime, int accuracy)
        {
            var city = _mapper.Map<City>(cityDto);

            if (!_validationService.Validate(city))
            {
                return null;
            }

            var nitrogenDioxide = _openWeatherMapAdapter.LoadNitrogenDioxide(_apiKey, city, dateTime, accuracy);

            return _mapper.Map<NitrogenDioxideDto>(nitrogenDioxide);
        }

        public OzoneDto LoadOzone(CityDto cityDto, DateTime dateTime, int accuracy)
        {
            var city = _mapper.Map<City>(cityDto);

            if (!_validationService.Validate(city))
            {
                return null;
            }

            var ozone = _openWeatherMapAdapter.LoadOzone(_apiKey, city, dateTime, accuracy);

            return _mapper.Map<OzoneDto>(ozone);
        }

        public SulfurDioxideDto LoadSulfurDioxide(CityDto cityDto, DateTime dateTime, int accuracy)
        {
            var city = _mapper.Map<City>(cityDto);

            if (!_validationService.Validate(city))
            {
                return null;
            }

            var sulfurDioxide = _openWeatherMapAdapter.LoadSulfurDioxide(_apiKey, city, dateTime, accuracy);

            return _mapper.Map<SulfurDioxideDto>(sulfurDioxide);
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
