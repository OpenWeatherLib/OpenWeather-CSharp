using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using GuepardoApps.OpenWeatherLib.Services.Unsplash;
using GuepardoApps.OpenWeatherLib.Services.Unsplash.Enum;
using GuepardoApps.OpenWeatherLib.Web.Models.Unsplash.Enum;

namespace GuepardoApps.OpenWeatherLib.Web.Controllers
{
    /// <summary>
    /// UnsplashController
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class UnsplashController : Controller
    {
        private readonly IMapper _mapper;

        private readonly IUnsplashService _unsplashService;

        /// <summary>
        /// UnsplashController
        /// </summary>
        /// <param name="mapper">mapper</param>
        /// <param name="unsplashService">service</param>
        public UnsplashController(IMapper mapper, IUnsplashService unsplashService)
        {
            _mapper = mapper;
            _unsplashService = unsplashService;
        }

        /// <summary>
        /// ReceiveImagePictureUrl
        /// </summary>
        /// <param name="cityName">cityName</param>
        /// <param name="unsplashImageOrientationViewModelEnumId">unsplashImageOrientationViewModelEnumId</param>
        /// <returns>string</returns>
        [HttpGet]
        public ActionResult<string> ReceiveImagePictureUrl(string cityName, int unsplashImageOrientationViewModelEnumId) =>
            _unsplashService.ReceiveImagePictureUrl(cityName,
                _mapper.Map<UnsplashImageOrientationDtoEnum>(UnsplashImageOrientationViewModelEnum.GetById(unsplashImageOrientationViewModelEnumId)));
    }
}
