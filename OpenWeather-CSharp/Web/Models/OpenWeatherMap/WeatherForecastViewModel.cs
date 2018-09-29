using System.Collections.Generic;
using GuepardoApps.OpenWeatherLib.Web.Models.DataScienceToolkit;

namespace GuepardoApps.OpenWeatherLib.Web.Models.OpenWeatherMap
{
    /// <summary>
    /// WeatherForecastViewModel
    /// </summary>
    public class WeatherForecastViewModel
    {
        /// <summary>
        /// Cod
        /// </summary>
        public string Cod { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public double Message { get; set; }

        /// <summary>
        /// Count
        /// </summary>
        public uint Count { get; set; }

        /// <summary>
        /// List
        /// </summary>
        public IList<WeatherForecastPartViewModel> List { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public CityViewModel City { get; set; }
    }
}
