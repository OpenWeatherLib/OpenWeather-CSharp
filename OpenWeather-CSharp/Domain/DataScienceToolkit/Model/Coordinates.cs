using GuepardoApps.OpenWeatherLib.Crosscutting.Attributes;

namespace GuepardoApps.OpenWeatherLib.Domain.DataScienceToolkit.Model
{
    public class Coordinates
    {
        [IsNotDefault(typeof(double), 720.0)]
        public double Lat { get; set; }

        [IsNotDefault(typeof(double), 720.0)]
        public double Lon { get; set; }
    }
}
