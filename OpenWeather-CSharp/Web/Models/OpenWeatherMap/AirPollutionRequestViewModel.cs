using GuepardoApps.OpenWeatherLib.Web.Models.DataScienceToolkit;
using System;

namespace GuepardoApps.OpenWeatherLib.Web.Models.OpenWeatherMap
{
    /// <summary>
    /// AirPollutionRequestViewModel
    /// </summary>
    public class AirPollutionRequestViewModel
    {
        /// <summary>
        /// City
        /// </summary>
        public CityViewModel City { get; set; }

        /// <summary>
        /// DateTime
        /// </summary>
        public DateTime? DateTime { get; set; }

        /// <summary>
        /// Accuracy
        /// </summary>
        public int Accuracy { get; set; }
    }
}
