using Domain.Unsplash.Enum;

namespace Domain.Unsplash
{
    public interface IUnsplashAdapter
    {
        string ReceiveImagePictureUrl(string clientId, string cityName, UnsplashImageOrientationEnum orientation);
    }
}
