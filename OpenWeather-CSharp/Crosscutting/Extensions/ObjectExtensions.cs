namespace GuepardoApps.OpenWeatherLib.Crosscutting.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsEmpty(this object value) => value is string ? string.IsNullOrWhiteSpace(value.ToString()) : value == null;
    }
}
