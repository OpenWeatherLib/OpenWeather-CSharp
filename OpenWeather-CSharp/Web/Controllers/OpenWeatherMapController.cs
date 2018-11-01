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
        /// LoadCarbonMonoxide
        /// </summary>
        /// <param name="request">AirPollutionRequestViewModel</param>
        /// <returns>CarbonMonoxideViewModel</returns>
        [HttpGet]
        public ActionResult<CarbonMonoxideViewModel> LoadCarbonMonoxide([FromQuery]AirPollutionRequestViewModel request)
        {
            var cityDto = _mapper.Map<CityDto>(request.City);
            var carbonMonoxideDto = _openWeatherMapService.LoadCarbonMonoxide(cityDto, request.DateTime, request.Accuracy);
            var carbonMonoxideViewModel = _mapper.Map<CarbonMonoxideViewModel>(carbonMonoxideDto);
            return carbonMonoxideViewModel;
        }

        /// <summary>
        /// LoadNitrogenDioxide
        /// </summary>
        /// <param name="request">AirPollutionRequestViewModel</param>
        /// <returns>NitrogenDioxideViewModel</returns>
        [HttpGet]
        public ActionResult<NitrogenDioxideViewModel> LoadNitrogenDioxide([FromQuery]AirPollutionRequestViewModel request)
        {
            var cityDto = _mapper.Map<CityDto>(request.City);
            var nitrogenDioxideDto = _openWeatherMapService.LoadNitrogenDioxide(cityDto, request.DateTime, request.Accuracy);
            var nitrogenDioxideViewModel = _mapper.Map<NitrogenDioxideViewModel>(nitrogenDioxideDto);
            return nitrogenDioxideViewModel;
        }

        /// <summary>
        /// LoadOzone
        /// </summary>
        /// <param name="request">AirPollutionRequestViewModel</param>
        /// <returns>OzoneViewModel</returns>
        [HttpGet]
        public ActionResult<OzoneViewModel> LoadOzone([FromQuery]AirPollutionRequestViewModel request)
        {
            var cityDto = _mapper.Map<CityDto>(request.City);
            var ozoneDto = _openWeatherMapService.LoadOzone(cityDto, request.DateTime, request.Accuracy);
            var ozoneViewModel = _mapper.Map<OzoneViewModel>(ozoneDto);
            return ozoneViewModel;
        }

        /// <summary>
        /// LoadSulfurDioxide
        /// </summary>
        /// <param name="request">AirPollutionRequestViewModel</param>
        /// <returns>SulfurDioxideViewModel</returns>
        [HttpGet]
        public ActionResult<SulfurDioxideViewModel> LoadSulfurDioxide([FromQuery]AirPollutionRequestViewModel request)
        {
            var cityDto = _mapper.Map<CityDto>(request.City);
            var sulfurDioxideDto = _openWeatherMapService.LoadSulfurDioxide(cityDto, request.DateTime, request.Accuracy);
            var sulfurDioxideViewModel = _mapper.Map<SulfurDioxideViewModel>(sulfurDioxideDto);
            return sulfurDioxideViewModel;
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
    }
}
