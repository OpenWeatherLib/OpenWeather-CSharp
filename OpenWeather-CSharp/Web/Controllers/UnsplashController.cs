using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Unsplash;
using Services.Unsplash.Enum;
using Web.Models.Unsplash.Enum;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnsplashController
    {
        private readonly IMapper _mapper;

        private readonly IUnsplashService _unsplashService;

        public UnsplashController(IMapper mapper, IUnsplashService unsplashService)
        {
            _mapper = mapper;
            _unsplashService = unsplashService;
        }

        [HttpGet]
        public ActionResult<string> ReceiveImagePictureUrl(string cityName, int unsplashImageOrientationViewModelEnumId)
        {
            var unsplashImageOrientationViewModelEnum = UnsplashImageOrientationViewModelEnum.GetById(unsplashImageOrientationViewModelEnumId);
            return _unsplashService.ReceiveImagePictureUrl(cityName, _mapper.Map<UnsplashImageOrientationDtoEnum>(unsplashImageOrientationViewModelEnum));
        }
    }
}
