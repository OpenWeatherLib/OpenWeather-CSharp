using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.DataScienceToolkit.Dto;
using Services.OpenWeatherMap;
using Web.Models.DataScienceToolkit;
using Web.Models.OpenWeatherMap;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenWeatherMapController
    {
        private readonly IMapper _mapper;

        private readonly IOpenWeatherMapService _openWeatherMapService;

        public OpenWeatherMapController(IMapper mapper, IOpenWeatherMapService openWeatherMapService)
        {
            _mapper = mapper;
            _openWeatherMapService = openWeatherMapService;
        }

        [HttpGet]
        public ActionResult<WeatherCurrentViewModel> LoadWeatherCurrent([FromQuery]CityViewModel cityViewModel)
        {
            var cityDto = _mapper.Map<CityDto>(cityViewModel);
            var weatherCurrentDto = _openWeatherMapService.LoadWeatherCurrent(cityDto);
            var weatherCurrentViewModel = _mapper.Map<WeatherCurrentViewModel>(weatherCurrentDto);
            return weatherCurrentViewModel;
        }

        [HttpGet]
        public ActionResult<WeatherForecastViewModel> LoadWeatherForecast([FromQuery]CityViewModel cityViewModel)
        {
            var cityDto = _mapper.Map<CityDto>(cityViewModel);
            var weatherForecastDto = _openWeatherMapService.LoadWeatherForecast(cityDto);
            var weatherForecastViewModel = _mapper.Map<WeatherForecastViewModel>(weatherForecastDto);
            return weatherForecastViewModel;
        }

        [HttpGet]
        public ActionResult<UvIndexViewModel> LoadUvIndex([FromQuery]CityViewModel cityViewModel)
        {
            var cityDto = _mapper.Map<CityDto>(cityViewModel);
            var uvIndexDto = _openWeatherMapService.LoadUvIndex(cityDto);
            var uvIndexViewModel = _mapper.Map<UvIndexViewModel>(uvIndexDto);
            return uvIndexViewModel;
        }
    }
}
