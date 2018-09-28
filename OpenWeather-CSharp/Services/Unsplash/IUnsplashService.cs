using Services.Unsplash.Enum;

namespace Services.Unsplash
{
    public interface IUnsplashService
    {
        string ReceiveImagePictureUrl(string cityName, UnsplashImageOrientationDtoEnum orientation);
    }
}
