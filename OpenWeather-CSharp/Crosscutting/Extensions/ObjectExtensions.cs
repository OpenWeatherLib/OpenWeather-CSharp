namespace GuepardoApps.OpenWeatherLib.Crosscutting.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsEmpty(this object value)
        {
            if (value is string)
            {
                return string.IsNullOrWhiteSpace(value.ToString());
            }

            return value == null;
        }
    }
}
