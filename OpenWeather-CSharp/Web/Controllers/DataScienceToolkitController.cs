﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using GuepardoApps.OpenWeatherLib.Services.DataScienceToolkit;
using GuepardoApps.OpenWeatherLib.Web.Models.DataScienceToolkit;

namespace GuepardoApps.OpenWeatherLib.Web.Controllers
{
    /// <summary>
    /// DataScienceToolkitController
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class DataScienceToolkitController : Controller
    {
        private readonly IMapper _mapper;

        private readonly IDataScienceToolkitService _dataScienceToolkitService;

        /// <summary>
        /// DataScienceToolkitController
        /// </summary>
        /// <param name="mapper">mapper</param>
        /// <param name="dataScienceToolkitService">service</param>
        public DataScienceToolkitController(IMapper mapper, IDataScienceToolkitService dataScienceToolkitService)
        {
            _mapper = mapper;
            _dataScienceToolkitService = dataScienceToolkitService;
        }

        /// <summary>
        /// LoadCityData
        /// </summary>
        /// <param name="cityName">cityName</param>
        /// <returns>CityViewModel</returns>
        [HttpGet]
        public ActionResult<CityViewModel> LoadCityData(string cityName) =>
            _mapper.Map<CityViewModel>(_dataScienceToolkitService.LoadCityData(cityName));
    }
}
