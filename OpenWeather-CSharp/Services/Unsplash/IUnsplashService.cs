using GuepardoApps.OpenWeatherLib.Services.Unsplash.Enum;

namespace GuepardoApps.OpenWeatherLib.Services.Unsplash
{
    public interface IUnsplashService
    {
        string ReceiveImagePictureUrl(string cityName, UnsplashImageOrientationDtoEnum orientation);
    }
}
