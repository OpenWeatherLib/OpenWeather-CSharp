namespace GuepardoApps.OpenWeatherLib.Web.Models.OpenWeatherMap
{
    /// <summary>
    /// MainViewModel
    /// </summary>
    public class MainViewModel
    {
        /// <summary>
        /// Temperature
        /// </summary>
        public double Temperature { get; set; }

        /// <summary>
        /// Temperature Min
        /// </summary>
        public double TemperatureMin { get; set; }

        /// <summary>
        /// Temperature Max
        /// </summary>
        public double TemperatureMax { get; set; }

        /// <summary>
        /// Temperature Kf
        /// </summary>
        public double TemperatureKf { get; set; }

        /// <summary>
        /// Pressure
        /// </summary>
        public double Pressure { get; set; }

        /// <summary>
        /// Pressure sea level
        /// </summary>
        public double PressureSeaLevel { get; set; }

        /// <summary>
        /// Pressure ground level
        /// </summary>
        public double PressureGroundLevel { get; set; }

        /// <summary>
        /// Humidity
        /// </summary>
        public double Humidity { get; set; }
    }
}
