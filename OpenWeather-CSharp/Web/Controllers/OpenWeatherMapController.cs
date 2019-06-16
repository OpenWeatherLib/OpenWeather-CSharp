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
        public ActionResult<CarbonMonoxideViewModel> LoadCarbonMonoxide([FromQuery]AirPollutionRequestViewModel request) =>
            _mapper.Map<CarbonMonoxideViewModel>(
                _openWeatherMapService.LoadCarbonMonoxide(_mapper.Map<CityDto>(request.City), request.DateTime, request.Accuracy));

        /// <summary>
        /// LoadNitrogenDioxide
        /// </summary>
        /// <param name="request">AirPollutionRequestViewModel</param>
        /// <returns>NitrogenDioxideViewModel</returns>
        [HttpGet]
        public ActionResult<NitrogenDioxideViewModel> LoadNitrogenDioxide([FromQuery]AirPollutionRequestViewModel request) =>
            _mapper.Map<NitrogenDioxideViewModel>(
                _openWeatherMapService.LoadNitrogenDioxide(_mapper.Map<CityDto>(request.City), request.DateTime, request.Accuracy));

        /// <summary>
        /// LoadOzone
        /// </summary>
        /// <param name="request">AirPollutionRequestViewModel</param>
        /// <returns>OzoneViewModel</returns>
        [HttpGet]
        public ActionResult<OzoneViewModel> LoadOzone([FromQuery]AirPollutionRequestViewModel request) =>
            _mapper.Map<OzoneViewModel>(
                _openWeatherMapService.LoadOzone(_mapper.Map<CityDto>(request.City), request.DateTime, request.Accuracy));

        /// <summary>
        /// LoadSulfurDioxide
        /// </summary>
        /// <param name="request">AirPollutionRequestViewModel</param>
        /// <returns>SulfurDioxideViewModel</returns>
        [HttpGet]
        public ActionResult<SulfurDioxideViewModel> LoadSulfurDioxide([FromQuery]AirPollutionRequestViewModel request) =>
            _mapper.Map<SulfurDioxideViewModel>(
                _openWeatherMapService.LoadSulfurDioxide(_mapper.Map<CityDto>(request.City), request.DateTime, request.Accuracy));

        /// <summary>
        /// LoadUvIndex
        /// </summary>
        /// <param name="cityViewModel">cityViewModel</param>
        /// <returns>UvIndexViewModel</returns>
        [HttpGet]
        public ActionResult<UvIndexViewModel> LoadUvIndex([FromQuery]CityViewModel cityViewModel) =>
            _mapper.Map<UvIndexViewModel>(
                _openWeatherMapService.LoadUvIndex(_mapper.Map<CityDto>(cityViewModel)));


        /// <summary>
        /// LoadWeatherCurrent
        /// </summary>
        /// <param name="cityViewModel">cityViewModel</param>
        /// <returns>WeatherCurrentViewModel</returns>
        [HttpGet]
        public ActionResult<WeatherCurrentViewModel> LoadWeatherCurrent([FromQuery]CityViewModel cityViewModel) =>
            _mapper.Map<WeatherCurrentViewModel>(
                _openWeatherMapService.LoadWeatherCurrent(_mapper.Map<CityDto>(cityViewModel)));

        /// <summary>
        /// LoadWeatherForecast
        /// </summary>
        /// <param name="cityViewModel">cityViewModel</param>
        /// <returns>WeatherForecastViewModel</returns>
        [HttpGet]
        public ActionResult<WeatherForecastViewModel> LoadWeatherForecast([FromQuery]CityViewModel cityViewModel) =>
            _mapper.Map<WeatherForecastViewModel>(
                _openWeatherMapService.LoadWeatherForecast(_mapper.Map<CityDto>(cityViewModel)));
    }
}
