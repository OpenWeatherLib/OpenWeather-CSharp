using System;
using AutoMapper;
using Domain.DataScienceToolkit.Model;
using Services.DataScienceToolkit.Dto;
using Services.OpenWeatherMap.Dto;
using Services.Validation;

namespace Services.OpenWeatherMap
{
    public class OpenWeatherMapService : IOpenWeatherMapService
    {
        private readonly IMapper _mapper;

        private readonly IValidationService _validationService;

        public OpenWeatherMapService(IMapper mapper, IValidationService validationService)
        {
            _mapper = mapper;
            _validationService = validationService;
        }

        public UvIndexDto LoadUvIndex(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);

            if (!_validationService.Validate(city))
            {
                return null;
            }

            // TODO

            throw new NotImplementedException();
        }

        public WeatherCurrentDto LoadWeatherCurrent(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);

            if (!_validationService.Validate(city))
            {
                return null;
            }

            // TODO

            throw new NotImplementedException();
        }

        public WeatherForecastDto LoadWeatherForecast(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);

            if (!_validationService.Validate(city))
            {
                return null;
            }

            // TODO

            throw new NotImplementedException();
        }
    }
}
