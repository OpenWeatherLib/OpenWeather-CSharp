using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.DataScienceToolkit;
using Web.Models.DataScienceToolkit;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataScienceToolkitController
    {
        private readonly IMapper _mapper;

        private readonly IDataScienceToolkitService _dataScienceToolkitService;

        public DataScienceToolkitController(IMapper mapper, IDataScienceToolkitService dataScienceToolkitService)
        {
            _mapper = mapper;
            _dataScienceToolkitService = dataScienceToolkitService;
        }

        // GET api/dataScienceToolkit/Nuremberg
        [HttpGet("{cityName}")]
        public ActionResult<CityViewModel> LoadCityData(string cityName)
        {
            var cityDto = _dataScienceToolkitService.LoadCityData(cityName);
            return _mapper.Map<CityViewModel>(cityDto);
        }
    }
}
