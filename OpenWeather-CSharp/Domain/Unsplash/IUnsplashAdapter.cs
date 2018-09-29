using GuepardoApps.OpenWeatherLib.Domain.Unsplash.Enum;

namespace GuepardoApps.OpenWeatherLib.Domain.Unsplash
{
    public interface IUnsplashAdapter
    {
        string ReceiveImagePictureUrl(string clientId, string cityName, UnsplashImageOrientationEnum orientation);
    }
}
