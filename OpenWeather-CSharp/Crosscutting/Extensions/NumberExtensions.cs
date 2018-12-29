namespace GuepardoApps.OpenWeatherLib.Crosscutting.Extensions
{
    public static class NumberExtensions
    {
        public static string ToFixed(this double value, int accuracy)
        {
            if (accuracy > 0)
            {
                var format = "0.";
                for (var index = 0; index < accuracy - 1; index++)
                {
                    format += "0";
                }
                format += "#";

                return value.ToString(format);
            }

            return value.ToString("0.0");
        }
    }
}
