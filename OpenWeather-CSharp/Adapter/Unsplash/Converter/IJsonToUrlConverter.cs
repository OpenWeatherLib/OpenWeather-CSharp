namespace GuepardoApps.OpenWeatherLib.Adapter.Unsplash.Converter
{
    public interface IJsonToUrlConverter
    {
        string Convert(string response);
    }
}
