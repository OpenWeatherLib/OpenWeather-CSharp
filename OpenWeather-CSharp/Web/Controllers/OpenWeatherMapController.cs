using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit.Dto;
using GuepardoApps.OpenWeatherLib.Services.OpenWeatherMap;
using GuepardoApps.OpenWeatherLib.Web.Models.DataScienceToolkit;
using GuepardoApps.OpenWeatherLib.Web.Models.OpenWeatherMap;

namespace GuepardoApps.OpenWeatherLib.Web.Controllers
{
    /// <summary>
    /// OpenWeatherMapController
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class OpenWeatherMapController : Controller
    {
        private readonly IMapper _mapper;

        private readonly IOpenWeatherMapService _openWeatherMapService;

        /// <summary>
        /// OpenWeatherMapController
        /// </summary>
        /// <param name="mapper">mapper</param>
        /// <param name="openWeatherMapService">service</param>
        public OpenWeatherMapController(IMapper mapper, IOpenWeatherMapService openWeatherMapService)
        {
            _mapper = mapper;
            _openWeatherMapService = openWeatherMapService;
        }

        /// <summary>
        /// LoadWeatherCurrent
        /// </summary>
        /// <param name="cityViewModel">cityViewModel</param>
        /// <returns>WeatherCurrentViewModel</returns>
        [HttpGet]
        public ActionResult<WeatherCurrentViewModel> LoadWeatherCurrent([FromQuery]CityViewModel cityViewModel)
        {
            var cityDto = _mapper.Map<CityDto>(cityViewModel);
            var weatherCurrentDto = _openWeatherMapService.LoadWeatherCurrent(cityDto);
            var weatherCurrentViewModel = _mapper.Map<WeatherCurrentViewModel>(weatherCurrentDto);
            return weatherCurrentViewModel;
        }

        /// <summary>
        /// LoadWeatherForecast
        /// </summary>
        /// <param name="cityViewModel">cityViewModel</param>
        /// <returns>WeatherForecastViewModel</returns>
        [HttpGet]
        public ActionResult<WeatherForecastViewModel> LoadWeatherForecast([FromQuery]CityViewModel cityViewModel)
        {
            var cityDto = _mapper.Map<CityDto>(cityViewModel);
            var weatherForecastDto = _openWeatherMapService.LoadWeatherForecast(cityDto);
            var weatherForecastViewModel = _mapper.Map<WeatherForecastViewModel>(weatherForecastDto);
            return weatherForecastViewModel;
        }

        /// <summary>
        /// LoadUvIndex
        /// </summary>
        /// <param name="cityViewModel">cityViewModel</param>
        /// <returns>UvIndexViewModel</returns>
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
